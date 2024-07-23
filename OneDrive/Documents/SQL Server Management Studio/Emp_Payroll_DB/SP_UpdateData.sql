--Update Employee Data using Id

CREATE PROC UpdateData
(
@Id INT,
@Name VARCHAR(50),
@State VARCHAR(50),
@City VARCHAR(50),
@Salary DECIMAL(10,2)
)
AS
BEGIN
	UPDATE Employee SET Name=@Name,State=@State,City=@City,Salary=@Salary WHERE ID=@Id;
END
