using xd.DAL.Context;
using xd.DAL.Repositories;
using xd.Interface;
namespace xd.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly XdContext _context;

        public UnitOfWork(XdContext context)
        {
            _context = context;
            AddressInformations = new AddressInformationRepository(_context);
AppUsers = new AppUserRepository(_context);
AppUserRoles = new AppUserRoleRepository(_context);
Contacts = new ContactRepository(_context);
Credentials = new CredentialsRepository(_context);
DbTypes = new DbTypeRepository(_context);
Entities = new EntityRepository(_context);
EntityTypes = new EntityTypeRepository(_context);
Fields = new FieldRepository(_context);
FieldRequirementLevels = new FieldRequirementLevelRepository(_context);
FieldTypes = new FieldTypeRepository(_context);
Forms = new FormRepository(_context);
FormTypes = new FormTypeRepository(_context);
Genders = new GenderRepository(_context);
MaritalStatuses = new MaritalStatusRepository(_context);
MenuItems = new MenuItemRepository(_context);
Roles = new RoleRepository(_context);
Tabs = new TabRepository(_context);
Titles = new TitleRepository(_context);
Views = new ViewRepository(_context);
ViewTypes = new ViewTypeRepository(_context);

        }
        public IAddressInformationRepository AddressInformations { get; private set; }
public IAppUserRepository AppUsers { get; private set; }
public IAppUserRoleRepository AppUserRoles { get; private set; }
public IContactRepository Contacts { get; private set; }
public ICredentialsRepository Credentials { get; private set; }
public IDbTypeRepository DbTypes { get; private set; }
public IEntityRepository Entities { get; private set; }
public IEntityTypeRepository EntityTypes { get; private set; }
public IFieldRepository Fields { get; private set; }
public IFieldRequirementLevelRepository FieldRequirementLevels { get; private set; }
public IFieldTypeRepository FieldTypes { get; private set; }
public IFormRepository Forms { get; private set; }
public IFormTypeRepository FormTypes { get; private set; }
public IGenderRepository Genders { get; private set; }
public IMaritalStatusRepository MaritalStatuses { get; private set; }
public IMenuItemRepository MenuItems { get; private set; }
public IRoleRepository Roles { get; private set; }
public ITabRepository Tabs { get; private set; }
public ITitleRepository Titles { get; private set; }
public IViewRepository Views { get; private set; }
public IViewTypeRepository ViewTypes { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

