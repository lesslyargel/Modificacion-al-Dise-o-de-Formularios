<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmFuncion.aspx.cs" Inherits="wfrmFuncion" StyleSheetTheme="Modal" %>

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
                    Text="FUNCIONES"></asp:Label>
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
                        &nbsp;
                        <asp:Label ID="lblTitulo" runat="server" Text="REGISTRO" 
                            CssClass="texto20"></asp:Label>
                        <table style="width:100%;">
                            <tr>
                                <td align="right" valign="top" width="20%">
                                    <asp:Label ID="Label31" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="CI :"></asp:Label>
                                </td>
                                <td align="left" valign="top" width="30%">
                                    <asp:TextBox ID="txtCI" runat="server" BackColor="#99FFCC" CssClass="texto10" MaxLength="50" Width="30%"></asp:TextBox>
                                    <asp:ImageButton ID="btniBusquedaCI" runat="server" 
                                        ImageUrl="~/Imagenes/buscar.png" onclick="btniBusquedaCI_Click" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ControlToValidate="txtCI" CssClass="lbl_xx-small" ErrorMessage="!solo numeros!" 
                                        ValidationExpression="^[1-9]+\d*$" ValidationGroup="Group20" />
                                </td>
                                <td align="right" class="style7" valign="top" width="20%">
                                    <asp:Label ID="Label60" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Materia :"></asp:Label>
                                </td>
                                <td align="left" valign="top" width="30%">
                                    <asp:DropDownList ID="ddlMateria" runat="server" AutoPostBack="True" 
                                        CssClass="texto10normal" Width="50%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label58" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Nombre Completo :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtNombreCompleto" runat="server" BackColor="#99FFCC" 
                                        CssClass="texto10" Enabled="False" MaxLength="100" Width="80%"></asp:TextBox>
                                </td>
                                <td align="right" class="style7" valign="top">
                                    <asp:Label ID="Label61" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Curso :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:DropDownList ID="ddlCurso" runat="server" AutoPostBack="True" 
                                        CssClass="texto10normal" Width="50%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                                <td align="right" class="style7" valign="top">
                                    <asp:Label ID="Label59" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Paralelo :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtParalelo" runat="server" BackColor="#99FFCC" 
                                        CssClass="texto10" MaxLength="20" Width="20%" style='text-transform:uppercase'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                                <td align="right" class="style7" valign="top">
                                    <asp:Label ID="Label62" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Comision :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:DropDownList ID="ddlComision" runat="server" AutoPostBack="True" 
                                        CssClass="texto10normal" Width="50%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4" valign="top">
                                    <asp:Button ID="btnAccionar" runat="server" CssClass="boton150normal" 
                                        onclick="btnAccionar_Click" 
                                        OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" 
                                        Text="Registrar" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="panelprincipal" colspan="4">
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
                                                    TabIndex="10" 
                                    style="height: 16px" onclick="imgNuevo_Click" />
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
                            ImageUrl="~/Imagenes/buscar.png" onclick="btniBusqueda_Click" />
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
                                    HorizontalAlign="Center" 
                                    SkinID="GridView" Width="99%" EnableModelValidation="True" 
                                    AutoGenerateColumns="False" onrowdatabound="gvDatos_RowDataBound" 
                                    onrowdeleting="gvDatos_RowDeleting" onrowediting="gvDatos_RowEditing">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/eliminar.png" 
                                            HeaderText="Eliminar" ItemStyle-Width="10%" ShowDeleteButton="True">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:CommandField ButtonType="Image" EditImageUrl="~/Imagenes/modificar.png" 
                                            HeaderText="Modificar" ItemStyle-Width="10%" ShowEditButton="True">
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

                                        <asp:BoundField DataField="Materia" HeaderText="Materia" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Curso" HeaderText="Curso" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Comision" HeaderText="Comision" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="EstadoRegistro" HeaderText="Estado" Visible="False" />
                                        <asp:BoundField DataField="IdFuncion" HeaderText="Estado" ItemStyle-Width="10%">
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
                <asp:Label ID="Label4" runat="server" CssClass="panelpeque" 
                                        Text="LM" Width="5%" 
                        ToolTip="Creacion: Lessly Mollinedo Laura" ForeColor="#666666"></asp:Label>
                </td>
        </tr>
        </table>
</asp:Content>

