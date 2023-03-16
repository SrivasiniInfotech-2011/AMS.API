CREATE TABLE [dbo].[AMB_TENANT_DETAILS] (
    [Tenant_Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Tenant_Name]          VARCHAR (200) NOT NULL,
    [Tenant_IsActive]      BIT           NOT NULL,
    [Tenant_ID_Proof]      VARCHAR (100) NULL,
    [Tenant_House_Id]      INT           NULL,
    [Block_ID]             INT           NULL,
    [Apartment_ID]         INT           NULL,
    [Tenant_Created_By]    INT           NULL,
    [Tenant_Created_Date]  DATETIME      CONSTRAINT [DF_AMB_TENANT_DETAILS_Tenant_Created_Date] DEFAULT (getdate()) NULL,
    [Tenant_Modified_By]   INT           NULL,
    [Tenant_Modified_Date] DATETIME      CONSTRAINT [DF_AMB_TENANT_DETAILS_Tenant_Modified_Date] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_AMB_TENANT_DETAILS] PRIMARY KEY CLUSTERED ([Tenant_Id] ASC)
);

