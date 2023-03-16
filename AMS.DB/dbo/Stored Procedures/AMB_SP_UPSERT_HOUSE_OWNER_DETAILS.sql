-- =============================================
-- Author:		Srivatsan Seshadri
-- Create date: 19-02-2022
-- Description:	Creates an House Owner Record
-- =============================================
CREATE PROCEDURE [dbo].[AMB_SP_UPSERT_HOUSE_OWNER_DETAILS]
	@Mode							as int, -- 1-Add,2-Modify,
	@House_Owner_ID					as int	=	null,
	@House_Owner_Name				as varchar(200),
	@House_Owner_ID_Proof           as varchar(100),
	@House_Owner_Address			as varchar(300),
	@House_Owner_Email				as varchar(200),
	@House_Owner_Mobile				as varchar(14),
	@House_Owner_House_ID			as int,
	@House_Owner_IsActive			as bit	= null,
	@Block_ID						as int,
	@Apartment_ID					as int,
	
	@User_Id						as	int,
	@Output_House_Owner_Id			as	int	OUT
AS
BEGIN
		If(@Mode = 1)	--INSERT.
		Begin
				Insert into [dbo].[AMB_HOUSE_OWNER_DETAILS](
					House_Owner_Name,
					House_Owner_ID_Proof,
					House_Owner_Address,
					House_Owner_Email,
					House_Owner_Mobile,
					House_Owner_House_ID,
					House_Owner_IsActive,
					Block_ID,
					Apartment_ID,
					House_Owner_Created_By
				)
				values(
					@House_Owner_Name,
					@House_Owner_ID_Proof,
					@House_Owner_Address,
					@House_Owner_Email,
					@House_Owner_Mobile,
					@House_Owner_House_ID,
					@House_Owner_IsActive,
					@Block_ID,
					@Apartment_ID,
					
					@User_Id
				)

			Set @Output_House_Owner_Id = @@IDENTITY;

		End
		Else if(@Mode = 2)	--MODIFY.
		Begin

				Update  [dbo].[AMB_HOUSE_OWNER_DETAILS]
				   Set 
					House_Owner_Name      = @House_Owner_Name,
					House_Owner_ID_Proof  = @House_Owner_ID_Proof,
					House_Owner_Address   = @House_Owner_Address,
					House_Owner_Email     = @House_Owner_Email,
					House_Owner_Mobile	  = @House_Owner_Mobile,
					House_Owner_House_Id  = @House_Owner_House_ID,
					House_Owner_IsActive  = @House_Owner_IsActive,
					Block_ID              = @Block_ID,
					Apartment_ID		  = @Apartment_ID,
					House_Owner_Modified_By		=	@User_Id
				 Where  House_Owner_ID						=	@House_Owner_ID

				Set @House_Owner_Id	=	@House_Owner_ID
			
		End
END