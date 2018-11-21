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
	Description varchar(max)
);

create table [xd].[FieldRequirementLevel]
(
	Id int identity(1,1) primary key ,
	Name varchar(100),
	Description varchar(max)
);

create table [xd].[FormType]
(
	Id int identity(1,1) primary key ,
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

create table [xd].[Credentials]
(
	Id uniqueidentifier unique not null,
	Username varchar(20),
	Password varchar(20),
	LastLogin smalldatetime
);

create table [xd].[Entity]
(
	Id uniqueidentifier primary key,
	Name varchar(150),
	Label varchar(200),
	CollectionName varchar(210),
	Description varchar(max)
);
