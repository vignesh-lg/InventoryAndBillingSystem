use Project

create table LogData
(
UserName varchar(20) not null, 
CustomerFirstName varchar(20) not null, 
CustomerSecondName varchar(20) not null, 
gender varchar(10) not null,
States varchar(20) not null ,
City varchar(20) not null ,
PermenantAddress varchar(20) not null, 
PinCode int  not null ,
CellNumber bigint not null,
Email varchar(20) not null ,
DateOfBirth varchar(20) not null,
RegistrationNumber varchar(20) not null,
Passwords varchar(20) not null,  
Personid int IDENTITY(1000,1)not null primary key,
created_at DATETIME NOT NULL
DEFAULT CURRENT_TIMESTAMP,
operation varchar(20) not null
)
--drop table LogData
create table UserData
(
CustomerFirstName varchar(20) not null, 
UserName varchar(20) not null, 
CustomerSecondName varchar(20) not null, 
gender varchar(10) not null,
States varchar(20) not null ,
City varchar(20) not null ,
PermenantAddress varchar(20) not null, 
PinCode varchar(20)  not null ,
CellNumber varchar(20) not null,
Email varchar(20) not null ,
DateOfBirth varchar(20) not null,
RegistrationNumber as ('OSIABS'+right('000000'+Cast(personid as varchar(6)),6)),
Passwords varchar(20) not null,  
Personid int IDENTITY(1000,1)not null primary key,
created_at DATETIME NOT NULL
DEFAULT CURRENT_TIMESTAMP
)
INSERT INTO UserData(UserName, CustomerFirstName, CustomerSecondName, gender, States, City, PermenantAddress, PinCode, CellNumber, Email, DateOfBirth, Passwords)
values('lg','viki','kg','male','tamilnadu','erode','amman nagar',632198,0987654321,'jgh@gj.com','14/11/1999','SD852963')
select * from UserData;
--drop table UserData
ALter PROCEDURE UserData_Procedure
--@Action int,
@CustomerFirstName varchar(20) , 
@CustomerSecondName varchar(20) , 
@State varchar(20)  ,
@City varchar(20)  ,
@PermenantAddress varchar(20) , 
@PinCode varchar(20) ,
@CellNumber varchar(20) ,
@Email varchar(20)  ,
@DateOfBirth varchar(20) ,
@Password varchar(20),
@gender varchar(10)


AS	
--INSERT
--IF @Action = 1
BEGIN
Declare @UserName varchar(20);
Declare @id int;
SELECT @id = ISNULL(MAX(Personid),1000) + 1 FROM UserData
 SELECT @UserName = @CustomerFirstName + RIGHT('0000000' + CAST(@Id AS VARCHAR(7)), 7)	
INSERT INTO UserData(UserName, CustomerFirstName, CustomerSecondName,gender, States, City, PermenantAddress, PinCode, CellNumber, Email, DateOfBirth, Passwords) VALUES (@UserName,  @CustomerFirstName,  @CustomerSecondName,@gender, @State,  @City,  @PermenantAddress  ,@PinCode,  @CellNumber,  @Email,  @DateOfBirth,  @Password )
END
Alter PROCEDURE UserData_Procedure_Update
--@Action int,
@UserName varchar(20) , 
@CustomerFirstName varchar(20) , 
@CustomerSecondName varchar(20) , 
@State varchar(20)  ,
@City varchar(20)  ,
@PermenantAddress varchar(20) , 
@PinCode varchar(20) ,
@CellNumber varchar(20) ,
@Email varchar(20)  ,
@DateOfBirth varchar(20) ,
@Password varchar(20),
@gender varchar(10),
@id int
AS 
--UPDATE
--IF @Action = 2
BEGIN
Update UserData Set UserName=@UserName,CustomerFirstName=@CustomerFirstName, CustomerSecondName= @CustomerSecondName,@gender=gender,States= @State, City= @City, PermenantAddress= @PermenantAddress  ,PinCode=@PinCode, CellNumber= @CellNumber, Email= @Email,DateOfBirth=  @DateOfBirth, Passwords= @Password where Personid=@id
--END
END

