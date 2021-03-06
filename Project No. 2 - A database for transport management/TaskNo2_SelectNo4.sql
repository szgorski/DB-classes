-- QUERY NO. 4 (IGNORES CLIENTS WITHOUT ORDERS, AS ONE CANNOT SELECT A DELIVERY FOR THEM)

USE [TaskNo2]
GO

SELECT C.CUSTOMER_NAME, COUNT(DISTINCT TE.EMPLOYEE_ID) AS MAX_OF_DRIVERS
FROM [CUSTOMERS] C
JOIN [TRANSPORTS] T ON T.CUSTOMER_ID = C.CUSTOMER_ID
JOIN [TRS-VEH] TV ON TV.TRANSPORT_ID = T.TRANSPORT_ID
JOIN [TRS-EMP] TE ON TE.TRANSPORT_ID = TV.TRANSPORT_ID AND TE.VIN = TV.VIN
WHERE T.TRANSPORT_ID IN (
	SELECT TOP 1 TT.TRANSPORT_ID
	FROM [TRANSPORTS] TT
	JOIN [CUSTOMERS] CC ON CC.CUSTOMER_ID = TT.CUSTOMER_ID
	JOIN [TRS-VEH] TVV ON TVV.TRANSPORT_ID = TT.TRANSPORT_ID
	JOIN [TRS-EMP] TEE ON TEE.TRANSPORT_ID = TVV.TRANSPORT_ID AND TEE.VIN = TVV.VIN
	WHERE C.CUSTOMER_ID = CC.CUSTOMER_ID
	GROUP BY TT.TRANSPORT_ID, CC.CUSTOMER_ID, CC.CUSTOMER_NAME
	ORDER BY COUNT(DISTINCT TEE.EMPLOYEE_ID) DESC
)
GROUP BY T.TRANSPORT_ID, C.CUSTOMER_ID, C.CUSTOMER_NAME
ORDER BY C.CUSTOMER_ID ASC