<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmPersona.aspx.cs" Inherits="wfrmPersona" StylesheetTheme="Modal" %>

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
            <td align="center" >
                                <asp:Panel ID="Panel1" runat="server" CssClass="panelprincipal">
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="center" width="20%">
                                                <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/nuevo.gif" 
                                                    onclick="imgNuevo_Click" />
                                            </td>
                                            <td align="center" width="60%">
                                                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />
                                                <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto20" 
                                                    Text="PERSONA"></asp:Label>
                                                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1" 
                                                    Visible="False"></asp:Label>
                                                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1" 
                                                    Visible="False"></asp:Label>
                                                <asp:Label ID="lblCodProcedencia" runat="server" Font-Size="Small" Text="1" 
                                                    Visible="False"></asp:Label>
                                                <asp:Label ID="lblCodRol" runat="server" Font-Size="Small" Text="1" 
                                                    Visible="False"></asp:Label>
                                            </td>
                                            <td align="center" width="20%">
                                                <asp:RadioButtonList ID="rbTipoMuestra" runat="server" AutoPostBack="True" 
                                                    CssClass="texto10" 
                                                    onselectedindexchanged="rbTipoMuestra_SelectedIndexChanged" 
                                                    RepeatDirection="Horizontal" TextAlign="Left" Width="200px">
                                                    <asp:ListItem Selected="True" Value="1">Todos</asp:ListItem>
                                                    <asp:ListItem Value="2">Solo Activos</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="20%">
                                                &nbsp;</td>
                                            <td align="center" width="60%">
                                                <asp:Label ID="Label1" runat="server" CssClass="etiqueta10" 
                                                    Text="Busca por Nombre :"></asp:Label>
                                                <asp:TextBox ID="txtNombrePersona" runat="server" CssClass="texto10mayusculas" 
                                                    Width="400px"></asp:TextBox>

                                                <cc1:AutoCompleteExtender ID="txtNombrePersona_AutoCompleteExtender" 
                                                    runat="server" completioninterval="10" completionsetcount="10" 
                                                    EnableCaching="True" Enabled="True" MinimumPrefixLength="1" 
                                                    ServiceMethod="BuscarFullName" servicepath="~/wsBuscarFullName.asmx" 
                                                    TargetControlID="txtNombrePersona" UseContextKey="True">
                                                </cc1:AutoCompleteExtender>
                                                <asp:ImageButton ID="imgBuscarWS" runat="server" Height="16px" 
                                                    ImageUrl="~/Imagenes/Ver16.png" onclick="imgBuscarWS_Click" 
                                                    style="width: 16px" />
                                            </td>
                                            <td align="center" width="20%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" 
                    CssClass="panelprincipal" Width="100%">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:GridView ID="gvDatos" runat="server" EnableModelValidation="True" 
                                    EnableTheming="True" HorizontalAlign="Center" 
                                    onrowdatabound="gvDatos_RowDataBound" onrowdeleting="gvDatos_RowDeleting" AutoGenerateColumns="false" 
                                    onrowediting="gvDatos_RowEditing" SkinID="GridView" Width="100%">
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

                                        <asp:BoundField DataField="CI" HeaderText="CI" ItemStyle-Width="10%"/>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" ItemStyle-Width="20%"/>
                                        <asp:BoundField DataField="Paterno" HeaderText="Paterno" ItemStyle-Width="10%"/>
                                        <asp:BoundField DataField="Materno" HeaderText="Materno" ItemStyle-Width="10%"/>
                                        <asp:BoundField DataField="Institucion" HeaderText="Institucion" ItemStyle-Width="10%"/>
                                        <asp:BoundField DataField="Cargo" HeaderText="Cargo" ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EstadoRegistro" HeaderText="Estado" Visible="False" />
                                        <asp:BoundField DataField="IdPersona" HeaderText="Estado" 
                                            ItemStyle-Width="10%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
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
            <td align="center">
                <asp:Label ID="lblObservaciones" runat="server" CssClass="texto10"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelprincipal" 
                    HorizontalAlign="Center" Width="70%">
                    <div>
                        <asp:Label ID="lblTitulo" runat="server" Text="PERSONA" 
                            CssClass="texto20"></asp:Label>
                        <table style="width:100%;">
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" Text="CI :"></asp:Label>
                                </td>
                                <td align="left" width="70%">
                                    <asp:TextBox ID="txtCI" runat="server" Width="20%" CssClass="texto10mayusculas" 
                                        MaxLength="20"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtCI_FilteredTextBoxExtender" runat="server" 
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtCI">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >
                                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Nombres :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNombres" runat="server" CssClass="texto10mayusculas" 
                                        MaxLength="100" Width="60%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtNombres_FilteredTextBoxExtender" 
                                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters" 
                                        TargetControlID="txtNombres" ValidChars=" áéíóúñÑ">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style6" >
                                    <asp:Label ID="Label14" runat="server" CssClass="etiqueta10" 
                                        Text="Apellido Paterno :"></asp:Label>
                                </td>
                                <td align="left" class="style6">
                                    <asp:TextBox ID="txtApellidop" runat="server" CssClass="texto10mayusculas" 
                                        MaxLength="50" Width="40%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtApellidop_FilteredTextBoxExtender1" 
                                        runat="server" FilterType=" Custom, LowercaseLetters, UppercaseLetters" 
                                        TargetControlID="txtApellidop" ValidChars=" áéíóúñÑ">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" >
                                    <asp:Label ID="Label3" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Apellido Materno :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtApellidom" runat="server" CssClass="texto10mayusculas" 
                                        MaxLength="50" Width="40%"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtApellidom_FilteredTextBoxExtender1" 
                                        runat="server" FilterType=" Custom, LowercaseLetters, UppercaseLetters" 
                                        TargetControlID="txtApellidom" ValidChars=" áéíóúñÑ">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label39" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Institucion/Empresa :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtInstitucion" runat="server" CssClass="texto10mayusculas" 
                                        MaxLength="100" Width="80%"></asp:TextBox>

                                    <cc1:AutoCompleteExtender ID="txtInstitucion_AutoCompleteExtender" 
                                        runat="server" completioninterval="10" completionsetcount="10"
                                        EnableCaching="True" Enabled="True" MinimumPrefixLength="1"
                                        ServiceMethod="BuscarInstitucion" servicepath="~/wsBuscarInstitucion.asmx"  
                                        TargetControlID="txtInstitucion" UseContextKey="True">
                                    </cc1:AutoCompleteExtender>

                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label40" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Cargo/Item :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCargo" runat="server" CssClass="texto10mayusculas" MaxLength="100" 
                                        Width="60%"></asp:TextBox>

                                    <cc1:AutoCompleteExtender ID="txtCargo_AutoCompleteExtender"
                                        runat="server" CompletionInterval="10" CompletionSetCount="10" 
                                        EnableCaching="true" Enabled="true" MinimumPrefixLength="1" 
                                        ServiceMethod="BuscarCargo" servicepath="~/wsBuscarCargo.asmx" 
                                        TargetControlID="txtCargo" UseContextKey="true">
                                    </cc1:AutoCompleteExtender>



                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label41" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="ROL - USUARIO"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="texto10mayusculas" 
                                        Width="40%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Panel ID="pnlOK" runat="server" CssClass="panelprincipal" Enabled="False" 
                                        Width="100%">
                                        <table style="width:100%;">
                                            <tr>
                                                <td align="right" width="30%">
                                                    <asp:Label ID="Label38" runat="server" CssClass="etiqueta10" 
                                                        Text="Login Generado: "></asp:Label>
                                                </td>
                                                <td align="left" width="70%">
                                                    <asp:Label ID="lblLoginF" runat="server" CssClass="texto10">primernombre.primerapellido</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label37" runat="server" CssClass="etiqueta10" 
                                                        Text="Password por Defecto :"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblObse" runat="server" CssClass="texto10"> CI o 123456</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
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
                            Text="Registrar" />
                        <asp:Button ID="btnCancelar" runat="server" EnableTheming="True" 
                            Text="Cancelar" 
                            CssClass="boton150normal" onclick="btnCancelar_Click" />
                        <br />
                    </div>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="pnlDatos_ModalPopupExtender" runat="server" 
                    DynamicServicePath="" Enabled="True" 
                    TargetControlID="lblTitulo"
                    CancelControlID = "btnCancelar"
                    PopupControlID="pnlDatos" 
                    BackgroundCssClass = "modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>

                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

