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

public partial class wfrmDocenteU : System.Web.UI.Page
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
            //cargar combos

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

    /* mis registros */
    protected void ListarRegistrosCI()
    {
        clsDocenteV admi = new clsDocenteV();
        gvDatos.DataSource = admi.ListarDocentesCIV(txtCI.Text);
        gvDatos.DataBind();
    }

    //Clean
    protected void LimpiarRegistro()
    {
        //LIMPIEZA DE CAMPOS 
        txtCI.Text = "";
        txtNombreCompleto.Text = "";

        txtAnosServicio.Text = "";
        //txtBusqueda.Text = "";
        chbFOTO.Checked = false;
        chbDoc.Checked = false;
        //BOTON
        btnAccionar.Text = "Registrar";
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

        //obtener datos usuario
        ObtenerDatosUsuario();
    }
    //Registro Docente
    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        /* --- dw --- */

        /* --- dw --- */
        
        int Cod = Convert.ToInt32(lblCodigo.Text);

        // - dw - // --------------

        if (btnAccionar.Text == "Registrar")
        {
            clsDocente adi = new clsDocente();
            adi.ModificarDocente(Convert.ToInt32(lblCodigo.Text), txtCI.Text, Convert.ToInt32(txtAnosServicio.Text), Convert.ToInt32(lblCodUsuario.Text));
            lblObservaciones.Text = "Adicion Satisfactoria";
        }

        if (btnAccionar.Text == "Eliminar")
        {
            clsDocente eli = new clsDocente();
            eli.EliminarDocente(Cod);
            lblObservaciones.Text = "Eliminacion Satisfactoria";
        }

        if (btnAccionar.Text == "Modificar")
        {
            clsDocente modi = new clsDocente();
            modi.ModificarDocente(Convert.ToInt32(lblCodigo.Text), txtCI.Text, Convert.ToInt32(txtAnosServicio.Text), Convert.ToInt32(lblCodUsuario.Text));
            lblObservaciones.Text = "Modificacion Satisfactoria";
        }

        ListarRegistrosCI();

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

        //Listado
        ListarRegistrosCI();
    }

    //registro vacio nuevo
    protected void RegistroVacio()
    {
        clsDocente adi = new clsDocente();
        adi.AdicionarDocente(txtCI.Text, 0, Convert.ToInt32(lblCodUsuario.Text));
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
        valor = gvDatos.Rows[val].Cells[7].Text;
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

    protected void btniSubirFOTO_Click(object sender, ImageClickEventArgs e)
    {
        //string CI = "";
        string Archivo = "FOTO"; // tipoArchivo
        CI = txtCI.Text;

        //FILEUPLOAD FOTO
        #region ARCHIVO fileuploadname
        if (FileUploadFOTO.HasFile)
        {
            string ext = System.IO.Path.GetExtension(this.FileUploadFOTO.PostedFile.FileName); //cut PostedFile
            if (ext == ".docx" || ext == ".xlsx" || ext == ".doc" || ext == ".xls" || ext == ".pdf" || ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                if (FileUploadFOTO.PostedFile.ContentLength < 1024000)
                {
                    //adicionando archivo version 1.1 dw
                    clsDocente adi = new clsDocente();
                    adi.ModificarDocenteFOTO(Convert.ToInt32(lblCodigo.Text), FileUploadFOTO.FileBytes, Convert.ToInt32(lblCodUsuario.Text));

                    lblObservaciones.Text = " El archivo " + Archivo + " se subio correctamente. ";

                    chbFOTO.Checked = true;
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

    protected void btniSubirCV_Click(object sender, ImageClickEventArgs e)
    {
        //string CI = "";
        string Archivo = "CV"; // tipoArchivo
        CI = txtCI.Text;

        //FILEUPLOAD CV
        #region ARCHIVO fileuploadname
        if (FileUploadCV.HasFile)
        {
            string ext = System.IO.Path.GetExtension(this.FileUploadCV.PostedFile.FileName); //cut PostedFile
            if (ext == ".docx" || ext == ".xlsx" || ext == ".doc" || ext == ".xls" || ext == ".pdf" || ext == ".jpg" || ext == ".png" || ext == ".jpeg")
            {
                if (FileUploadCV.PostedFile.ContentLength < 1024000)
                {
                    //adicionando archivo version 1.1 dw
                    clsDocente adi = new clsDocente();
                    adi.ModificarDocenteCV(Convert.ToInt32(lblCodigo.Text), FileUploadCV.FileBytes, Convert.ToInt32(lblCodUsuario.Text));

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

