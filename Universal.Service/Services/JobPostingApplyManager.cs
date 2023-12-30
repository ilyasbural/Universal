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

        public async Task<Response<JobPostingApply>> SelectAsync()
        {
            Collection = await UnitOfWork.JobPostingApply.SelectAsync(x => x.IsActive == true);
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