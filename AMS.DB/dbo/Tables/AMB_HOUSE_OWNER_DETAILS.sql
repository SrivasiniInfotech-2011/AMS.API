CREATE TABLE [dbo].[AMB_HOUSE_OWNER_DETAILS] (
    [House_Owner_ID]            INT            IDENTITY (1, 1) NOT NULL,
    [House_Owner_Name]          VARCHAR (200)  NOT NULL,
    [House_Owner_ID_Proof]      VARCHAR (100)  NULL,
    [House_Owner_Address]       VARCHAR (1000) NOT NULL,
    [House_Owner_Email]         VARCHAR (200)  NULL,
    [House_Owner_Mobile]        VARCHAR (14)   NULL,
    [House_Owner_House_Id]      INT            NOT NULL,
    [House_Owner_IsActive]      BIT            NOT NULL,
    [Block_ID]                  INT            NOT NULL,
    [Apartment_ID]              INT            NOT NULL,
    [House_Owner_Created_By]    INT            NULL,
    [House_Owner_Created_Date]  DATETIME       CONSTRAINT [DF_AMB_HOUSE_OWNER_DETAILS_House_Owner_Created_Date] DEFAULT (getdate()) NULL,
    [House_Owner_Modified_By]   INT            NULL,
    [House_Owner_Modified_Date] DATETIME       CONSTRAINT [DF_AMB_HOUSE_OWNER_DETAILS_House_Owner_Modified_Date] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_AMB_HOUSE_OWNER_DETAILS] PRIMARY KEY CLUSTERED ([House_Owner_ID] ASC)
);







