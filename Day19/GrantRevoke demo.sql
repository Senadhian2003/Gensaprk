use dbEmployeeTracker;

---Login as system user
select * from sys.tables

select * from Areas


SELECT SYSTEM_USER;

CREATE LOGIN Spiderman WITH PASSWORD = 'Spider@2024';  

CREATE USER Spiderman FOR LOGIN Spiderman;  

GRANT INSERT ON Areas TO [Spiderman];

--- Login as Spiderman

select * from Areas