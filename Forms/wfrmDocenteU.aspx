﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmDocenteU.aspx.cs" Inherits="wfrmDocenteU" StyleSheetTheme="Modal" %>

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
            <td align="center" class="style7" dir="ltr" rowspan="1">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto20" 
                    Text="DOCENTE"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="9" 
                    Font-Bold="True"></asp:Label>
                <asp:Label ID="lblCodRol" runat="server" Font-Size="Small" Text="1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="style2">

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
                                    <asp:TextBox ID="txtCI" runat="server" BackColor="#99FFCC" CssClass="texto10" Enabled="False" MaxLength="50" Width="30%"></asp:TextBox>

                                </td>
                                <td align="right" class="style7" valign="top" width="20%">
                                    <asp:Label ID="Label59" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Años de Servicio :"></asp:Label>
                                </td>
                                <td align="left" valign="top" width="30%">
                                    <asp:TextBox ID="txtAnosServicio" runat="server" BackColor="#99FFCC" 
                                        CssClass="texto10" MaxLength="2" Width="20%"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAnosServicio" CssClass="lbl_xx-small" ErrorMessage="!solo numeros!" ValidationExpression="^[1-9]+\d*$" ValidationGroup="Group20" />
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
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label21" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Subir FOTO :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:FileUpload ID="FileUploadFOTO" runat="server" CssClass="etiqueta10" />
                                </td>
                                <td align="right" class="style7" valign="top">
                                    <asp:Label ID="Label41" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Subir CV :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:FileUpload ID="FileUploadCV" runat="server" CssClass="etiqueta10" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:ImageButton ID="btniSubirFOTO" runat="server" 
                                        ImageUrl="~/Imagenes/bc/Subir.png" onclick="btniSubirFOTO_Click" 
                                        ToolTip="Subir Carta" />
                                </td>
                                <td align="left" valign="top">
                                    <asp:ImageButton ID="btniBajarFOTO" runat="server" 
                                        ImageUrl="~/Imagenes/bc/Bajar.png" onclick="btniBajarFOTO_Click" 
                                        ToolTip="Bajar Carta" />
                                </td>
                                <td align="right" 
                                    valign="top">
                                    <%--                                    <cc1:FilteredTextBoxExtender ID="txtDesCom_FilteredTextBoxExtender" 
                                        runat="server" FilterType="Numbers, Custom, LowercaseLetters, UppercaseLetters" 
                                        TargetControlID="txtDesCom" ValidChars=" _.-/áéíóú">
                                    </cc1:FilteredTextBoxExtender>--%>
                                    <asp:ImageButton ID="btniSubirCV" runat="server" 
                                        ImageUrl="~/Imagenes/bc/Subir.png" onclick="btniSubirCV_Click" 
                                        ToolTip="Subir Carta" />
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    <asp:ImageButton ID="btniBajarCV" runat="server" 
                                        ImageUrl="~/Imagenes/bc/Bajar.png" onclick="btniBajarCV_Click" 
                                        ToolTip="Bajar Carta" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label61" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Archivo Adjunto :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:CheckBox ID="chbFOTO" runat="server" Enabled="False" Text=" " />
                                </td>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label60" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Archivo Adjunto :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:CheckBox ID="chbDoc" runat="server" Enabled="False" Text=" " />
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
            <td>
                <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%" 
                    CssClass="panelprincipal">
                    <table style="width:99%;">
                        <tr>
                            <td>
                                <asp:GridView ID="gvDatos" runat="server" EnableTheming="True" 
                                    HorizontalAlign="Center" 
                                    SkinID="GridView" Width="99%" EnableModelValidation="True" 
                                    AutoGenerateColumns="False" onrowdatabound="gvDatos_RowDataBound" 
                                    onrowdeleting="gvDatos_RowDeleting" onrowediting="gvDatos_RowEditing" >
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
                                            ItemStyle-Width="40%">
                                        <ItemStyle Width="40%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AnosServicio" HeaderText="AnosServicio" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AdjuntoFoto" HeaderText="Foto" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Adjunto" HeaderText="CV" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="EstadoRegistro" HeaderText="Estado" Visible="False" />
                                        <asp:BoundField DataField="IdDocente" HeaderText="Estado" ItemStyle-Width="10%">
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
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="panelpeque" 
                                        Text="LM" Width="5%" 
                        ToolTip="Creacion: Lessly Mollinedo Laura" ForeColor="#666666"></asp:Label>
                </td>
        </tr>
        </table>
</asp:Content>
