-- =============================================  
-- Author:  Srivatsan Seshadri  
-- Create date: 15-02-2022 
-- Description: Creates an Tenant Detail  
-- =============================================  
CREATE  PROCEDURE [dbo].[AMB_SP_UPSERT_TENANT_DETAILS]  
 @Mode					as int, -- 1-Add,2-Modify,
 @Tenant_ID				as int = null,
 @Tenant_Name			as varchar(200),
 @Tenant_IsActive		as bit = null,
 @Tenant_ID_Proof		as varchar(100),
 @Tenant_House_ID		as int = null,
 @Block_ID				as int = null,
 @Apartment_ID			as int =null,
 @User_Id      as int,  
 @Output_Tenant_Id   as int OUT  
AS  
BEGIN  
  If(@Mode = 1) --INSERT.  
  Begin  
    Insert into [dbo].[AMB_TENANT_DETAILS](  
    
	 Tenant_Name, 
     Tenant_IsActive,  
	 Tenant_ID_Proof,
	 Tenant_House_ID,
	 Block_ID,
     Apartment_ID,  
     Tenant_Created_By  
    )  
    values( 
	
     @Tenant_Name, 
     @Tenant_IsActive,
	 @Tenant_ID_Proof,
	 @Tenant_House_ID,
	 @Block_ID,
     @Apartment_ID,
     @User_Id  
    )  
  
   Set @Output_Tenant_Id = @@IDENTITY;  
  
  End  
  Else if(@Mode = 2) --MODIFY.  
  Begin  
  
    Update  [dbo].[AMB_TENANT_DETAILS]  
       Set
	  Tenant_Name		=	@Tenant_Name, 
	  Tenant_IsActive    =	@Tenant_IsActive,
	  Tenant_ID_Proof   =   @Tenant_ID_Proof,
	  Tenant_House_ID   =   @Tenant_House_ID,
	  Block_ID          =   @Block_ID,
      Apartment_ID		=	@Apartment_ID,
      Tenant_Modified_By  = @User_Id  
     Where  Tenant_ID      = @Tenant_ID  
  
    Set @Output_Tenant_Id = @Tenant_ID  
     
  End  
END