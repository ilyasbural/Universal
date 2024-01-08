namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class CertificateManager : BusinessObject<Certificate>, ICertificateService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Certificate> Validator;

        public CertificateManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Certificate> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<Certificate>> InsertAsync(CertificateRegisterDto Model)
        {
            Data = Mapper.Map<Certificate>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Certificate>(Data);
            await UnitOfWork.Certificate.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Certificate>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Certificate>> UpdateAsync(CertificateUpdateDto Model)
        {
            Collection = await UnitOfWork.Certificate.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Certificate>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Certificate.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Certificate>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<Certificate>> DeleteAsync(CertificateDeleteDto Model)
        {
            Collection = await UnitOfWork.Certificate.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Certificate>(Collection[0]);

            await UnitOfWork.Certificate.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Certificate>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<Certificate>> SelectAsync(CertificateSelectDto Model)
        {
            Collection = await UnitOfWork.Certificate.SelectAsync(x => x.IsActive == true);
            return new Response<Certificate>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<Certificate>> SelectSingleAsync(CertificateSelectDto Model)
        {
            Collection = await UnitOfWork.Certificate.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<Certificate>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}