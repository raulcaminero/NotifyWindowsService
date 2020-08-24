-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Oliver Corsino
-- Create date: 01-17-2019
-- Description:	This SPC is used for getting the information needed form OnBase for get to know if a user is log in at OnBase
--              for let to know to "Balanceo de Carga" app that a user is loged in the system and its able for a new assignation.
-- =============================================
CREATE PROCEDURE SPC_GetOnBaseUserInformation -- EXEC SPC_GetOnBaseUserInformation
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT UA.[username] AS [UserName],
		   UG.[usergroupname] AS [UserGroupName],
		   UA.[lastlogon] AS [LastLogon]
	FROM [hsi].[useraccount] UA
		   JOIN [hsi].[userxusergroup] UXUG
		   ON UA.[usernum] = UXUG.[usernum]
		   JOIN [hsi].[usergroup] UG
		   ON UXUG.[usergroupnum] = UG.[usergroupnum]
END
GO
