use pubs;

select * from titles;

---Print all the titles names
select title from titles;

---Print all the titles that have been published by 1389
select title from titles where pub_id=1389;

---Print the books that have price in rangeof 10 to 15
select * from titles where price between 10 and 15;

---Print those books that have no price
select * from titles where price is NULL;

---Print the book names that strat with 'The'
select title from titles where title like 'The%'; 

---Print the book names that do not have 'v' in their name
select title from titles where title not like '%v%';

---print the books sorted by the royalty
select * from titles order by royalty;

---print the books sorted by publisher in descending then by types in asending then by price in descending
select * from titles order by pub_id desc, type, price desc;

---Print the average price of books in every type
select type, Avg(price) "Average Price" from titles group by type;

---print all the types in uniques
select Distinct(type) "Types" from titles;

---Print the first 2 costliest books
select top 2 * from titles order by price desc;

---Print books that are of type business and have price less than 20 which also have advance greater than 7000
select * from titles where type = 'business' and price <20 and advance>7000;

---Select those publisher id and number of books which have price between 15 to 25 and have 'It' in its name. Print only those which have count greater than 2. Also sort the result in ascending order of count
select pub_id, count(title) from titles where price between 15 and 25 and title like '%i%t%' group by pub_id having count(title)>2  order by count(title);

---Print the Authors who are from 'CA'
select * from authors where state='CA';

---Print the count of authors from every state
select state, count(au_id) from authors group by state;

