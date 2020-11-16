-- datatype 
-- ddl
-- create alter drop

-- default to the expensive version
-- create database chinook2;

-- namespace for tables, other objects called schem
create schema School;
GO
-- dbo is the default schema, 
select * from dbo.Track
-- tables creation

-- ~~~ unavoided assume you run the entire script at once
drop table School.Course;
create table School.Course(
  CourseId NVARCHAR(30) NOT NULL,
  CourseName NVARCHAR(150) NOT NULL, -- highlighted sometimes dont matter use '' or [] to avoid
  TeacherId int NULL,
  StartDate Date Not NULL default getdate(),
  EndDate Date not null ,
  check( enddate > startdate)
)

Alter table School.Course
    drop column 
    drop constraint (name from error)
    add constraint name foreign key( column name)
        reference school.Teacher(id)

-- can use select statement in these

-- constraints in sql server
-- any column by default could be NULL
-- use NOT NULL, write NULLL explicitly, eaiser to read 

-- Unique - prevent duplicate values in that column
-- good for candidate keys, 1-1 Foreign Key

-- primary key
-- auto implies unique and null
-- still write out not null for reability

-- check: set condition, must be true for every row
-- default: sets a default value if  an insert done without value
-- doesnt have to be constant- evaluated at insert time, 

-- identity(start,offset), auto incrementing default number, default 1-> 2
-- prevent manully inserting values
-- if deleted , will not restart

-- foreign key:
-- list out constraint, can have names
-- constraint ct_checkdate check( something)
-- on delete cascade/set null/set default, delete dependency
-- on update
-- batch


-- multiplicity, relationship between data. entities
-- 1-1, 1-n, n-n

-- 1-1 in the same table/row, unique fk to another table
-- 1-n, fk on the many. not unique

-- n-n
-- not directly, 
-- intro an intermediate (junction) table with two fk to two pre-existing tbales
-- but can contain other columns as well
-- primry key(courseId, studentId)

-- exercise
-- DDL
create Schema dept;

drop table dept.department;
create table dept.department
(
    id NVARCHAR(20) primary key,
    name NVARCHAR(20) not null,
    location NVARCHAR(50) not null
)

drop table dept.employee;
create table dept.employee
(
    employeeID NVARCHAR(20) PRIMARY key,
    firstname NVARCHAR(20) not null,
    lastname NVARCHAR(20) not null,
    ssn NVARCHAR(10) not NULL unique, --
    deptID NVARCHAR(20) not null, -- not unique
    foreign key (deptID) REFERENCEs dept.department(id)
)

drop table dept.empdetails;
create table dept.empdetails
(
    detailID NVARCHAR(20) primary key,
    employeeID NVARCHAR(20) not null unique,
    salary int not null,
    address1 NVARCHAR(50) not null,
    address2 NVARCHAR(50) null,
    city NVARCHAR(10) not null,
    state NVARCHAR(20) null,
    country NVARCHAR(50) not null,
    foreign key (employeeID) REFERENCES dept.employee(employeeID)

)

-- DML
-- add at least 3 records into each table
select * from dept.department
insert into dept.department(id,name,location) values ('1','Video','Phoenix');
insert into dept.department(id,name,location) values ('2','Game','Tempe');
insert into dept.department(id,name,location) values ('3','Comic','Chandler');

select * from dept.employee
insert into dept.employee(employeeid,firstname,lastname,ssn,deptid) values ('0011','John','Smith','123123123','1');
insert into dept.employee(employeeid,firstname,lastname,ssn,deptid) values ('0022','John','Snow','456123123','2');
insert into dept.employee(employeeid,firstname,lastname,ssn,deptid) values ('0033','Adam','Savage','789123123','3');

select* from dept.empdetails
insert into dept.empdetails values('x1','0011',50000,'Riverview 500','N/A', 'Mesa','Arizona','USA');
insert into dept.empdetails values('y1','0022',60000,'Mountainview 600','N/A', 'Phoenix','Arizona','USA');
insert into dept.empdetails values('z1','0033',70000,'Centralview 700','N/A', 'Chandler','Arizona','USA');

-- add employee Tina Smith
insert into dept.employee(employeeid,firstname,lastname,ssn,deptid) values ('0044','Tina','Smith','111111111','1');



-- add department marketing
insert into dept.department(id,name,location) values('4','Sports','Scottsdale');
insert into dept.department(id,name,location) values('5','Marketing','Scottsdale');
insert into dept.employee(employeeid,firstname,lastname,ssn,deptid) values ('0055','Mark','Kting','444411111','5');
-- list all employees in marketing
select * 
from dept.Employee e
join dept.department d on e.deptID = d.id
where d.name = 'Marketing'


-- report total salary of marketing


-- report total employees by department

-- increase salary of tina smith to 90000



-- indexes 
-- clustered, one, primary keys sets clustered index

-- nonclustered, many, unique sets nonclustered