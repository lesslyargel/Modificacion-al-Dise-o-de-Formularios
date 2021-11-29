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
//*using Auditoria.Logica;*/
//new
using Datos;
using Negocio;
//
using System.Drawing;

using System.IO;
//nuevo
using System.Data.SqlClient;
using System.Text;

/// -------------------------------------
/// Solo A D M I N I S T R A D O R
/// -------------------------------------

public partial class wfrmAsignacionAF : System.Web.UI.Page
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
            Response.Redirect("~/Forms/wfrmAsignacionAFU.aspx");
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
            CargaEstadoActivoFijo();

            // listado inicial
            ListarRegistros();
        }

    }

    /***** dw combos *****/
    protected void CargaEstadoActivoFijo()
    {
        clsEstadoActivoFijo lis = new clsEstadoActivoFijo();
        ddlEstadoActivoFijo.DataSource = lis.ListarEstadoActivoFijo(0, 0);
        ddlEstadoActivoFijo.DataValueField = "IdEstadoActivoFijo";
        ddlEstadoActivoFijo.DataTextField = "Descripcion";
        ddlEstadoActivoFijo.DataBind();
    }

    /* listados */
    protected void ListarRegistros()
    {
        clsAsignacionAFV admi = new clsAsignacionAFV();
        gvDatos.DataSource = admi.ListarAsignacionAFV(Convert.ToInt32(txtPagina.Text), Convert.ToInt32(txtRango.Text));
        gvDatos.DataBind();
    }
    /*mis*/
    protected void ListarRegistrosCI()
    {
        clsAsignacionAFV admi = new clsAsignacionAFV();
        gvDatos.DataSource = admi.ListarAsignacionAFCIV(txtCI.Text);
        gvDatos.DataBind();
    }
    /* palabra */
    protected void ListarRegistroPalabra()
    {
        clsAsignacionAFV admi = new clsAsignacionAFV();
        gvDatos.DataSource = admi.ListarAsignacionAFPalabraV(txtBusqueda.Text);
        gvDatos.DataBind();
    }

    //clean
    protected void LimpiarRegistro()
    {
        //LIMPIEZA DE CAMPOS 
        txtCI.Text = "";
        txtNombreCompleto.Text = "";

        txtCodigoActivoFijo.Text = "";
        txtDescripcion.Text = "";
        txtCaracteristicas.Text = "";
        txtObservacion.Text = "";
        ddlEstadoActivoFijo.SelectedValue = "1";
        //BOTON
        btnAccionar.Text = "Registrar";
    }

    //Busqueda por Palabra
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
    //Busqueda ActivoFijo por Codigo
    protected void btniBusquedaAF_Click(object sender, ImageClickEventArgs e)
    {
        clsActivoFijo tp1 = new clsActivoFijo();
        foreach (clsActivoFijo tp2 in tp1.ObtenerActivoFijoCodigoAF(txtCodigoActivoFijo.Text))
        {
            //CARGA DE DATOS
            txtCodigoActivoFijo.Text = tp2.CodigoActivoFijo;
            txtDescripcion.Text = tp2.Descripcion;
            txtCaracteristicas.Text = tp2.Caracteristicas;
            txtObservacion.Text = tp2.Observacion;
            ddlEstadoActivoFijo.SelectedValue = tp2.IdEstadoActivoFijo.ToString();
        }

        CI = txtCI.Text;
        ListarRegistrosCI();
    }

    /// -------------------------------------
    /// Carga datos especificos al Formulario
    /// -------------------------------------
    protected void VerDatos()
    {
        int Cod;
        Cod = Convert.ToInt32(lblCodigo.Text);

        clsAsignacionAF tp1 = new clsAsignacionAF();

        foreach (clsAsignacionAF tp2 in tp1.ObtenerAsignacionAF(Cod))
        {
            //CARGA DE DATOS
            CI = tp2.CI;
            txtCodigoActivoFijo.Text = tp2.CodigoActivoFijo;
        }

        clsActivoFijo tp10 = new clsActivoFijo();
        foreach (clsActivoFijo tp20 in tp10.ObtenerActivoFijoCodigoAF(txtCodigoActivoFijo.Text))
        {
            //CARGA DE DATOS
            txtCodigoActivoFijo.Text = tp20.CodigoActivoFijo;
            txtDescripcion.Text = tp20.Descripcion;
            txtCaracteristicas.Text = tp20.Caracteristicas;
            txtObservacion.Text = tp20.Observacion;
            ddlEstadoActivoFijo.SelectedValue = tp20.IdEstadoActivoFijo.ToString();
        }

        clsUsuarios tp100 = new clsUsuarios();
        foreach (clsUsuarios tp200 in tp100.ObtenerUsuarioCI(CI))
        {
            //CARGA DE DATOS
            txtCI.Text = tp200.CI;
            txtNombreCompleto.Text = tp200.NombreCompleto;
        }
    }

    //Registro ActivoFijo
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
            clsAsignacionAF adi = new clsAsignacionAF();
            adi.AdicionarAsignacionAF(txtCI.Text, txtCodigoActivoFijo.Text, Convert.ToInt32(lblCodUsuario.Text));
            lblObservaciones.Text = "Adicion Satisfactoria";            
        }

        if (btnAccionar.Text == "Eliminar")
        {
            clsAsignacionAF eli = new clsAsignacionAF();
            eli.EliminarAsignacionAF(Cod);
            lblObservaciones.Text = "Eliminacion Satisfactoria";
        }

        ListarRegistros();
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
        //Habiltaciones
        pnlDatos.Visible = true;

        //Limpiar
        LimpiarRegistro();

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
        valor = gvDatos.Rows[val].Cells[6].Text;
        lblCodigo.Text = valor;

        LimpiarRegistro();

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
        valor = gvDatos.Rows[val].Cells[6].Text;
        lblCodigo.Text = valor;

        LimpiarRegistro();

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
                e.Row.Cells[6].Controls.Add(hlnk);
            }
            if (DEstado == 0)
            {
                e.Row.BackColor = Color.Silver;
                e.Row.ForeColor = Color.Lavender;
                //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/Inactivo.png";
                e.Row.Cells[6].Controls.Add(hlnk);
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

        clsAsignacionAF tp1 = new clsAsignacionAF();
        foreach (clsAsignacionAF tp2 in tp1.ContarAsignacionAF())
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
    }

    public void ExportGridToExcel()
    {
        StringBuilder builder = new StringBuilder();
        string strFileName = "GridviewExcel_" + DateTime.Now.ToShortDateString() + ".csv";
        builder.Append("ci, nombrecompleto, codigo, descripcion " + Environment.NewLine);

        foreach (GridViewRow row in gvDatos.Rows)
        {
            string ci = row.Cells[1].Text;
            string nombrecompleto = row.Cells[2].Text;
            string codigo = row.Cells[3].Text;
            string descripcion = row.Cells[4].Text;
            builder.Append(ci + "," + nombrecompleto + "," + codigo + "," + descripcion + Environment.NewLine);
        }

        Response.Clear();
        Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + strFileName);
        Response.Write(builder.ToString());
        Response.End();
    }
}

