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
using wcfProyecto.Logica;
using Auditoria.Logica;

using System.Drawing;

public partial class wfrmUsuarios : System.Web.UI.Page
{
    int Estado;
    string Datos;
    clsAuditoria audi = new clsAuditoria();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["CodUsuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                lblCodUsuario.Text = Session["CodUsuario"].ToString();
                lblCodProcedencia.Text = Session["CodProcedencia"].ToString();
                lblCodRol.Text = Session["CodRol"].ToString();
            }

            ContarUsuarios();
            txtPagina.Text = txtTotalPaginas.Text;
            ValidarBotones();

            ListarUsuarios();

            CargarComboRol();
            CargarComboCaso();
        }
    }

    /***** dw *****/
    protected void CargarComboRol()
    {
        clsRoles lis = new clsRoles();
        ddlRol.DataSource = lis.ListarRoles(0, 0);
        ddlRol.DataValueField = "IdRol";
        ddlRol.DataTextField = "Descripcion";
        ddlRol.DataBind();
    }

    protected void CargarComboCaso()
    {
        clsCaso lisdw = new clsCaso();
        ddlCaso.DataSource = lisdw.ListarCasos(0, 0);
        ddlCaso.DataValueField = "IdCaso";
        ddlCaso.DataTextField = "Descripcion";
        ddlCaso.DataBind();
    }
    /***** dw *****/

    protected void ListarUsuarios()
    {
        clsUsuarios admi = new clsUsuarios();
        gvDatos.DataSource = admi.ListarUsuarios(Convert.ToInt32(txtPagina.Text), Convert.ToInt32(txtRango.Text));
        gvDatos.DataBind();
    }

    protected void Limpiar()
    {
        chbEstado.Checked = true;
        lblObservaciones.Text = "";
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void VerDatos()
    {
        int Cod;
        Cod = Convert.ToInt32(lblCodigo.Text);
        clsUsuarios tp1 = new clsUsuarios();

        foreach (clsUsuarios tp2 in tp1.ObtenerUsuario(Cod))
        {
            txtLoginUsuario.Text = tp2.LoginUsuario.Trim();
            txtNombreCompleto.Text = tp2.NombreCompleto.Trim();
            ddlRol.SelectedValue = tp2.IdRol.ToString();

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
        int Cod = Convert.ToInt32(lblCodigo.Text);

        if (chbEstado.Checked)
        {
            Estado = 1;
        }
        else
        {
            Estado = 0;
        }

        if (btnAccionar.Text == "Eliminar")
        {
            clsUsuarios eli = new clsUsuarios();

            eli.EliminarUsuario(Cod);
            lblObservaciones.Text = "Eliminacion Satisfactoria";
        }

        // solo se modifica el rol del usuario
        if (btnAccionar.Text == "Modificar")
        {
            clsUsuarios modi = new clsUsuarios();
            modi.ModificarUsuario(Cod, txtLoginUsuario.Text, Convert.ToInt32(ddlRol.SelectedValue), Convert.ToInt32(ddlCaso.SelectedValue), Estado);
            lblObservaciones.Text = "Modificacion Satisfactoria";
        }

        // poner el CI del usuario registrado como password por defecto - resetear
        if (btnAccionar.Text == "Resetear")
        {
            string nombre_completo = "";
            clsUsuarios tp1 = new clsUsuarios();
            foreach (clsUsuarios tp2 in tp1.ObtenerUsuario(Cod))
            {
                nombre_completo = tp2.NombreCompleto.Trim();
            }

            string ci = "";
            clsPersona tp10 = new clsPersona();
            foreach (clsPersona tp20 in tp10.ObtenerPersonaNombreCompleto(nombre_completo))
            {
                ci = tp20.CI.Trim();
            }

            clsUsuarios mod = new clsUsuarios();
            mod.ModificarSoloPassword(Cod, ci, 1);
        }

        // para finalizar procesos
        
        AdicionarAuditoria();
        ListarUsuarios();
        Limpiar();
    }

    #region Auditoria
    public void AdicionarAuditoria()
    {
        Datos = txtNombreCompleto.Text + "," + txtLoginUsuario.Text + "," + ddlRol.Text + "," + Estado.ToString();
        audi.AdicionarAuditoria(Convert.ToInt32(lblCodUsuario.Text), lblTitulo.Text + ",obs:" + lblObservaciones.Text, Datos, Page.Request.Url.AbsoluteUri, Page.Request.TotalBytes);
    }
    #endregion

    #region habilitacion

    protected void gvDatos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string valor;
        int val;

        GridViewRow row = gvDatos.Rows[e.RowIndex];
        val = row.RowIndex;
        valor = gvDatos.Rows[val].Cells[7].Text;
        lblCodigo.Text = valor;

        Limpiar();

        btnAccionar.Text = "Eliminar";
        lblTitulo.Text = "Eliminacion de Registro - USUARIO";

        //txtCuentaUsuario.Enabled = false;
        //txtNombreCompleto.Enabled = false;
        //chbEstado.Enabled = false;

        VerDatos();
        this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void gvDatos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string valor;
        int val;
        GridViewRow row = gvDatos.Rows[e.NewEditIndex];
        val = row.RowIndex;
        valor = gvDatos.Rows[val].Cells[7].Text;
        lblCodigo.Text = valor;

        Limpiar();

        btnAccionar.Text = "Modificar";
        lblTitulo.Text = "Modificacion de Registro - USUARIO";

        //txtCuentaUsuario.Enabled = false;
        //txtNombreCompleto.Enabled = false;
        //chbEstado.Enabled = true;

        VerDatos();
        this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void imgReset_Click(object sender, ImageClickEventArgs e)
    {
        Limpiar();

        btnAccionar.Text = "Resetear";
        lblTitulo.Text = "RESETEO de Registro - USUARIO";

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
                if (rbTipoMuestra.SelectedIndex == 1)
                    e.Row.Visible = false;
            }
        }
    }

    protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        string valor;
        //int val;

        GridViewRow row = gvDatos.SelectedRow;
        valor = row.Cells[7].Text;
        lblCodigo.Text = valor;

        //Session["CodRol"] = Convert.ToInt32(lblCodigo.Text);
        //Response.Redirect("wfrmPrincipal.aspx");

        Limpiar();

        btnAccionar.Text = "Resetear";
        lblTitulo.Text = "Resetear Login & Password";

        chbEstado.Enabled = true;

        VerDatos();
        this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void rbTipoMuestra_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarUsuarios();
    }

    #region paginacion

    protected void ContarUsuarios()
    {
        int divisor;

        clsUsuarios tp1 = new clsUsuarios();
        foreach (clsUsuarios tp2 in tp1.ContarUsuarios())
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
        ListarUsuarios();
        ContarUsuarios();
        ValidarBotones();
    }
    protected void btnAnt_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) - 1);
        ListarUsuarios();
        ContarUsuarios();
        ValidarBotones();
    }
    protected void btnSig_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) + 1);
        ListarUsuarios();
        ContarUsuarios();
        ValidarBotones();
    }
    protected void btnFin_Click(object sender, EventArgs e)
    {
        txtPagina.Text = txtTotalPaginas.Text;
        ListarUsuarios();
        ContarUsuarios();
        ValidarBotones();
    }

    #endregion



}