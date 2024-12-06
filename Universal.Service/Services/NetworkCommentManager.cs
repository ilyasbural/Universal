namespace Universal.Service
{
    using Core;
    using Common;
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

        public async Task<Response<NetworkCommentResponse>> InsertAsync(NetworkCommentRegisterDto Model)
        {
            Data = Mapper.Map<NetworkComment>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<NetworkComment>(Data);
            await UnitOfWork.NetworkComment.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkCommentResponse>
            {
                Message = "Success",
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkCommentResponse>> UpdateAsync(NetworkCommentUpdateDto Model)
        {
            Collection = await UnitOfWork.NetworkComment.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<NetworkComment>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.NetworkComment.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkCommentResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkCommentResponse>> DeleteAsync(NetworkCommentDeleteDto Model)
        {
            Collection = await UnitOfWork.NetworkComment.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<NetworkComment>(Collection[0]);

            await UnitOfWork.NetworkComment.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<NetworkCommentResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkCommentResponse>> SelectAsync(NetworkCommentSelectDto Model)
        {
            Collection = await UnitOfWork.NetworkComment.SelectAsync(x => x.IsActive == true);
            return new Response<NetworkCommentResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<NetworkCommentResponse>> SelectSingleAsync(NetworkCommentSelectDto Model)
        {
            Collection = await UnitOfWork.NetworkComment.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<NetworkCommentResponse>
            {
                Message = "Success",
                Success = 1,
                IsValidationError = false
            };
        }
    }
}