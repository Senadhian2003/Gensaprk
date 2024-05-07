use Northwind

select * from Categories

select * from Suppliers

select CategoryID,  categoryname from Categories
union
select SupplierId,CompanyName from Suppliers

select * from [Order Details]

select * from Orders where ShipCountry='Spain'
union
select * from orders where Freight>50

select * from Orders where ShipCountry='Spain'
union all
select * from orders where Freight>50


select * from Orders where ShipCountry='Spain'
intersect
select * from orders where Freight>50


--get the order id, productname and quantitysold of products that have price
--greater than 15
select * from products
select od.OrderId, p.ProductName, od.Quantity from [Order Details] od join Products p on od.ProductID = p.ProductID
where p.UnitPrice>15;

--get the order id, productname and quantitysold of products that are from category 'dairy'
--and within the price range of 10 to 20
select od.OrderID, p.ProductName, od.Quantity from [Order Details] od join Products p on od.ProductID = p.ProductID 
join Categories c on p.CategoryID = c.CategoryID where c.CategoryName like '%dairy%';


select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%'
order by p.unitprice desc


with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

select top 10 * from  OrderDetails_CTE order by price desc


create view vwOrderDetails
as
(select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')


select * from vwOrderDetails order by UnitPrice

--Get the first 10 records of

--The order ID, Customer name and the product name for products that are purchaced by 
--people from USA
--The order ID, Customer name and the product name for products that are ordered by people from france 
--with fright less than 20
select * from customers;

with OrderDetailsCTE(OrderId,CustomerName,ProductName)
as
(select o.OrderID, c.ContactName, p.ProductName from Orders o join Customers c on o.CustomerID = c.CustomerID join [Order Details] od on o.OrderID = od.OrderID
join Products p on od.ProductID=p.ProductID where c.Country='USA'
union
select o.OrderID, c.ContactName, p.ProductName from Orders o join Customers c on o.CustomerID = c.CustomerID join [Order Details] od on o.OrderID = od.OrderID
join Products p on od.ProductID=p.ProductID where c.Country='france' and o.Freight<20)

select top 10 * from OrderDetailsCTE;



