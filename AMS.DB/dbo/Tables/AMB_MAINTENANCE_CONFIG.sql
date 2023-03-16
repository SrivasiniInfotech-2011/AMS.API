CREATE TABLE [dbo].[AMB_MAINTENANCE_CONFIG] (
    [Maintenance_Config_Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Maintenance_House_id]         INT            NOT NULL,
    [Maintenance_Total_SquareFeet] INT            NOT NULL,
    [Maintenance_Rate_Per_SqFeet]  DECIMAL (5, 2) NOT NULL,
    [Maintenance_Charges]          DECIMAL (5, 2) NOT NULL,
    [Maintenance_Water_Charges]    DECIMAL (5, 2) NOT NULL,
    [Maintenance_Created_By]       INT            NOT NULL,
    [Maintenance_Created_Date]     DATETIME       NOT NULL,
    [Maintenance_Modified_By]      INT            NOT NULL,
    [Maintenance_Modified_Date]    DATETIME       NOT NULL,
    CONSTRAINT [PK_AMB_MAINTENANCE_CONFIG] PRIMARY KEY CLUSTERED ([Maintenance_Config_Id] ASC),
    CONSTRAINT [FK_AMB_MAINTENANCE_CONFIG_AMB_HOUSE_DETAILS] FOREIGN KEY ([Maintenance_Config_Id]) REFERENCES [dbo].[AMB_HOUSE_DETAILS] ([House_Id])
);





