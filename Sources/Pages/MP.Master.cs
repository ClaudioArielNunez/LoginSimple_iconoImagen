using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaLogin.Sources.Pages
{
    public partial class MP : System.Web.UI.MasterPage
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //validamos
            if (Session["usuarioLogueado"] != null)
            {
                int id = int.Parse(Session["usuarioLogueado"].ToString());
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("Perfil", con);//me trae todos los datos de ambas tablas
                    cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dr.Read();
                    this.lblUsuario.Text = dr["Apellidos"].ToString() + ", " + dr["Nombres"].ToString();
                    imgPerfil.ImageUrl = "/Sources/Pages/FrmImagen.aspx?id=" + id; //POSIBLE ERROR-----------------
                }
            }
            else
            {
                Response.Redirect("/Sources/Pages/FrmLogin.aspx");
            }
        }

        protected void Perfil(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/FrmPerfil.aspx");
        }

       
        protected void cerrarSesion_Click1(object sender, EventArgs e)
        {
            //primero eliminamos session
            Session.Remove("usuarioLogueado"); //atencion parentesis , no corchetes
            //luego redirijimos
            Response.Redirect("/Sources/Pages/FrmLogin.aspx");
        }
    }
}