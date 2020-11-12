-- SQL comments
-- 1. list all customers (full names, customer ID, and country) who are not in the US
select * from customer where country != 'USA'; -- 46

-- 2. list all customers from brazil
select * from customer where country = 'Brazil'; -- 5

-- 3. list all sales agents
select * from Employee where Title = 'Sales Support Agent'; -- 3

-- 4. show a list of all countries in billing addresses on invoices.
select distinct BillingCountry from Invoice; -- 24 with distinct

-- 5. how many invoices were there in 2009, and what was the sales total for that year?
select count(*) as SalesCount ,sum(total) as SalesTotal from invoice where invoiceDate >= '2009' and InvoiceDate < '2010';
-- 83, 449.46

-- 6. how many line items were there for invoice #37?
-- line items not sure
select InvoiceId,count(*) as ItemNumbers
from InvoiceLine l
where l.InvoiceId= 37
group by InvoiceId
-- 4
-- whenever use count, must use group by

-- 7. how many invoices per country?
select * from invoice;

select i.BillingCountry, count(*)
from invoice i
group by i.BillingCountry
-- 24 enties, top 5 should be Argentina 7 Australia 7 Austria 7 Belgium 7 Brazil 35 ascending order if used


-- 8. show total sales per country, ordered by highest sales first.
select * from Invoice;

select BillingCountry,sum(Total) as TotalSales
from Invoice
group by BillingCountry order by TotalSales desc;
-- order by must have a variable to follow
-- 24 entries USA 523.06 Canada 303.96

