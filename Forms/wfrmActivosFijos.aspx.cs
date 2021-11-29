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

/// -------------------------------------
/// Solo A D M I N I S T R A D O R
/// -------------------------------------

public partial class wfrmActivosFijos : System.Web.UI.Page
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
            ContarRegistros();
            txtPagina.Text = txtTotalPaginas.Text;
            ValidarBotones();

            //cargar combos
            CargaEstadoActivoFijo();

            //listado inicial
            ListarRegistros();
        }
    }

    /***** dw *****/
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
        clsActivoFijo admi = new clsActivoFijo();
        gvDatos.DataSource = admi.ListarActivosFijos(Convert.ToInt32(txtPagina.Text), Convert.ToInt32(txtRango.Text));
        gvDatos.DataBind();
    }
    /* palabra */
    protected void ListarRegistroPalabra()
    {
        clsActivoFijo admi = new clsActivoFijo();
        gvDatos.DataSource = admi.ListarActivoFijoPalabra(txtBusqueda.Text);
        gvDatos.DataBind();
    }

    protected void LimpiarRegistro()
    {
        //LIMPIEZA DE CAMPOS 
        txtCodigoActivoFijo.Text = "";
        txtDescripcion.Text = "";
        txtCaracteristicas.Text = "";
        txtObservacion.Text = "";
        ddlEstadoActivoFijo.SelectedValue = "1";
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

    /// -------------------------------------
    /// Carga datos especificos al Formulario
    /// -------------------------------------
    protected void VerDatos()
    {
        int Cod;
        Cod = Convert.ToInt32(lblCodigo.Text);

        clsActivoFijo tp1 = new clsActivoFijo();

        foreach (clsActivoFijo tp2 in tp1.ObtenerActivoFijo(Cod))
        {
            //CARGA DE DATOS
            txtCodigoActivoFijo.Text = tp2.CodigoActivoFijo;
            txtDescripcion.Text = tp2.Descripcion;
            txtCaracteristicas.Text = tp2.Caracteristicas;
            ddlEstadoActivoFijo.SelectedValue = tp2.IdEstadoActivoFijo.ToString();
            txtObservacion.Text = tp2.Observacion;
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
            clsActivoFijo adi = new clsActivoFijo();
            adi.AdicionarActivoFijo(txtCodigoActivoFijo.Text, txtDescripcion.Text, txtCaracteristicas.Text, txtObservacion.Text, Convert.ToInt32(ddlEstadoActivoFijo.SelectedValue), Convert.ToInt32(lblCodUsuario.Text));
            lblObservaciones.Text = "Adicion Satisfactoria";
        }

        if (btnAccionar.Text == "Eliminar")
        {
            clsActivoFijo eli = new clsActivoFijo();
            eli.EliminarActivoFijo(Cod);
            lblObservaciones.Text = "Eliminacion Satisfactoria";
        }

        if (btnAccionar.Text == "Modificar")
        {
            clsActivoFijo modi = new clsActivoFijo();
            modi.ModificarActivoFijo(Cod, txtCodigoActivoFijo.Text, txtDescripcion.Text, txtCaracteristicas.Text, txtObservacion.Text, Convert.ToInt32(ddlEstadoActivoFijo.SelectedValue), Convert.ToInt32(lblCodUsuario.Text));
            lblObservaciones.Text = "Modificacion Satisfactoria";
        }

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

        //LimpiarRegistro
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

    #region paginacion

    protected void ContarRegistros()
    {
        int divisor;

        clsActivoFijo tp1 = new clsActivoFijo();
        foreach (clsActivoFijo tp2 in tp1.ContarActivoFijos())
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

