-- =============================================  
-- Author:  Srivatsan Seshadri  
-- Create date: 14-10-2021  
-- Description: Creates an Block Record  
-- =============================================  
CREATE  PROCEDURE [dbo].[AMB_SP_UPSERT_BLOCK_DETAILS]  
 @Mode					as int, -- 1-Add,2-Modify,  
 @Block_ID				as int = null,  
 @Block_Apartment_Id	as	int,  
 @Block_IsActive		as bit = null,  
 @Block_Name			as varchar(300),  
   
 @User_Id      as int,  
 @Output_Block_Id   as int OUT  
AS  
BEGIN  
  If(@Mode = 1) --INSERT.  
  Begin  
    Insert into [dbo].[AMB_BLOCK_DETAILS](  
       
     Block_IsActive,  
     Block_Name,  
     Apartment_ID,  
     Block_Created_By  
    )  
    values(  
       
     @Block_IsActive,  
     @Block_Name,  
     @Block_Apartment_Id,
     @User_Id  
    )  
  
   Set @Output_Block_Id = @@IDENTITY;  
  
  End  
  Else if(@Mode = 2) --MODIFY.  
  Begin  
  
    Update  [dbo].[AMB_BLOCK_DETAILS]  
       Set    
      Block_IsActive    =	@Block_IsActive,  
      Block_Name		=	@Block_Name,  
      Apartment_ID		=	@Block_Apartment_Id,
      Block_Modified_By   = @User_Id  
     Where  Block_ID      = @Block_ID  
  
    Set @Output_Block_Id = @Block_ID  
     
  End  
END