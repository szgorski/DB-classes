-- UPDATE NO. 3

USE [TaskNo2]
GO

SET TRANSACTION
ISOLATION LEVEL READ COMMITTED

BEGIN TRANSACTION

DECLARE @ID INT
DECLARE @CURRENT_DATE DATETIME
SET @CURRENT_DATE = GETDATE()

INSERT INTO [TRANSPORTS]([SOURCE_ID], [TARGET_ID], [CUSTOMER_ID], [PICKUP_TIME], [IS_DELAYED], [HAS_STARTED], [HAS_FINISHED])
VALUES (2, 4, 2, @CURRENT_DATE, 0, 0, 0)

SELECT @ID = T.TRANSPORT_ID
FROM [TRANSPORTS] T
WHERE SOURCE_ID = 2
AND TARGET_ID = 4
AND CUSTOMER_ID = 2
AND PICKUP_TIME = @CURRENT_DATE

INSERT INTO [dbo].[TRS-PRO]([TRANSPORT_ID], [PRODUCT_ID], [AMOUNT])
VALUES
(@ID, 1, 1),
(@ID, 3, 1),
(@ID, 4, 1)

INSERT INTO [dbo].[TRS-VEH]([TRANSPORT_ID], [VIN], [DRIVE_LAUNCH], [DRIVE_FINISH], [DISTANCE])
VALUES
(@ID, 'WAUFGAFC2EN138014', NULL, NULL, 0),
(@ID, '3GCEC14X06G175122', NULL, NULL, 0)

INSERT INTO [dbo].[TRS-EMP]([TRANSPORT_ID], [VIN], [EMPLOYEE_ID])
VALUES
(@ID, 'WAUFGAFC2EN138014', 4),
(@ID, '3GCEC14X06G175122', 5)

COMMIT