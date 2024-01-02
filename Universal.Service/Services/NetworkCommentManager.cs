namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class NetworkCommentManager : BusinessObject<NetworkComment>, INetworkCommentService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<NetworkComment> Validator;

        public NetworkCommentManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<NetworkComment> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<NetworkComment>> InsertAsync(NetworkCommentRegisterDto Model)
        {
            Data = Mapper.Map<NetworkComment>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<NetworkComment>(Data);
            await UnitOfWork.NetworkComment.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkComment>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public Task<Response<NetworkComment>> UpdateAsync(NetworkCommentUpdateDto Model)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NetworkComment>> DeleteAsync(NetworkCommentDeleteDto Model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<NetworkComment>> SelectAsync(NetworkCommentSelectDto Model)
        {
            Collection = await UnitOfWork.NetworkComment.SelectAsync(x => x.IsActive == true);
            return new Response<NetworkComment>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public Task<Response<NetworkComment>> SelectSingleAsync(NetworkCommentSelectDto Model)
        {
            throw new NotImplementedException();
        }
    }
}