drop procedure UserData_Procedure
use project
Alter PROCEDURE User_Procedure
AS

--SELECT
BEGIN
SELECT * FROM UserData
END
ALter PROCEDURE User_Procedure_Search
@id Varchar(20)
AS

--SELECT
BEGIN
SELECT * FROM UserData where UserName LIKE '%' + @id + '%'
END
create  procedure UserData_Procedure_Delete
@id int
as
begin
delete from UserData where Personid=@id;
end
Alter PROCEDURE User_Procedure_Login
@UserName1 varchar(20), 
@Password1 varchar(20),
@Error varchar(100) out
AS

BEGIN

--Login
SELECT * from UserData WHERE UserName = @UserName1 and Passwords=@Password1
if exists ( SELECT * from UserData WHERE UserName = @UserName1 and Passwords=@Password1)
BEGIN  
SET @ERROR = @UserName1 + ' Login Successfully'  
END  
ELSE  
BEGIN  
SET @ERROR = @UserName1 + ' Logined failed Successfully'  
END  
END
select * from UserData
--__________________________________________________________________________________--

create table ProductData
(
OrderID int NOT NULL,
PersonID int not null,
FOREIGN KEY (personid) REFERENCES UserData(Personid) ON DELETE CASCADE,
ProductName varchar(20) not null, 
ProductNumber varchar(20) not null,
created_at DATETIME NOT NULL
DEFAULT CURRENT_TIMESTAMP
)  
Insert into ProductData(OrderID,ProductName,ProductNumber,PersonID) values (1133,'viki','viki',1000)
select * from ProductData

--drop table ProductData
--__________________________________________________________________________________--
alter VIEW JoinedData 
AS
SELECT OrderID,UserName,CustomerFirstName,CustomerSecondName,States,City,PermenantAddress,PinCode,CellNumber,DateOfBirth,RegistrationNumber,Email,Passwords,ProductData.PersonID,userdata.created_at FROM UserData inner join ProductData on UserData.Personid=ProductData.PersonID


SELECT * FROM JoinedData
--drop view JoinedData
--__________________________________________________________________________________--

Alter TRIGGER AfterInsert
ON UserData
INSTEAD OF INSERT  
AS
BEGIN
	DECLARE @UserName varchar(20) , 
@CustomerFirstName varchar(20) , 
@CustomerSecondName varchar(20) , 
@State varchar(20)  ,
@City varchar(20)  ,
@PermenantAddress varchar(20) , 
@PinCode int ,
@CellNumber bigint ,
@Email varchar(20)  ,
@DateOfBirth varchar(20) ,
@RegistrationNumber varchar(20) ,
@Password varchar(20),
@created_at DATETIMe,
@operation Varchar(20)
	select   @UserName=UserName,@CustomerFirstName=CustomerFirstName,  @CustomerSecondName=CustomerSecondName, @State=States,  @City=City,  @PermenantAddress=PermenantAddress  ,@PinCode=PinCode,  @CellNumber=CellNumber,  @Email=Email,  @DateOfBirth=DateOfBirth,  @RegistrationNumber=RegistrationNumber,  @Password=Passwords from inserted
	INSERT INTO LogData(UserName, CustomerFirstName, CustomerSecondName, States, City, PermenantAddress, PinCode, CellNumber, Email, DateOfBirth, RegistrationNumber, Passwords,operation)  VALUES (  cast(@UserName as nvarchar(10)),@CustomerFirstName,  @CustomerSecondName, @State,  @City,  @PermenantAddress  ,@PinCode,  @CellNumber,  @Email,  @DateOfBirth,  @RegistrationNumber,  @Password,'Data is inserted')
