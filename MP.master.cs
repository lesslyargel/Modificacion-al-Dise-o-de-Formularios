using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class MP : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////////--//-------------------------------------------------------
        //if (Session["CodUsuario"] == null)
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
        ////////--//-------------------------------------------------------

        if (!Page.IsPostBack)
        {
            Obtener_Fecha_Sevidor();

            ////////--//-----------------------------------------------------------------------
            //if (Session["NombreCompleto"] == null)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
            //    lblCodRR.Text = Session["CodRol"].ToString();
            //    lblCodUU.Text = Session["CodUsuario"].ToString();
            //    lblNombreCompleto.Text = Session["NombreCompleto"].ToString();

            //}
            ////////--//-----------------------------------------------------------------------

            BindMenuControl();
        }
    }

    protected void Obtener_Fecha_Sevidor()
    {
        SqlConnection sqlConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSeguridad"].ConnectionString.ToString());
        SqlCommand cmd = new SqlCommand();
        string lblfecha1;

        cmd.CommandText = "SELECT CONVERT(Char(11), GETDATE(), 106)"; // 103
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConexion;

        sqlConexion.Open();
        lblfecha1 = Convert.ToString(cmd.ExecuteScalar());
        lblfecha1 = Convert.ToDateTime(lblfecha1).ToLongDateString();
        lblfecha1 = Convert.ToString(lblfecha1);
        lblFecha.Text = lblfecha1;
        sqlConexion.Close();
    }

    protected void BindMenuControl()
    {
        string param = lblCodRR.Text; //hab...

        SqlConnection scSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnSeguridad"].ConnectionString.ToString());
        SqlCommand scSqlCommand = new SqlCommand("SELECT IdMenu, ' ' + Descripcion, PadreId, Ruta, Posicion, Imagen FROM Menu WHERE IdRol >=" + param + " AND IdEstado = 1", scSqlConnection);
        SqlDataAdapter sdaSqlDataAdapter = new SqlDataAdapter(scSqlCommand);

        DataSet dsDataSet = new DataSet();
        DataTable dtDataTable = null;

        //clsMenuV genemenu = new clsMenuV();
        //dtDataTable = genemenu.ListarMenuV2(Convert.ToInt32(param));

        try
        {
            //scSqlConnection.Open();
            //sdaSqlDataAdapter.Fill(dsDataSet);
            //dtDataTable = dsDataSet.Tables[0];

            //if (dtDataTable != null && dtDataTable.Rows.Count > 0)
            //{
            //    foreach (DataRow drDataRow in dtDataTable.Rows)
            //    {
            //        if (Convert.ToInt32(drDataRow[0]) == Convert.ToInt32(drDataRow[2]))
            //        {
            //            MenuItem miMenuItem = new MenuItem(Convert.ToString(drDataRow[1]), Convert.ToString(drDataRow[0]), Convert.ToString(drDataRow[5]), Convert.ToString(drDataRow[3]));
            //            //MenuItem miMenuItem = new MenuItem(Convert.ToString(drDataRow[1]), Convert.ToString(drDataRow[0]), String.Empty, Convert.ToString(drDataRow[3]));
            //            this.Menu.Items.Add(miMenuItem);
            //            AddChildItem(ref miMenuItem, dtDataTable);
            //        }
            //    }
            //}
        }

        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }

        finally
        {
            //scSqlConnection.Close();
            //sdaSqlDataAdapter.Dispose();
            //dsDataSet.Dispose();
            //dtDataTable.Dispose();
        }
    }

    protected void AddChildItem(ref MenuItem miMenuItem, DataTable dtDataTable)
    {
        foreach (DataRow drDataRow in dtDataTable.Rows)
        {
            if (Convert.ToInt32(drDataRow[2]) == Convert.ToInt32(miMenuItem.Value) && Convert.ToInt32(drDataRow[0]) != Convert.ToInt32(drDataRow[2]))
            {
                MenuItem miMenuItemChild = new MenuItem(Convert.ToString(drDataRow[1]), Convert.ToString(drDataRow[0]), Convert.ToString(drDataRow[5]), Convert.ToString(drDataRow[3]));
                //MenuItem miMenuItemChild = new MenuItem(Convert.ToString(drDataRow[1]), Convert.ToString(drDataRow[0]), String.Empty, Convert.ToString(drDataRow[3]));
                miMenuItem.ChildItems.Add(miMenuItemChild);
                AddChildItem(ref miMenuItemChild, dtDataTable);
            }
        }
    }

    protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
}
