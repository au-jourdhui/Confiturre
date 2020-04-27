create database ConfiturreDB;
go

use ConfiturreDB;
go

create table dbo.Messages
(
	ID int primary key identity(1,1),
	Name nvarchar(100) not null,
	Email nvarchar(500) not null,
	Message nvarchar(max) not null,
	DateCreated datetime not null default getdate()
);
go