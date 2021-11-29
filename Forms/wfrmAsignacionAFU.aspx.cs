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

public partial class wfrmAsignacionAFU : System.Web.UI.Page
{
    string CI;
    int Cod;
    //clavedw
    //string Extension = string.Empty;
    //string NombreDW = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
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
            // cargar combos
            CargaEstadoActivoFijo();

            //obtener datos usuario
            ObtenerDatosUsuario();

            // listado inicial 
            ListarRegistrosCI();
        }

    }

    //obtener datos de Usuario
    protected void ObtenerDatosUsuario()
    {
        clsUsuarios tp1 = new clsUsuarios();
        foreach (clsUsuarios tp2 in tp1.ObtenerUsuario(Convert.ToInt32(lblCodUsuario.Text)))
        {
            //CARGA DE DATOS
            CI = tp2.CI;
            txtCI.Text = tp2.CI;
            txtNombreCompleto.Text = tp2.NombreCompleto;
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

    /* mis registros */
    protected void ListarRegistrosCI()
    {
        clsAsignacionAFV admi = new clsAsignacionAFV();
        gvDatos.DataSource = admi.ListarAsignacionAFCIV(txtCI.Text);
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
        //btnAccionar.Text = "Registrar";
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

