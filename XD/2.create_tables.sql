create table [xd].[DbType]
(
	Id int identity(1,1) primary key ,
	Name varchar(100),
	Description varchar(max)
);

create table [xd].[FieldType]
(
	Id int identity(1,1) primary key ,
	Name varchar(100),
	Description varchar(max),
	DbTypeId int
);

create table [xd].[FieldRequirementLevel]
(
	Id int identity(1,1) primary key ,
	Name varchar(100),
	Description varchar(max)
);

create table [xd].[FormType]
(
	Id int identity(1,1) primary key,
	Name varchar(100),
	Description varchar(max)
);

create table [xd].[ViewType]
(
	Id int identity(1,1) primary key ,
	Name varchar(100),
	Description varchar(max)
);

create table [xd].[AppUser]
(
	Id uniqueidentifier,
	Fullname varchar(150),
	FirstName varchar(75),
	LastName varchar(75),
	UniqueName varchar(15)
);

create table [xd].[Gender]
(
	Id int identity(1,1) primary key,
	Name varchar(100),
	Description varchar(max)
);

create table [xd].[AddressInformation]
(
	Id int identity(1,1) primary key,
	UnitNumber varchar(10),
	StreetAddress varchar(300),
	Suburb varchar(100),
	City varchar(100),
	Province varchar(100),
	PostalCode varchar(5)
);

create table [xd].[Title]
(
	Id int identity(1,1) primary key,
	Name varchar(100),
	Description varchar(max)
);

create table [xd].[MaritalStatus]
(
	Id int identity(1,1) primary key,
	Name varchar(100),
	Description varchar(max)
);

create table [xd].[Contact]
(
	Id uniqueidentifier,
	TitleId int,
	Fullname varchar(150),
	FirstName varchar(75),
	LastName varchar(75),
	MiddleName varchar(75),
	GenderId int,
	DateOfBirth date,
	Age int,
	IdNumber varchar(20),
	CellPhoneNumber varchar(13),
	HomePhoneNumber varchar(13),
	EmailAddress varchar(50),
);

create table [xd].[Credentials]
(
	AppUserId uniqueidentifier unique not null,
	Username varchar(20),
	Password varchar(20),
	LastLogin smalldatetime
);

create table [xd].[EntityType]
(
	Id int identity(1,1) primary key ,
	Name varchar(100),
	Description varchar(max)
);

create table [xd].[Entity]
(
	Id uniqueidentifier primary key,
	UniqueName varchar(150),
	Name varchar(150),
	CollectionName varchar(210),
	Description varchar(max),
	EntityTypeId int,
);

create table [xd].[Field]
(
	Id uniqueidentifier primary key,
	SchemaName varchar(150),
	DisplayName varchar(300),
	Description varchar(max),
	FieldTypeId int,
	EntityId uniqueidentifier,
	FieldRequirementId int
);

create table [xd].[View]
(
	Id uniqueidentifier primary key,
	Name varchar(150),
	Description varchar(max)
);

create table [xd].[Tab]
(
	Id uniqueidentifier primary key,
	Name varchar(150)
);

create table [xd].[Role]
(
	Id uniqueidentifier primary key,
	Name varchar(150)
);

create table [xd].[AppUserRole]
(
	AppUserId uniqueidentifier,
	RoleId uniqueidentifier
);

alter table [xd].[Credentials] add constraint FK_AppUser_Id_Credentials_AppUserId foreign key references [xd].[Credentials](AppUserId); 

alter table [xd].[Contact] add constraint [FK_xd.Contact_xd.Gender_GenderId] foreign key ([GenderId]) references [xd].[Gender]([Id]);
alter table [xd].[Contact] add constraint [FK_xd.Contact_xd.Address_AddressId] foreign key ([AddressId]) references [xd].[Address]([Id]);
alter table [xd].[Contact] add constraint [FK_xd.Contact_xd.Title_TitleId] foreign key ([TitleId]) references [xd].[Title]([Id]);
alter table [xd].[Contact] add constraint [FK_xd.Contact_xd.[MaritalStatus_MaritalStatusId] foreign key ([MaritalStatusId]) references [xd].[MaritalStatus]([Id]);


alter table [xd].[t1] add constraint [FK_xd.t1_xd.[t2_t2Id] foreign key ([t2Id]) references [xd].[[t2]([Id]);


alter table [xd].[Field] add constraint [FK_xd.Field_xd.FieldType_FieldTypeId] foreign key ([FieldTypeId]) references [xd].[FieldType]([Id]);
alter table [xd].[Entity] add constraint [FK_xd.Entity_xd.EntityType_EntityTypeId] foreign key ([EntityTypeId]) references [xd].[EntityType]([Id]);
alter table [xd].[Field] add constraint [FK_xd.Field_xd.FieldRequirementLevel_FieldRequirementLevelId] foreign key ([FieldRequirementLevelId]) references [xd].[FieldRequirementLevel]([Id]);
alter table [xd].[Field] add constraint [FK_xd.Field_xd.FieldType_FieldTypeId] foreign key ([FieldTypeId]) references [xd].[FieldType]([Id]);
alter table [xd].[Form] add constraint [FK_xd.Form_xd.FormType_FormTypeId] foreign key ([FormTypeId]) references [xd].[FormType]([Id]);
alter table [xd].[View] add constraint [FK_xd.View_xd.ViewType_ViewTypeId] foreign key ([ViewTypeId]) references [xd].[ViewType]([Id]);
alter table [xd].[AppUserRole] add constraint [FK_xd.AppUserRole_xd.AppUser_AppUserId] foreign key ([AppUserId]) references [xd].[AppUser]([Id]);
alter table [xd].[AppUserRole] add constraint [FK_xd.AppUserRole_xd.Role_RoleId] foreign key ([RoleId]) references [xd].[Role]([Id]);


