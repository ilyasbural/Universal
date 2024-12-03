namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class CollegeManager : BusinessObject<College>, ICollegeService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<College> Validator;

        public CollegeManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<College> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<College>> InsertAsync(CollegeRegisterDto Model)
        {
            Data = Mapper.Map<College>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<College>(Data);
            await UnitOfWork.College.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<College>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<College>> UpdateAsync(CollegeUpdateDto Model)
        {
            Collection = await UnitOfWork.College.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<College>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.College.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<College>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<College>> DeleteAsync(CollegeDeleteDto Model)
        {
            Collection = await UnitOfWork.College.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<College>(Collection[0]);

            await UnitOfWork.College.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<College>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<College>> SelectAsync(CollegeSelectDto Model)
        {
            Collection = await UnitOfWork.College.SelectAsync(x => x.IsActive == true);
            return new Response<College>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<College>> SelectSingleAsync(CollegeSelectDto Model)
        {
            Collection = await UnitOfWork.College.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<College>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}