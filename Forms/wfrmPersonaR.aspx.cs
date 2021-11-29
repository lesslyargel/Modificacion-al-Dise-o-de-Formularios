using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using wcfProyecto.Logica;
using Seguridad.Logica;
/*using Auditoria.Logica;*/
//new
using Datos;
using Negocio;
//
using System.Drawing;

using System.IO;
//nuevo
using System.Data.SqlClient;

public partial class wfrmPersonaR : System.Web.UI.Page
{
    string CI;
    int Cod;
    //clavedw
    //string Extension = string.Empty;
    //string NombreDW = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        // no existe sesiones aqui

        if (!Page.IsPostBack)
        {
            //combos
        }
    }

    // clean
    protected void LimpiarPersona()
    {
        //LIMPIEZA DE CAMPOS 
        txtCI.Text = "";
        txtEXT.Text = "";
        txtNombres.Text = "";
        txtPaterno.Text = "";
        txtMaterno.Text = "";
        txtDireccion.Text = "";
        txtTelefono.Text = "";
        txtCelular.Text = "";
        txtCorreo.Text = "";
        //txtBusqueda.Text = "";
        //BOTON
        btnAccionar.Text = "Registrar";
    }


    /// -------------------------------------
    /// Carga datos especificos al Formulario
    /// -------------------------------------
    protected void VerDatos()
    {
        int Cod;
        Cod = 0;

        clsPersona tp1 = new clsPersona();

        foreach (clsPersona tp2 in tp1.ObtenerPersona(Cod))
        {
            //CARGA DE DATOS
            txtCI.Text = tp2.CI;
            txtEXT.Text = tp2.EXP;
            txtNombres.Text = tp2.Nombres;
            txtPaterno.Text = tp2.Paterno;
            txtMaterno.Text = tp2.Materno;
            txtDireccion.Text = tp2.Direccion;
            txtTelefono.Text = tp2.Telefono;
            txtCorreo.Text = tp2.CorreoElectronico;
        }

    }

    //Registro Persona
    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        /* --- dw --- */
        if (btnAccionar.Text == "Continuar")
        {
            Response.Redirect("~/Login.aspx");
        }
        
        //if (btnAccionar.Text == "Siguiente")
        //{
        //    Limpiar();
        //    LimpiarDatosPersona();
        //}

        /* --- dw --- */

        int Cod;
        Cod = 0;

        // - dw - // --------------

        if (btnAccionar.Text == "Registrar")
        {
            clsPersona adi = new clsPersona();
            adi.AdicionarPersona(txtCI.Text, txtEXT.Text, txtNombres.Text, txtPaterno.Text, txtMaterno.Text, txtFechaNacimiento.Text, txtTelefono.Text, txtCelular.Text, txtDireccion.Text, txtCorreo.Text, 0);
            lblObservaciones.Text = "Adicion Satisfactoria";

            /* region loginpassword */
            #region loginpassword
            ////Pa armado login
            string[] loginS;
            string loginU;
            string apellido;

            ////Generacion de Login Usuario y Password
            loginS = txtNombres.Text.Split(' ');
            if (txtPaterno.Text == "")
            {
                apellido = txtMaterno.Text;
            }
            else
            {
                apellido = txtPaterno.Text;
            }
            loginU = Convert.ToString(loginS[0]).ToLower() + '.' + apellido.ToLower();

            if (apellido.Length >= 3)
            {
                //Adicionar Usuario
                clsUsuarios adiusuario = new clsUsuarios();
                adiusuario.AdicionarUsuario(txtCI.Text,(txtNombres.Text + ' ' + txtPaterno.Text + ' ' + txtMaterno.Text) ,loginU, txtCI.Text, 2, 0); //provisionalmente el rol 3
                lblObservaciones.Text = "Adicion Satisfactoria ......";

                //// Credenciales
                lblLogin.Text = loginU;
                lblPassword.Text = txtCI.Text;
                //Session["CI"] = txtCI.Text;
                //Session["loginU"] = loginU;
                
            }
            else
            {
                //lblObservaciones.Text = "Ingrese un apellido valido";
            }
            #endregion
            btnAccionar.Text = "Continuar";
            lblObservaciones.Text = lblObservaciones.Text + " " + "Guarde sus credenciales para Ingresar Nuevamente en el Sistema";
        }

    }


    #region Auditoria
    public void AdicionarAuditoria()
    {
        //Datos = ddlGestion.Items + "," + ddlEstadoCivil.Items + "," + ddlCaso.Items + "," + txtCarpeta.Text + "," + txtTomo.Text.ToUpper() + "," + txtCI.Text + "," + txtEXT.Text + "," + txtNombres.Text + "," + txtNombreArchivo.Text + "," + txtObservaciones.Text + "," + lblCodUsuario.Text + Estado.ToString();
        ////Datos = ddlGestion.Items + "," + ddlProcedencia.Items + "," + ddlCaso.Items + "," + txtCarpeta.Text + "," + txtTomo.Text.ToUpper() + "," + txtHR.Text + "," + txtDe.Text + "," + txtCITE.Text + "," + txtDescripcion.Text + "," + txtNombreArchivo.Text + "," + txtObservaciones.Text + "," + lblCodUsuario.Text + Estado.ToString();
        //audi.AdicionarAuditoria(Convert.ToInt32(lblCodUsuario.Text), lblTitulo.Text + ",obs:" + lblObservaciones.Text, Datos, Page.Request.Url.AbsoluteUri, Page.Request.TotalBytes);
    }
    #endregion

    //Fecha
    protected void imgbtnFecha_Click(object sender, ImageClickEventArgs e)
    {
        //mostramos u ocultamos la Fecha
        Fecha.Visible = !Fecha.Visible;
    }
    protected void Fecha_SelectionChanged(object sender, EventArgs e)
    {
        txtFechaNacimiento.Text = Fecha.SelectedDate.ToShortDateString();
    }
    protected void Fecha_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Day.IsSelectable = false;
        }
    }
}

