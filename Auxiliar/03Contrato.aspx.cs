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
using Seguridad.Entidades;
using Seguridad.Datos;

using System.Drawing;

public partial class Contrato : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblLoginU.Text = Session["loginU"].ToString();
            lblPasswordU.Text = Session["CI"].ToString();
        }
    }


    protected void btnRegistro4_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
}