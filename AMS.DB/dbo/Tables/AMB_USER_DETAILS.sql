CREATE TABLE [dbo].[AMB_USER_DETAILS] (
    [User_Id]            INT           IDENTITY (1, 1) NOT NULL,
    [User_First_Name]    VARCHAR (200) NOT NULL,
    [User_Last_Name]     VARCHAR (200) NULL,
    [User_User_Name]     VARCHAR (100) NULL,
    [User_Password]      VARCHAR (200) NULL,
    [User_Doj]           DATETIME      NULL,
    [User_Dob]           DATETIME      NULL,
    [User_Created_By]    INT           NULL,
    [User_Created_Date]  DATETIME      CONSTRAINT [DF_AMB_USER_DETAILS_User_Created_Date] DEFAULT (getdate()) NOT NULL,
    [User_Modified_By]   INT           NULL,
    [User_Modified_Date] DATETIME      CONSTRAINT [DF_AMB_USER_DETAILS_User_Modified_Date] DEFAULT (getdate()) NOT NULL,
    [User_IsActive]      BIT           CONSTRAINT [DF_AMB_USER_DETAILS_User_IsActive] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_AMB_USER_DETAILS] PRIMARY KEY CLUSTERED ([User_Id] ASC)
);

