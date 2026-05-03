-- Create DMRMaster and DMRDetail tables
-- Run this script in your database to create the tables used by the DMR stored procedures.

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DMRMaster' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.DMRMaster (
        DmrId INT IDENTITY(1,1) PRIMARY KEY,
        POId INT NULL,
        VendorId INT NOT NULL,
        DeliveryDate DATETIME NOT NULL,
        ApprovedBy NVARCHAR(200) NOT NULL,
        IsFinalized BIT NOT NULL DEFAULT 0,
        FinalizedDate DATETIME NULL,
        Remarks NVARCHAR(MAX) NULL,
        CONSTRAINT FK_DMRMaster_PO FOREIGN KEY (POId) REFERENCES dbo.PurchaseOrderMaster(POId)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DMRDetail' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.DMRDetail (
        DmrDetailId INT IDENTITY(1,1) PRIMARY KEY,
        DmrId INT NOT NULL,
        ProductId INT NOT NULL,
        Quantity INT NOT NULL,
        Status NVARCHAR(100) NULL,
        CONSTRAINT FK_DMRDetail_DMRMaster FOREIGN KEY (DmrId) REFERENCES dbo.DMRMaster(DmrId) ON DELETE CASCADE
    );
END
GO

-- Optional: create indexes for common queries
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DMRMaster_DeliveryDate' AND object_id = OBJECT_ID('dbo.DMRMaster'))
BEGIN
    CREATE INDEX IX_DMRMaster_DeliveryDate ON dbo.DMRMaster(DeliveryDate DESC);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DMRDetail_DmrId' AND object_id = OBJECT_ID('dbo.DMRDetail'))
BEGIN
    CREATE INDEX IX_DMRDetail_DmrId ON dbo.DMRDetail(DmrId);
END
GO
