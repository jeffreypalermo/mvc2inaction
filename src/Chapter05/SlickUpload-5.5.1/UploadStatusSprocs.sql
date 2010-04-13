CREATE PROCEDURE kw_InsertStatus
(
	@uploadId char(36),
	@uploadStatus varchar(MAX)
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO UploadStatus (UploadStatus, UploadId) VALUES (@uploadStatus,@uploadId);
END
GO

CREATE PROCEDURE kw_UpdateStatus
(
	@uploadId char(36),
	@uploadStatus varchar(MAX)
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE UploadStatus SET UploadStatus=@uploadStatus, LastUpdated=GETDATE() WHERE UploadId=@uploadId;
END
GO

CREATE PROCEDURE kw_GetStatus
(
	@uploadId char(36)
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT UploadStatus FROM UploadStatus WHERE UploadId=@uploadId;
END
GO

CREATE PROCEDURE kw_DeleteStatus
(
	@uploadId char(36)
)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM UploadStatus WHERE UploadId=@uploadId;
END
GO

CREATE PROCEDURE kw_DeleteStaleStatus
(
	@staleMinutes int
)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM UploadStatus WHERE DATEDIFF(n, LastUpdated, GETDATE()) > @staleMinutes;
END
GO