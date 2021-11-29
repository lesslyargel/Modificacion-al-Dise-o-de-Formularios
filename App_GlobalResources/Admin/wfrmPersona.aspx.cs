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

public partial class wfrmPersona : System.Web.UI.Page
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

            ListarRegistros();

            CargarComboRol();
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
    /***** dw *****/

    protected void Limpiar()
    {
        chbEstado.Checked = true;
        lblObservaciones.Text = "";
    }

    protected void ListarRegistros()
    {
        clsPersonaV admi = new clsPersonaV();
        gvDatos.DataSource = admi.ListarPersonasV(Convert.ToInt32(txtPagina.Text), Convert.ToInt32(txtRango.Text));
        gvDatos.DataBind();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void VerDatos()
    {
        int Cod = Convert.ToInt32(lblCodigo.Text);

        clsPersona tp1 = new clsPersona();
        foreach (clsPersona tp2 in tp1.ObtenerPersona(Cod))
        {
            txtCI.Text = tp2.CI;
            txtNombres.Text = tp2.Nombres;
            txtApellidop.Text = tp2.Paterno;
            txtApellidom.Text = tp2.Materno;
            
            //Obterer Institucion 
            clsInstitucion tp10 = new clsInstitucion();
            foreach (clsInstitucion tp20 in tp10.ObtenerInstitucion(tp2.IdInstitucion))
            {
                txtInstitucion.Text = tp20.Descripcion.ToString();
            }
            //Obterer Cargo 
            clsCargo tp100 = new clsCargo();
            foreach (clsCargo tp200 in tp100.ObtenerCargo(tp2.IdCargo))
            {
                txtCargo.Text = tp200.Descripcion.ToString();
            }
            // je je -- dw --

            if (tp2.IdEstado == 1)
            {
                chbEstado.Checked = true;
            }
            else
            {
                chbEstado.Checked = false;
            }
        }

        //recuperando datos de rol del usuario

        clsUsuarios tp11 = new clsUsuarios();
        txtNombrePersona.Text = txtNombres.Text.Trim() + ' ' + txtApellidop.Text.Trim() + ' ' + txtApellidom.Text.Trim();
        foreach (clsUsuarios tp21 in tp11.ObtenerIdPorNombreCompleto(txtNombrePersona.Text))
        {
            ddlRol.SelectedValue = tp21.IdRol.ToString();
           // ddlCaso.SelectedValue = tp21.IdCaso.ToString();  /aun no implementado
        }

    }

    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        //Pa armado login
        string[] loginS;
        string loginU, passwordU, apellido;
        //DW

        //1// Obteniendo Id institucion por descripcion
        int id_institucion = 0;
        clsInstitucion tp10 = new clsInstitucion();
        foreach (clsInstitucion tp20 in tp10.VerificarInstitucion(txtInstitucion.Text))
        {
            id_institucion = tp20.IdInstitucion;
            //..... lo demas no lo necesito
        }
        //Si la institucion no esta registrada agregar a instituciones
        if (id_institucion == 0)
        {
            clsInstitucion adii = new clsInstitucion();
            adii.AdicionarInstitucion("", txtInstitucion.Text);
        }
        // Otra vez intentamos obtener Id institucion por descripcion
        clsInstitucion tp100 = new clsInstitucion();
        foreach (clsInstitucion tp200 in tp100.VerificarInstitucion(txtInstitucion.Text))
        {
            id_institucion = tp200.IdInstitucion;
            //..... lo demas no lo necesito
        }

        ////4// Obteniendo Id cargo por descripcion
        int id_cargo = 0;
        clsCargo tp1051 = new clsCargo();
        foreach (clsCargo tp2051 in tp1051.VerificarCargo(txtCargo.Text))
        {
            id_cargo = tp2051.IdCargo;
            //..... lo demas no lo necesito
        }
        //Si la institucion no esta registrada agregar a instituciones
        if (id_cargo == 0)
        {
            clsCargo adid = new clsCargo();
            adid.AdicionarCargo(txtCargo.Text);
        }
        // Otra vez intentamos obtener Id institucion por descripcion
        clsCargo tp10710 = new clsCargo();
        foreach (clsCargo tp20710 in tp10710.VerificarCargo(txtCargo.Text))
        {
            id_cargo = tp20710.IdCargo;
            //..... lo demas no lo necesito
        }

        // - dw -

        if (chbEstado.Checked)
        {
            Estado = 1;
        }
        else
        {
            Estado = 0;
        }

        ////Generacion de Login Usuario y Password - parte 1
        loginS = txtNombres.Text.Split(' ');
        if (txtApellidop.Text == "")
        {
            apellido = txtApellidom.Text;
        }
        else
        {
            apellido = txtApellidop.Text;
        }
        loginU = Convert.ToString(loginS[0]).ToLower() + '.' + apellido.ToLower();
        lblLoginF.Text = loginU;

        //Adicionando Login Usuario Password nombrecompleto etc
        if (txtCI.Text != "")
        {
            passwordU = txtCI.Text;
        }
        else
        {
            passwordU = "123456";
        }

        if (btnAccionar.Text == "Registrar")
        {
            //Validar que no se pueda asignar el mismo Ejemplo al mismo usuario

            clsPersona adi = new clsPersona();
            adi.AdicionarPersona(txtCI.Text, txtNombres.Text, txtApellidop.Text, txtApellidom.Text, id_institucion, 1, 1 , id_cargo);
            lblObservaciones.Text = "Adicion Satisfactoria";

            //// Grabando Login y Usuario - parte 2
            if (ddlRol.SelectedValue != "0") // solo si escoge usuario diferente de 0 se registrara al usuario
            {
                ddlRol.Enabled = false;
                clsUsuarios adiusuario = new clsUsuarios();
                adiusuario.AdicionarUsuario(txtNombres.Text.Trim() + ' ' + txtApellidop.Text.Trim() + ' ' + txtApellidom.Text.Trim(), lblLoginF.Text, passwordU, Convert.ToInt32(ddlRol.SelectedValue), 2, 1); // Rol por si acaso // Sin Caso por si acaso
            }
            else
            {
                ddlRol.Enabled = true;
            }
            
        }

        if (btnAccionar.Text == "Eliminar")
        {
            int Cod;

            clsPersona eli = new clsPersona();
            Cod = Convert.ToInt32(lblCodigo.Text);

            eli.EliminarPersona(Cod);
            lblObservaciones.Text = "La Eliminacion fue satisfactoria";
        }

        if (btnAccionar.Text == "Modificar")
        {            
            int Cod = Convert.ToInt32(lblCodigo.Text);
            clsPersona modi = new clsPersona();

            modi.ModificarPersona(Cod, txtCI.Text, txtNombres.Text, txtApellidop.Text, txtApellidom.Text, id_institucion, 1, 1, id_cargo, Estado);
            lblObservaciones.Text = "Modificacion Satisfactoria";

            //// Grabando Login y Usuario - parte 2
            if (ddlRol.SelectedValue != "0") // solo si escoge usuario diferente de 0 se registrara al usuario
            {
                ddlRol.Enabled = false;
                clsUsuarios adiu = new clsUsuarios();
                adiu.AdicionarUsuario(txtNombres.Text.Trim() + ' ' + txtApellidop.Text.Trim() + ' ' + txtApellidom.Text.Trim(), lblLoginF.Text, passwordU, Convert.ToInt32(ddlRol.SelectedValue), 0,  1); // Rol por si acaso // Sin Caso por si acaso tambien
            }
            else
            {
                ddlRol.Enabled = true;
            }
        } // fin

        // para finalizar procesos
        
        ListarRegistros();
        AdicionarAuditoria();
        Limpiar();
    }

    #region Auditoria
    public void AdicionarAuditoria()
    {
        Datos = txtCI.Text + "," + txtNombres.Text + "," + txtApellidop.Text + "," + txtApellidom.Text + "," + ddlRol.Text + "," + txtInstitucion.Text + "," + "1" + "," + "1" + "," + txtCargo.Text + "," + Estado.ToString();
        audi.AdicionarAuditoria(Convert.ToInt32(lblCodUsuario.Text), lblTitulo.Text + ",obs:" + lblObservaciones.Text, Datos, Page.Request.Url.AbsoluteUri, Page.Request.TotalBytes);
    }
    #endregion

    #region habilitacion

    protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
    {
        Limpiar();

        btnAccionar.Text = "Registrar";
        lblTitulo.Text = "Adicion de Registro - PERSONA";

        //chbEstado.Enabled = true;
        
        this.pnlDatos_ModalPopupExtender.Show();
    }

    protected void gvDatos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string valor;
        int val;

        GridViewRow row = gvDatos.Rows[e.RowIndex];
        val = row.RowIndex;
        valor = gvDatos.Rows[val].Cells[9].Text;

        lblCodigo.Text = valor;

        Limpiar();

        btnAccionar.Text = "Eliminar";
        lblTitulo.Text = "Eliminacion de Registro - PERSONA";

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
        valor = gvDatos.Rows[val].Cells[9].Text;
        lblCodigo.Text = valor;

        Limpiar();

        btnAccionar.Text = "Modificar";
        lblTitulo.Text = "Modificacion de Registro - PERSONA";

        //chbEstado.Enabled = true;
        VerDatos();
        this.pnlDatos_ModalPopupExtender.Show();
    }

    #endregion

    protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Cells[9].Controls.Add(hlnk);
            }
            if (DEstado == 0)
            {
                e.Row.BackColor = Color.Silver;
                e.Row.ForeColor = Color.Lavender;
                //e.Row.Cells[2].BackColor = Color.FromName("#c6efce");
                HyperLink hlnk = new HyperLink();
                hlnk.NavigateUrl = "";
                hlnk.ImageUrl = "~/Imagenes/Inactivo.png";
                e.Row.Cells[9].Controls.Add(hlnk);
                if (rbTipoMuestra.SelectedIndex == 1)
                    e.Row.Visible = false;
            }
        }
    }

    protected void rbTipoMuestra_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListarRegistros();
    }

    #region paginacion

    protected void ContarRegistros()
    {
        int divisor;

        clsPersona tp1 = new clsPersona();
        foreach (clsPersona tp2 in tp1.ContarPersonas())
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
        ListarRegistros();
        ValidarBotones();
    }
    protected void btnAnt_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) - 1);
        ListarRegistros();
        ValidarBotones();
    }
    protected void btnSig_Click(object sender, EventArgs e)
    {
        txtPagina.Text = Convert.ToString(Convert.ToInt32(txtPagina.Text) + 1);
        ListarRegistros();
        ValidarBotones();
    }
    protected void btnFin_Click(object sender, EventArgs e)
    {
        txtPagina.Text = txtTotalPaginas.Text;
        ListarRegistros();
        ValidarBotones();
    }
    #endregion

    protected void imgBuscarWS_Click(object sender, ImageClickEventArgs e)
    {
        clsPersonaV admi = new clsPersonaV();
        gvDatos.DataSource = admi.ObtenerPersonaFullNameV(txtNombrePersona.Text);
        gvDatos.DataBind();
    }
}