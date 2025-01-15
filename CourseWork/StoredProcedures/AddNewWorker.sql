CREATE PROCEDURE AddNewWorker
    @WorkerName NVARCHAR(30),
    @WorkRole NVARCHAR(10),
    @WorkerContactNumber NVARCHAR(10),
    @WorkShift NVARCHAR(11),
    @Salary INT
AS
BEGIN
    INSERT INTO Workers (WorkerName, WorkRole, WorkerContactNumber, WorkShift, Salary)
    VALUES (@WorkerName, @WorkRole, @WorkerContactNumber, @WorkShift, @Salary);
END;