-- =============================================
-- Author:		Srivatsan Seshadri
-- Create date: 02-03-2022
-- Description:	Creates an Block Record
-- =============================================
CREATE PROCEDURE [dbo].[AMB_SP_UPSERT_BLOCK_DETAILS]
	@Mode							as int, -- 1-Add,2-Modify,
	@Block_ID						as int = null,
	@Apartment_ID					as int	=	null,
	@Block_Name					as	varchar(500),
	@Block_IsActive				as	bit	= null,
	@User_Id						as	int,
	@Output_Block_Id			as	int	OUT
AS
BEGIN
		If(@Mode = 1)	--INSERT.
		Begin
				Insert into [dbo].[AMB_BLOCK_DETAILS](
					Apartment_ID,
					Block_Name,
					Block_IsActive,
					Block_Created_By
				)
				values(
					@Apartment_ID,
					@Block_Name,
					@Block_IsActive,
					@User_Id
				)

			Set @Output_Block_Id = @@IDENTITY;

		End
		Else if(@Mode = 2)	--MODIFY.
		Begin

				Update  [dbo].[AMB_BLOCK_DETAILS]
				   Set  Apartment_ID				=	@Apartment_ID,
						Block_Name					=	@Block_Name,
						Block_IsActive				=	@Block_IsActive,
						Block_Modified_By			=	@User_Id
				 Where  Block_ID						=	@Block_ID

				Set @Output_Block_Id	=	@Block_ID
			
		End
END