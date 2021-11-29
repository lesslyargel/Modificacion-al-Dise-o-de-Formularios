<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcercaDe.aspx.vb" Inherits="Auxiliar_AcercaDe" StylesheetTheme ="Modal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

            #form1
            {
                width: 600px;
            }

        </style>
    <base target="_self" />
</head>
<body style="width: 600px" >
    <form id="form1" runat="server" >
            <div align="center" class="panelprincipal">
                <asp:Label ID="lblTitulo0" runat="server" Text="Acerca De:" 
                    CssClass="texto20"></asp:Label>
                <table style="width:100%;">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label22" runat="server" CssClass="etiqueta10" 
                                style="text-align: left" 
                                Text="UERBO" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="40%">
                            <asp:Label ID="Label7" runat="server" CssClass="etiqueta10" 
                                style="text-align: left" Text="Desarrollado en :"></asp:Label>
                        </td>
                        <td align="left" width="60%">
                            <asp:Label ID="Label8" runat="server" CssClass="etiqueta10" 
                                style="text-align: left" 
                                Text="3L &amp; WCF"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label15" runat="server" CssClass="etiqueta10" 
                                style="text-align: left" Text="Diseño apoyado en :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label16" runat="server" CssClass="etiqueta10" 
                                style="text-align: left" Text="AjaxControlToolKit, Framework 3.5"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label10" runat="server" CssClass="etiqueta10" 
                                style="text-align: left" Text="Gestion :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label21" runat="server" CssClass="etiqueta10" 
                                style="text-align: left" 
                                Text="2021"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label19" runat="server" CssClass="etiqueta10" 
                                style="text-align: left" Text="email :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label18" runat="server" CssClass="etiqueta10" 
                                style="text-align: left" Text="davidwilly@hotmail.com"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/facebook16.png" />
                        </td>
                        <td align="left">
                            <asp:Label ID="Label20" runat="server" CssClass="etiqueta10" 
                                style="text-align: left" Text="david willy"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnCerrar0" runat="server" 
                            Text="Cerrar" onclick="btnCerrar_Click" 
                    CssClass="boton150normal" />
            </div>
    </form>
</body>
</html>
