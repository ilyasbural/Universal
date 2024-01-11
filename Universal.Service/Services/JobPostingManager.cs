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

        public async Task<Response<JobPosting>> UpdateAsync(JobPostingUpdateDto Model)
        {
            Collection = await UnitOfWork.JobPosting.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<JobPosting>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.JobPosting.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPosting>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPosting>> DeleteAsync(JobPostingDeleteDto Model)
        {
            Collection = await UnitOfWork.JobPosting.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<JobPosting>(Collection[0]);

            await UnitOfWork.JobPosting.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPosting>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPosting>> SelectAsync(JobPostingSelectDto Model)
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

        public async Task<Response<JobPosting>> SelectSingleAsync(JobPostingSelectDto Model)
        {
            Collection = await UnitOfWork.JobPosting.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<JobPosting>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}