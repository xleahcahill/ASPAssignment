DECLARE @MinShowDate DATETIME;
DECLARE @DaysSinceMinShowDate INT;

SELECT @MinShowDate = Min(ShowDate) FROM ShowDetails;
SELECT @DaysSinceMinShowDate = DATEDIFF(d, @MinShowDate, GETDATE());

IF @DaysSinceMinShowDate > 0
	UPDATE ShowDetails
	SET ShowDate = DATEADD(d, @DaysSinceMinShowDate, ShowDate);
ELSE
	Print 'Nothing to Update'