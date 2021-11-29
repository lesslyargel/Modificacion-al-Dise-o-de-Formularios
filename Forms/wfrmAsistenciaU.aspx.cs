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

public partial class wfrmAsistenciaU : System.Web.UI.Page
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
            CargaTipoAsistencia();
            CargaMes();

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
    protected void CargaTipoAsistencia()
    {
        clsTipoAsistencia lis = new clsTipoAsistencia();
        ddlTipoAsistencia.DataSource = lis.ListarTipoAsistencia(0, 0);
        ddlTipoAsistencia.DataValueField = "IdTipoAsistencia";
        ddlTipoAsistencia.DataTextField = "Descripcion";
        ddlTipoAsistencia.DataBind();
    }

    protected void CargaMes()
    {
        clsMes lis = new clsMes();
        ddlMes.DataSource = lis.ListarMes(0, 0);
        ddlMes.DataValueField = "IdMes";
        ddlMes.DataTextField = "Descripcion";
        ddlMes.DataBind();
    }

    /* mis registros */
    protected void ListarRegistrosCI()
    {
        clsAsistenciaV admi = new clsAsistenciaV();
        gvDatos.DataSource = admi.ListarAsistenciaCIV(txtCI.Text);
        gvDatos.DataBind();
    }

    
    //clean
    protected void LimpiarRegistro()
    {
        //LIMPIEZA DE CAMPOS 
        txtCI.Text = "";
        txtNombreCompleto.Text = "";

        //txtBusqueda.Text = "";
        ddlMes.SelectedValue = "1";
        ddlTipoAsistencia.SelectedValue = "1";
        txtNumero.Text = "";
        //BOTON
        //btnAccionar.Text = "Registrar";
    }
  

   /// -------------------------------------
   /// Carga datos especificos al Formulario
   /// -------------------------------------
    protected void VerDatos()
    {
        Cod = Convert.ToInt32(lblCodigo.Text);

        clsAsistencia tp1 = new clsAsistencia();
        foreach (clsAsistencia tp2 in tp1.ObtenerAsistencia(Cod))
        {
            //CARGA DE DATOS
            txtCI.Text = tp2.CI;
            txtGestion.Text = tp2.Gestion.ToString();
            ddlMes.SelectedValue = tp2.IdMes.ToString();
            ddlTipoAsistencia.SelectedValue = tp2.IdTipoAsistencia.ToString();
            txtNumero.Text = tp2.Numero.ToString();
        }

        clsUsuarios tp10 = new clsUsuarios();
        foreach (clsUsuarios tp20 in tp10.ObtenerUsuarioCI(txtCI.Text))
        {
            //CARGA DE DATOS
            txtCI.Text = tp20.CI;
            txtNombreCompleto.Text = tp20.NombreCompleto;
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
        valor = gvDatos.Rows[val].Cells[8].Text;
        lblCodigo.Text = valor;

        LimpiarRegistro();

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
        valor = gvDatos.Rows[val].Cells[8].Text;
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
                e.Row.Cells[8].Controls.Add(hlnk);
            }
            if (DEstado == 0)
            {
                e.Row.BackColor = Color.Silver;
                e.Row.ForeColor = Color.Lavender;
                //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/Inactivo.png";
                e.Row.Cells[8].Controls.Add(hlnk);
                //if (rbTipoMuestra.SelectedIndex == 1)
                //    e.Row.Visible = false;
            }
        }
    }

    #endregion


}

