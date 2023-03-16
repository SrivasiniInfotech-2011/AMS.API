-- =============================================  
-- Author:  Srivatsan Seshadri  
-- Create date: 26-10-2021  
-- Description: Creates an House Record  
-- =============================================  
CREATE  PROCEDURE [dbo].[AMB_SP_UPSERT_HOUSE_DETAILS]  
 @Mode					as int, -- 1-Add,2-Modify,  
 @House_ID				as int = null, 
 @Block_Id				as	int, 
 @Apartment_Id			as	int,  
 @House_Number			as varchar(500), 
 @House_IsActive		as bit = null,  

 @User_Id           as int,  
 @Output_House_Id   as int OUT  
AS  
BEGIN  
  If(@Mode = 1) --INSERT.  
  Begin  
    Insert into [dbo].[AMB_HOUSE_DETAILS](  
       
     Block_ID,
     Apartment_ID,
	 House_Number,
	 House_IsActive,
	 House_Created_By  
    )  
    values(
	 @Block_Id,
	 @Apartment_Id,
     @House_Number,  
     @House_IsActive,  
     @User_Id  
    )  
  
   Set @Output_House_Id = @@IDENTITY;  
  
  End  
  Else if(@Mode = 2) --MODIFY.  
  Begin  
  
    Update  [dbo].[AMB_HOUSE_DETAILS]  
       Set
	   Block_ID		    =	@Block_Id,
	   Apartment_ID	    =	@Apartment_Id,
	   House_Number	    =	@House_Number, 
       House_IsActive    =	@House_IsActive,  
      House_Modified_By =   @User_Id  
     Where  House_Id    =   @House_ID  
  
    Set @Output_House_Id = @House_ID  
     
  End  
END