using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wfrmPrincipal : System.Web.UI.Page
{
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

        //if (!Page.IsPostBack)
        //{
        //    lnkAcercaDe.Attributes["onclick"] = "javascript:ModalPopup()";
        //}

        // validaciones panel para los NO administradores
        if (Convert.ToInt32(lblCodRol.Text) != 1)
        {
            pnlPersonas.Visible = false;
            
            pnlFunciones.Visible = false;
            
            pnlActivosFijos.Visible = false;
            //pnlMisActivosFijos.Visible = true;
        }
        else //adimnistradores
        {
            pnlPersonas.Visible = true;

            pnlFunciones.Visible = true;

            pnlActivosFijos.Visible = true;
            //pnlMisActivosFijos.Visible = false;

            hPlanes.Text = "Seguimiento Curricular";
        }

    }

    protected void lnkAcercaDe_Click(object sender, EventArgs e)
    {
        //lnkAcercaDe.Attributes["onclick"] = "javascript: ModalPopup()";
        Response.Write("<script type='text/javascript'>window.open('\\Auxiliar/AcercaDe.aspx','','width=620, height=220');</script>");
    }

}