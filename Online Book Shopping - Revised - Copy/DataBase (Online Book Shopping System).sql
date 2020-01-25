CREATE TABLE Customer (
Name varchar(20) Not Null,
UserName varchar(15) Not Null Unique,
MailID varchar(50) ,
Password varchar(10) Not Null,
Role varchar(10) Not Null,
CustomerID int Identity(1,1) Primary Key
) 

CREATE TABLE Seller (
Name varchar(20) Not Null,
UserName varchar(15) Not Null Unique,
MailID varchar(50) ,
PhoneNumber decimal(10,0) ,
Password varchar(10) Not Null,
Role varchar(10) Not Null,
SellerID int Identity(1,1) Primary Key
)

CREATE TABLE Admin (
Name varchar(15) Not Null,
UserName varchar(10) Not Null Unique,
MailID varchar(50) ,
PhoneNumber decimal(10,0) ,
Password varchar(10) Not Null,
Role varchar(10) Not Null,
AdminID int Identity(1,1) Primary Key
)

CREATE TABLE Book (
BookID int Identity(1,1) Primary Key,
SellerID int Foreign Key References Seller(SellerID),
Title varchar(20) Not Null Unique,
Author varchar(20) Not Null,
Genere varchar(15) Not Null,
Price int Not Null,
NoOfPages int Not Null
)

alter Proc spCheckUserNameandPassword
@_UserName varchar(15),
@_Password varchar(10),
@_Role varchar(10) out
AS

Begin
Select @_Role=Role From Customer Where UserName=@_UserName And Password=@_Password
End

Begin 
Select @_Role=Role From Seller Where UserName=@_UserName And Password=@_Password
End

Begin
Select @_Role=Role From Admin Where UserName=@_UserName And Password=@_Password 
End

if(@_Role = '')
Begin 
Raiserror ('No User is found with this User name and Password',16,1)
End

Declare @role varchar(20)
Exec spCheckUserNameandPassword ,'Bathri','1234',@_Role=@role out
Print @role


CREATE Proc spInsertBook
@Title varchar(20),
@Author varchar(20),
@Genere varchar(15),
@Price int,
@NoOfPages int
As
Begin
insert into Book(Title,Author,Genere,Price,NoOfPages) Values (@Title,@Author,@Genere,@Price,@NoOfPages)
End

Create Proc spInsertCustomer
@Name Varchar(20),
@UserName varchar(15),
@MailId varchar(50),
@Password varchar(10),
@Role varchar(10)
AS
Begin
Insert into Customer(Name,UserName,MailID,Password,Role) Values (@Name,@UserName,@MailID,@Password,@Role)
End

Create Proc spInsertSeller
@Name Varchar(20),
@UserName varchar(15),
@MailId varchar(50),
@PhoneNumber decimal(10,0),
@Password varchar(10),
@Role varchar(10)
AS
Begin
Insert into Seller(Name,UserName,MailID,PhoneNumber,Password,Role) Values (@Name,@UserName,@MailID,@PhoneNumber,@Password,@Role)
End