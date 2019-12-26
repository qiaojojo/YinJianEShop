create database eShopDatabase	--创建数据库
use eShopDatabase
go

--卖家表
CREATE TABLE Sellers(
	Id INT PRIMARY KEY IDENTITY,	--自增主键
	SellerName NVARCHAR(50),
	SellerNum	NVARCHAR(50),
	SellerPasswd NVARCHAR(100),
	Telephone NVARCHAR(100)
)

--用户表
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,	--自增主键
	UserNum	NVARCHAR(50),
	UserName NVARCHAR(50),
	UserPasswd NVARCHAR(100),
	Gender BIT,
	Identification NVARCHAR(100),
	Telephone NVARCHAR(100)
)

--用户收货地址表
CREATE TABLE UserShippingAddress(
	Id INT PRIMARY KEY IDENTITY,
	Receiver NVARCHAR(50),
	Telephone NVARCHAR(100),
	Address NVARCHAR(300),
	UserId INT,
	FOREIGN KEY(UserId) REFERENCES Users(Id)	--创建外键
)


--商品表
CREATE TABLE GoodsInfo(
	Id INT PRIMARY KEY IDENTITY,	--自增主键
	GoodName NVARCHAR(20),
	GoodPrice DECIMAL,
	AddedDate DATETIME,
	Remark NVARCHAR(200),
	AdderId INT,
	FOREIGN KEY(AdderId) REFERENCES Sellers(Id)	--创建外键
)	

--商品图片表
CREATE TABLE GoodsImg(
	Id INT PRIMARY KEY IDENTITY,	--自增主键
	ImgUrl NVARCHAR(100),
	GoodId INT,
	FOREIGN KEY(GoodId) REFERENCES GoodsInfo(Id)	--创建外键
)

--订单项表
CREATE TABLE GoodOrder(
	Id INT PRIMARY KEY IDENTITY,
	GoodNum INT, 
	GoodId INT,
	OrderId INT,
	FOREIGN KEY(GoodId) REFERENCES GoodsInfo(Id),	--商品id
	FOREIGN KEY(OrderId) REFERENCES OrderState(Id)	--订单id
)

--订单表
CREATE TABLE OrderState(
	Id INT PRIMARY KEY IDENTITY,
	UserId INT,
	AddressId INT,
	CourierNum NVARCHAR(50)	--快递单号
	OrderState INT,			--订单状态
	OrderNum NVARCHAR(100),	--订单编号
	RealPay DECIMAL,		--实付款
	CreateDate DATETIME,
	PayDate DATETIME,
	SendDate DATETIME,
	UserGetDate DATETIME,
	FOREIGN KEY(UserId) REFERENCES Users(Id),
	FOREIGN KEY(AddressId) REFERENCES UserShippingAddress(Id),
)

