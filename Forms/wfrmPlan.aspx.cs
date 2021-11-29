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

/// -------------------------------------
/// Solo A D M I N I S T R A D O R
/// -------------------------------------

public partial class wfrmPlan : System.Web.UI.Page
{
    string CI;
    int Cod;
    //clavedw
    //string Extension = string.Empty;
    //string NombreDW = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CodRol"].ToString() == "2")
        {
            Response.Redirect("~/Forms/wfrmPlanU.aspx");
        }

        if (Session["CodUsuario"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            lblCodUsuario.Text = Session["CodUsuario"].ToString();
            lblCodRol.Text = Session["CodRol"].ToString();
        }

        if (!Page.IsPostBack)
        {
            ContarRegistros();
            txtPagina.Text = txtTotalPaginas.Text;
            ValidarBotones();

            // cargar combos
            CargarTipoPlan();
            CargarEvaluacion();

            // listado inicial
            ListarRegistros();
        }
    }

    /***** dw combos *****/
    protected void CargarTipoPlan()
    {
        clsTipoPlan lis = new clsTipoPlan();
        ddlTipoPlan.DataSource = lis.ListarTipoPlan(0, 0);
        ddlTipoPlan.DataValueField = "IdTipoPlan";
        ddlTipoPlan.DataTextField = "Descripcion";
        ddlTipoPlan.DataBind();
    }
    protected void CargarEvaluacion()
    {
        clsEvaluacion lis = new clsEvaluacion();
        ddlEvaluacion.DataSource = lis.ListarEvaluacion(0, 0);
        ddlEvaluacion.DataValueField = "IdEvaluacion";
        ddlEvaluacion.DataTextField = "Descripcion";
        ddlEvaluacion.DataBind();
    }

    /* listados */
    protected void ListarRegistros()
    {
        clsPlanV admi = new clsPlanV();
        gvDatos.DataSource = admi.ListarPlanV(Convert.ToInt32(txtPagina.Text), Convert.ToInt32(txtRango.Text));
        gvDatos.DataBind();
    }
    //ci
    protected void ListarRegistrosCI()
    {
        clsPlanV admi = new clsPlanV();
        gvDatos.DataSource = admi.ListarPlanCIV(txtCI.Text);
        gvDatos.DataBind();
    }
    //Persona
    protected void ListarPlanPalabra()
    {
        clsPlanV admi = new clsPlanV();
        gvDatos.DataSource = admi.ListarPlanPalabraV(txtBusqueda.Text);
        gvDatos.DataBind();
    }
    //Clean
    protected void LimpiarRegistros()
    {
        //LIMPIEZA DE CAMPOS
        txtCI.Text = "";
        txtNombreCompleto.Text = "";

        ddlTipoPlan.SelectedValue = "1";
        txtNota.Text = "";
        ddlEvaluacion.SelectedValue = "1";
        txtBusqueda.Text = "";
        chbDoc.Checked = false;
        txtBusqueda.Text = "";
        //BOTON
        btnAccionar.Text = "Registrar";
    }

    //Busqueda Persona
    protected void btniBusqueda_Click(object sender, ImageClickEventArgs e)
    {
        if (txtBusqueda.Text.Length > 2)
        {
            ListarPlanPalabra();
        }
        else
        {
            lblObservaciones.Text = "La busqueda debe contener al menos 3 caracteres. ";
        }
    }
    //Busqueda Usuario por CI
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

    protected void VerDatos()
    {
        Cod = Convert.ToInt32(lblCodigo.Text);
        int ADJUNTO = 0;

        clsPlan tp1 = new clsPlan();
        foreach (clsPlan tp2 in tp1.ObtenerPlan(Cod))
        {
            //CARGA DE DATOS
            CI = tp2.CI;
            ddlTipoPlan.SelectedValue = tp2.IdTipoPlan.ToString();
            ddlEvaluacion.SelectedValue = tp2.IdEvaluacion.ToString();
            ADJUNTO = tp2.Adjunto;
            txtNota.Text = tp2.Nota;
        }

        //CheckBox
        if (ADJUNTO == 1)
        {
            chbDoc.Checked = true;
        }
        else
        {
            chbDoc.Checked = false;
        }

        //Usuario
        clsUsuarios tp100 = new clsUsuarios();
        foreach (clsUsuarios tp200 in tp100.ObtenerUsuarioCI(CI))
        {
            //CARGA DE DATOS
            txtCI.Text = tp200.CI;
            txtNombreCompleto.Text = tp200.NombreCompleto;
        }
    }


