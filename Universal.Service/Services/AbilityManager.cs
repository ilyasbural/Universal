namespace Universal.Service
{
    using Core;
    using AutoMapper;
    using FluentValidation;

    public class AbilityManager : BusinessObject<Ability>, IAbilityService
    {
        readonly IMapper Mapper;
        readonly IUnitOfWork UnitOfWork;
        readonly IValidator<Ability> Validator;

        public AbilityManager(IMapper mapper, IUnitOfWork unitOfWork, IValidator<Ability> validator)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            Validator = validator;
        }

        public async Task<Response<Ability>> InsertAsync(AbilityRegisterDto Model)
        {
            Data = Mapper.Map<Ability>(Model);
            Data.Id = Guid.NewGuid();
            Data.RegisterDate = DateTime.Now;
            Data.UpdateDate = DateTime.Now;
            Data.IsActive = true;

            Validator.ValidateAndThrow<Ability>(Data);
            await UnitOfWork.Ability.InsertAsync(Data);
            await UnitOfWork.SaveChangesAsync();

            return new Response<Ability>
            {
                Message = "Success",
                Data = Data,
                IsValidationError = false
            };
        }

        public async Task<Response<Ability>> SelectAsync()
        {
            Collection = await UnitOfWork.Ability.SelectAsync(x => x.IsActive == true);
            return new Response<Ability>
            {
                Message = "Success",
                Collection = Collection,
                Success = 1,
                IsValidationError = false
            };
        }

        //public async Task<Response<Ability>> InsertAsync(AbilityDataTransfer Model)
        //{
        //    Entity = Mapper.Map<Ability>(Model);
        //    Entity.Id = Guid.NewGuid();
        //    Entity.RegisterDate = DateTime.Now;
        //    Entity.UpdateDate = DateTime.Now;
        //    Entity.IsActive = true;
        //    Validator.ValidateAndThrow(Entity);

        //    await UnitOfWork.Ability.InsertAsync(Entity);
        //    Success = await UnitOfWork.SaveChangesAsync();

        //    return new Response<Ability>
        //    {
        //        Message = "Success",
        //        Data = Entity, 
        //        Success = Success,
        //        IsValidationError = false
        //    };
        //}

        //public async Task<Response<Ability>> UpdateAsync(AbilityDataTransfer Model)
        //{
        //    Collection = await UnitOfWork.Ability.SelectAsync(x => x.Id == Model.Id);
        //    Entity = Mapper.Map<Ability>(Collection[0]);
        //    Entity.UpdateDate = DateTime.Now;
        //    Validator.ValidateAndThrow(Entity);

        //    await UnitOfWork.Ability.UpdateAsync(Entity);
        //    Success = await UnitOfWork.SaveChangesAsync();

        //    return new Response<Ability>
        //    {
        //        Message = "Success",
        //        Data = Entity,
        //        Success = Success,
        //        IsValidationError = false
        //    };
        //}

        //public async Task<Response<Ability>> DeleteAsync(AbilityDataTransfer Model)
        //{
        //    Collection = await UnitOfWork.Ability.SelectAsync(x => x.Id == Model.Id);
        //    Entity = Mapper.Map<Ability>(Collection[0]);

        //    await UnitOfWork.Ability.DeleteAsync(Entity);
        //    Success = await UnitOfWork.SaveChangesAsync();

        //    return new Response<Ability>
        //    {
        //        Message = "Success",
        //        Data = Entity,
        //        Success = Success,
        //        IsValidationError = false
        //    };
        //}

        //public async Task<Response<Ability>> SelectAsync(AbilityDataTransfer Model)
        //{
        //    Collection = await UnitOfWork.Ability.SelectAsync(x => x.IsActive == true);
        //    return new Response<Ability>
        //    {
        //        Message = "Success",
        //        Collection = Collection,
        //        Success = Success,
        //        IsValidationError = false
        //    };
        //}

        //public async Task<Response<Ability>> AnySelectAsync(AbilityDataTransfer Model)
        //{
        //    Collection = await UnitOfWork.Ability.SelectAsync(x => x.Id == Model.Id && x.IsActive == true);
        //    return new Response<Ability>
        //    {
        //        Message = "Success",
        //        Collection = Collection,
        //        Success = Success,
        //        IsValidationError = false
        //    };
        //}

        //public Response<Ability> Insert(AbilityDataTransfer Model)
        //{
        //    Entity = Mapper.Map<Ability>(Model);
        //    Entity.Id = Guid.NewGuid();
        //    Entity.RegisterDate = DateTime.Now;
        //    Entity.UpdateDate = DateTime.Now;
        //    Entity.IsActive = true;
        //    Validator.ValidateAndThrow(Entity);

        //    UnitOfWork.Ability.Insert(Entity);
        //    Success = UnitOfWork.SaveChanges();

        //    return new Response<Ability>
        //    {
        //        Message = "Success",
        //        Data = Entity,
        //        Success = Success,
        //        IsValidationError = false
        //    };
        //}

        //public Response<Ability> Update(AbilityDataTransfer Model)
        //{
        //    Collection = UnitOfWork.Ability.Select(x => x.Id == Model.Id);
        //    Entity = Mapper.Map<Ability>(Collection[0]);
        //    Entity.UpdateDate = DateTime.Now;
        //    Validator.ValidateAndThrow(Entity);

        //    UnitOfWork.Ability.Update(Entity);
        //    Success = UnitOfWork.SaveChanges();

        //    return new Response<Ability>
        //    {
        //        Message = "Success",
        //        Data = Entity,
        //        Success = Success,
        //        IsValidationError = false
        //    };
        //}

        //public Response<Ability> Delete(AbilityDataTransfer Model)
        //{
        //    Collection = UnitOfWork.Ability.Select(x => x.Id == Model.Id);
        //    Entity = Mapper.Map<Ability>(Collection[0]);

        //    UnitOfWork.Ability.Delete(Entity);
        //    Success = UnitOfWork.SaveChanges();

        //    return new Response<Ability>
        //    {
        //        Message = "Success",
        //        Data = Entity,
        //        Success = Success,
        //        IsValidationError = false
        //    };
        //}

        //public Response<Ability> Select(AbilityDataTransfer Model)
        //{
        //    Collection = UnitOfWork.Ability.Select(x => x.IsActive == true);
        //    return new Response<Ability>
        //    {
        //        Message = "Success",
        //        Collection = Collection,
        //        Success = Success,
        //        IsValidationError = false
        //    };
        //}

        //public Response<Ability> AnySelect(AbilityDataTransfer Model)
        //{
        //    Collection = UnitOfWork.Ability.Select(x => x.Id == Model.Id && x.IsActive == true);
        //    return new Response<Ability>
        //    {
        //        Message = "Success",
        //        Collection = Collection,
        //        Success = Success,
        //        IsValidationError = false
        //    };
        //}
    }
}