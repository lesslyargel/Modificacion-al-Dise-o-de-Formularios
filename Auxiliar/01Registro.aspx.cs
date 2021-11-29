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

using System.Data.SqlClient;

using Seguridad.Logica;
//using wcfPersonal.Logica;

using System.Drawing;

public partial class Registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnRegistro(object sender, EventArgs e)
    {
        if(txtCI.Text.Length >= 3)
        {
                Session["CI"] = txtCI.Text;
                Response.Redirect("~/Auxiliar/02DatosPersonales.aspx");
        }
        else
        {
            lblObservaciones.Text = "Ingrese un CI valido";
        }
    }

}