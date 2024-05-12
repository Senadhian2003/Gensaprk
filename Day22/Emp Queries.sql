use dbEmployeeTrackerCF;

select * from Employees

select * from Requests

select * from Employees

sp_help Employees

SELECT 
    COLUMN_NAME
FROM 
    INFORMATION_SCHEMA.COLUMNS
WHERE 
    TABLE_NAME = 'RequestSolutions'
    AND IS_NULLABLE = 'NO';