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

public partial class wfrmFuncion : System.Web.UI.Page
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
            Response.Redirect("~/Forms/wfrmFuncionU.aspx");
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

            //combos
            CargaMateria();
            CargaComision();
            CargaCurso();

            // listado inicial
            ListarRegistros();

        }

    }

    /***** dw combos *****/
    protected void CargaMateria()
    {
        clsMateria lis = new clsMateria();
        ddlMateria.DataSource = lis.ListarMateria(0, 0);
        ddlMateria.DataValueField = "IdMateria";
        ddlMateria.DataTextField = "Descripcion";
        ddlMateria.DataBind();
    }
    protected void CargaCurso()
    {
        clsCurso lis = new clsCurso();
        ddlCurso.DataSource = lis.ListarCurso(0, 0);
        ddlCurso.DataValueField = "IdCurso";
        ddlCurso.DataTextField = "Descripcion";
        ddlCurso.DataBind();
    }
    protected void CargaComision()
    {
        clsComision lis = new clsComision();
        ddlComision.DataSource = lis.ListarComision(0, 0);
        ddlComision.DataValueField = "IdComision";
        ddlComision.DataTextField = "Descripcion";
        ddlComision.DataBind();
    }

    /* listados */
    protected void ListarRegistros()
    {
        clsFuncionV admi = new clsFuncionV();
        gvDatos.DataSource = admi.ListarFuncionV(Convert.ToInt32(txtPagina.Text), Convert.ToInt32(txtRango.Text));
        gvDatos.DataBind();
    }
    /*mis*/
    protected void ListarRegistrosCI()
    {
        clsFuncionV admi = new clsFuncionV();
        gvDatos.DataSource = admi.ListarFuncionCIV(txtCI.Text);
        gvDatos.DataBind();
    }
    /* palabra */
    protected void ListarRegistroPalabra()
    {
        clsFuncionV admi = new clsFuncionV();
        gvDatos.DataSource = admi.ListarFuncionPalabraV(txtBusqueda.Text);
        gvDatos.DataBind();
    }
    
    //clean
    protected void LimpiarRegistro()
    {
        //LIMPIEZA DE CAMPOS 
        txtCI.Text = "";
        txtNombreCompleto.Text = "";

        ddlMateria.SelectedValue = "1";
        ddlCurso.SelectedValue = "1";
        txtParalelo.Text = "";
        ddlComision.SelectedValue = "1";
        txtBusqueda.Text = "";

        ddlMateria.SelectedValue = "1";
        ddlCurso.SelectedValue = "1";
        txtParalelo.Text = "";
        ddlComision.SelectedValue = "1";
        txtBusqueda.Text = "";
        //BOTON
        btnAccionar.Text = "Registrar";
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
        int Cod;
        Cod = Convert.ToInt32(lblCodigo.Text);

        clsFuncion tp1 = new clsFuncion();
        foreach (clsFuncion tp2 in tp1.ObtenerFuncion(Cod))
        {
            //CARGA DE DATOS
            txtCI.Text = tp2.CI;
            ddlMateria.SelectedValue = tp2.IdMateria.ToString();
            ddlCurso.SelectedValue = tp2.IdCurso.ToString();
            txtParalelo.Text = tp2.Paralelo;
            ddlComision.SelectedValue = tp2.IdComision.ToString();
        }

        clsUsuarios tp100 = new clsUsuarios();
        foreach (clsUsuarios tp200 in tp100.ObtenerUsuarioCI(txtCI.Text))
        {
            //CARGA DE DATOS
            txtCI.Text = tp200.CI;
            txtNombreCompleto.Text = tp200.NombreCompleto;
        }
    }

    //Registro Funcion
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
            clsFuncion adi = new clsFuncion();
            adi.AdicionarFuncion(txtCI.Text, Convert.ToInt32(ddlMateria.SelectedValue), Convert.ToInt32(ddlCurso.SelectedValue), txtParalelo.Text, Convert.ToInt32(ddlComision.SelectedValue), Convert.ToInt32(lblCodUsuario.Text));
            lblObservaciones.Text = "Adicion Satisfactoria";
        }

        if (btnAccionar.Text == "Eliminar")
        {
            clsFuncion eli = new clsFuncion();
            eli.EliminarFuncion(Cod);
            lblObservaciones.Text = "Eliminacion Satisfactoria";
        }

        if (btnAccionar.Text == "Modificar")
        {
            clsFuncion modi = new clsFuncion();
            modi.ModificarFuncion(Cod, txtCI.Text, Convert.ToInt32(ddlMateria.SelectedValue), Convert.ToInt32(ddlCurso.SelectedValue), txtParalelo.Text, Convert.ToInt32(ddlComision.SelectedValue), Convert.ToInt32(lblCodUsuario.Text));
            lblObservaciones.Text = "Modificacion Satisfactoria";
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
        valor = gvDatos.Rows[val].Cells[8].Text;
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
        valor = gvDatos.Rows[val].Cells[8].Text;
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

    #region paginacion

    protected void ContarRegistros()
    {
        int divisor;

        clsFuncion tp1 = new clsFuncion();
        foreach (clsFuncion tp2 in tp1.ContarFunciones())
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


}

