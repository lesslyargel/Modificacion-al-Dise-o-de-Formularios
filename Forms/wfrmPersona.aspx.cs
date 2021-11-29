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
//Excel
using System.Text;
//itect
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.pdf.parser;

/// -------------------------------------
/// Solo A D M I N I S T R A D O R
/// -------------------------------------

public partial class wfrmPersona : System.Web.UI.Page
{
    string CI;
    int Cod;
    //clavedw
    //string Extension = string.Empty;
    //string NombreDW = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["CodUsuario"] == null)
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
        //else
        //{
        //    lblCodUsuario.Text = Session["CodUsuario"].ToString();
        //    lblCodRol.Text = Session["CodRol"].ToString();
        //}

        if (!Page.IsPostBack)
        {
            ContarRegistros();
            txtPagina.Text = txtTotalPaginas.Text;
            ValidarBotones();
            
            // cargar combos

            // listado inicial
            ListarRegistros();
        }

        
    }

    protected void ListarRegistros()
    {
        clsPersona admi = new clsPersona();
        gvDatos.DataSource = admi.ListarPersonas(Convert.ToInt32(txtPagina.Text), Convert.ToInt32(txtRango.Text));
        gvDatos.DataBind();
    }
    //ci
    protected void ListarRegistrosCI()
    {
        clsInformeV admi = new clsInformeV();
        gvDatos.DataSource = admi.ListarInformeCIV(txtCI.Text);
        gvDatos.DataBind();
    }
    protected void ListarBusquedaPersona()
    {
        clsPersona admi = new clsPersona();
        gvDatos.DataSource = admi.ListarBusquedaPersona(txtBusqueda.Text);
        gvDatos.DataBind();
    }

    //Busqueda Persona
    protected void btniBusqueda_Click(object sender, ImageClickEventArgs e)
    {
        if (txtBusqueda.Text.Length > 2)
        {
            ListarBusquedaPersona();
        }
        else
        {
            lblObservaciones.Text = "La busqueda debe contener al menos 3 caracteres. ";
        }
    }

    protected void btniBusquedaCI_Click(object sender, ImageClickEventArgs e)
    {
        clsUsuarios tp1 = new clsUsuarios();
        foreach (clsUsuarios tp2 in tp1.ObtenerUsuarioCI(txtCI.Text))
        {
            //CARGA DE DATOS
            txtCI.Text = tp2.CI;
            txtNombreCompleto.Text = tp2.NombreCompleto;
        }

        ListarRegistrosCI();
    }

    protected void LimpiarPersona()
    {
        //LIMPIEZA DE CAMPOS 
        txtCI.Text = "";
        txtEXT.Text = "";
        txtNombreCompleto.Text = "";
        txtPaterno.Text = "";
        txtMaterno.Text = "";
        txtDireccion.Text = "";
        txtTelefono.Text = "";
        txtCelular.Text = "";
        txtCorreo.Text = "";
        txtBusqueda.Text = "";
        //BOTON
        btnAccionar.Text = "Registrar";
    }

    /// -------------------------------------
    /// Carga datos especificos al Formulario
    /// -------------------------------------
    protected void VerDatos()
    {
        Cod = Convert.ToInt32(lblCodigo.Text);

        clsPersona tp1 = new clsPersona();

        foreach (clsPersona tp2 in tp1.ObtenerPersona(Cod))
        {
            //CARGA DE DATOS
            txtCI.Text = tp2.CI;
            txtNombreCompleto.Text = tp2.Nombres;

            txtEXT.Text = tp2.EXP;
            txtNombreCompleto.Text = tp2.Nombres;
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

        //if (btnAccionar.Text == "Siguiente")
        //{
        //    Limpiar();
        //    LimpiarDatosPersona();
        //}

        /* --- dw --- */

        int Cod = Convert.ToInt32(lblCodigo.Text);

        // - dw - // --------------

        if (btnAccionar.Text == "Registrar")
        {
            clsPersona adi = new clsPersona();
            adi.AdicionarPersona(txtCI.Text, txtEXT.Text, txtNombreCompleto.Text, txtPaterno.Text, txtMaterno.Text, txtFechaNacimiento.Text, txtTelefono.Text, txtCelular.Text, txtDireccion.Text, txtCorreo.Text, 0);
            lblObservaciones.Text = "Adicion Satisfactoria";

            /* region loginpassword */
            #region loginpassword
            ////Pa armado login
            string[] loginS;
            string loginU;
            string apellido;

            ////Generacion de Login Usuario y Password
            loginS = txtNombreCompleto.Text.Split(' ');
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
                adiusuario.AdicionarUsuario(txtCI.Text,(txtNombreCompleto.Text + ' ' + txtPaterno.Text + ' ' + txtMaterno.Text) ,loginU, txtCI.Text, 2, Convert.ToInt32(lblCodUsuario.Text)); //provisionalmente el rol 3
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

            lblObservaciones.Text = lblObservaciones.Text + " " + "Guarde sus credenciales para Ingresar Nuevamente en el Sistema";
        }

        if (btnAccionar.Text == "Eliminar")
        {
            clsPersona eli = new clsPersona();
            eli.EliminarPersona(Cod);
            lblObservaciones.Text = "Eliminacion Satisfactoria";
        }

        if (btnAccionar.Text == "Modificar")
        {
            clsPersona modi = new clsPersona();
            modi.ModificarPersona(Cod, txtCI.Text, txtEXT.Text, txtNombreCompleto.Text, txtPaterno.Text, txtMaterno.Text, txtFechaNacimiento.Text, txtTelefono.Text, txtCelular.Text, txtDireccion.Text, txtCorreo.Text, 0);
            lblObservaciones.Text = "Modificacion Satisfactoria";

            /* region loginpassword */
            #region loginpassword
            ////Pa armado login
            string[] loginS;
            string loginU;
            string apellido;

            ////Generacion de Login Usuario y Password
            loginS = txtNombreCompleto.Text.Split(' ');
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
                clsUsuarios modiusuario = new clsUsuarios();
                modiusuario.ModificarUsuarioPassword(txtCI.Text, loginU, txtCI.Text, Convert.ToInt32(lblCodUsuario.Text)); //provisionalmente el rol 3
                lblObservaciones.Text = "Modificacion Satisfactoria ......";

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

            lblObservaciones.Text = lblObservaciones.Text + " " + "Guarde sus credenciales para Ingresar Nuevamente en el Sistema";
        }

        //Listados
        ListarRegistros();
    }


    #region Auditoria
    public void AdicionarAuditoria()
    {
        //Datos = ddlGestion.Items + "," + ddlEstadoCivil.Items + "," + ddlCaso.Items + "," + txtCarpeta.Text + "," + txtTomo.Text.ToUpper() + "," + txtCI.Text + "," + txtEXT.Text + "," + txtNombres.Text + "," + txtNombreArchivo.Text + "," + txtObservaciones.Text + "," + lblCodUsuario.Text + Estado.ToString();
        ////Datos = ddlGestion.Items + "," + ddlProcedencia.Items + "," + ddlCaso.Items + "," + txtCarpeta.Text + "," + txtTomo.Text.ToUpper() + "," + txtHR.Text + "," + txtDe.Text + "," + txtCITE.Text + "," + txtDescripcion.Text + "," + txtNombreArchivo.Text + "," + txtObservaciones.Text + "," + lblCodUsuario.Text + Estado.ToString();
        //audi.AdicionarAuditoria(Convert.ToInt32(lblCodUsuario.Text), lblTitulo.Text + ",obs:" + lblObservaciones.Text, Datos, Page.Request.Url.AbsoluteUri, Page.Request.TotalBytes);
    }
    #endregion

    #region habilitacion

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        //Habiltaciones
        pnlDatos.Visible = true;

        //Limpiar
        LimpiarPersona();

        btnAccionar.Text = "Registrar";
        //lblTitulo.Text = "Adicion de Registro - Archivo";
    }

    protected void gvDatos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //aux
        pnlDatos.Visible = true;
        // aux

        string valor;
        int val;

        GridViewRow row = gvDatos.Rows[e.RowIndex];
        val = row.RowIndex;
        valor = gvDatos.Rows[val].Cells[9].Text;
        lblCodigo.Text = valor;

        LimpiarPersona();

        btnAccionar.Text = "Eliminar";
        lblTitulo.Text = "Eliminacion de Registro - Archivo";

        VerDatos();

        //this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void gvDatos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //aux
        pnlDatos.Visible = true;
        // aux

        string valor;
        int val;
        GridViewRow row = gvDatos.Rows[e.NewEditIndex];
        val = row.RowIndex;
        valor = gvDatos.Rows[val].Cells[9].Text;
        lblCodigo.Text = valor;

        LimpiarPersona();

        btnAccionar.Text = "Modificar";
        lblTitulo.Text = "Modificacion de Registro - Archivo";

        VerDatos();

        //this.pnlDatos_ModalPopupExtender.Show();
    }

    #endregion

    protected void gvDatos_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int DEstado;
            DEstado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "EstadoRegistro"));

            if (DEstado == 1)
            {
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/Activo.png";
                e.Row.Cells[9].Controls.Add(hlnk);
            }
            if (DEstado == 0)
            {
                e.Row.BackColor = Color.Silver;
                e.Row.ForeColor = Color.Lavender;
                //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/Inactivo.png";
                e.Row.Cells[9].Controls.Add(hlnk);
                //if (rbTipoMuestra.SelectedIndex == 1)
                //    e.Row.Visible = false;
            }
        }
    }

    #region paginacion

    protected void ContarRegistros()
    {
        int divisor;

        clsPersona tp1 = new clsPersona();
        foreach (clsPersona tp2 in tp1.ContarPersonas())
        {
            txtTotal.Text = tp2.TotalR.ToString();
        }

        divisor = Convert.ToInt32(txtTotal.Text) / Convert.ToInt32(txtRango.Text);

        if (Convert.ToInt32(txtTotal.Text) % Convert.ToInt32(txtRango.Text) > 0)
        {
            txtTotalPaginas.Text = Convert.ToString(divisor + 1);
        }
        else
        {
            txtTotalPaginas.Text = Convert.ToString(divisor);
        }
    }
    protected void ValidarBotones()
    {
        if (Convert.ToInt32(txtPagina.Text) == 1)
        {
            btnAnt.Enabled = false;
            btnIni.Enabled = false;
        }
        else
        {
            btnAnt.Enabled = true;
            btnIni.Enabled = true;
        }
        if (Convert.ToInt32(txtPagina.Text) == Convert.ToInt32(txtTotalPaginas.Text))
        {
            btnSig.Enabled = false;
            btnFin.Enabled = false;
        }
        else
        {
            btnSig.Enabled = true;
            btnFin.Enabled = true;
        }
    }

    protected void btnIni_Click(object sender, EventArgs e)
    {
        txtPagina.Text = "1";
        ContarRegistros();
        ValidarBotones();

            ListarRegistros();
    }
    protected void btnAnt_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) - 1);
        ContarRegistros();
        ValidarBotones();

            ListarRegistros();
    }
    protected void btnSig_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) + 1);
        ContarRegistros();
        ValidarBotones();

            ListarRegistros();
    }
    protected void btnFin_Click(object sender, EventArgs e)
    {
        txtPagina.Text = txtTotalPaginas.Text;
        ContarRegistros();
        ValidarBotones();


            ListarRegistros();
    }

    #endregion

    protected void btniExportar_Click(object sender, ImageClickEventArgs e)
    {
        ExportGridToExcel();
        //ExportAUX();
    }

    //protected void ExportToExcel(object sender, EventArgs e)
    //{
        
    //}
    public void ExportGridToExcel()
    {
        StringBuilder builder = new StringBuilder();
        string strFileName = "GridviewExcel_" + DateTime.Now.ToShortDateString() + ".csv";
        builder.Append("ci, nombres, paterno, materno " + Environment.NewLine);

        foreach (GridViewRow row in gvDatos.Rows)
        {
            string ci = row.Cells[2].Text;
            string nombres = row.Cells[3].Text;
            string paterno = row.Cells[4].Text;
            string materno = row.Cells[5].Text;
            builder.Append(ci + "," + nombres + "," + paterno + "," + materno + Environment.NewLine);
        }

        Response.Clear();
        Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + strFileName);
        Response.Write(builder.ToString());
        Response.End();
    }

    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    /* Verifies that the control is rendered */
    //}

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
        if(e.Day.IsOtherMonth)
        {
            e.Day.IsSelectable = false;
        }  
    }


}

