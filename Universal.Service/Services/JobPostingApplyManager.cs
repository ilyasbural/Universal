namespace Universal.Service
{
    using Core;
	using Common;
	using AutoMapper;
    using FluentValidation;

    public class JobPostingApplyManager : BusinessObject<JobPostingApply>, IJobPostingApplyService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<JobPostingApply> Validator;

        public JobPostingApplyManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<JobPostingApply> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<JobPostingApplyResponse>> InsertAsync(JobPostingApplyRegisterDto Model)
        {
            Data = Mapper.Map<JobPostingApply>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<JobPostingApply>(Data);
            await UnitOfWork.JobPostingApply.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPostingApplyResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }    

        public async Task<Response<JobPostingApplyResponse>> UpdateAsync(JobPostingApplyUpdateDto Model)
        {
            Collection = await UnitOfWork.JobPostingApply.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<JobPostingApply>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.JobPostingApply.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPostingApplyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPostingApplyResponse>> DeleteAsync(JobPostingApplyDeleteDto Model)
        {
            Collection = await UnitOfWork.JobPostingApply.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<JobPostingApply>(Collection[0]);

            await UnitOfWork.JobPostingApply.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPostingApplyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPostingApplyResponse>> SelectAsync(JobPostingApplySelectDto Model)
        {
            Collection = await UnitOfWork.JobPostingApply.SelectAsync(x => x.IsActive == true, x => x.JobPosting);
            return new Response<JobPostingApplyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPostingApplyResponse>> SelectSingleAsync(JobPostingApplySelectDto Model)
        {
            Collection = await UnitOfWork.JobPostingApply.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.JobPosting);
            return new Response<JobPostingApplyResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}