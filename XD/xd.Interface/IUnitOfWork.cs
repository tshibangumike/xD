using System;
namespace xd.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressInformationRepository AddressInformations { get; }
        IAppUserRepository AppUsers { get; }
        IAppUserRoleRepository AppUserRoles { get; }
        IContactRepository Contacts { get; }
        ICredentialsRepository Credentials { get; }
        IDbTypeRepository DbTypes { get; }
        IEntityRepository Entities { get; }
        IEntityTypeRepository EntityTypes { get; }
        IFieldRepository Fields { get; }
        IFieldRequirementLevelRepository FieldRequirementLevels { get; }
        IFieldTypeRepository FieldTypes { get; }
        IFormRepository Forms { get; }
        IFormTypeRepository FormTypes { get; }
        IGenderRepository Genders { get; }
        IMaritalStatusRepository MaritalStatuses { get; }
        IMenuItemRepository MenuItems { get; }
        IRoleRepository Roles { get; }
        ITabRepository Tabs { get; }
        ITitleRepository Titles { get; }
        IViewRepository Views { get; }
        IViewTypeRepository ViewTypes { get; }

        int Commit();
    }
}

