-- DMR (Daily Material Report) stored procedures
-- Adjust schema and types as needed for your database

IF OBJECT_ID('dbo.sp_DMR_GetById', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DMR_GetById;
GO
CREATE PROCEDURE dbo.sp_DMR_GetById
    @DmrId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT m.DmrId, m.POId, p.PONumber, m.VendorId, m.DeliveryDate, m.ApprovedBy, m.IsFinalized, m.FinalizedDate, m.Remarks
    FROM dbo.DMRMaster m
    LEFT JOIN dbo.PurchaseOrderMaster p ON m.POId = p.POId
    WHERE m.DmrId = @DmrId;
END
GO

IF OBJECT_ID('dbo.sp_DMR_GetAll', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DMR_GetAll;
GO
CREATE PROCEDURE dbo.sp_DMR_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT m.DmrId, m.POId, p.PONumber, m.VendorId, m.DeliveryDate, m.ApprovedBy, m.IsFinalized, m.FinalizedDate, m.Remarks
    FROM dbo.DMRMaster m
    LEFT JOIN dbo.PurchaseOrderMaster p ON m.POId = p.POId
    ORDER BY m.DeliveryDate DESC, m.DmrId DESC;
END
GO

IF OBJECT_ID('dbo.sp_DMR_Add', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DMR_Add;
GO
CREATE PROCEDURE dbo.sp_DMR_Add
    @POId INT = NULL,
    @VendorId INT,
    @DeliveryDate DATETIME,
    @ApprovedBy NVARCHAR(200),
    @IsFinalized BIT,
    @FinalizedDate DATETIME = NULL,
    @Remarks NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.DMRMaster (POId, VendorId, DeliveryDate, ApprovedBy, IsFinalized, FinalizedDate, Remarks)
    VALUES (@POId, @VendorId, @DeliveryDate, @ApprovedBy, @IsFinalized, @FinalizedDate, @Remarks);
    SELECT SCOPE_IDENTITY() AS NewId;
END
GO

IF OBJECT_ID('dbo.sp_DMR_Update', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DMR_Update;
GO
CREATE PROCEDURE dbo.sp_DMR_Update
    @DmrId INT,
    @POId INT = NULL,
    @VendorId INT,
    @DeliveryDate DATETIME,
    @ApprovedBy NVARCHAR(200),
    @IsFinalized BIT,
    @FinalizedDate DATETIME = NULL,
    @Remarks NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.DMRMaster
    SET POId = @POId,
        VendorId = @VendorId,
        DeliveryDate = @DeliveryDate,
        ApprovedBy = @ApprovedBy,
        IsFinalized = @IsFinalized,
        FinalizedDate = @FinalizedDate,
        Remarks = @Remarks
    WHERE DmrId = @DmrId;
END
GO

IF OBJECT_ID('dbo.sp_DMR_Delete', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DMR_Delete;
GO
CREATE PROCEDURE dbo.sp_DMR_Delete
    @DmrId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.DMRDetail WHERE DmrId = @DmrId;
    DELETE FROM dbo.DMRMaster WHERE DmrId = @DmrId;
END
GO

-- DMR Detail procedures
IF OBJECT_ID('dbo.sp_DMRDetail_GetById', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DMRDetail_GetById;
GO
CREATE PROCEDURE dbo.sp_DMRDetail_GetById
    @DmrDetailId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DmrDetailId, DmrId, ProductId, Quantity, Status
    FROM dbo.DMRDetail
    WHERE DmrDetailId = @DmrDetailId;
END
GO

IF OBJECT_ID('dbo.sp_DMRDetail_GetByDmrId', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DMRDetail_GetByDmrId;
GO
CREATE PROCEDURE dbo.sp_DMRDetail_GetByDmrId
    @DmrId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DmrDetailId, DmrId, ProductId, Quantity, Status
    FROM dbo.DMRDetail
    WHERE DmrId = @DmrId
    ORDER BY DmrDetailId;
END
GO

IF OBJECT_ID('dbo.sp_DMRDetail_Add', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DMRDetail_Add;
GO
CREATE PROCEDURE dbo.sp_DMRDetail_Add
    @DmrId INT,
    @ProductId INT,
    @Quantity INT,
    @Status NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.DMRDetail (DmrId, ProductId, Quantity, Status)
    VALUES (@DmrId, @ProductId, @Quantity, @Status);
    SELECT SCOPE_IDENTITY() AS NewId;
END
GO

IF OBJECT_ID('dbo.sp_DMRDetail_Update', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DMRDetail_Update;
GO
CREATE PROCEDURE dbo.sp_DMRDetail_Update
    @DmrDetailId INT,
    @DmrId INT,
    @ProductId INT,
    @Quantity INT,
    @Status NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.DMRDetail
    SET DmrId = @DmrId,
        ProductId = @ProductId,
        Quantity = @Quantity,
        Status = @Status
    WHERE DmrDetailId = @DmrDetailId;
END
GO

IF OBJECT_ID('dbo.sp_DMRDetail_Delete', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DMRDetail_Delete;
GO
CREATE PROCEDURE dbo.sp_DMRDetail_Delete
    @DmrDetailId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.DMRDetail WHERE DmrDetailId = @DmrDetailId;
END
GO
