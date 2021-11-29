<%@ Page Title="" Language="C#" MasterPageFile="~/MP.master" AutoEventWireup="true" CodeFile="wfrmPersonaR.aspx.cs" Inherits="wfrmPersonaR" StyleSheetTheme="Modal" %>

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
                    Text="PERSONA"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="style2">

                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelprincipal" 
                    HorizontalAlign="Center" Width="100%">
                    <div>
                        <asp:Label ID="lblTitulo" runat="server" Text="REGISTRO" 
                            CssClass="texto20"></asp:Label>
                        <table style="width:100%;">
                            <tr>
                                <td align="right" valign="top" width="20%">
                                    <asp:Label ID="Label21" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="CI"></asp:Label>
                                </td>
                                <td align="left" valign="top" width="30%">
                                    <asp:TextBox ID="txtCI" runat="server" BackColor="#99FFCC" CssClass="texto10" MaxLength="50" Width="50%" ValidationGroup="Group20"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCI" CssClass="lbl_xx-small" ErrorMessage="!solo numeros!" ValidationExpression="^[1-9]+\d*$" ValidationGroup="Group20" />
                                </td>
                                <td align="right" class="style7" valign="top" width="20%">
                                    <asp:Label ID="Label31" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Extension :"></asp:Label>
                                </td>
                                <td align="left" valign="top" width="30%">
                                    <asp:TextBox ID="txtEXT" runat="server" BackColor="#99FFCC" CssClass="texto10" 
                                        MaxLength="10" Width="20%" style='text-transform:uppercase'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label41" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Nombres :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtNombres" runat="server" BackColor="#99FFCC" CssClass="texto10" MaxLength="50" Width="80%" style='text-transform:uppercase'></asp:TextBox>
                                </td>
                                <td align="right" class="style7" valign="top">
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label43" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Paterno :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtPaterno" runat="server" BackColor="#99FFCC" CssClass="texto10" MaxLength="50" Width="50%" style='text-transform:uppercase'></asp:TextBox>
                                </td>
                                <td align="right" class="style7" valign="top">
                                    <asp:Label ID="Label44" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Materno :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtMaterno" runat="server" BackColor="#99FFCC" CssClass="texto10" MaxLength="50" Width="50%" style='text-transform:uppercase'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label38" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Fecha de Nacimiento"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtFechaNacimiento" runat="server" BackColor="#99FFCC" 
                                        CssClass="texto10" MaxLength="10" Width="30%"></asp:TextBox>
                                    <asp:ImageButton ID="imgbtnFecha" runat="server" 
                                        ImageUrl="~/Imagenes/menu/gestion16.png" onclick="imgbtnFecha_Click" />
                                    <asp:Calendar ID="Fecha" runat="server" BackColor="White" BorderColor="#999999" 
                                        CellPadding="4" DayNameFormat="Shortest" EnableTheming="True" 
                                        Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                                        ondayrender="Fecha_DayRender" onselectionchanged="Fecha_SelectionChanged" 
                                        Visible="False" Width="200px">
                                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" 
                                            Wrap="True" />
                                        <NextPrevStyle VerticalAlign="Bottom" />
                                        <OtherMonthDayStyle ForeColor="#808080" />
                                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                        <SelectorStyle BackColor="#CCCCCC" />
                                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <WeekendDayStyle BackColor="#FFFFCC" />
                                    </asp:Calendar>
                                </td>
                                <td align="right" 
                                    valign="top">
                                    <%--                                    <cc1:FilteredTextBoxExtender ID="txtDesCom_FilteredTextBoxExtender" 
                                        runat="server" FilterType="Numbers, Custom, LowercaseLetters, UppercaseLetters" 
                                        TargetControlID="txtDesCom" ValidChars=" _.-/áéíóú">
                                    </cc1:FilteredTextBoxExtender>--%>
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label46" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Telefono :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtTelefono" runat="server" BackColor="#99FFCC" CssClass="texto10" MaxLength="50" Width="50%" ValidationGroup="Group20"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTelefono" CssClass="lbl_xx-small" ErrorMessage="!solo numeros!" ValidationExpression="^[1-9]+\d*$" ValidationGroup="Group20" />
                                </td>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label57" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Celular :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtCelular" runat="server" BackColor="#99FFCC" CssClass="texto10" MaxLength="50" Width="50%" ValidationGroup="Group20"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCelular" CssClass="lbl_xx-small" ErrorMessage="!solo numeros!" ValidationExpression="^[1-9]+\d*$" ValidationGroup="Group20" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label45" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Direccion :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtDireccion" runat="server" BackColor="#99FFCC" 
                                        CssClass="texto10" MaxLength="200" Width="80%"></asp:TextBox>
                                </td>
                                <td align="right" valign="top">
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label47" runat="server" CssClass="etiqueta10" 
                                        style="text-align: left" Text="Correo Electronico :"></asp:Label>
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtCorreo" runat="server" BackColor="#99FFCC" 
                                        CssClass="texto10" MaxLength="50" Width="80%"></asp:TextBox>
                                </td>
                                <td align="right" valign="top">
                                    &nbsp;</td>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" valign="top" colspan="4">
                                    <asp:Button ID="btnAccionar" runat="server" CssClass="boton150normal" onclick="btnAccionar_Click" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" Text="Registrar" ValidationGroup="Group20" />
                                    <br />
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="right" width="20%">
                                                <asp:Label ID="Label58" runat="server" CssClass="etiqueta10" 
                                                    style="text-align: left" Text="Login"></asp:Label>
                                            </td>
                                            <td align="left" width="30%">
                                                <asp:Label ID="lblLogin" runat="server" CssClass="etiqueta10" 
                                                    style="text-align: left"></asp:Label>
                                            </td>
                                            <td align="right" width="20%">
                                                <asp:Label ID="Label59" runat="server" CssClass="etiqueta10" 
                                                    style="text-align: left" Text="Password :"></asp:Label>
                                            </td>
                                            <td align="left" width="30%">
                                                <asp:Label ID="lblPassword" runat="server" CssClass="etiqueta10" 
                                                    style="text-align: left"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
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
                <asp:Label ID="Label4" runat="server" CssClass="panelpeque" 
                                        Text="LM" Width="5%" 
                        ToolTip="Creacion: Lessly Mollinedo Laura" ForeColor="#666666"></asp:Label>
                </td>
        </tr>
        </table>
</asp:Content>

