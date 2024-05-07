use pubs
select * from sys.tables
select * from titles
select * from authors
select * from publishers
select * from sales
select * from employee	
select * from titleauthor
select * from jobs
select * from employee


---1) Create a stored procedure that will take the author firstname and print all the books polished 
---by him with the publisher's name

create procedure proc_PrintBooksWithAutherName(@aname varchar(20))
as
begin
select t.title, p.pub_name from titles t join publishers p on t.pub_id=p.pub_id join titleauthor ta on ta.title_id= t.title_id
join authors a on ta.au_id = a.au_id where a.au_fname=@aname;
end

execute proc_PrintBooksWithAutherName 'Johnson'


---2) Create a sp that will take the employee's firtname and print all the titles sold by him/her,
---price, quantity and the cost.

create proc proc_PrintBooksWithEmployeeFname(@ename varchar(20))
as
begin
select t.title, t.price, s.qty, (t.price * s.qty) 'Total Cost' from titles t join sales s on t.title_id = s.title_id
join employee e on e.pub_id = t.pub_id where e.fname=@ename
end

exec proc_PrintBooksWithEmployeeFname 'Pedro'

---3) Create a query that will print all names from authors and employees
select au_fname from authors 
union
select fname from employee

---4) Create a  query that will float the data from sales,titles, 
---publisher and authors table to print title name, Publisher's name, 
---author's full name with quantity ordered and price for the order for all orders,
---print first 5 orders after sorting them based on the price of order

select top 5 t.title, p.pub_name, CONCAT(a.au_fname, ' ', a.au_lname) 'Author Name', t.price, s.qty, (t.price*s.qty)'Total Cost' from sales s join titles t on s.title_id=t.title_id join publishers p on t.pub_id=p.pub_id
join titleauthor ta on t.title_id = ta.title_id join authors a on ta.au_id = a.au_id order by (t.price*s.qty) desc



