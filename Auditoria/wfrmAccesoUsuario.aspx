<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmAccesoUsuario.aspx.cs" Inherits="wfrmAccesoUsuario" StylesheetTheme="Modal" %>

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
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" 
                    Text="Acceso de Usuarios" CssClass="texto20"></asp:Label>
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
            <td align="right" valign="top">
                <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%" 
                    CssClass="panelprincipal">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Panel ID="pnlSeleccion" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="left" class="panelprincipal" valign="middle" width="80%">
                                                <asp:Label ID="lblUsuario" runat="server" CssClass="texto10" 
                                                    style="text-align: left" Text="Listar por usuario :"></asp:Label>
                                                <asp:DropDownList ID="ddlUsuario" runat="server" AutoPostBack="True" 
                                                    CssClass="texto10mayusculas" onselectedindexchanged="ddlUsuario_SelectedIndexChanged" 
                                                    style="text-align: left" Visible="False" Width="50%">
                                                    <asp:ListItem Value="0">TODOS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="panelprincipal" valign="middle" width="20%">
                                                <asp:Label ID="Label12" runat="server" CssClass="texto10" 
                                                    style="text-align: left; margin-left: 0px;" Text="Listar por fecha:" 
                                                    Visible="False"></asp:Label>
                                                <asp:TextBox ID="txtFecha" runat="server" AutoPostBack="True" 
                                                    ontextchanged="txtFecha_TextChanged" Width="78px" Visible="False" 
                                                    CssClass="texto10mayusculas"></asp:TextBox>
                                                <cc1:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" 
                                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFecha">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvDatos" runat="server" EnableTheming="True" AutoGenerateColumns="false" 
                                    HorizontalAlign="Center" SkinID="GridView" Width="100%">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LogON" HeaderText="LogON" 
                                            ItemStyle-Width="20%">
                                        <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IP" HeaderText="IP" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Navegador" HeaderText="Navegador" 
                                            ItemStyle-Width="30%">
                                        <ItemStyle Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaR" HeaderText="FechaR" 
                                            ItemStyle-Width="20%">
                                        <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EstadoRegistro" HeaderText="Estado" 
                                            Visible="False" />
                                        <asp:BoundField DataField="IdAcceso" HeaderText="Estado" ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlBotones" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td valign="middle">
                                                <asp:Label ID="Label9" runat="server" CssClass="etiqueta8" 
                                                    style="text-align: left; font-family: Arial; font-size: x-small;" 
                                                    Text="Paginacion de:" Width="80px"></asp:Label>
                                                <asp:TextBox ID="txtRango" runat="server" 
                                                    style="text-align: center; font-size: xx-small; font-family: Arial" 
                                                    Width="25px" CssClass="texto8">15</asp:TextBox>
                                            </td>
                                            <td valign="middle">
                                                <asp:Button ID="btnIni" runat="server" CssClass="boton50" 
                                                    onclick="btnIni_Click" Text="Inicio" />
                                                <asp:Button ID="btnAnt" runat="server" CssClass="boton50" 
                                                    onclick="btnAnt_Click" Text="&lt;-Ant" />
                                                <asp:TextBox ID="txtPagina" runat="server" CssClass="texto8" 
                                                    style="text-align: center; font-size: xx-small; font-family: Arial" 
                                                    Width="25px">1</asp:TextBox>
                                                <asp:Label ID="Label11" runat="server" CssClass="etiqueta8" 
                                                    style="font-family: Arial; font-size: x-small" Text="de"></asp:Label>
                                                <asp:TextBox ID="txtTotalPaginas" runat="server" CssClass="texto8" 
                                                    Enabled="False" 
                                                    style="text-align: center; font-size: xx-small; font-family: Arial" 
                                                    Width="25px"></asp:TextBox>
                                                <asp:Button ID="btnSig" runat="server" CssClass="boton50" 
                                                    onclick="btnSig_Click" Text="Sig-&gt;" />
                                                <asp:Button ID="btnFin" runat="server" CssClass="boton50" 
                                                    onclick="btnFin_Click" Text="Fin" />
                                            </td>
                                            <td valign="middle">
                                                <asp:Label ID="Label10" runat="server" CssClass="etiqueta8" 
                                                    style="font-family: Arial; font-size: x-small" Text="Total Registros:" 
                                                    Width="80px"></asp:Label>
                                                <asp:TextBox ID="txtTotal" runat="server" Enabled="False" 
                                                    style="text-align: center; font-size: xx-small; font-family: Arial" 
                                                    Width="25px" CssClass="texto8"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

