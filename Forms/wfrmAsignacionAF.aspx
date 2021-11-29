<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmAsignacionAF.aspx.cs" Inherits="wfrmAsignacionAF" StyleSheetTheme="Modal" %>

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
    <table style="width:99%;">
        <tr>
            <td align="center" colspan="2" class="style7" dir="ltr" rowspan="1">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto20" 
                    Text="ASIGNACION ACTIVOS FIJOS"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1" 
                    Font-Bold="True"></asp:Label>
                <asp:Label ID="lblCodRol" runat="server" Font-Size="Small" Text="1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="style2">
                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelprincipal" 
                    HorizontalAlign="Center" Width="100%" Visible="False">
                    <div>
                        <asp:Label ID="lblTitulo" runat="server" Text="REGISTRO" 
                            CssClass="texto20"></asp:Label>
                        <table style="width:100%;">
                            <tr>
                                <td align="right" valign="top" width="20%">
                                    <asp:Label ID="Label31" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="CI :"></asp:Label>
                                </td>
                                <td align="left" valign="top" width="30%">
                                    <asp:TextBox ID="txtCI" runat="server" BackColor="#99FFCC" CssClass="texto10" 
                                        MaxLength="50" Width="30%"></asp:TextBox>
                                    <asp:ImageButton ID="btniBusquedaCI" runat="server" 
                                        ImageUrl="~/Imagenes/buscar.png" onclick="btniBusquedaCI_Click" 
                                        style="width: 16px" />
                                </td>
                                <td align="right" valign="top" width="20%">
                                    <asp:Label ID="Label21" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Codigo Activo Fijo"></asp:Label>
                                </td>
                                <td align="left" valign="top" width="30%">
                                    <asp:TextBox ID="txtCodigoActivoFijo" runat="server" BackColor="#99FFCC" CssClass="texto10" MaxLength="50" Width="50%" style='text-transform:uppercase'></asp:TextBox>
                                    <asp:ImageButton ID="btniBusquedaAF" runat="server" 
                                        ImageUrl="~/Imagenes/buscar.png" onclick="btniBusquedaAF_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label48" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Nombre Completo :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtNombreCompleto" runat="server" BackColor="#99FFCC" 
                                        CssClass="texto10" MaxLength="100" Width="80%" Enabled="False"></asp:TextBox>
                                </td>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label49" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Descripcion :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtDescripcion" runat="server" BackColor="#99FFCC" 
                                        CssClass="texto10" MaxLength="100" Width="80%" Enabled="False" 
                                        style='text-transform:uppercase'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label41" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Caracteristicas :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtCaracteristicas" runat="server" BackColor="#99FFCC" 
                                        CssClass="texto10" MaxLength="200" Width="80%" 
                                        Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                                <td align="right" valign="top">
                                    &nbsp;</td>
                                <td align="right">
                                    <asp:Label ID="Label47" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Observacion :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtObservacion" runat="server" BackColor="#99FFCC" 
                                        CssClass="texto10" MaxLength="100" Width="80%" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                                <td align="right">
                                    &nbsp;</td>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label38" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Estado Activo Fijo :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:DropDownList ID="ddlEstadoActivoFijo" runat="server" AutoPostBack="True" 
                                        CssClass="texto10normal" Width="50%" Enabled="False">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    &nbsp;</td>
                                <td align="center">
                                    &nbsp;</td>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnAccionar" runat="server" CssClass="boton150normal" 
                                        onclick="btnAccionar_Click" 
                                        OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" 
                                        Text="Registrar" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="panelprincipal">
                                    &nbsp;</td>
                                <td align="center" class="panelprincipal">
                                    &nbsp;</td>
                                <td align="center" class="panelprincipal" colspan="2">
                                    <asp:Label ID="lblObservaciones" runat="server" CssClass="texto10"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="panelprincipal">
                <asp:Panel ID="pnlNew" runat="server" Height="24px" 
                    Width="80px">
                    <table style="width:99%;">
                        <tr>
                            <td align="center" width="10%">
                                <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/nuevo.gif" 
                                                    onclick="imgNuevo_Click" TabIndex="10" 
                                    style="height: 16px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="panelprincipal" align="right" width="90%">
                                    <asp:Label ID="lblBusqueda" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Busqueda :"></asp:Label>
                                    <asp:TextBox ID="txtBusqueda" runat="server" BackColor="#99FFCC" 
                                        CssClass="texto10" MaxLength="50" Width="60%"></asp:TextBox>
                                <asp:ImageButton ID="btniBusqueda" runat="server" 
                            ImageUrl="~/Imagenes/buscar.png" onclick="btniBusqueda_Click" style="width: 16px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%" 
                    CssClass="panelprincipal">
                    <table style="width:99%;">
                        <tr>
                            <td>
                                <asp:GridView ID="gvDatos" runat="server" EnableTheming="True" 
                                    HorizontalAlign="Center" onrowdatabound="gvDatos_RowDataBound" 
                                    onrowdeleting="gvDatos_RowDeleting" onrowediting="gvDatos_RowEditing" 
                                    SkinID="GridView" Width="99%" EnableModelValidation="True" 
                                    AutoGenerateColumns="False">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/eliminar.png" 
                                            HeaderText="Eliminar" ItemStyle-Width="10%" ShowDeleteButton="True">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>

                                        <asp:BoundField DataField="CI" HeaderText="CI" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NombreCompleto" HeaderText="NombreCompleto" 
                                            ItemStyle-Width="30%">
                                        <ItemStyle Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CodigoActivoFijo" HeaderText="Codigo" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                                            ItemStyle-Width="30%">
                                        <ItemStyle Width="30%" />
                                        </asp:BoundField>


                                        <asp:BoundField DataField="EstadoRegistro" HeaderText="Estado" Visible="False" />
                                        <asp:BoundField DataField="IdAsignacionAF" HeaderText="Estado" ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlBotones" runat="server">
                                    <table style="width: 99%;">
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
            <td colspan="2">
                <asp:ImageButton ID="btniExportar" runat="server" 
                    ImageUrl="~/Imagenes/menu/xls16.png" onclick="btniExportar_Click" 
                    ToolTip="Descargar CSV" />
            </td>
        </tr>
    </table>
</asp:Content>

