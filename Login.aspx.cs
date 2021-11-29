using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;

using Seguridad.Logica;
//using Auditoria.Logica;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            Session.Abandon();
            Session["LoginUsuario"] = "LoginUsuario";

            txtLogin.Focus();
            txtLogin.Text = "";
            txtPassword.Text = "";
        }

    }

    protected void Limpiar()
    {
        txtLogin.Focus();
        txtLogin.Text = "";
        txtPassword.Text = "";

        lblPass.Text = "Contraseña :";
        btnIngreso.Text = "Ingresar";

        pnlCambioPassword.Visible = false;

        btnCambioPassword.Visible = true;
        //btnRegistro1.Visible = true;

        lblObservaciones.Text = "";
    }
    internal string generarMD5(string sCadena)
    {
        UnicodeEncoding ueCodigo = new UnicodeEncoding();
        MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
        byte[] bHash = Md5.ComputeHash(ueCodigo.GetBytes(sCadena));
        return Convert.ToBase64String(bHash);
    }
    internal string generarSHA(string sCadena)
    {
        UnicodeEncoding ueCodigo = new UnicodeEncoding();
        SHA512Managed SHA = new SHA512Managed();
        byte[] bHash = SHA.ComputeHash(ueCodigo.GetBytes(sCadena));
        return Convert.ToBase64String(bHash);
    }

    public static string SHA512(string input)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(input);
        using (var hash = System.Security.Cryptography.SHA512.Create())
        {
            var hashedInputBytes = hash.ComputeHash(bytes);

            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new System.Text.StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        int CodUsuario = 0, Estado = 0, CodRol = 0, CodDepartamento = 0;
        string CI = "", NombreCompleto = "", LoginUsuario = "", Password = "";

        //Verificando Login y Password del Usuario
        clsUsuarios tp10 = new clsUsuarios();
        foreach (clsUsuarios tp2 in tp10.VerificarUsuarioLoginPassword(txtLogin.Text, generarMD5(txtPassword.Text)))
        {
            CodUsuario = tp2.IdUsuario;
            CI = tp2.CI;
            NombreCompleto = tp2.NombreCompleto;
            CodRol = tp2.IdRol;

            LoginUsuario = tp2.LoginUsuario;
            Password = tp2.PasswordHash;

            Estado = tp2.EstadoRegistro;
        }

        #region UsuarioExistente
        if (CodUsuario != 0)
        {
            #region ingreso_principal
            if (btnIngreso.Text == "Ingresar")
            {
                if ((LoginUsuario != "" && Password != ""))
                {
                    Session["CodUsuario"] = CodUsuario;
                    Session["CodRol"] = CodRol;
                    Session["CodDepartamento"] = CodDepartamento;
                    Session["NombreCompleto"] = NombreCompleto;
                    Session["CI"] = CI;
                    Session["LoginUsuario"] = LoginUsuario;

                    lblObservaciones.Text = "";
                    Response.Redirect("~/wfrmPrincipal.aspx");
                }
                else
                {
                    lblObservaciones.Text = "El Login de Usuario o Contraseña no son admitidos";
                }

            }
            #endregion
        }
        else
        {
            lblObservaciones.Text = "No se pudo autenticar al Usuario con los parámetros introducidos.";
        }

        //Modificacion de Password
        #region Modificar
        if (btnIngreso.Text == "Modificar")
        {

            if ((LoginUsuario != "" && Password != ""))
            {
                if (txtPasswordNuevo.Text == txtPasswordBIS.Text && txtPasswordNuevo.Text.Length > 1)
                {
                    clsUsuarios modi = new clsUsuarios();
                    modi.ModificarSoloPassword(CodUsuario, txtPasswordNuevo.Text);

                    //Response.Redirect("~/Login.aspx");
                    Limpiar();

                    lblObservaciones.Text = "Cambio de Contraseña Satisfactorio";
                }
                else
                {
                    lblObservaciones.Text = "Repita correctamente su Nueva Contraseña";
                }
            }
            else
            {
                lblObservaciones.Text = "No se pudo autenticar al Usuario con los parametros introducidos...";
                //Response.Redirect("Default.aspx");
            }
        }
        #endregion

        #endregion
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void btnCambioPassword_Click(object sender, EventArgs e)
    {
        pnlCambioPassword.Visible = true;

        btnCambioPassword.Visible = false;
        //btnRegistro1.Visible = false;

        lblPass.Text = "Contraseña Actual :";
        btnIngreso.Text = "Modificar";
    }
    protected void btnRegistro1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/RegistroUsuario.aspx");
    }

}