using System;
using System.Web;
using System.Web.Services;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class wsBuscarNombreCompleto : System.Web.Services.WebService {

    public wsBuscarNombreCompleto () {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]

    public string[] BuscarNombreCompleto(string prefixText)
    {
        string connstring = ConfigurationManager.ConnectionStrings["cnnSeguridad"].ConnectionString;

        using (SqlConnection con = new SqlConnection(connstring))
        {
            SqlCommand comando = new SqlCommand("SELECT TOP(20) NombreCompleto FROM TrnUsuarios WHERE NombreCompleto LIKE '%' + @param + '%' ORDER BY NombreCompleto", con);

            comando.Parameters.AddWithValue("@param", prefixText.ToUpper());

            SqlDataReader dr = default(SqlDataReader); comando.Connection.Open();
            dr = comando.ExecuteReader();
            List<string> items = new List<string>();
            while (dr.Read())
            {
                items.Add(dr["Nombrecompleto"].ToString());
            }
            comando.Connection.Close();
            return items.ToArray();
        }
    }
    
}
