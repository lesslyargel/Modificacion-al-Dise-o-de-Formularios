<%@ Page Language="C#" AutoEventWireup="true" CodeFile="03Contrato.aspx.cs" Inherits="Contrato" StylesheetTheme="Modal" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .cssHeaderImg
	    {
	        background-image : url(../Imagenes/Menu4.png);
        }
    </style>
</head>
<body>

    <form id="form2" runat="server">
    <table style="width:100%;">
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" >
                <asp:Panel ID="pnlRegistro" runat="server" Width="60%" CssClass="panelprincipal">
                    <table style="width:100%;">
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="Label1" runat="server" CssClass="texto20" 
                                    Text="Paso 3. Aceptar Registro"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="40%">
                                <asp:Label ID="Label4" runat="server" CssClass="texto12" 
                                    Text="Login:"></asp:Label>
                                <br />
                            </td>
                            <td align="left" width="60%">
                                <asp:Label ID="lblLoginU" runat="server" CssClass="texto12"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label5" runat="server" CssClass="texto12" Text="Password:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPasswordU" runat="server" CssClass="texto12"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                    <asp:Label ID="lblObservaciones" runat="server" CssClass="texto10">No olvide su Login (1erNombre.1erApellido)</asp:Label>
                                    <br />
                                    <asp:Label ID="lblObservaciones0" runat="server" CssClass="texto10">y su Password inicial su CI</asp:Label>
                                    <br />
                                    <asp:Label ID="lblObservaciones1" runat="server" CssClass="texto10">Autentiquese por favor ...</asp:Label>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Button ID="btnRegistro4" runat="server" CssClass="boton150normal" 
                                                onclick="btnRegistro4_Click" Text="Autenticar" />
                                        </td>
                                    </tr>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                </cc1:ToolkitScriptManager>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>
    </form>
</body>
</body>
</html>
