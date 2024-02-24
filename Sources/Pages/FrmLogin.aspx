<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="PruebaLogin.Sources.Pages.FrmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width-device-width, initial-scale=1.0" />
    <%--bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">

    <title>Inicio de Sesión</title>
</head>
<body>
    <br />
    <br />
    <br />
    <br />
    <form id="FrmLogin" class="container d-flex justify-content-center align-items-center " runat="server">
        <div class="col-5">
            <div class="form-control card card-body align-items-center h3">
                <div class="modal-title align-content-center h3">
                <asp:Label runat="server" Text="Inicio de Sesión" Font-Size="Larger"></asp:Label>
                </div>

            <br />
            <div class="input-group">
                <asp:TextBox ID="tbUsuario" CssClass="form-control" placeholder="User" runat="server"></asp:TextBox>
            </div>
            <br />
            <div class="input-group">
                <asp:TextBox ID="tbClave" CssClass="form-control" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
            </div>
            <br />
            <div class="input-group">
                <asp:Button ID="Button1" OnClick="Iniciar" CssClass="form-control btn btn-dark" runat="server" Text="LOG IN" />
            </div>
            <br />
            <br />
            <div class="">
                <asp:Label runat="server" ID="lblError" CssClass="alert-danger" ></asp:Label>
                <br />
                <asp:Label  runat="server" Text="¿No tienes una cuenta?, Registrate"></asp:Label>
                <asp:LinkButton runat="server" OnClick="Registrarse" Text="Aquí"></asp:LinkButton>
            </div>

            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <script src="../Javascript/script.js"></script>
    <%--ref a carpeta js--%>
</body>
</html>
