CREATE TABLE [dbo].[AMB_HOUSE_DETAILS] (
    [House_Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Block_ID]            INT           NOT NULL,
    [Apartment_ID]        INT           NOT NULL,
    [House_Number]        VARCHAR (500) NOT NULL,
    [House_IsActive]      BIT           NOT NULL,
    [House_Created_By]    INT           NULL,
    [House_Created_Date]  DATETIME      NULL,
    [House_Modified_By]   INT           NULL,
    [House_Modified_Date] DATETIME      NULL,
    CONSTRAINT [PK_AMB_HOUSE_DETAILS] PRIMARY KEY CLUSTERED ([House_Id] ASC)
);











