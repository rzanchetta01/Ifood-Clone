
IF NOT EXISTS (select 1 from dbo.sysobjects where id = object_id(N'dbo.tbBusiness_Products') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
create table tbBusiness_Category
(
	Id int identity(1,1),
	Category varchar(50),
	primary key (Id)
)


IF NOT EXISTS (select 1 from dbo.sysobjects where id = object_id(N'dbo.tbBusiness_Products') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
create table tbBusiness_Avg_Price
(
	Id int identity(1,1),
	Avg_Price int,
	primary key (Id)
)

IF NOT EXISTS (select 1 from dbo.sysobjects where id = object_id(N'dbo.tbBusiness_Products') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
create table tbBusiness_Products
(
	Id int identity(1,1) not null,
	Id_Restaurant int not null, --fk
	Product_Name varchar(100) not null,
	Product_Description varchar(200),
	Price decimal(5,2) not null,
	Product_Image int not null
	primary key (Id)
)

IF NOT EXISTS (select 1 from dbo.sysobjects where id = object_id(N'dbo.tbBusiness_Restaurant') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
create table tbBusiness_Restaurant
(
	Id int identity(1,1) not null,
	Restaurant_Name varchar(100) not null,
	Restaurant_Adress varchar(200) not null,
	Restaurant_Rating tinyint not null,
	Id_Category int not null,
	Id_Restaurant_Avg_Price int not null,
	primary key (Id),
	foreign key (Id_Category) references tbBusiness_Category(Id),
	foreign key (Id_Restaurant_Avg_Price) references tbBusiness_Avg_Price(Id)
)

IF NOT EXISTS (select * from tbBusiness_Avg_Price)
insert into tbBusiness_Avg_Price (Avg_Price) values(1), (2), (3), (4), (5)
