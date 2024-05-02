use NorthWind;

Select * from Products;

select ProductName, QuantityPerUnit from Products

select ProductName Name_Of_Product, QuantityPerUnit as Quantity_Per_Unit from Products

select ProductName 'Name Of Product', QuantityPerUnit as Quantity_Per_Unit from Products

select * from products where UnitPrice>10

--Select all the products that are out of stock
select * from Products where UnitsInStock=0

--select the products that will no more be stocked
select * from products where Discontinued =1

--Select Products that will be in clearance
select * from products where Discontinued =1 and UnitsInStock>0


--select products that are in teh range of 10 to 30
select * from products where unitprice>10 and unitprice<30
select * from products where unitprice between 10 and 30
--(or)
select * from products where unitprice>=10 and unitprice<=30


select sum(UnitsInStock) "Stock of products in category 3"
from Products where CategoryID =3

--Avreage price of products supplied by supplier 2
select avg(UnitPrice) "Price of products in by supplier 2"
from Products where SupplierID =2

--Worth of products in order
select sum(UnitsInStock * ReorderLevel) as "Expected amount to be paid" from Products;

select * from Products;
select SupplierId, avg(UnitPrice * UnitsInStock) as "Average price" from Products group by SupplierID;

select categoryId , sum(UnitsInStock) "Units in stock" from Products group by CategoryID having sum(UnitsInStock)>10 order by sum(UnitPrice);

select ProductName, UnitPrice from Products where Discontinued = 1 order by UnitsInStock;


Select * from Customers

--Rank the customer based on the country name in ascending order
Select ContactName , RANK() over (order by Country desc) "Country Rank" from Customers;
