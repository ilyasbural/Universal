namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class JobPostingDetailManager : BusinessObject<JobPostingDetail>, IJobPostingDetailService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<JobPostingDetail> Validator;

        public JobPostingDetailManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<JobPostingDetail> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<JobPostingDetail>> InsertAsync(JobPostingDetailRegisterDto Model)
        {
            List<JobPosting> JobPostingList = await UnitOfWork.JobPosting.SelectAsync(x => x.Id == Model.JobPostingId);

            Data = Mapper.Map<JobPostingDetail>(Model);
            Data.JobPosting = JobPostingList.FirstOrDefault(x => x.Id == Model.JobPostingId) ?? new JobPosting();
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<JobPostingDetail>(Data);
            await UnitOfWork.JobPostingDetail.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPostingDetail>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPostingDetail>> UpdateAsync(JobPostingDetailUpdateDto Model)
        {
            List<JobPosting> JobPostingList = await UnitOfWork.JobPosting.SelectAsync(x => x.Id == Model.JobPostingId);
            Collection = await UnitOfWork.JobPostingDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<JobPostingDetail>(Collection[0]);
            Data.JobPosting = JobPostingList.FirstOrDefault(x => x.Id == Model.JobPostingId) ?? new JobPosting();
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.JobPostingDetail.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPostingDetail>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPostingDetail>> DeleteAsync(JobPostingDetailDeleteDto Model)
        {
            Collection = await UnitOfWork.JobPostingDetail.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<JobPostingDetail>(Collection[0]);

            await UnitOfWork.JobPostingDetail.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPostingDetail>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPostingDetail>> SelectAsync(JobPostingDetailSelectDto Model)
        {
            Collection = await UnitOfWork.JobPostingDetail.SelectAsync(x => x.IsActive == true, x => x.JobPosting);
            return new Response<JobPostingDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPostingDetail>> SelectSingleAsync(JobPostingDetailSelectDto Model)
        {
            Collection = await UnitOfWork.JobPostingDetail.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.JobPosting);
            return new Response<JobPostingDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}