--GEtting Record Based on ID
ALTER PROC GetById
(
@Id INT
)
AS
BEGIN
	SELECT * FROM Employee WHERE ID=@Id;
END