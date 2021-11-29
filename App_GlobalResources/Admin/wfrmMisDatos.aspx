<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmMisDatos.aspx.cs" Inherits="wfrmMisDatos" StylesheetTheme="Modal" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
            .cssHeaderImg
	        {
	        background-image : url(../Imagenes/Menu4.png);
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="center">
                                                <asp:ImageButton ID="imgAux" runat="server" 
                    ImageUrl="~/Imagenes/w.png" />
                                                <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto20" 
                                                    Text="DATOS PERSONALES"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1" 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1" 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodProcedencia" runat="server" Font-Size="Small" Text="1" 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodRol" runat="server" Font-Size="Small" Text="1" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelprincipal" 
                    HorizontalAlign="Center" Width="70%">
                    <div>
                        <table style="width:100%;">
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" Text="CI :"></asp:Label>
                                </td>
                                <td align="left" width="70%">
                                    <asp:TextBox ID="txtCI" runat="server" Width="20%" CssClass="texto10mayusculas" 
                                        MaxLength="20" ReadOnly="True"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtCI_FilteredTextBoxExtender" runat="server" 
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtCI">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >
                                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Nombres:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNombres" runat="server" CssClass="texto10mayusculas" 
                                        MaxLength="100" Width="60%" ReadOnly="True"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtNombres_FilteredTextBoxExtender" 
                                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters" 
                                        TargetControlID="txtNombres" ValidChars=" ">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >
                                    <asp:Label ID="Label14" runat="server" CssClass="etiqueta10" 
                                        Text="Apellido Paterno:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtApellidop" runat="server" CssClass="texto10mayusculas" 
                                        MaxLength="50" Width="40%" ReadOnly="True"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtApellidop_FilteredTextBoxExtender1" 
                                        runat="server" FilterType=" Custom, LowercaseLetters, UppercaseLetters" 
                                        TargetControlID="txtApellidop" ValidChars=" ">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >
                                    <asp:Label ID="Label3" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Apellido Materno:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtApellidom" runat="server" CssClass="texto10mayusculas" 
                                        MaxLength="50" Width="40%" ReadOnly="True"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtApellidom_FilteredTextBoxExtender1" 
                                        runat="server" FilterType=" Custom, LowercaseLetters, UppercaseLetters" 
                                        TargetControlID="txtApellidom" ValidChars=" ">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CheckBox ID="chbEstado" runat="server" Checked="True" CssClass="texto10" 
                                        Text="Activar" />
                                </td>
                            </tr>
                            </caption>
                        </table>
                        <asp:Button ID="btnAccionar" runat="server" CssClass="boton150normal" 
                            onclick="btnAccionar_Click" 
                            OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" 
                            Text="Actualizar" />
                        <asp:Button ID="btnCancelar" runat="server" EnableTheming="True" 
                            Text="Cancelar" 
                            CssClass="boton150normal" onclick="btnCancelar_Click" />
                        <br />
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">

                <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs">Si sus datos deben ser modificados pongase en contacto con el adminsitrador</asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

