--Creating Stored Procedure To Get All the Data Present in Employee Table

CREATE PROC GetData
AS
BEGIN
	SELECT * FROM Employee;
END