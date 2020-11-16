create schema CA;
GO
create table CA.products
(
    id NVARCHAR(10) primary key not null,
    name NVARCHAR(10) not null,
    price float not null,
    check(price >0)

)

create table CA.customers
(
    id NVARCHAR(10) primary key not null,
    firstname NVARCHAR(10) not null,
    lastname NVARCHAR(10) not null,
    cardnumber NVARCHAR(15) not null

)

create table CA.orders
(
    id NVARCHAR(10) not null,
    productid NVARCHAR(10) not null,
    customerid NVARCHAR(10) not null,
    foreign key(productid) REFERENCES CA.products(id)
        on delete cascade on update cascade,
    foreign key(customerid) REFERENCES CA.customers(id)
        on delete cascade on update cascade

)

-- dml
-- 1
insert into CA.products(id,name,price) values ('p101','Coke',1.0);
insert into CA.products(id,name,price) values ('p102','Chips',5.0);
insert into CA.products(id,name,price) values ('p103','Cake',10.0);

insert into CA.customers values('c1','John','Smith','1111');
insert into CA.customers values('c2','Adam','Savage','2222');
insert into CA.customers values('c3','Jane','Doe','3333');

insert into CA.orders values('o1','p101','c1');
insert into CA.orders values('o2','p102','c2');
insert into CA.orders values('o3','p103','c3');

-- 2
insert into CA.products values('p104','Iphone',200);

-- 3
insert into CA.customers values('c4', 'Tina','Smith', '4444' );

-- 4
insert into CA.orders values('o4','p104','c4');

-- 5
select *
from CA.orders o 
join CA.customers c on o.customerid = c.id
where c.firstname = 'Tina' and c.lastname = 'Smith'

-- 6
select p.Name, sum(p.price) as TotalSales
from CA.orders o 
join CA.products p on o.productid = p.id
where p.Name = 'Iphone'
group by p.Name

-- 7
update CA.products set price = 250 where name = 'Iphone';

-- checking for results
select * from CA.products
select * from CA.customers
select * from CA.orders


