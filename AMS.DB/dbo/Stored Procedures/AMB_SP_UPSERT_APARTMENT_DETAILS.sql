-- =============================================
-- Author:		Srivatsan Seshadri
-- Create date: 30-09-2021
-- Description:	Creates an Apartment Record
-- =============================================
CREATE PROCEDURE [dbo].[AMB_SP_UPSERT_APARTMENT_DETAILS]
	@Mode							as int, -- 1-Add,2-Modify,
	@Apartment_ID					as int	=	null,
	@Apartment_Address				as	varchar(300),
	@Apartment_Construction_Date	as	datetime,
	@Apartment_IsActive				as	bit	= null,
	@Apartment_Name					as	varchar(300),
	@Apartment_RegistrationId		as	varchar(100),
	@User_Id						as	int,
	@Output_Apartment_Id			as	int	OUT
AS
BEGIN
		If(@Mode = 1)	--INSERT.
		Begin
				Insert into [dbo].[AMB_APARTMENT_DETAILS](
					Apartment_Address,
					Apartment_Construction_Date,
					Apartment_IsActive,
					Apartment_Name,
					Apartment_RegistrationId,
					Apartment_Created_By
				)
				values(
					@Apartment_Address,
					@Apartment_Construction_Date,
					@Apartment_IsActive,
					@Apartment_Name,
					@Apartment_RegistrationId,
					@User_Id
				)

			Set @Output_Apartment_Id = @@IDENTITY;

		End
		Else if(@Mode = 2)	--MODIFY.
		Begin

				Update  [dbo].[AMB_APARTMENT_DETAILS]
				   Set  Apartment_Address				=	@Apartment_Address,
						Apartment_Construction_Date		=	@Apartment_Construction_Date,
						Apartment_IsActive				=	@Apartment_IsActive,
						Apartment_Name					=	@Apartment_Name,
						Apartment_RegistrationId		=	@Apartment_RegistrationId,
						Apartment_Modified_By			=	@User_Id
				 Where  Apartment_ID						=	@Apartment_ID

				Set @Output_Apartment_Id	=	@Apartment_ID
			
		End
END