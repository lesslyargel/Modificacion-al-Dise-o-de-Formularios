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

public partial class wfrmDocente : System.Web.UI.Page
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
            Response.Redirect("~/Forms/wfrmDocenteU.aspx");
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

            //cargar combos

            // listado inicial
            ListarRegistros();
        }

    }
    /* listados */
    protected void ListarRegistros()
    {
        clsDocenteV admi = new clsDocenteV();
        gvDatos.DataSource = admi.ListarDocentesV(Convert.ToInt32(txtPagina.Text), Convert.ToInt32(txtRango.Text));
        gvDatos.DataBind();
    }
    /* mis registros */
    protected void ListarRegistrosCI()
    {
        clsDocenteV admi = new clsDocenteV();
        gvDatos.DataSource = admi.ListarDocentesCIV(txtCI.Text);
        gvDatos.DataBind();
    }
    /* palabra */
    protected void ListarRegistroPalabra()
    {
        clsDocenteV admi = new clsDocenteV();
        gvDatos.DataSource = admi.ListarDocentePalabraV(txtBusqueda.Text);
        gvDatos.DataBind();
    }
    //Clean
    protected void LimpiarRegistro()
    {
        //LIMPIEZA DE CAMPOS 
        txtCI.Text = "";
        txtNombreCompleto.Text = "";
        
        txtAnosServicio.Text = "";
        txtBusqueda.Text = "";
        chbFOTO.Checked = false;
        chbDoc.Checked = false;
        //BOTON
        //btnAccionar.Text = "Registrar";
    }

    //Busqueda Persona
    protected void btniBusqueda_Click(object sender, ImageClickEventArgs e)
    {
        if (txtBusqueda.Text.Length > 2)
        {
            ListarRegistroPalabra();
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
    /// -------------------------------------
    /// Carga datos especificos al Formulario
    /// -------------------------------------
    protected void VerDatos()
    {
        Cod = Convert.ToInt32(lblCodigo.Text);
        int ADJUNTO = 0;
        int ADJUNTOFOTO = 0;

        clsDocente tp1 = new clsDocente();
        foreach (clsDocente tp2 in tp1.ObtenerDocente(Cod))
        {
            //CARGA DE DATOS
            CI = tp2.CI;
            txtAnosServicio.Text = tp2.AnosServicio.ToString();
            ADJUNTO = tp2.Adjunto;
            ADJUNTOFOTO = tp2.AdjuntoFOTO;
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
        //CheckBox
        if (ADJUNTOFOTO == 1)
        {
            chbFOTO.Checked = true;
        }
        else
        {
            chbFOTO.Checked = false;
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
    //Registro Docente

    #region Auditoria
    //public void AdicionarAuditoria()
    //{
    //    //Datos = ddlGestion.Items + "," + ddlEstadoCivil.Items + "," + ddlCaso.Items + "," + txtCarpeta.Text + "," + txtTomo.Text.ToUpper() + "," + txtCI.Text + "," + txtEXT.Text + "," + txtNombres.Text + "," + txtNombreArchivo.Text + "," + txtObservaciones.Text + "," + lblCodUsuario.Text + Estado.ToString();
    //    ////Datos = ddlGestion.Items + "," + ddlProcedencia.Items + "," + ddlCaso.Items + "," + txtCarpeta.Text + "," + txtTomo.Text.ToUpper() + "," + txtHR.Text + "," + txtDe.Text + "," + txtCITE.Text + "," + txtDescripcion.Text + "," + txtNombreArchivo.Text + "," + txtObservaciones.Text + "," + lblCodUsuario.Text + Estado.ToString();
    //    //audi.AdicionarAuditoria(Convert.ToInt32(lblCodUsuario.Text), lblTitulo.Text + ",obs:" + lblObservaciones.Text, Datos, Page.Request.Url.AbsoluteUri, Page.Request.TotalBytes);
    //}
    #endregion

    #region habilitacion

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

        LimpiarRegistro();

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

        LimpiarRegistro();

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

        clsDocente tp1 = new clsDocente();
        foreach (clsDocente tp2 in tp1.ContarDocentes())
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

    protected void btniBajarFOTO_Click(object sender, ImageClickEventArgs e)
    {
        //imgBajarCarta.Enabled = false;

        clsDocente tp1 = new clsDocente();
        foreach (clsDocente tp2 in tp1.ObtenerDocenteCI(CI))
        {
            lblCodigo.Text = tp2.IdDocente.ToString();
        }

        //Descargar
        DescargarFOTO();
    }

    protected void DescargarFOTO()
    {
        DataTable dt = AccesoLogica.descargarFOTO(Convert.ToInt32(lblCodigo.Text));
        try
        {
            string x = dt.Rows[0][0].ToString();
            downloadFOTO(dt);
        }
        catch
        {
            lblObservaciones.Text = "Estado: No existe el Id.";
        }
    }

    private void downloadFOTO(DataTable dt)
    {
        Byte[] bytes = (Byte[])dt.Rows[0]["FOTO"];
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application / pdf"; //dt.Rows[0]["Tipo"].ToString();
        Response.AddHeader("content-disposition", "attachment; filename=" + (dt.Rows[0]["CI"].ToString() + "FOTO.pdf"));
        //Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["Nombre"].ToString());
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }

    protected void btniBajarCV_Click(object sender, ImageClickEventArgs e)
    {
        //imgBajarCarta.Enabled = false;

        clsDocente tp1 = new clsDocente();
        foreach (clsDocente tp2 in tp1.ObtenerDocenteCI(CI))
        {
            lblCodigo.Text = tp2.IdDocente.ToString();
        }

        //Descargar
        DescargarCV();
    }

    protected void DescargarCV()
    {
        DataTable dt = AccesoLogica.descargarCV(Convert.ToInt32(lblCodigo.Text));
        try
        {
            string x = dt.Rows[0][0].ToString();
            downloadCV(dt);
        }
        catch
        {
            lblObservaciones.Text = "Estado: No existe el Id.";
        }
    }

    private void downloadCV(DataTable dt)
    {
        Byte[] bytes = (Byte[])dt.Rows[0]["CV"];
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application / pdf"; //dt.Rows[0]["Tipo"].ToString();
        Response.AddHeader("content-disposition", "attachment; filename=" + (dt.Rows[0]["CI"].ToString() + "CV.pdf"));
        //Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["Nombre"].ToString());
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }

}

