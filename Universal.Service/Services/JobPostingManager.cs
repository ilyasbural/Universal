namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class JobPostingManager : BusinessObject<JobPosting>, IJobPostingService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<JobPosting> Validator;

        public JobPostingManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<JobPosting> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public Task<Response<JobPosting>> DeleteAsync(JobPostingDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<JobPosting>> InsertAsync(JobPostingRegisterDto Model)
        {
            Data = Mapper.Map<JobPosting>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<JobPosting>(Data);
            await UnitOfWork.JobPosting.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPosting>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPosting>> SelectAsync()
        {
            Collection = await UnitOfWork.JobPosting.SelectAsync(x => x.IsActive == true);
            return new Response<JobPosting>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<JobPosting>> SelectAsync(JobPostingSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<JobPosting>> SelectSingleAsync(JobPostingSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<JobPosting>> UpdateAsync(JobPostingUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}