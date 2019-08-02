Use UserOrders;


DECLARE @i int;
SET @i = 0
DECLARE @dat Date;
SET @dat=GETDATE()
WHILE @i < 100
BEGIN
INSERT INTO Users
VALUES(CONCAT('ÔÈÎ',@i),dateadd(day,-10000+@i,@dat), RAND()*100)
SET @i=@i+1
end

GO

DECLARE @i int;
SET @i=0
DECLARE @dat Date;
SET @dat=GETDATE()
DECLARE @j int;
SET @j=0
WHILE @i<100
BEGIN 
INSERT INTO Orders
VALUES ((SELECT MIN(ID) FROM Users)+@i,
CONCAT('Description',Rand()*@i),
dateadd(day,-@j,@dat),
Rand()*100)
SET @j=@j+1
IF @j=15 SET @i=@i+1
IF @j=15 SET @j=0

end

GO