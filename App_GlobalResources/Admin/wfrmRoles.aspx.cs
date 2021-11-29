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

using Seguridad.Logica;
using Auditoria.Logica;

using System.Drawing;

public partial class Administracion_wfrmRoles : System.Web.UI.Page
{
    int Estado;
    string Datos;
    clsAuditoria audi = new clsAuditoria();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CodUsuario"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            lblCodUsuario.Text = Session["CodUsuario"].ToString();
            //lblCodProcedencia.Text = Session["CodProcedencia"].ToString();
            lblCodRol.Text = Session["CodRol"].ToString();
        }

        if (!Page.IsPostBack)
        {
            ContarRegistros();
            txtPagina.Text = txtTotalPaginas.Text;
            ValidarBotones();

            ListarRoles();

            txtAbreviacion.Focus(); // Foco
        }
    }


    protected void ListarRoles()
    {
        clsRoles admi = new clsRoles();
        gvDatos.DataSource = admi.ListarRoles(Convert.ToInt32(txtPagina.Text), Convert.ToInt32(txtRango.Text));
        gvDatos.DataBind();
    }

    protected void Limpiar()
    {
        txtDescripcion.Text = "";
        txtAbreviacion.Text = "";

        chbEstado.Checked = true;
        lblObservaciones.Text = "";
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    /// -------------------------------------
    /// Carga datos especificos al Formulario
    /// -------------------------------------
    protected void VerDatos()
    {
        int Cod = Convert.ToInt32(lblCodigo.Text);
        clsRoles tp1 = new clsRoles();
        foreach (clsRoles tp2 in tp1.ObtenerRol(Cod))
        {
            txtAbreviacion.Text = tp2.Abreviacion;
            txtDescripcion.Text = tp2.Descripcion;

            if (tp2.IdEstado == 1)
            {
                chbEstado.Checked = true;
            }
            else
            {
                chbEstado.Checked = false;
            }
        }
    }

    protected void btnAccionar_Click(object sender, EventArgs e)
     {
         if (chbEstado.Checked)
         {
             Estado = 1;
         }
         else
         {
             Estado = 0;
         }

         if (btnAccionar.Text == "Registrar")
         {
             //Validar otras restricciones

             if (txtDescripcion.Text != "")
             {
                clsRoles adi = new clsRoles();
                adi.AdicionarRol(5, txtAbreviacion.Text, txtDescripcion.Text, Estado);
                lblObservaciones.Text = "Adicion Satisfactoria";
             }
             else
             {
                 lblObservaciones.Text = "Descripcion No Valida";
             }

         }

         if (btnAccionar.Text == "Eliminar")
         {
             int Cod;

             clsRoles eli = new clsRoles();
             Cod = Convert.ToInt32(lblCodigo.Text);

             eli.EliminarRol(Cod);
             lblObservaciones.Text = "Eliminacion Satisfactoria";
         }

         if (btnAccionar.Text == "Modificar")
         {
             int Cod = Convert.ToInt32(lblCodigo.Text);

             if (txtDescripcion.Text != "")
             {
                clsRoles modi = new clsRoles();
                modi.ModificarRol(Cod, 5, txtAbreviacion.Text, txtDescripcion.Text, Estado);
                lblObservaciones.Text = "Modificacion Satisfactoria";
             }
             else
             {
                lblObservaciones.Text = "Introduzca Descripcion";
             }
         } // fin

        // para finalizar procesos
        
        AdicionarAuditoria();
        ListarRoles();
        Limpiar();      
     }

    #region Auditoria
    public void AdicionarAuditoria()
    {
        Datos = txtAbreviacion.Text + "," + txtDescripcion.Text + "," + Estado.ToString();
        audi.AdicionarAuditoria(Convert.ToInt32(lblCodUsuario.Text), lblTitulo.Text + ",obs:" + lblObservaciones.Text, Datos, Page.Request.Url.AbsoluteUri, Page.Request.TotalBytes);
    }
    #endregion

    #region habilitacion

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Limpiar();

        btnAccionar.Text = "Registrar";
        lblTitulo.Text = "Adicion de Registro - ROLES";

        //Habilitar 
        txtDescripcion.Enabled = true;
        txtAbreviacion.Enabled = true;
        chbEstado.Enabled = true;

        this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void gvDatos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string valor;
        int val;

        GridViewRow row = gvDatos.Rows[e.RowIndex];
        val = row.RowIndex;
        valor = gvDatos.Rows[val].Cells[5].Text;
        lblCodigo.Text = valor;

        Limpiar();

        btnAccionar.Text = "Eliminar";
        lblTitulo.Text = "Eliminacion de Registro - ROLES";

        //Inhabilitar 
        txtDescripcion.Enabled = false;
        txtAbreviacion.Enabled = false;
        chbEstado.Enabled = false;

        VerDatos();

        this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void gvDatos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string valor;
        int val;
        GridViewRow row = gvDatos.Rows[e.NewEditIndex];
        val = row.RowIndex;
        valor = gvDatos.Rows[val].Cells[5].Text;
        lblCodigo.Text = valor;

        Limpiar();

        btnAccionar.Text = "Modificar";
        lblTitulo.Text = "Modificacion de Registro - ROLES";

        //Habilitar 
        txtDescripcion.Enabled = true;
        txtAbreviacion.Enabled = true;
        chbEstado.Enabled = true;

        VerDatos();

        this.pnlDatos_ModalPopupExtender.Show();
    }

    #endregion

    protected void gvDatos_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int DEstado;
            DEstado = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdEstado"));

            if (DEstado == 1)
            {
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/Activo.png";
                e.Row.Cells[5].Controls.Add(hlnk);
            }
            if (DEstado == 0)
            {
                e.Row.BackColor = Color.Silver;
                e.Row.ForeColor = Color.Lavender;
                //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/Inactivo.png";
                e.Row.Cells[5].Controls.Add(hlnk);
                if (rbTipoMuestra.SelectedIndex == 1)
                    e.Row.Visible = false;
            }
        }
    }
  
    protected void rbTipoMuestra_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarRoles();
    }

    #region paginacion

    protected void ContarRegistros()
    {
        int divisor;

        clsRoles tp1 = new clsRoles();
        foreach (clsRoles tp2 in tp1.ContarRoles())
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
        ListarRoles();
        ContarRegistros();
        ValidarBotones();
    }
    protected void btnAnt_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) - 1);
        ListarRoles();
        ContarRegistros();
        ValidarBotones();
    }
    protected void btnSig_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) + 1);
        ListarRoles();
        ContarRegistros();
        ValidarBotones();
    }
    protected void btnFin_Click(object sender, EventArgs e)
    {
        txtPagina.Text = txtTotalPaginas.Text;
        ListarRoles();
        ContarRegistros();
        ValidarBotones();
    }

    #endregion

    protected void ddlProcedencia_SelectedIndexChanged(object sender, EventArgs e)
    {
            ListarRoles();
    }
}