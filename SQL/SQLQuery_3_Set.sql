-- set
-- index starts at 1, substring 1,1 initial

-- sub queries
-- common table expression , have to be called again in query

-- IS NOT NULL, IS NULL
-- execution plan in Microsoft database


-- 1. which artists did not make any albums at all?
-- set opeation 
select * from album;
select * from artist;

select artistID from artist 
EXCEPT
select artistID from album;
-- 71 entries

-- subquery
select * from artist where ArtistId NOT IN(select ArtistId from Album);

-- common table expression
with func as (select ArtistId from Album)
SELECT * from artist where ArtistId NOT IN( select * from func);


-- 2. which artists did not record any tracks of the Latin genre?

-- artist that have
select distinct a.ArtistId,a.Name 
from Artist a 
inner join Album b on a.artistId = b.artistId
inner join Track t on b.albumId = t.albumId
inner join Genre g on t.genreid = g.GenreId
where g.Name = 'Latin';
-- 28 unique latin artists

select * from Artist -- 275 artists - 28 latin artist = 247
EXCEPT
select a.ArtistId,a.Name -- distinct here does not matter
from Artist a 
inner join Album b on a.artistId = b.artistId
inner join Track t on b.albumId = t.albumId
inner join Genre g on t.genreid = g.GenreId
where g.Name = 'Latin';
-- 247


-- 3. which video track has the longest length? (use media type table)
select * from MediaType;
select * from track;

select top(1) *
from track t 
where t.MediaTypeId = 3
order by t.Milliseconds desc;
--trackID 2820

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)
select * from customer;
select * from Employee;

select * from customer c where c.city = (
    select city from Employee e where e.ReportsTo  is null 
)
-- ID14 Mark Philips lives in Edmonton as well

-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?
select i.BillingCountry, sum(l.Quantity) TotalTracks,sum(l.Quantity*l.UnitPrice) TotalPrice
from invoice i 
join InvoiceLine l on i.invoiceid = l.InvoiceId
join track t on l.TrackId = t.TrackId
join MediaType m on t.MediaTypeId = m.MediaTypeId
where m.MediaTypeId != 3 and i.BillingCountry = 'Germany'
group by i.BillingCountry
-- 146 144.54, done using join

-- Matt's
SELECT COUNT(*) AS "# Tracks", SUM(l.UnitPrice) AS "Total Price" FROM InvoiceLine l
WHERE l.InvoiceId IN (
    SELECT i.InvoiceId FROM Invoice i
    WHERE i.CustomerId IN (
        SELECT c.CustomerId FROM Customer c
        WHERE c.Country = 'Germany'
    )
) AND l.TrackId IN (
    SELECT t.TrackId FROM Track t
    WHERE t.MediaTypeId IN (
        SELECT m.MediaTypeId FROM MediaType m
        WHERE m.Name LIKE '%audio%'
    )
)

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.
select * from employee

select * from Employee e
where DATEDIFF(MONTH,BirthDate,HireDate) < 12*35


select c.FirstName,c.LastName,c.Country 
from Customer c
join Employee e on c.SupportRepId = e.EmployeeId
where DATEDIFF(MONTH,BirthDate,HireDate) < 12*35

