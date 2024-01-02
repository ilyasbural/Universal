namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class CompanyFollowerManager : BusinessObject<CompanyFollower>, ICompanyFollowerService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<CompanyFollower> Validator;

        public CompanyFollowerManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<CompanyFollower> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<CompanyFollower>> InsertAsync(CompanyFollowerRegisterDto Model)
        {
            Data = Mapper.Map<CompanyFollower>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<CompanyFollower>(Data);
            await UnitOfWork.CompanyFollower.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<CompanyFollower>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public Task<Response<CompanyFollower>> UpdateAsync(CompanyFollowerUpdateDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CompanyFollower>> DeleteAsync(CompanyFollowerDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<CompanyFollower>> SelectAsync(CompanyFollowerSelectDto Model)
        {
            Collection = await UnitOfWork.CompanyFollower.SelectAsync(x => x.IsActive == true);
            return new Response<CompanyFollower>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<CompanyFollower>> SelectSingleAsync(CompanyFollowerSelectDto Model)
        {
            throw new NotImplementedException();
        }
    }
}