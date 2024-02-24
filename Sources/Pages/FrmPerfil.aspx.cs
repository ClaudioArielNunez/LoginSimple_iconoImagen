using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace PruebaLogin.Sources.Pages
{
    public partial class FrmPerfil : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static int id; //Agregamos variable static
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Session["usuarioLogueado"].ToString());
            if (Session["usuarioLogueado"] == null)
            {
                Response.Redirect("/Sources/Pages/FrmLogin.aspx");
            }
            else
            {




                SqlCommand cmd = new SqlCommand("Perfil", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            //asigno un url al control imagen
                            image.ImageUrl = "/Sources/Pages/FrmImagen.aspx?id=" + id;
                            this.tbNombres.Text = dr["Nombres"].ToString();
                            this.tbApellidos.Text = dr["Apellidos"].ToString();
                            this.tbFecha.Text = dr["Fecha"].ToString();
                            //tbFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
                            this.tbUsuario.Text = dr["Usuario"].ToString();
                            dr.Close();
                        }
                        con.Close();
                    
                
            }
        }
        //metodo para ocultar la tabla de contraseñas
        void MetodoOcultar()
        {
            if(contrasenia.Visible == false)
            {
                contrasenia.Visible = true;
                BtnGuardar.Visible = true;
                BtnCambiar.Text = "Cancelar";
                lblErrorClave.Text = "";
            }
            else
            {
                contrasenia.Visible = false;
                BtnGuardar.Visible = false;
                BtnCambiar.Text = "Cambiar seña";
                lblErrorClave.Text = "";
            }
        }

        //Metodo para actualizar imagen
        protected void BtnAplicar_Click(object sender, EventArgs e)
        {
            int tamanioArchivo;//para guardar el peso de la imagen
            byte[] imagen = FUImage.FileBytes;
            tamanioArchivo = int.Parse(FUImage.FileContent.Length.ToString());

            if(tamanioArchivo >= 2097151000)
            {
                lblError.Text = "El tamanio de la imagen debe ser menor a 10Mb";
            }
            else if(FUImage.HasFile) //indica si tiene un archivo
            {
                try
                {
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("CambiarImagen", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@imagen", SqlDbType.Image).Value = imagen;
                            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            lblError.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;                    
                }                

            }
            else
            {
                lblError.Text = "No se ha cargado una imagen de perfil nueva";
            }
        }

        protected void BtnCambiar_Click(object sender, EventArgs e)
        {
            MetodoOcultar();

        }

        //guardar contraseña
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            //usamos los regex
            string contraseniaSinVerificar = tbClave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");

             //valida q se haya escrito
            if (tbClave.Text == "" || tbClave2.Text == "")
            {
                lblError.Text = "Las contraseñas no pueden estar vacias";
            }
            //valida q las claves sean iguales
            else if (tbClave.Text != tbClave2.Text)
            {
                lblError.Text = "Las contraseñas no coinciden";
            }
            //usamos los regex, devuelve true si hay coincidencia (tiene letras? da true, lo niego! muestra cartel)
            else if (!letras.IsMatch(contraseniaSinVerificar))
            {
                lblError.Text = "Las contraseñas deben contener letras!";
            }
            else if (!numeros.IsMatch(contraseniaSinVerificar))
            {
                lblError.Text = "Las contraseñas deben contener numeros!";
            }
            else if (!especiales.IsMatch(contraseniaSinVerificar))
            {
                lblError.Text = "Las contraseñas deben contener algun caracter especial!";
            }
            else
            {
                try
                {
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("CambiarContraeña",con))
                        {
                            string patron = "InfoToolsSV";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id",SqlDbType.Int).Value = id;
                            cmd.Parameters.AddWithValue("@Clave", SqlDbType.VarChar).Value = tbClave.Text;
                            cmd.Parameters.AddWithValue("@Patron", SqlDbType.VarChar).Value = patron;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MetodoOcultar();
                            lblError.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        //eliminar usuario
        protected void Eliminar_Click(object sender, EventArgs e)
        {
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("Eliminar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session.Remove("usuarioLogueado");
                    Response.Redirect("/Sources/Pages/FrmLogin.aspx");
                }
            }
        }
    }
}