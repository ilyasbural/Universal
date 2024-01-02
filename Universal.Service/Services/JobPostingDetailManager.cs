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

        public Task<Response<JobPostingDetail>> DeleteAsync(JobPostingDetailDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<JobPostingDetail>> InsertAsync(JobPostingDetailRegisterDto Model)
        {
            Data = Mapper.Map<JobPostingDetail>(Model);
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

        public async Task<Response<JobPostingDetail>> SelectAsync()
        {
            Collection = await UnitOfWork.JobPostingDetail.SelectAsync(x => x.IsActive == true);
            return new Response<JobPostingDetail>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<JobPostingDetail>> SelectAsync(JobPostingDetailSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<JobPostingDetail>> SelectSingleAsync(JobPostingDetailSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<JobPostingDetail>> UpdateAsync(JobPostingDetailUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}