END
select * from LogData
--_____________________________________________________________________--
Alter TRIGGER tg_Update
ON UserData
INSTEAD OF Update
AS
BEGIN
		DECLARE @UserName varchar(20) , 
@CustomerFirstName varchar(20) , 
@CustomerSecondName varchar(20) , 
@State varchar(20)  ,
@City varchar(20)  ,
@PermenantAddress varchar(20) , 
@PinCode int ,
@CellNumber bigint ,
@Email varchar(20)  ,
@DateOfBirth varchar(20) ,
@RegistrationNumber varchar(20) ,
@Password varchar(20),
@created_at DATETIMe,
@operation Varchar(20)
	select @UserName = UserName,@CustomerFirstName=CustomerFirstName,  @CustomerSecondName=CustomerSecondName, @State=States,  @City=City,  @PermenantAddress=PermenantAddress  ,@PinCode=PinCode,  @CellNumber=CellNumber,  @Email=Email,  @DateOfBirth=DateOfBirth,  @RegistrationNumber=RegistrationNumber,  @Password=Passwords from inserted
	Update UserData Set CustomerFirstName=@CustomerFirstName, CustomerSecondName= @CustomerSecondName,States= @State, City= @City, PermenantAddress= @PermenantAddress  ,PinCode=@PinCode, CellNumber= @CellNumber, Email= @Email,DateOfBirth=  @DateOfBirth, RegistrationNumber= @RegistrationNumber, Passwords= @Password,@operation='Data is Updated' where UserName=@UserName
	INSERT INTO LogData(UserName, CustomerFirstName, CustomerSecondName, States, City, PermenantAddress, PinCode, CellNumber, Email, DateOfBirth, RegistrationNumber, Passwords,operation)  VALUES (  cast(@UserName as nvarchar(10)),@CustomerFirstName,  @CustomerSecondName, @State,  @City,  @PermenantAddress  ,@PinCode,  @CellNumber,  @Email,  @DateOfBirth,  @RegistrationNumber,  @Password,'Data is Updated')
END
DISABLE TRIGGER ALL ON userdata;
DISABLE TRIGGER ALL ON project;
ENABLE TRIGGER ALL ON userdata;
ENABLE TRIGGER ALL ON project;
disable trigger  tg_Delete on userdata
enable trigger  tg_Delete on userdata
Create TRIGGER tg_Delete
ON joinedData
INSTEAD OF Delete
AS
BEGIN
		DECLARE @UserName varchar(20) , 
@CustomerFirstName varchar(20) , 
@CustomerSecondName varchar(20) , 
@State varchar(20)  ,
@City varchar(20)  ,
@PermenantAddress varchar(20) , 
@PinCode int ,
@CellNumber bigint ,
@Email varchar(20)  ,
@DateOfBirth varchar(20) ,
@RegistrationNumber varchar(20) ,
@Password varchar(20),
@created_at DATETIMe,
@operation Varchar(20)
	select @UserName = UserName,@CustomerFirstName=CustomerFirstName,  @CustomerSecondName=CustomerSecondName, @State=States,  @City=City,  @PermenantAddress=PermenantAddress  ,@PinCode=PinCode,  @CellNumber=CellNumber,  @Email=Email,  @DateOfBirth=DateOfBirth,  @RegistrationNumber=RegistrationNumber,  @Password=Passwords from deleted
	DELETE FROM UserData WHERE UserName = @UserName
	INSERT INTO LogData(UserName, CustomerFirstName, CustomerSecondName, States, City, PermenantAddress, PinCode, CellNumber, Email, DateOfBirth, RegistrationNumber, Passwords,operation)  VALUES (  cast(@UserName as nvarchar(10)),@CustomerFirstName,  @CustomerSecondName, @State,  @City,  @PermenantAddress  ,@PinCode,  @CellNumber,  @Email,  @DateOfBirth,  @RegistrationNumber,  @Password,'Data is Deleted')
END
DROP TRIgger tg_Delete
