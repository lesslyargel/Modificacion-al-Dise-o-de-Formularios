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
//using Auditoria.Logica;

using System.Drawing;

public partial class wfrmAccesoUsuario : System.Web.UI.Page
{
    int Estado;

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

            if (lblCodRol.Text == "1")
            {
                ListarAccesosFullUsuario();
                CargarComboDeUsuarios();
                lblUsuario.Visible = true;
                ddlUsuario.Visible = true;
            }
            else
            {
                ListarAccesosPorUsuario();
                pnlBotones.Visible = false;
            }
        }

    }

    protected void CargarComboDeUsuarios()
    {
        /*
        clsUsuarios admi = new clsUsuarios();
        ddlUsuario.DataSource = admi.ListarUsuarios(0, 0);
        ddlUsuario.DataValueField = "IdUsuario";
        ddlUsuario.DataTextField = "NombreCompleto";
        ddlUsuario.DataBind();
        */
    }

    protected void ListarAccesosFullUsuario()
    {
        clsAccesoUsuario admi = new clsAccesoUsuario();
        //gvDatos.DataSource = admi.ListarAccesosFullUsuario(Convert.ToInt32(txtPagina.Text), Convert.ToInt32(txtRango.Text));
        //gvDatos.DataBind();
    }

    protected void ListarAccesosPorUsuario()
    {
        clsAccesoUsuario adm = new clsAccesoUsuario();
        //gvDatos.DataSource = adm.ListarAccesosPorUsuario(Convert.ToInt32(lblCodUsuario.Text));
        //gvDatos.DataBind();
    }

    protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string CodU;
        //CodU = ddlUsuario.SelectedValue.ToString();
        //ListarAccesosPorUsuario();

        clsAccesoUsuario adm = new clsAccesoUsuario();
        //gvDatos.DataSource = adm.ListarAccesosPorUsuario(Convert.ToInt32(ddlUsuario.SelectedValue));
        //gvDatos.DataBind();
    }

    protected void txtFecha_TextChanged(object sender, EventArgs e)
    {
        string FechaCapturada = txtFecha.Text;
    }

    #region paginacion

    protected void ContarRegistros()
    {
        int divisor;

        /*
        clsAccesoUsuario tp1 = new clsAccesoUsuario();
        foreach (clsAccesoUsuario tp2 in tp1.ContarAccesosUsuario())
        {
            txtTotal.Text = tp2.TotalR.ToString();
        }
        */

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
        ListarAccesosFullUsuario();
        ContarRegistros();
        ValidarBotones();
    }
    protected void btnAnt_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) - 1);
        ListarAccesosFullUsuario();
        ContarRegistros();
        ValidarBotones();
    }
    protected void btnSig_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) + 1);
        ListarAccesosFullUsuario();
        ContarRegistros();
        ValidarBotones();
    }
    protected void btnFin_Click(object sender, EventArgs e)
    {
        txtPagina.Text = txtTotalPaginas.Text;
        ListarAccesosFullUsuario();
        ContarRegistros();
        ValidarBotones();
    }

    #endregion

}