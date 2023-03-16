CREATE TABLE [dbo].[AMB_APARTMENT_DETAILS] (
    [Apartment_ID]                INT            IDENTITY (1, 1) NOT NULL,
    [Apartment_Name]              VARCHAR (500)  NOT NULL,
    [Apartment_Address]           VARCHAR (1000) NOT NULL,
    [Apartment_RegistrationId]    VARCHAR (100)  NULL,
    [Apartment_IsActive]          BIT            NOT NULL,
    [Apartment_Construction_Date] DATETIME       NOT NULL,
    [Apartment_Created_By]        INT            NULL,
    [Apartment_Created_Date]      DATETIME       CONSTRAINT [DF_AMB_APARTMENT_DETAILS_Apartment_Created_Date] DEFAULT (getdate()) NULL,
    [Apartment_Modified_By]       INT            NULL,
    [Apartment_Modified_Date]     DATETIME       CONSTRAINT [DF_AMB_APARTMENT_DETAILS_Apartment_Modified_Date] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_AMB_APARTMENT_DETAILS] PRIMARY KEY CLUSTERED ([Apartment_ID] ASC)
);







