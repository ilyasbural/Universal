namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class MessageBoxManager : BusinessObject<MessageBox>, IMessageBoxService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<MessageBox> Validator;

        public MessageBoxManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<MessageBox> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public Task<Response<MessageBox>> DeleteAsync(MessageBoxDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<MessageBox>> InsertAsync(MessageBoxRegisterDto Model)
        {
            Data = Mapper.Map<MessageBox>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<MessageBox>(Data);
            await UnitOfWork.MessageBox.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<MessageBox>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<MessageBox>> SelectAsync()
        {
            Collection = await UnitOfWork.MessageBox.SelectAsync(x => x.IsActive == true);
            return new Response<MessageBox>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<MessageBox>> SelectAsync(MessageBoxSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<MessageBox>> SelectSingleAsync(MessageBoxSelectDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<MessageBox>> UpdateAsync(MessageBoxUpdateDto Model)
        {
            throw new NotImplementedException();
        }
    }
}