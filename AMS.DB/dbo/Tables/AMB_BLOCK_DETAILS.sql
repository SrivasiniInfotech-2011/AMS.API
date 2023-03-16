CREATE TABLE [dbo].[AMB_BLOCK_DETAILS] (
    [Block_ID]            INT           IDENTITY (1, 1) NOT NULL,
    [Apartment_ID]        INT           NOT NULL,
    [Block_Name]          VARCHAR (500) NOT NULL,
    [Block_IsActive]      BIT           NOT NULL,
    [Block_Created_By]    INT           NULL,
    [Block_Created_Date]  DATETIME      CONSTRAINT [DF_AMB_BLOCK_DETAILS_Block_Created_Date] DEFAULT (getdate()) NULL,
    [Block_Modified_By]   INT           NULL,
    [Block_Modified_Date] DATETIME      CONSTRAINT [DF_AMB_BLOCK_DETAILS_Block_Modified_Date] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_AMB_BLOCK_DETAILS] PRIMARY KEY CLUSTERED ([Block_ID] ASC)
);









