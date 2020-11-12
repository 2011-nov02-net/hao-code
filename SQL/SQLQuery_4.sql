-- SQL commands are divided into a few categories
-- DML
-- select, insert,update,delete, truncate
-- on rows


-- DDL
-- Create Alter Drop
--- on  tables, function, views

-- Date Control Language
-- grant, revoke, 

-- select return a table
-- others succeed, rows affected

-- insert, no provided-> NULL
-- best to be specific(x,y) values(a,b)
-- can insert multiple rows
-- insert a select statement


-- update table set name = "xx", 
-- set a select statement(value)

-- delete conditon, one at a time

-- truncate table table name, all at once, no condition

-- insert two new records into the employ table
select * from Employee;
insert into Employee(EmployeeId,LastName,FirstName) values (9,'Yang','Hao');
insert into Employee(EmployeeId,LastName,FirstName) values (10,'Yang2','Hao2');

-- both reverted
delete Employee 
where EmployeeId = 9;
delete from Employee
where FirstName = 'Hao2';


-- 2. insert two new records into the tracks table.
-- insert failed because keys cannot be NULL
select * from Track;
insert into Track(TrackId,Name) values (3504,'SQL Data Overload');
insert into Track(TrackId,Name) values (3505,'SQL Data Overload2');


-- 3. update customer Aaron Mitchell's name to Robert Walter
select * from Customer;
UPDATE Customer
set FirstName = 'Robert', LastName = 'Walter'
where Customer.FirstName = 'Aaron' AND Customer.LastName = 'Mitchell'
-- reverted
UPDATE Customer
set FirstName = 'Aaron', LastName = 'Mitchell'
where Customer.FirstName = 'Robert' AND Customer.LastName = 'Walter'


-- 4. delete one of the employees you inserted.




-- 5. delete customer Robert Walter
-- deletion failed, referential integrity
-- prevent foreign keys pointing to null references
-- delete invoiceline, then delete invoice, finally delete customer
delete from Customer
where FirstName = 'Robert' and LastName = 'Walter';

