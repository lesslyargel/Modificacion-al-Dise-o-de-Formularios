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

public partial class wfrmPlanU : System.Web.UI.Page
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
            CargarTipoPlan();

            //obtener datos usuario
            ObtenerDatosUsuario();

            //Registro Vacio
            RegistroVacio();

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
    protected void CargarTipoPlan()
    {
        clsTipoPlan lis = new clsTipoPlan();
        ddlTipoPlan.DataSource = lis.ListarTipoPlan(0, 0);
        ddlTipoPlan.DataValueField = "IdTipoPlan";
        ddlTipoPlan.DataTextField = "Descripcion";
        ddlTipoPlan.DataBind();
    }

    /* mis registros */
    protected void ListarRegistrosCI()
    {
        clsPlanV admi = new clsPlanV();
        gvDatos.DataSource = admi.ListarPlanCIV(txtCI.Text);
        gvDatos.DataBind();
    }

    //Clean
    protected void LimpiarRegistros()
    {
        //LIMPIEZA DE CAMPOS
        txtCI.Text = "";
        txtNombreCompleto.Text = "";

        ddlTipoPlan.SelectedValue = "1";
        //txtNota.Text = "";
        //ddlEvaluacion.SelectedValue = "1";
        //txtBusqueda.Text = "";
        chbDoc.Checked = false;
        //txtBusqueda.Text = "";

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
            ADJUNTO = tp2.Adjunto;
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

        //obtener datos usuario
        ObtenerDatosUsuario();
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


    //registro vacio nuevo
    protected void RegistroVacio()
    {
        clsPlan adi = new clsPlan();
        adi.AdicionarPlan(txtCI.Text, 2, 0, 1, "", Convert.ToInt32(lblCodUsuario.Text));
        adi.AdicionarPlan(txtCI.Text, 3, 0, 1, "", Convert.ToInt32(lblCodUsuario.Text));
        adi.AdicionarPlan(txtCI.Text, 4, 0, 1, "", Convert.ToInt32(lblCodUsuario.Text));
        adi.AdicionarPlan(txtCI.Text, 5, 0, 1, "", Convert.ToInt32(lblCodUsuario.Text));
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
        valor = gvDatos.Rows[val].Cells[6].Text;
        lblCodigo.Text = valor;

        LimpiarRegistros();

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

        LimpiarRegistros();

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

    protected void btniSubirDOC_Click(object sender, ImageClickEventArgs e)
    {
        //string CI = "";
        string Archivo = "DOC"; // tipoArchivo
        CI = txtCI.Text;

        //FILEUPLOAD FOTO
        #region ARCHIVO fileuploadname
        if (FileUploadDOC.HasFile)
        {
            string ext = System.IO.Path.GetExtension(this.FileUploadDOC.PostedFile.FileName); //cut PostedFile
            if (ext == ".docx" || ext == ".xlsx" || ext == ".doc" || ext == ".xls" || ext == ".pdf" || ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                if (FileUploadDOC.PostedFile.ContentLength < 1024000)
                {
                    //adicionando archivo version 1.1 dw
                    clsPlan adi = new clsPlan();
                    adi.ModificarPlanDOC(Convert.ToInt32(lblCodigo.Text), FileUploadDOC.FileBytes, Convert.ToInt32(lblCodUsuario.Text));

                    lblObservaciones.Text = " El archivo " + Archivo + " se subio correctamente. ";

                    chbDoc.Checked = true;
                }
                else
                {
                    lblObservaciones.Text = " Tamaño maximo de Archivo 1Mb. ";
                }
            }
            else
            {
                lblObservaciones.Text = " Formatos válidos: .pdf  .jpg  .png  .jpeg";
            }
        }
        else
        {
            lblObservaciones.Text = "Seleccione un Archivo";
        }

        #endregion

        ListarRegistrosCI();
    }

    protected void btniBajarDOC_Click(object sender, ImageClickEventArgs e)
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


}

