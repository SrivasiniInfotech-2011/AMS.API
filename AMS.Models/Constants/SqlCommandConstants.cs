namespace AMS.Models.Constants
{
    public class SqlCommandConstants
    {
        public const string DEACTIVATE_APARTMENT = @"Update [dbo].[AMB_APARTMENT_DETAILS] Set Apartment_IsActive = 0 Where Apartment_ID = @ApartmentId";
        public const string GET_ALL_APARTMENTS = @"select   Apartment_ID                 as  Id,
		                                                Apartment_Address                as  ApartmentAddress,
		                                                Apartment_Construction_Date      as  ConstructionDate,
		                                                Apartment_IsActive               as  IsActive,
		                                                Apartment_Name                   as  ApartmentName,
		                                                Apartment_RegistrationId         as  RegistrationId
                                                 from  [dbo].[AMB_APARTMENT_DETAILS]";

        public const string GET_APARTMENTS = @"select   Apartment_ID                     as  Id,
		                                                Apartment_Address                as  ApartmentAddress,
		                                                Apartment_Construction_Date      as  ConstructionDate,
		                                                Apartment_IsActive               as  IsActive,
		                                                Apartment_Name                   as  ApartmentName,
		                                                Apartment_RegistrationId         as  RegistrationId
                                                 from  [dbo].[AMB_APARTMENT_DETAILS]
                                                Where Apartment_ID = ISNULL(@ApartmentId,Apartment_ID)";

        public const string AMB_SP_UPSERT_APARTMENT_DETAILS = @"AMB_SP_UPSERT_APARTMENT_DETAILS";

        public const string DEACTIVATE_BLOCK = @"Update [dbo].[AMB_BLOCK_DETAILS] Set Block_IsActive = 0 Where Block_ID = @BlockId";
        public const string GET_ALL_BLOCKS = @"select   Block_ID                    as  Id,
                                                        Apartment_ID                as  ApartmentId,
		                                                Block_Name                  as  BlockName
                                                 from  [dbo].[AMB_BLOCK_DETAILS]";

        public const string GET_BLOCKS = @"select   Block_ID                     as  Id,
                                                    Apartment_ID                 as  ApartmentId,
                                                    Block_Name                   as  BlockName
                                                    from  [dbo].[AMB_BLOCK_DETAILS]
                                                Where Block_ID = ISNULL(@BlockId,Block_ID) ";

        public const string AMB_SP_UPSERT_BLOCK_DETAILS = @"AMB_SP_UPSERT_BLOCK_DETAILS";

        public const string DEACTIVATE_TENANT = @"Update [dbo].[AMB_TENANT_DETAILS] Set Tenant_IsActive = 0 Where Tenant_ID = @TenantId";
        public const string GET_ALL_TENANTS = @"select  tnt.Tenant_ID                as  TenantId,
		                                                tnt.Tenant_Name              as  TenantName,
		                                                tnt.Tenant_Id_Proof          as  TenantIdProof,
		                                                Tenant_House_ID				 as  HouseId,
		                                                hs.House_Number				 as  HouseNumber,
		                                                blk.Block_ID				 as  BlockId,
		                                                blk.Block_Name				 as  BlockName,
		                                                apmnt.Apartment_ID			 as  ApartmentId,
		                                                apmnt.Apartment_Name		 as  ApartmentName,
		                                                tnt.Tenant_IsActive			 as  IsActive
	                                                from  [dbo].[AMB_TENANT_DETAILS] tnt
		                                                inner join [dbo].[AMB_APARTMENT_DETAILS]	apmnt		on apmnt.Apartment_ID	=	tnt.Apartment_ID
		                                                inner join [dbo].[AMB_BLOCK_DETAILS]		blk			on blk.Block_ID			=	tnt.Block_ID
		                                                inner join [dbo].[AMB_HOUSE_DETAILS]		hs			on hs.House_Id			=	tnt.Tenant_House_ID";

        public const string GET_TENANTS = @"select  Tenant_ID               as  TenantId,
		                                            Tenant_Name             as  TenantName,
                                                    Tenant_Id_Proof         as  TenantIdProof,
                                                    Tenant_House_ID         as  HouseId,
                                                    Block_ID                as  BlockId,
                                                    Apartment_ID            as  ApartmentId
                                                
                                                    from  [dbo].[AMB_TENANT_DETAILS]
                                                Where Tenant_ID = ISNULL(@TenantId,Tenant_ID) ";

        public const string AMB_SP_UPSERT_TENANT_DETAILS = @"AMB_SP_UPSERT_TENANT_DETAILS";

        public const string DEACTIVATE_HOUSE_OWNER = @"Update [dbo].[AMB_HOUSE_OWNER_DETAILS] Set House_Owner_IsActive = 0 Where House_Owner_ID = @HouseOwnerId";
        public const string GET_ALL_HOUSE_OWNERS = @"select   House_Owner_ID             as HouseOwnerId,
		                                                House_Owner_Name                 as HouseOwnerName,
                                                        House_Owner_ID_Proof             as HouseOwnerIDProof,
                                                        House_Owner_Address              as HouseOwnerAddress,
                                                        House_Owner_Email                as HouseOwnerEmail,
                                                        House_Owner_Mobile               as HouseOwnerMobile,
                                                        House_Owner_House_ID             as HouseOwnerHouseID,
                                                        Block_ID                         as BlockID,
                                                        Apartment_ID                     as ApartmentID

                                                 from  [dbo].[AMB_HOUSE_OWNER_DETAILS]";

        public const string GET_HOUSE_OWNERS = @"select House_Owner_ID              as HouseOwnerId,
		                                                House_Owner_Name            as HouseOwnerName,
                                                        House_Owner_ID_Proof        as HouseOwnerIDProof,
                                                        House_Owner_Address         as HouseOwnerAddress,
                                                        House_Owner_Email           as HouseOwnerEmail,
                                                        House_Owner_Mobile          as HouseOwnerMobile,
                                                        House_Owner_House_ID        as HouseOwnerHouseID,
                                                        Block_ID                    as BlockID,
                                                        Apartment_ID                as ApartmentID
                                                    from  [dbo].[AMB_HOUSE_OWNER_DETAILS]
                                                Where House_Owner_ID = ISNULL(@HouseOwnerId,House_Owner_ID) ";

        public const string AMB_SP_UPSERT_HOUSE_OWNER_DETAILS = @"AMB_SP_UPSERT_HOUSE_OWNER_DETAILS";


        public const string DEACTIVATE_HOUSE = @"Update [dbo].[AMB_HOUSE_DETAILS] Set House_IsActive = 0 Where House_ID = @HouseId";
        public const string GET_ALL_HOUSES = @"select    House_ID                as  Id,
		                                                 House_Number			 as  HouseNumber,
                                                         apmt.Apartment_ID       as  ApartmentId,
                                                         blk.Block_ID            as  BlockId,
		                                                 blk.Block_Name			 as  BlockName,
		                                                 apmt.Apartment_Name	 as  ApartmentName
                                                  from  [dbo].[AMB_HOUSE_DETAILS] house 
		                                                inner join [dbo].[AMB_APARTMENT_DETAILS] apmt on apmt.Apartment_ID		=	house.Apartment_ID
		                                                inner join [dbo].[AMB_BLOCK_DETAILS]	 blk on  blk.Block_ID	        = house.Block_ID";

        public const string GET_HOUSES = @"select       House_ID                      as  HouseId,
                                                        Block_ID                      as  BlockId,
                                                        Apartment_ID                  as  ApartmentId,
                                                        House_Number                  as  HouseNumber
                                                    from  [dbo].[AMB_HOUSE_DETAILS]
                                                Where House_ID = ISNULL(@HouseId,House_ID) ";

        public const string AMB_SP_UPSERT_HOUSE_DETAILS = @"AMB_SP_UPSERT_HOUSE_DETAILS";
        public const string AMB_SP_UPSERT_USER_DETAILS = @"AMB_SP_UPSERT_USER_DETAILS";

        public const string GET_ALL_USERS = @"select    User_First_Name         as  UserFirstName,
		                                                User_Last_Name          as  UserLastName,
		                                                User_User_Name          as  UserUserName,
		                                                User_Password           as  UserPassword,
		                                                User_Doj                as  UserDoj,
		                                                User_Dob                as  UserDob
                                                 from AMB_USER_DETAILS";

        public const string GET_USER_BY_ID = @"select   User_First_Name         as  UserFirstName,
		                                                User_Last_Name          as  UserLastName,
		                                                User_User_Name          as  UserUserName,
		                                                User_Password           as  UserPassword,
		                                                User_Doj                as  UserDoj,
		                                                User_Dob                as  UserDob
                                                 from   AMB_USER_DETAILS
                                                 where  [User_Id]		=	@UserId ";

        public const string GET_USER_BY_USERNAME_AND_PASSWORD = @"select    User_Id                 as  UserId,
                                                                            User_First_Name         as  UserFirstName,
		                                                                    User_Last_Name          as  UserLastName,
		                                                                    User_User_Name          as  UserUserName,
		                                                                    User_Password           as  UserPassword,
		                                                                    User_Doj                as  UserDoj,
		                                                                    User_Dob                as  UserDob
                                                                     from   AMB_USER_DETAILS
                                                                     where  User_User_Name	 = @UserName and User_Password = @UserPassword ";
        public const string DEACTIVATE_USER = @"Update [dbo].[AMB_USER_DETAILS] Set User_IsActive = 0 Where [User_Id]		=	@UserId ";

        public const string GetUserByUsernameAndPassword = @"SELECT    [User_Id]
                                                                          ,[User_First_Name]
                                                                          ,[User_Last_Name]
                                                                          ,[User_User_Name]
                                                                          ,[User_Password]
                                                                          ,[User_Doj]
                                                                          ,[User_Dob]
                                                                          ,[User_Created_By]
                                                                          ,[User_Created_Date]
                                                                          ,[User_Modified_By]
                                                                          ,[User_Modified_Date]
                                                                          ,[User_IsActive]
                                                                      FROM [APARTMENT_MAINTENANCE_DB].[dbo].[AMB_USER_DETAILS] Where User_User_Name = @UserName;";

        public const string GetUserById = @"SELECT    [User_Id]
                                                                          ,[User_First_Name]
                                                                          ,[User_Last_Name]
                                                                          ,[User_User_Name]
                                                                          ,[User_Password]
                                                                          ,[User_Doj]
                                                                          ,[User_Dob]
                                                                          ,[User_Created_By]
                                                                          ,[User_Created_Date]
                                                                          ,[User_Modified_By]
                                                                          ,[User_Modified_Date]
                                                                          ,[User_IsActive]
                                                                      FROM [APARTMENT_MAINTENANCE_DB].[dbo].[AMB_USER_DETAILS] Where [User_Id] = @UserId;";

        public const string BMS_ADD_EDIT_DELETE_BANKDETAILS = "[dbo].[BMS_ADD_EDIT_DELETE_BANKDETAILS]";
        public const string BMS_FETCH_BANKDETAILS = "[dbo].[BMS_FETCH_BANKDETAILS]";

        public const string BMS_ADD_EDIT_DELETE_COMPANYDETAILS = "[dbo].[BMS_ADD_EDIT_DELETE_COMPANYDETAILS]";
        public const string BMS_FETCH_COMPANYDETAILS = "[dbo].[BMS_FETCH_COMPANYDETAILS]";

        public enum Mode
        {
            ADD = 1,
            MODIFY = 2,
            DELETE=3
        }
    }


}