    #region Auditoria
    //public void AdicionarAuditoria()
    //{
    //    //Datos = ddlGestion.Items + "," + ddlEstadoCivil.Items + "," + ddlCaso.Items + "," + txtCarpeta.Text + "," + txtTomo.Text.ToUpper() + "," + txtCI.Text + "," + txtEXT.Text + "," + txtNombres.Text + "," + txtNombreArchivo.Text + "," + txtObservaciones.Text + "," + lblCodUsuario.Text + Estado.ToString();
    //    ////Datos = ddlGestion.Items + "," + ddlProcedencia.Items + "," + ddlCaso.Items + "," + txtCarpeta.Text + "," + txtTomo.Text.ToUpper() + "," + txtHR.Text + "," + txtDe.Text + "," + txtCITE.Text + "," + txtDescripcion.Text + "," + txtNombreArchivo.Text + "," + txtObservaciones.Text + "," + lblCodUsuario.Text + Estado.ToString();
    //    //audi.AdicionarAuditoria(Convert.ToInt32(lblCodUsuario.Text), lblTitulo.Text + ",obs:" + lblObservaciones.Text, Datos, Page.Request.Url.AbsoluteUri, Page.Request.TotalBytes);
    //}
    #endregion

    #region habilitacion

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        //habilitando registro vacio
        RegistroVacio();

        //Habiltaciones
        pnlDatos.Visible = true;

        //Limpiar
        LimpiarRegistros();
    }

    //registro vacio nuevo
    protected void RegistroVacio()
    {
        clsPlan adi = new clsPlan();
        adi.AdicionarPlan(CI, 1, 0, 1, "", Convert.ToInt32(lblCodUsuario.Text));
        lblObservaciones.Text = "Registro Nuevo";
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
        valor = gvDatos.Rows[val].Cells[7].Text;
        lblCodigo.Text = valor;

        LimpiarRegistros();

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
        valor = gvDatos.Rows[val].Cells[7].Text;
        lblCodigo.Text = valor;

        LimpiarRegistros();

        btnAccionar.Text = "Modificar";
        lblTitulo.Text = "Modificacion de Registro - Archivo";

        VerDatos();

        //this.pnlDatos_ModalPopupExtender.Show();
    }

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
                e.Row.Cells[7].Controls.Add(hlnk);
            }
            if (DEstado == 0)
            {
                e.Row.BackColor = Color.Silver;
                e.Row.ForeColor = Color.Lavender;
                //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/Inactivo.png";
                e.Row.Cells[7].Controls.Add(hlnk);
                //if (rbTipoMuestra.SelectedIndex == 1)
                //    e.Row.Visible = false;
            }
        }
    }

    #endregion

    #region paginacion

    protected void ContarRegistros()
    {
        int divisor;

        clsPlan tp1 = new clsPlan();
        foreach (clsPlan tp2 in tp1.ContarPlanes())
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

    protected void btniBajarPlan_Click(object sender, ImageClickEventArgs e)
    {
        //imgBajarCarta.Enabled = false;

        clsPlan tp1 = new clsPlan();
        foreach (clsPlan tp2 in tp1.ObtenerPlanCI(CI))
        {
            lblCodigo.Text = tp2.IdPlan.ToString();
        }

        //Descargar
        Descargar();
    }

    protected void Descargar()
    {
        DataTable dt = AccesoLogica.descargarPLAN(Convert.ToInt32(lblCodigo.Text));
        try
        {
            string x = dt.Rows[0][0].ToString();
            download(dt);
        }
        catch
        {
            lblObservaciones.Text = "Estado: No existe el Id.";
        }
    }

    private void download(DataTable dt)
    {
        Byte[] bytes = (Byte[])dt.Rows[0]["DOC"];
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application / pdf"; //dt.Rows[0]["Tipo"].ToString();
        Response.AddHeader("content-disposition", "attachment; filename=" + (dt.Rows[0]["CI"].ToString() + "PLAN.pdf"));
        //Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["Nombre"].ToString());
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }


    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        /* --- dw --- */

        int ADJUNTO = 0;
        if (chbDoc.Checked)
        {
            ADJUNTO = 1;
        }

        /* --- dw --- */

        clsPlan modi = new clsPlan();
        modi.ModificarPlan(Convert.ToInt32(lblCodigo.Text), txtCI.Text, Convert.ToInt32(ddlTipoPlan.SelectedValue), Convert.ToInt32(ddlEvaluacion.SelectedValue), txtNota.Text, Convert.ToInt32(lblCodUsuario.Text));
        lblObservaciones.Text = "Modificacion Satisfactoria";

        ListarRegistros();
    }
}

