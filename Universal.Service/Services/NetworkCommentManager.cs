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

        public async Task<Response<NetworkComment>> UpdateAsync(NetworkCommentUpdateDto Model)
        {
            Collection = await UnitOfWork.NetworkComment.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<NetworkComment>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.NetworkComment.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkComment>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkComment>> DeleteAsync(NetworkCommentDeleteDto Model)
        {
            Collection = await UnitOfWork.NetworkComment.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<NetworkComment>(Collection[0]);

            await UnitOfWork.NetworkComment.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkComment>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
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

        public async Task<Response<NetworkComment>> SelectSingleAsync(NetworkCommentSelectDto Model)
        {
            Collection = await UnitOfWork.NetworkComment.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<NetworkComment>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}