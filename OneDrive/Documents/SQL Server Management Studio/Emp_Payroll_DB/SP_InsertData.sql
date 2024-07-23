--Creating Stored Procedure To insert Data into Employee Table

CREATE PROC InsertData
(

@Name VARCHAR(50),
@State VARCHAR(50),
@City VARCHAR(50),
@Salary DECIMAL(10,2)
)
AS
BEGIN
	INSERT INTO Employee(Name,State,City,Salary)
	VALUES(@Name,@State,@City,@Salary);
END