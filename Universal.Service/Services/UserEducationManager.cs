﻿namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class UserEducationManager : BusinessObject<UserEducation>, IUserEducationService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<UserEducation> Validator;

        public UserEducationManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserEducation> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<UserEducation>> InsertAsync(UserEducationRegisterDto Model)
        {
            Data = Mapper.Map<UserEducation>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<UserEducation>(Data);
            await UnitOfWork.UserEducation.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserEducation>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }   

        public async Task<Response<UserEducation>> UpdateAsync(UserEducationUpdateDto Model)
        {
            Collection = await UnitOfWork.UserEducation.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserEducation>(Collection[0]);
            Data.UpdateDate = DateTime.Now;
            Validator.ValidateAndThrow(Data);

            await UnitOfWork.UserEducation.UpdateAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserEducation>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserEducation>> DeleteAsync(UserEducationDeleteDto Model)
        {
            Collection = await UnitOfWork.UserEducation.SelectAsync(x => x.Id == Model.Id);
            Data = Mapper.Map<UserEducation>(Collection[0]);

            await UnitOfWork.UserEducation.DeleteAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<UserEducation>
            {
                Message = "Success",
                Data = Data,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserEducation>> SelectAsync(UserEducationSelectDto Model)
        {
            Collection = await UnitOfWork.UserEducation.SelectAsync(x => x.IsActive == true);
            return new Response<UserEducation>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        public async Task<Response<UserEducation>> SelectSingleAsync(UserEducationSelectDto Model)
        {
            Collection = await UnitOfWork.UserEducation.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
            return new Response<UserEducation>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }
    }
}