<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmPlanU.aspx.cs" Inherits="wfrmPlanU" StyleSheetTheme="Modal" %>

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
                    Text="PLAN CURRICULAR"></asp:Label>
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
                                    <asp:TextBox ID="txtCI" runat="server" BackColor="#99FFCC" CssClass="texto10" 
                                        Enabled="False" MaxLength="50" Width="30%"></asp:TextBox>
                                </td>
                                <td align="right" class="style7" valign="top" width="20%">
                                    <asp:Label ID="Label59" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Tipo de Plan :"></asp:Label>
                                </td>
                                <td align="left" valign="top" width="30%">
                                    <asp:DropDownList ID="ddlTipoPlan" runat="server" AutoPostBack="True" 
                                        CssClass="texto10normal" Width="50%" Enabled="False">
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
                                    <asp:Label ID="Label21" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="PLAN :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:FileUpload ID="FileUploadDOC" runat="server" CssClass="etiqueta10" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                                <td align="right" class="style7" valign="top">
                                    <asp:ImageButton ID="btniSubirDOC" runat="server" 
                                        ImageUrl="~/Imagenes/bc/Subir.png" onclick="btniSubirDOC_Click" 
                                        ToolTip="Subir Carta" />
                                </td>
                                <td align="left" valign="top">
                                    <asp:ImageButton ID="btniBajarDOC" runat="server" 
                                        ImageUrl="~/Imagenes/bc/Bajar.png" onclick="btniBajarDOC_Click" 
                                        ToolTip="Bajar Carta" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                                <td align="right" class="style7" valign="top">
                                    <asp:Label ID="Label60" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Archivo Adjunto :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:CheckBox ID="chbDoc" runat="server" Enabled="False" Text=" " />
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
                &nbsp;</td>
            <td class="panelprincipal" align="right" width="90%">
                                    &nbsp;</td>
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
                                        <asp:BoundField DataField="TipoPlan" HeaderText="TipoPlan" 
                                            ItemStyle-Width="30%">
                                        <ItemStyle Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Adjunto" HeaderText="Adjunto" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="EstadoRegistro" HeaderText="Estado" Visible="False" />
                                        <asp:BoundField DataField="IdPlan" HeaderText="Estado" ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
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

