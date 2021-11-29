<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" StylesheetTheme="Modal" %>

<%@ Register namespace="AjaxControlToolkit" tagprefix="AjaxControlToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
    </style>
</head>

    <form id="form1" runat="server">
    <table style="width:100%;">
        <tr>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnlLogin" runat="server" Width="60%" CssClass="panelprincipal">
                    <table style="width:100%;">
                        <tr>
                            <td align="center" width="50%" colspan="3" style="width: 100%">
                                <asp:Label ID="Label1" runat="server" CssClass="texto20" 
                                    Text="INICIO DE SESION"></asp:Label>
                                <asp:Label ID="lblCon" runat="server" Font-Size="Small" Text="0" 
                                    Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="50%">
                                <asp:Label ID="Label2" runat="server" CssClass="texto10" Text="Login :"></asp:Label>
                            </td>
                            <td align="left" width="50%" colspan="2">
                                <asp:TextBox ID="txtLogin" runat="server" CssClass="texto10normal" 
                                    Width="60%" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" >
                                <asp:Label ID="lblPass" runat="server" CssClass="texto10" Text="Password :"></asp:Label>
                            </td>
                            <td align="left" colspan="2" >
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="texto10normal" 
                                    TextMode="Password" Width="60%" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <asp:Panel ID="pnlCambioPassword" runat="server" Visible="False">
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="right" width="50%">
                                                <asp:Label ID="Label3" runat="server" CssClass="texto10" 
                                                    Text="Nuevo Password :"></asp:Label>
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:TextBox ID="txtPasswordNuevo" runat="server" CssClass="texto10normal" 
                                                    TextMode="Password" Width="60%" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label5" runat="server" CssClass="texto10" 
                                                    Text="Repita Password :"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtPasswordBIS" runat="server" CssClass="texto10normal" 
                                                    TextMode="Password" Width="60%" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3">
                                <asp:Button ID="btnIngreso" runat="server" CssClass="boton150normal" 
                                    onclick="btnAceptar_Click" Text="Ingresar" />
                                <asp:Button ID="btnCancelar" runat="server" CssClass="boton150normal" 
                                    onclick="btnCancelar_Click" Text="Cancelar" />
                                <br />
                                <asp:Label ID="lblObservaciones" runat="server" CssClass="texto10"></asp:Label>
                                <br />
                                <asp:Label ID="Label6" runat="server" CssClass="texto10" Text="version: 1.00"></asp:Label>
                                <br />
                                <asp:Button ID="btnCambioPassword" runat="server" CssClass="boton150normal" 
                                    onclick="btnCambioPassword_Click" Text="Cambiar Password" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:HyperLink ID="hlManual" runat="server" CssClass="etiqueta10azul" 
                                    Font-Names="Arial" Font-Size="Small" NavigateUrl="~/Auxiliar/ManualUsuario.pdf">Ver Manual</asp:HyperLink>
                            </td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="right">
                                <asp:HyperLink ID="hlManual1" runat="server" CssClass="etiqueta10azul" 
                                    Font-Names="Arial" Font-Size="Small" 
                                    NavigateUrl="~/Forms/wfrmPersonaR.aspx">Registro Personal</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" class="style1" >
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
