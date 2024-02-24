<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRegistro.aspx.cs" Inherits="PruebaLogin.Sources.Pages.FrmRegistro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width-device-width, initial-scale=1.0" />
    <%--bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">

    <title>Registro de usuarios</title>
</head>
<body>
    <form id="FrmRegistro" runat="server">
        <%-- etiqueta id--%>
        <div class="container d-flex justify-content-center">                             
            <div class="col-8">
                <div class="form-control card card-body">
                    <div class="row justify-content-center">
                        <asp:Label runat="server" CssClass="row justify-content-center h3">Registro de usuarios</asp:Label>
                    </div>
                    <fieldset>
                        <legend class="row justify-content-center">Datos personales</legend>
                        <div class="input-group">
                            <asp:Label ID="Label1" CssClass="form-control" runat="server" Text="Nombres:"></asp:Label>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="ej.Nombrepersona" runat="server" />
                        </div>
                        <br />
                        <div class="input-group">
                            <asp:Label ID="Label2" CssClass="form-control" runat="server" Text="Apellidos:"></asp:Label>
                            <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="ej.Apellidopersona" runat="server" />
                        </div>
                        <br />
                        <div class="input-group">
                            <asp:Label ID="Label3" CssClass="form-control" runat="server" Text="Fecha de nacimiento:"></asp:Label>
                            <asp:TextBox ID="txtFecha" CssClass="form-control" TextMode="Date" runat="server" />
                        </div>
                    </fieldset>
                    <br />
                    <fieldset>
                        <legend class="row justify-content-center">Datos de inicio de sesion</legend>
                        <div class="input-group">
                            <asp:Label ID="Label4" CssClass="form-control" runat="server" Text="Usuario:"></asp:Label>
                            <asp:TextBox ID="tbUsuario" CssClass="form-control" placeholder="ej. annie" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <div class="input-group">
                            <asp:Label ID="Label5" CssClass="form-control" runat="server" Text="Clave:"></asp:Label>
                            <asp:TextBox ID="tbClave" CssClass="form-control" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <div class="input-group">
                            <asp:Label ID="Label6" CssClass="form-control" runat="server" Text="Repetir Clave:"></asp:Label>
                            <asp:TextBox ID="tbClve2" CssClass="form-control" TextMode="Password" placeholder="Password Again" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <div class="row justify-content-center">
                            <asp:Image ImageUrl="~/Sources/Imagenes/icono-perfil-vacio.jpg" CssClass="img-thumbnail" Width="150" Height="150" runat="server" />
                        </div>
                        <div class="row justity-content-center">
                            <%--javascript: onchange="mostrarImagen(this)"--%>
                            <asp:FileUpload ID="FUImage" CssClass="small form-control" onchange="mostrarImagen(this)" runat="server" />
                        </div>
                    </fieldset>
                    <br />
                    <asp:Label ID="lblError" CssClass="alert-danger" Text="" runat="server" />
                    <br />
                    <div class="row">
                        <asp:Button Text="Completar Registro" ID="Registrar" OnClick="Registrar_Click1" CssClass="form-control btn btn-success" runat="server" />
                        <hr />
                        <asp:Button Text="Cancelar" OnClick="Cancelar_Click" CssClass="form-control btn btn-warning" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <script src="../Javascript/script.js"></script>
</body>
</html>
