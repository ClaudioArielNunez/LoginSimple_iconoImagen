using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaLogin.Sources.Pages
{
    public partial class FrmLogin : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrarse(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/FrmRegistro.aspx");
        }

        protected void Iniciar(object sender, EventArgs e)
        {
            //validamos campos vacios
            if (tbUsuario.Text == "" || tbClave.Text == "")
            {
                lblError.Text = "Los campos no pueden quedar vacios";
            }
            else
            {
                string patron = "InfoToolsSV";
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("Validar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Usuario",SqlDbType.VarChar).Value = tbUsuario.Text;
                        cmd.Parameters.AddWithValue("@Clave", SqlDbType.VarChar).Value = tbClave.Text;
                        cmd.Parameters.AddWithValue("@Patron", SqlDbType.VarChar).Value = patron;

                        con.Open();
                        //necesitamos un sql data reader
                        SqlDataReader dr = cmd.ExecuteReader();
                        //validamos usuario
                        if (dr.Read())
                        {
                            //se crea una session
                            Session["usuarioLogueado"] = dr["Id"].ToString();
                            Response.Redirect("/Sources/Pages/Index.aspx");
                        }
                        else
                        {
                            lblError.Text = "Usuario o contraseña incorrectos";
                        }
                        con.Close();
                    }
                }
            }
        }
    }
}