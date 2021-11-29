<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmPrincipal.aspx.cs" Inherits="wfrmPrincipal" StylesheetTheme ="Modal" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

        <script type="text/javascript" language="javascript">
//                function ModalPopup() {
//                    var vpRND = Math.random() * 20;
//                    showModalDialog('\Auxiliar\\AcercaDe.aspx?rn=' + vpRND, '', 'dialogWidth=640px; dialogHeight=240px; center=yes; scrollbars=no');
//                }

        </script>

        <style type="text/css">
            .style6
            {
                height: 23px;
            }
            </style>

        </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">

    <table style="width:100%;" class="paneloscuro">
        <tr>
            <td class="style6" align="center">
                <asp:Label ID="lblTituloAUX" runat="server" 
                    Text="PAGINA PRINCIPAL" CssClass="texto20"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1" 
                    Font-Bold="True"></asp:Label>
                <asp:Label ID="lblCodRol" runat="server" Font-Size="Small" Text="2"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelprincipal" 
                    HorizontalAlign="Center" Width="100%">
                    <table style="width:100%;">
                        <tr>
                            <td valign="top" width="20%">
                                <asp:Panel ID="pnlDocentes" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgUsuarios" runat="server" Enabled="False" 
                                                    ImageUrl="~/Imagenes/menu/Usuarios.png" />
                                                <br />
                                                <asp:HyperLink ID="hUsuarios1" runat="server" CssClass="etiqueta10azul" 
                                                    NavigateUrl="~/Forms/wfrmDocente.aspx">Docentes</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlPersonas" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgDatosPersonales0" runat="server" Enabled="False" 
                                                    ImageUrl="~/Imagenes/menu/Personas.png" />
                                                <br />
                                                <asp:HyperLink ID="hDatosPersonas" runat="server" CssClass="etiqueta10azul" 
                                                    NavigateUrl="~/Forms/wfrmPersona.aspx">Personas</asp:HyperLink>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td valign="top" width="20%">
                                <asp:Panel ID="pnlPlanes" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgBuscar7" runat="server" Enabled="False" Height="48px" 
                                                    ImageUrl="~/Imagenes/menu/Planes.png" Width="48px" />
                                                <br />
                                                <asp:HyperLink ID="hPlanes" runat="server" CssClass="etiqueta10azul" 
                                                    NavigateUrl="~/Forms/wfrmPlan.aspx">Planes</asp:HyperLink>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td valign="top" width="20%">
                                <asp:Panel ID="pnlInformes" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgBuscar2" runat="server" Enabled="False" 
                                                    ImageUrl="~/Imagenes/menu/Informe.png" Height="48px" Width="48px" />
                                                <br />
                                                <asp:HyperLink ID="hArchivo" runat="server" CssClass="etiqueta10azul" 
                                                    NavigateUrl="~/Forms/wfrmInforme.aspx">Informes</asp:HyperLink>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td valign="top" width="20%">
                                <asp:Panel ID="pnlAsistencias" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgBuscar5" runat="server" Enabled="False" 
                                                    ImageUrl="~/Imagenes/menu/area.png" />
                                                <br />
                                                <asp:HyperLink ID="hArchivo3" runat="server" 
                                                    NavigateUrl="~/Forms/wfrmAsistencia.aspx" CssClass="etiqueta10azul">Permisos, Atrasos y Faltas</asp:HyperLink>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlFunciones" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgArchivo" runat="server" Enabled="False" 
                                                    ImageUrl="~/Imagenes/menu/digitalizacion.png" />
                                                <br />
                                                <asp:HyperLink ID="hInformes" runat="server" CssClass="etiqueta10azul" 
                                                    NavigateUrl="~/Forms/wfrmFuncion.aspx">Funciones</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td valign="top" width="20%">
                                <asp:Panel ID="pnlAsignacionAF" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgBuscar4" runat="server" Enabled="False" 
                                                    ImageUrl="~/Imagenes/menu/Asignacion.png" />
                                                <br />
                                                <asp:HyperLink ID="hArchivo2" runat="server" CssClass="etiqueta10azul" 
                                                    NavigateUrl="~/Forms/wfrmAsignacionAF.aspx">Asignacion AF</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="pnlActivosFijos" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgActivosFijos" runat="server" Enabled="False" 
                                                    ImageUrl="~/Imagenes/menu/Registro.png" />
                                                <br />
                                                <asp:HyperLink ID="hActivosFijos" runat="server" CssClass="etiqueta10azul" 
                                                    NavigateUrl="~/Forms/wfrmActivosFijos.aspx">Activos Fijos</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
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
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

