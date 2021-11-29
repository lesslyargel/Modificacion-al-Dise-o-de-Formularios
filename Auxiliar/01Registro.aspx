<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01Registro.aspx.cs" Inherits="Registro" StylesheetTheme="Modal" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

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
                <asp:Panel ID="pnlRegistro" runat="server" Width="50%" CssClass="panelprincipal">
                    <table style="width:100%;">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label1" runat="server" CssClass="texto20" 
                                    Text="Paso 1. Registro CI"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="40%">
                                <asp:Label ID="Label4" runat="server" CssClass="etiqueta10" 
                                    Text="Introduzca su CI:"></asp:Label>
                                <br />
                            </td>
                            <td align="left" width="60%">
                                <asp:TextBox ID="txtCI" runat="server" CssClass="texto10normal" 
                                    Width="40%" MaxLength="20" ></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="txtCI_FilteredTextBoxExtender" runat="server" 
                                    Enabled="True" FilterType="Numbers" TargetControlID="txtCI">
                                </asp:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                    <asp:Button ID="btnRegistro2" runat="server" CssClass="boton150normal" 
                                        onclick="btnRegistro" Text="1er. Paso" />
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Label ID="lblObservaciones" runat="server" CssClass="texto10"></asp:Label>
                                        </td>
                                    </tr>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                </asp:ToolkitScriptManager>
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
