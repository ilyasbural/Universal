namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<EmojiResponse>> InsertAsync(EmojiRegisterDto Model)
        {
            Data = Mapper.Map<Emoji>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Emoji>(Data);
            await UnitOfWork.Emoji.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<EmojiResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<EmojiResponse>> UpdateAsync(EmojiUpdateDto Model)
        {
            Collection = await UnitOfWork.Emoji.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Emoji>(Collection[0]);
            Data.Name = Model.Name;
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.Emoji.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<EmojiResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<EmojiResponse>> DeleteAsync(EmojiDeleteDto Model)
        {
            Collection = await UnitOfWork.Emoji.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<Emoji>(Collection[0]);

            await UnitOfWork.Emoji.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<EmojiResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<EmojiResponse>> SelectAsync(EmojiSelectDto Model)
        {
            Collection = await UnitOfWork.Emoji.SelectAsync(x => x.IsActive == true);
            return new Response<EmojiResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<EmojiResponse>> SelectSingleAsync(EmojiSelectDto Model)
        {
            Collection = await UnitOfWork.Emoji.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<EmojiResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}