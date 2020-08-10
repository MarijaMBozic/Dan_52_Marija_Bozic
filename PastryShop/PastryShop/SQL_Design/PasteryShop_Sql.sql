Use PastryShop

drop table if exists Customer
drop table if exists Cake
drop table if exists Orders
drop table if exists ListOfCakeInOrder 

create table Customer (
   CustomerId       int            identity (1,1) primary key,   
   FullName       nvarchar(100)          not null,
   Address        nvarchar(100)          not null,
   PhoneNumber    nvarchar(15)   unique  not null,
   Username       nvarchar(100)  unique  not null,
   Password       nvarchar(max)          not null,
   NumberOfOrders int					 
)

create table Cake (
   CakeId          int            identity (1,1) primary key,   
   Name            nvarchar(100)          not null,
   IsForChildren   bit                    not null,
   PurchasePrice   float                  not null,
   SellingPrice    float                  not null
)

create table Orders (
	OrderId          int            identity (1,1) primary key,
	Date             date                   not null,
	TotalPrice       float                  not null,
    NumberOfCakes    int                    not null,
	CustomerId           int                    not null,
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)	
)

create table ListOfCakeInOrder (
	ListOfCakeInOrderId  int            identity (1,1) primary key,
	OrderId        int                      not null,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    CakeId         int                       not null,
    FOREIGN KEY (CakeId) REFERENCES Cake(CakeId)
)

insert into Cake(Name, IsForChildren, PurchasePrice, SellingPrice)
values('Ljubavno gnezdo', 0, 1000, 1200 ),
	  ('Lincer', 0, 2000, 2400 ),
	  ('Cheese cake', 0, 1200, 1440 ),
	  ('Dobos', 1, 2500, 3000 ),
	  ('Bomba', 1, 800, 960 ),
	  ('Kinder', 1, 1100, 1320 )