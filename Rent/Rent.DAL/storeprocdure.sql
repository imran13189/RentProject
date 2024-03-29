USE [BuildersAlliances]
GO
/****** Object:  StoredProcedure [dbo].[GetManufacturer]    Script Date: 17-01-2019 00:41:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[GetManufacturer] --0,10,'desc','ManufacturerName'
(
@offset int ,
@limit int,
@order varchar(10)=null,
@sort varchar(100)=null,
@Manufacturer varchar(100)=null,
@Contact varchar(100)=null,
@Address varchar(100)=null,
@Email varchar(100)=null,
@Website varchar(100)=null

)
as
begin


;WITH CTE AS (
    SELECT * TotalRows = COUNT(*) OVER()
    FROM dbo.Manufacturer 
	where ManufacturerName like case when @Manufacturer is null then ManufacturerName else '%'+@Manufacturer+'%' end
	and [Address] like case when @Address is null then [Address] else '%'+@Address+'%' end
	and EmailId like case when @Email is null then EmailId else '%'+@Email+'%' end
and ContactNumber like case when @Contact is null then ContactNumber else '%'+@Contact+'%' end
and ISNULL(WebSiteUrl,'') like case when @Website is null then ISNULL(WebSiteUrl,'') else '%'+@Website+'%' end
and IsDeleted=0  
)

SELECT 
    CTE.*,
    tCountOrders.CountOrders AS TotalRows
FROM CTE
    CROSS JOIN (SELECT Count(*) AS CountOrders FROM CTE) AS tCountOrders
ORDER BY 
		case when @sort='ManufacturerName' and @order ='asc' then ManufacturerName end ASC,
		case when @sort='ManufacturerName' and @order ='desc'then ManufacturerName end DESC,
		case when @sort='ManufacturerId' and @order ='asc' then ManufacturerName end ASC,
		case when @sort='ManufacturerId' and @order ='desc'then ManufacturerName end DESC,
		case when @sort='EmailId' and @order ='asc'then EmailId end ASC,
		case when @sort='EmailId' and @order ='desc'then EmailId end DESC

OFFSET @offset ROWS
FETCH NEXT @limit ROWS ONLY;


end
