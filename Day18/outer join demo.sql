use NorthWind

select * from orders

select ContactName,ShipName,ShipAddress
from customers c join orders o
on c.CustomerID = o.CustomerID

select ContactName,ShipName,ShipAddress
from customers c left outer join orders o
on c.CustomerID = o.CustomerID

select * from products where ProductID not in (select distinct ProductID from [Order Details])

select p.ProductName, od.Quantity from Products p left outer join [Order Details] od on p.ProductID = od.ProductID;
