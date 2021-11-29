using System;
using System.Web;
using System.Web.Services;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class wsBuscarFullName : System.Web.Services.WebService {

    public wsBuscarFullName () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]

    public string[] BuscarFullName(string prefixText)
    {
        string connstring = ConfigurationManager.ConnectionStrings["cnnSeguridad"].ConnectionString;

        using (SqlConnection con = new SqlConnection(connstring))
        {
            SqlCommand comando = new SqlCommand("SELECT TOP(20) NombreCompleto FROM PersonaDW WHERE NombreCompleto LIKE '%' + @param + '%' ORDER BY 1", con);

            comando.Parameters.AddWithValue("@param", prefixText.ToUpper());

            SqlDataReader dr = default(SqlDataReader); comando.Connection.Open();
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();
            while (dr.Read())
            {
                items.Add(dr["NombreCompleto"].ToString());
            }
            comando.Connection.Close();
            return items.ToArray();
        }
    }
    
}
