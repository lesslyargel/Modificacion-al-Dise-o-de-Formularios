<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmUsuarios.aspx.cs" Inherits="wfrmUsuarios" StyleSheetTheme="Modal" %>

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
                                <asp:Panel ID="Panel1" runat="server" CssClass="panelprincipal">
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="center" width="20%">
                                                &nbsp;</td>
                                            <td align="center" width="60%">
                                                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />
                                                <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto20" 
                                                    Text="USUARIOS"></asp:Label>
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
                                                    RepeatDirection="Horizontal" TextAlign="Left">
                                                    <asp:ListItem Selected="True" Value="1">Todos</asp:ListItem>
                                                    <asp:ListItem Value="2">Solo Activos</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
            </td>
         </tr>
          <tr>
            <td> 
              <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%" 
                    CssClass="panelprincipal">
                    <table style="width:100%;">
                        <tr>
                            <td valign="100%">
                                <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" 
                                    EnableModelValidation="True" EnableTheming="True" HorizontalAlign="Center" 
                                    onrowdatabound="gvDatos_RowDataBound" 
                                    onrowdeleting="gvDatos_RowDeleting" 
                                    onrowediting="gvDatos_RowEditing" SkinID="GridView" Width="100%" 
                                    onselectedindexchanged="gvDatos_SelectedIndexChanged">
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
                                        <asp:CommandField ButtonType="Image" HeaderText="Resetear" ItemStyle-Width="10%"
                                            SelectImageUrl="~/Imagenes/reset.png" ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>

                                        <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo">
                                        <ItemStyle Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LoginUsuario" HeaderText="Login" ItemStyle-Width="20%">
                                        <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="IdRol" HeaderText="IdRol" ItemStyle-Width="20%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EstadoRegistro" HeaderText="Estado" Visible="False" />
                                        <asp:BoundField DataField="IdUsuario" HeaderText="Estado" 
                                            ItemStyle-Width="10%">
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
                                                    Width="25px">texto8</asp:TextBox>
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
                <asp:Label ID="lblObservaciones" runat="server" CssClass="texto10"></asp:Label>
            </td>
          </tr>
          <tr>
            <td>
                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelprincipal" 
                    HorizontalAlign="Center" Width="70%">
                    <div>
                        <asp:Label ID="lblTitulo" runat="server" Text="USUARIOS" 
                            CssClass="texto20"></asp:Label>
                        <table style="width:100%;">
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="Label16" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Nombre del Usuario :"></asp:Label>
                                </td>
                                <td align="left" width="70%">
                                    <asp:TextBox ID="txtNombreCompleto" runat="server" MaxLength="100" 
                                        Width="80%" CssClass="texto10mayusculas" Enabled="False"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtNombreCompleto_FilteredTextBoxExtender" 
                                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters" ValidChars=" "
                                        TargetControlID="txtNombreCompleto">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Login del usuario :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLoginUsuario" runat="server" MaxLength="50" Width="40%" 
                                        CssClass="texto10normal" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Rol :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlRol" runat="server" Width="60%" 
                                        CssClass="texto10mayusculas">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label18" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Caso :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCaso" runat="server" CssClass="texto10normal" 
                                        Width="60%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <asp:CheckBox ID="chbEstado" runat="server" Checked="True" 
                            Text="Activar" CssClass="texto10" />
                        <br />
                        <asp:Button ID="btnAccionar" runat="server" CssClass="boton150normal" 
                            onclick="btnAccionar_Click" 
                            OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" 
                            Text="Registrar" />
                        <asp:Button ID="btnCancelar" runat="server" EnableTheming="True" 
                            onclick="btnCancelar_Click" Text="Cancelar" 
                            CssClass="boton150normal" />
                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlDatos_RoundedCornersExtender" runat="server" 
                    Enabled="True" TargetControlID="pnlDatos" Radius="10" BorderColor="Black" >
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender 
                    ID="pnlDatos_ModalPopupExtender" 
                    runat="server" 
                    DynamicServicePath="" 
                    Enabled="True" 
                    TargetControlID="lblTitulo"
                    CancelControlID = "btnCancelar"
                    PopupControlID="pnlDatos" 
                    BackgroundCssClass = "modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
      
        
    </table>
</asp:Content>

