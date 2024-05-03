use NorthWind;

select * from Products
select * from Categories

select CategoryId from Categories where CategoryName = 'Confections'

--All the products from 'Confections'
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')

select * from Suppliers
--select product names from the supplier Tokyo Traders
select ProductName from Products where SupplierID=(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')

select * from Products where CategoryID in (Select CategoryID from Categories where Description like '%ea%')

select * from products where CategoryID in
(select CategoryID from Categories where Description like '%ea%')
and SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')

select * from Products
--select the product id and the quantity ordered by customrs from France
select * from sys.tables;
select * from Customers
select * from Orders;
select ProductID, Quantity from [Order Details] where OrderID in 
(select OrderID from Orders where CustomerID in 
(select CustomerID from Customers where Country = 'France'))





--Get the products that are priced above the average price of all the products
select * from Products where UnitPrice>(Select avg(UnitPrice) from Products)

--Select the lastet order by every employee
select * from orders o1
where orderdate = 
(select max(orderdate) from orders o2
where o2.EmployeeID = o1.employeeid)
order by o1.EmployeeID

--Select the maximum priced product in every category
Select * from products
Select * from products p1 where p1.UnitPrice = (select max(UnitPrice) from products p2 where p2.CategoryId = p1.CategoryId)
---Another way using joins
Select * from products p1 join (select categoryId, max(UnitPrice) as MaxPrice from products group by categoryId) p2 
on p1.CategoryID = p2.CategoryId where p1.UnitPrice = p2.MaxPrice;
---
select * from orders
--select the order number for the maximum fright paid by every customer
select * from orders o1 where o1.Freight = (select max(Freight) from orders o2 where o2.CustomerId = o1.CustomerId)


select * from Categories
---inner join
--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID

select * from Products
--Get the Supplier company name, contact person name, Product name and the stock ordered
select CompanyName, ContactName, ProductName, UnitsOnOrder from Suppliers join Products on Suppliers.SupplierID = Products.SupplierId;

 --Print the order id, customername and the fright cost for all teh orders
 select * from customers
 select * from orders

 Select OrderId, ContactName, Freight from orders join customers on orders.CustomerId = Customers.CustomerID;


--product name, quantity sold, Discount Price, Order Id, Fright for all orders
 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join [Order Details] od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID

 --select customer name, product name, quantity sold and the frieght, 
 --total price(unitpice*quantity+freight)
 select * from [Order Details]
 select * from orders
 select * from Products
 select * from customers
select c.ContactName, p.ProductName, od.Quantity, o.Freight , ((p.UnitPrice * od.Quantity) + Freight) as 'Total Price' from
Customers c join orders o on c.customerId = o.CustomerId 
join [Order Details] od on o.OrderId = od.OrderId
join Products p on p.ProductId = od.ProductId;

 --Print the product name and the total quantity sold
   select productName,sum(quantity) "Total quantity sold"
 from products p join [Order Details] od
 on p.ProductID = od.ProductID
 group by ProductName
 order by 2 desc

 ---customer name and number of products bought for every order
 select * from [Order Details]
 select * from orders
 select * from Products
 select * from customers
 select * from Employees

 select c.ContactName, sum(od.Quantity) from Customers c join Orders o on c.CustomerId = o.CustomerId
 join [Order Details] od on od.OrderId = o.OrderId 
 group by c.ContactName, od.OrderId;



 ---employee name, Customer name, product name, Total price of the product
 select e.LastName, c.ContactName, p.ProductName, (od.Quantity * p.UnitPrice) 'Total Price' from
 Employees e join Orders o on e.EmployeeID = o.EmployeeID 
 join Customers c on c.CustomerId = o.CustomerId 
 join [Order Details] od on od.OrderId = o.OrderId
 join Products p on p.ProductId = od.ProductId


