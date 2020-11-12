-- for part 2 join
select * from Album;

SELECT ArtistId
FROM Artist
WHERE Name = 'Various Artists';

SELECT *
FROM Album
WHERE ArtistId = 21;

-- pair with someone who is not yourself
SELECT *
FROM Employee AS e1 CROSS JOIN Employee AS e2
WHERE e1.EmployeeId != e2.EmployeeId;
-- not commonly used

-- join two artist table and album table only if theier artistID are the same
-- innoer join: no match no show
SELECT al.Title, ar.Name
FROM Artist AS ar
	INNER JOIN Album AS al ON ar.ArtistId = al.ArtistId;

--left: left no match still show with NULL value
-- modified selected-list to fit
SELECT ar.Name,al.Title
FROM Artist AS ar LEFT JOIN Album AS al
	ON ar.ArtistId = al.ArtistId;

-- all rock songs, showing the name in the format 'ArtistName - SongName'
-- merged two columns into one
SELECT COALESCE(ar.Name, 'n/a') + ' - ' + t.Name AS Song
FROM Track AS t
	INNER JOIN Genre ON Genre.GenreId = t.GenreId
	LEFT JOIN Album AS al ON t.AlbumId = al.AlbumId
	LEFT JOIN Artist AS ar ON al.ArtistId = ar.ArtistId
WHERE Genre.Name = 'Rock';
-- it turns out every track does have an album & artist...
-- but if one didn't, we'd still want to have it in the results. thus, left joins.

-- if there might be a null, we have a few ways to deal with that.
-- '= NULL' is always false, even NULL = NULL is false.
-- we use "IS NULL" and "IS NOT NULL" to check.
-- COALESCE(thing-that-might-be-null, replacement-if-it-is-null) lets you handle the null case

-- self.join, foreign key into itself

-- 1. show all invoices of customers from brazil (mailing address not billing)
select * from Customer;
select * from Invoice;
-- only about invoices
select i.* from Customer c join invoice i on c.CustomerId = i.CustomerId where c.Country = 'Brazil';
-- 35

-- 2. show all invoices together with the name of the sales agent of each one
select * from Employee;
select * from Invoice;

select i.*, e.FirstName,e.LastName
from invoice i
left join Customer c on i.customerId = c.customerId
left join Employee e on c.supportRepId = e.employeeId
-- 412, same as the invoice table


-- 3. show all playlists ordered by the total number of tracks they have
select * from Playlist;
select * from PlaylistTrack; -- join table/junction table

select p.*, count(*) as trackNumber
from playlist P
left join PlaylistTrack pt on p.playlistid = pt.playlistid
group by p.playlistid, p.name order by trackNumber desc;
-- 18 entries, top 3 desc
-- ID  Name    trackNumber
-- 1   Music     3290
-- 8   Musci     3290
-- 5  90's Music 1477

-- 4. which sales agent made the most in sales in 2009?
select * from invoice;
select * from invoiceLine;
SELECT * from Employee;


select top(1) e.EmployeeId, e.FirstName, e.LastName, sum(i.total) TotalSales
from employee e 
join customer c on e.employeeId = c.supportRepId
join invoice i on c.customerId = i.customerId
group by e.employeeId,e.firstname,e.lastname order by TotalSales desc;
-- Id 3 Jane Peacock 833.04


-- 5. how many customers are assigned to each sales agent?
select * from customer

select e.Employeeid,e.FirstName,e.LastName, count(*) as NumberCustomer
from employee e
left join customer c on e.employeeId = c.supportRepId
where e.title = 'Sales Support Agent'
group by e.employeeId,e.firstname,e.lastname 
-- 3 Jane 21
-- 4 Margaret 20
-- 5 Steve 18


-- 6. which track was purchased the most since 2010?
-- track and invoiceitem
select* from track
select * from invoice;
select * from InvoiceLine;

select t.trackId ,t.name, Sum(it.quantity) as PurchaseNumber
from track t
join invoiceLine it on t.trackId = it.trackId
join invoice i on it.invoiceId = i.invoiceId
where YEAR(i.invoiceDate) >= 2010
group by t.trackId,t.Name order by PurchaseNumber desc;
-- 124 items all have 2, so top(1) isnt correct


-/*
select t.trackID,t.Name, count(*) as c
from track t 
left join InvoiceLine as l on t.TrackId = l.TrackId
inner join Invoice i on i.InvoiceId = l.InvoiceId
where year(i.InvoiceDate) >= 2010
group by t.TrackId,t.Name 
order by c desc;
*/-

-- 7. show the top three best-selling artists.
-- artist, album,track,invoiceline
select top(3) a.artistid,a.name, sum(il.quantity) TotalSales
from artist a
join album b on a.artistid =b.artistid
join track t on b.albumid =t.albumid
join invoiceline il on t.trackid = il.trackId
group by a.artistid,a.name order by TotalSales desc
-- 90 Iron Maiden 140
-- 150 U2 107
-- 50 Metallica 91

-- 8. which customers have the same initials as at least one other customer?
select SUBSTRING(FirstName,1,1) + SUBSTRING(LastName,1,1) from customer
INTERSECT
select SUBSTRING(FirstName,1,1) + SUBSTRING(LastName,1,1) from customer
-- 54 entries using substring intersect substring, change employee to customer in the solution provided
-- suing subquery one of those =1,>1, >=1, two copies of the same table problem

-----------------------

-- 1. show all invoices of customers from brazil (mailing address not billing)
-- 35

-- 2. show all invoices together with the name of the sales agent of each one
-- 412, same as the invoice table, literally just added names 

-- 3. show all playlists ordered by the total number of tracks they have
-- 18 entries, top 3 desc
-- ID  Name    trackNumber
-- 1   Music     3290
-- 8   Musci     3290
-- 5  90's Music 1477

-- 4. which sales agent made the most in sales in 2009?
-- Id 3 Jane Peacock 833.04

-- 5. how many customers are assigned to each sales agent?
-- ID3 Jane 21
-- ID4 Margaret 20
-- ID5 Steve 18

-- 6. which track was purchased the most since 2010?
-- not sure about this one
-- 124 items all have 2, so top(1) isnt correct

-- 7. show the top three best-selling artists.
-- ArtID 90 Iron Maiden 140
-- ArtID 150  U2        107
-- ArtID 50  Metallica  91

-- 8. which customers have the same initials as at least one other customer?
-- 54 entries using substring intersect substring, change employee to customer in the solution provided
-- using subquery one of those =1,>1, >=1, two copies of the same table problem