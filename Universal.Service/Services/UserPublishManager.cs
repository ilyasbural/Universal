﻿namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserPublishManager : BusinessObject<UserPublish>, IUserPublishService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserPublish> Validator;

        public UserPublishManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserPublish> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserPublish>> InsertAsync(UserPublishRegisterDto Model)
        {
            Data = Mapper.Map<UserPublish>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserPublish>(Data);
            await UnitOfWork.UserPublish.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserPublish>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<UserPublish>> UpdateAsync(UserPublishUpdateDto Model)
        {
            Collection = await UnitOfWork.UserPublish.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserPublish>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserPublish.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserPublish>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserPublish>> DeleteAsync(UserPublishDeleteDto Model)
        {
            Collection = await UnitOfWork.UserPublish.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserPublish>(Collection[0]);

            await UnitOfWork.UserPublish.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserPublish>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserPublish>> SelectAsync(UserPublishSelectDto Model)
        {
            Collection = await UnitOfWork.UserPublish.SelectAsync(x => x.IsActive == true);
            return new Response<UserPublish>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserPublish>> SelectSingleAsync(UserPublishSelectDto Model)
        {
            Collection = await UnitOfWork.UserPublish.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<UserPublish>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}