Imports System.Data
Imports System.Data.SqlClient

Partial Class Auxiliar_AcercaDe
    Inherits System.Web.UI.Page
    Private funGEN As New funciones_generales

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar0.Click
        ClientScript.RegisterStartupScript(Page.GetType, "dw", funGEN.fgsCerrar)
    End Sub
End Class
