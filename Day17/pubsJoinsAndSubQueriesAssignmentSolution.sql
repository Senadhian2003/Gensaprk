use pubs

select * from sys.tables;


---1) Print the storeid and number of orders for the store
select stor_id, count(stor_id) 'Number of orders' from sales group by stor_Id;

---2) print the numebr of orders for every title
select t.title, count(s.title_id) 'Number of Orders' from titles t join sales s on t.title_id = s.title_id group by s.title_id, t.title;


---3) print the publisher name and book name
select t.title, p.pub_name from titles t join publishers p on t.pub_id=p.pub_id;

---4) Print the author full name for al the authors
select CONCAT(au_fname,' ',au_lname)'Author Name' from authors

---5) Print the price or every book with tax (price+price*12.36/100)
select title, price+(price * 0.1236) 'Price with tax' from titles;

---6) Print the author name, title name
select CONCAT(a.au_fname,' ',a.au_lname)'Author Name', t.title from titleauthor ta join authors a on ta.au_id = a.au_id 
join titles t on ta.title_id=t.title_id;

---7) print the author name, title name and the publisher name
select CONCAT(a.au_fname,' ',a.au_lname)'Author Name', t.title, p.pub_name 
from titleauthor ta join authors a on ta.au_id = a.au_id
join titles t on ta.title_id=t.title_id 
join publishers p on p.pub_id=t.pub_id;

--- 8) Print the average price of books pulished by every publicher
select p.pub_name, avg(t.price) 'Average price' from titles t join publishers p on t.pub_id=p.pub_id group by t.pub_id,p.pub_name;


--- 9) print the books published by 'Marjorie'
select t.title from titleauthor ta join authors a on ta.au_id = a.au_id 
join titles t on ta.title_id = t.title_id where a.au_id=(select au_id from authors where au_fname='Marjorie')

---10) Print the order numbers of books published by 'New Moon Books'
select s.ord_num from sales s join titles t on s.title_id = t.title_id 
where t.pub_id = (select pub_id from publishers where pub_name='New Moon Books')

--- 11) Print the number of orders for every publisher
select p.pub_name, count(s.title_id) 'No of orders' from sales s join titles t on s.title_id = t.title_id 
join publishers p on p.pub_id = t.pub_id group by p.pub_name;

---12) print the order number , book name, quantity, price and the total price for all orders
select s.ord_num, t.title, s.qty 'Quantity', t.price 'Price per book', (s.qty * t.price) 'Total Price' from 
sales s join titles t on s.title_id = t.title_id;

---13) print he total order quantity fro every book
select t.title,sum(s.qty)'Order Quantity' from sales s join titles t on s.title_id = t.title_id group by t.title;

---14) print the total ordervalue for every book
select t.title, sum(s.qty*t.price)'Order value' from sales s join titles t on s.title_id = t.title_id group by title;

---15) print the orders that are for the books published by the publisher for which 'Paolo' works for
select s.ord_num, t.title  from sales s join titles t on s.title_id = t.title_id 
where t.pub_id=(select pub_id from employee where fname = 'Paolo') 




