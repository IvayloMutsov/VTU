CREATE PROCEDURE DeleteClient
    @ClientID INT
AS
BEGIN
    DELETE FROM Clients
    WHERE ClientID = @ClientID;
END;