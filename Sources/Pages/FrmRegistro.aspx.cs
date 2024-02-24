using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace PruebaLogin.Sources.Pages
{
    public partial class FrmRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/FrmLogin.aspx");
        }

        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Registrar_Click(object sender, EventArgs e)
        {
            int tamanioImg = int.Parse(FUImage.FileContent.Length.ToString());
            string contraseniaSinVerificar = tbClave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");

            SqlCommand usuario = new SqlCommand("ContarUsuario", con);
            usuario.CommandType = CommandType.StoredProcedure;
            usuario.Parameters.AddWithValue("@usuario", SqlDbType.VarChar).Value=tbUsuario.Text;
            int user = Convert.ToInt32(usuario.ExecuteScalar());
            //validaciones , valida q los campos no queden vacios
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtFecha.Text == "" || tbUsuario.Text == "" )
            {
                lblError.Text = "Los campos no pueden quedar vacios!!!";
            }
            //valida que no haya usuarios con nombre repetidos
            else if(user>=1)
            {
                lblError.Text = "El usuario " + tbUsuario.Text + "ya existe!";
            }
            //valida q las claves sean iguales
            else if(tbClave.Text != tbClve2.Text)
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
            //valida si tiene un file cargado, devuelve true si tiene
            else if (!FUImage.HasFile)
            {
                lblError.Text = "No se ha cargado una imagen de perfil!";
            }
            //valida tamanio ,este esta en el webconfig
            else if (tamanioImg >= 2097151000)
            {
                lblError.Text = "El tamaño de la imagen no puede ser mayor a 10 Mb!";
            }
            else //si paso todas las validaciones llega aqui
            {
                //byte[] imagen: Declara una variable llamada imagen que es un arreglo de bytes 
                //esta almacena datos binarios como los de una imagen
                //la propiedad FileBytes devuelve los datos del archivo en FUImage en forma de un arreglo de bytes. 
                byte[] imagen = FUImage.FileBytes;
                string patron = "InfoToolsSV";
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("Registrar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombres", SqlDbType.VarChar).Value = txtNombre.Text;
                        cmd.Parameters.AddWithValue("@Apellidos", SqlDbType.VarChar).Value=txtApellido.Text;
                        cmd.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value=txtFecha.Text;
                        cmd.Parameters.AddWithValue("@Usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
                        cmd.Parameters.AddWithValue("@Clave", SqlDbType.VarChar).Value = tbClave.Text;
                        cmd.Parameters.AddWithValue("@Patron", SqlDbType.VarChar).Value = patron; //linea 85
                        cmd.Parameters.AddWithValue("@IdUsuario", SqlDbType.Int).Value = 0;
                        cmd.Parameters.AddWithValue("@Imagen", SqlDbType.Image).Value = imagen;//linea 84
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("/Sources/Pages/FrmLogin.aspx");
                    }

                }
        }
    }
}