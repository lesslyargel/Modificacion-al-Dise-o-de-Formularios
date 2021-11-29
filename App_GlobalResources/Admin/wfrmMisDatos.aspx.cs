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

//using Seguridad.Logica;

using System.Drawing;


public partial class wfrmMisDatos : System.Web.UI.Page
{
    int Estado;

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
                //lblCodProcedencia.Text = Session["CodProcedencia"].ToString();
                lblCodRol.Text = Session["CodRol"].ToString();
            }

            ObtenerIdUsuario();

            //VerDatos();
        }


    }

    protected void ObtenerIdUsuario()
    {
        int Cod = Convert.ToInt32(lblCodUsuario.Text);

        clsUsuarios tp1 = new clsUsuarios();
        foreach (clsUsuarios tp2 in tp1.ObtenerUsuario(Cod))
        {
            txtNombres.Text = tp2.NombreCompleto.Trim();
        }

        clsPersonaV tp10 = new clsPersonaV();
        foreach (clsPersonaV tp20 in tp10.ObtenerPersonaFullNameV(txtNombres.Text))
        {
            txtCI.Text = tp20.CI;
            txtNombres.Text = tp20.Nombres;
            txtApellidop.Text = tp20.Paterno;
            txtApellidom.Text = tp20.Materno;

            //txtInstitucion.Text = tp20.Institucion.Trim();
            //txtDireccion.Text = tp20.Direccion.Trim();
            //txtUnidad.Text = tp20.Unidad.Trim();
            //txtCargo.Text = tp20.Cargo.Trim();

            if (tp20.IdEstado == 1)
            {
                chbEstado.Checked = true;
            }
            else
            {
                chbEstado.Checked = false;
            }
        }
    }


    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        lblObservaciones.Text = "hasta la vista baby";
        Response.Redirect("~/wfrmPrincipal.aspx");
    }

    protected void btnAccionar_Click(object sender, EventArgs e)
    {
        //1// Obteniendo Id institucion por descripcion
        //int id_institucion = 0;
        //clsInstitucion tp10 = new clsInstitucion();
        //foreach (clsInstitucion tp20 in tp10.VerificarInstitucion(txtInstitucion.Text))
        //{
        //    id_institucion = tp20.IdInstitucion;
        //    //..... lo demas no lo necesito
        //}
        ////Si la institucion no esta registrada agregar a instituciones
        //if (id_institucion == 0)
        //{
        //    clsInstitucion adii = new clsInstitucion();
        //    adii.AdicionarInstitucion("", txtInstitucion.Text);
        //}
        //// Otra vez intentamos obtener Id institucion por descripcion
        //clsInstitucion tp100 = new clsInstitucion();
        //foreach (clsInstitucion tp200 in tp100.VerificarInstitucion(txtInstitucion.Text))
        //{
        //    id_institucion = tp200.IdInstitucion;
        //    //..... lo demas no lo necesito
        //}

        ////2// Obteniendo Id direccion por descripcion
        //int id_direccion = 0;
        //clsDireccion tp108 = new clsDireccion();
        //foreach (clsDireccion tp208 in tp108.VerificarDireccion(txtDireccion.Text))
        //{
        //    id_direccion = tp208.IdDireccion;
        //    //..... lo demas no lo necesito
        //}
        ////Si la institucion no esta registrada agregar a instituciones
        //if (id_direccion == 0)
        //{
        //    clsDireccion adid = new clsDireccion();
        //    adid.AdicionarDireccion(txtDireccion.Text);
        //}
        //// Otra vez intentamos obtener Id institucion por descripcion
        //clsDireccion tp107 = new clsDireccion();
        //foreach (clsDireccion tp207 in tp107.VerificarDireccion(txtDireccion.Text))
        //{
        //    id_direccion = tp207.IdDireccion;
        //    //..... lo demas no lo necesito
        //}

        ////3// Obteniendo Id unidad por descripcion
        //int id_unidad = 0;
        //clsUnidad tp1081 = new clsUnidad();
        //foreach (clsUnidad tp2081 in tp1081.VerificarUnidad(txtUnidad.Text))
        //{
        //    id_unidad = tp2081.IdUnidad;
        //    //..... lo demas no lo necesito
        //}
        ////Si la institucion no esta registrada agregar a instituciones
        //if (id_unidad == 0)
        //{
        //    clsUnidad adid = new clsUnidad();
        //    adid.AdicionarUnidad(txtUnidad.Text);
        //}
        //// Otra vez intentamos obtener Id institucion por descripcion
        //clsUnidad tp1071 = new clsUnidad();
        //foreach (clsUnidad tp2071 in tp1071.VerificarUnidad(txtUnidad.Text))
        //{
        //    id_unidad = tp2071.IdUnidad;
        //    //..... lo demas no lo necesito
        //}

        ////4// Obteniendo Id cargo por descripcion
        //int id_cargo = 0;
        //clsCargo tp1051 = new clsCargo();
        //foreach (clsCargo tp2051 in tp1051.VerificarCargo(txtCargo.Text))
        //{
        //    id_cargo = tp2051.IdCargo;
        //    //..... lo demas no lo necesito
        //}
        ////Si la institucion no esta registrada agregar a instituciones
        //if (id_cargo == 0)
        //{
        //    clsCargo adid = new clsCargo();
        //    adid.AdicionarCargo(txtCargo.Text);
        //}
        //// Otra vez intentamos obtener Id institucion por descripcion
        //clsCargo tp10710 = new clsCargo();
        //foreach (clsCargo tp20710 in tp10710.VerificarCargo(txtCargo.Text))
        //{
        //    id_cargo = tp20710.IdCargo;
        //    //..... lo demas no lo necesito
        //}

        if (chbEstado.Checked)
        {
            Estado = 1;
        }
        else
        {
            Estado = 0;
        }

        int Cod;
        Cod = Convert.ToInt32(lblCodUsuario.Text);
        clsPersona modi = new clsPersona();
        modi.ModificarPersona(Cod, txtCI.Text, txtNombres.Text, txtApellidop.Text, txtApellidom.Text, 2, 1, 1, 1, Estado);
        lblObservaciones.Text = "Modificacion Satisfactoria";

        Response.Redirect("~/wfrmPrincipal.aspx");
    }
}