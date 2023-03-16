-- =============================================
-- Author:		Srivatsan Seshadri
-- Create date: 01-12-2021
-- Description:	Creates a User Record
-- =============================================
CREATE PROCEDURE [dbo].[AMB_SP_UPSERT_USER_DETAILS]
	@Mode							as int, -- 1-Add,2-Modify,
	@User_Id						as	int	=	NULL,
	@User_First_Name				as	varchar(200),
	@User_Last_Name					as	varchar(200),
	@User_User_Name					as	varchar(100),
	@User_Password					as	varchar(200),
	@User_Doj						as	datetime,
	@User_Dob						as	datetime,
	@User_CreatorOrModifier_Id				as	int,
	@Output_User_Id					as	int	OUT

AS
BEGIN
		If(@Mode = 1)	--INSERT.
		Begin
				Insert into [dbo].[AMB_USER_DETAILS]
				(
					User_First_Name,
					User_Last_Name,
					User_User_Name,
					User_Password,
					User_Doj,
					User_Dob,
					User_Created_By
				)
				values(
					@User_First_Name,
					@User_Last_Name,
					@User_User_Name,
					@User_Password,
					@User_Doj,
					@User_Dob,
					@User_CreatorOrModifier_Id
				)

			Set @Output_User_Id = @@IDENTITY;

		End
		Else if(@Mode = 2)	--MODIFY.
		Begin

				Update  [dbo].[AMB_USER_DETAILS]
				   Set  User_First_Name				=	@User_First_Name,
						User_Last_Name				=	@User_Last_Name,
						User_User_Name				=	@User_User_Name,
						User_Password				=	@User_Password,
						User_Doj					=	@User_Doj,
						User_Dob					=	@User_Dob,
						User_Modified_By			=	@User_CreatorOrModifier_Id
				 Where  [User_Id]					=	@User_Id

				Set @Output_User_Id	=	@User_Id
			
		End
END