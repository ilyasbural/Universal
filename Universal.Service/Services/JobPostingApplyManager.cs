namespace Universal.Service
{
    using Core;
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

        public async Task<Response<JobPostingApply>> InsertAsync(JobPostingApplyRegisterDto Model)
        {
            Data = Mapper.Map<JobPostingApply>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<JobPostingApply>(Data);
            await UnitOfWork.JobPostingApply.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPostingApply>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }    

        public async Task<Response<JobPostingApply>> UpdateAsync(JobPostingApplyUpdateDto Model)
        {
            Collection = await UnitOfWork.JobPostingApply.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<JobPostingApply>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.JobPostingApply.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPostingApply>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPostingApply>> DeleteAsync(JobPostingApplyDeleteDto Model)
        {
            Collection = await UnitOfWork.JobPostingApply.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<JobPostingApply>(Collection[0]);

            await UnitOfWork.JobPostingApply.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<JobPostingApply>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPostingApply>> SelectAsync(JobPostingApplySelectDto Model)
        {
            Collection = await UnitOfWork.JobPostingApply.SelectAsync(x => x.IsActive == true, x => x.JobPosting);
            return new Response<JobPostingApply>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<JobPostingApply>> SelectSingleAsync(JobPostingApplySelectDto Model)
        {
            Collection = await UnitOfWork.JobPostingApply.SelectAsync(x => x.Id == Model.Id && x.IsActive == true, x => x.JobPosting);
            return new Response<JobPostingApply>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}