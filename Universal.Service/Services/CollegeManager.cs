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

        public Task<Response<College>> DeleteAsync(CollegeDeleteDto Model)
        {
            throw new NotImplementedException();
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

        public async Task<Response<College>> SelectAsync()
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

        public Task<Response<College>> SelectAsync(CollegeSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<College>> SelectSingleAsync(CollegeSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<College>> UpdateAsync(CollegeUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}