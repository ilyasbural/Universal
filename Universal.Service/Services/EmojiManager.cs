namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class EmojiManager : BusinessObject<Emoji>, IEmojiService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Emoji> Validator;

        public EmojiManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Emoji> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<Emoji>> InsertAsync(EmojiRegisterDto Model)
        {
            Data = Mapper.Map<Emoji>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Emoji>(Data);
            await UnitOfWork.Emoji.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Emoji>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Emoji>> SelectAsync()
        {
            Collection = await UnitOfWork.Emoji.SelectAsync(x => x.IsActive == true);
            return new Response<Emoji>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}