<%@ Page Title="" Language="C#" MasterPageFile="~/Sources/Pages/MP.Master" AutoEventWireup="true" CodeBehind="FrmPerfil.aspx.cs" Inherits="PruebaLogin.Sources.Pages.FrmPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Mi perfil
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">


    <div class="container">
        <fieldset class="row">
            <div class="container text-black-50 row">
                <div class="col-6 row justify-content-center">
                    <div class="align-items-center col-auto">
                        <fieldset>
                            <div class="row">
                                <asp:Image runat="server" ID="image" CssClass="form-control img-thumbnail" Height="300" />
                            </div>
                            <br />
                            <div class="row">
                                <asp:FileUpload runat="server" ID="FUImage" CssClass="form-control form-control-sm" />
                            </div>
                            <br />
                            <div class="row">
                                <asp:Button runat="server" ID="BtnAplicar" CssClass="form-control btn btn-dark" Text="Aplicar Cambios" OnClick="BtnAplicar_Click" />
                            </div>
                        </fieldset>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label>
                    </div>
                </div>
                <div class="col-6 row justify-content-center">
                    <div class="align-items-center col-auto">
                        <fieldset>
                            <legend>Datos personales               
                            </legend>
                            <%--inicia tabla asp--%>
                            <asp:Table runat="server" Enabled="false">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Nombres:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbNombres" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Apellidos:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbApellidos" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Fecha de nacimiento:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbFecha" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <%--fin  de tabla--%>
                        </fieldset>
                        <br />
                        <fieldset>
                            <legend> Datos de sesión </legend>
                                <%--inicia tabla asp--%>
                            <asp:Table runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Usuario:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbUsuario" Enabled="false"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Button runat="server" CssClass="form-control btn btn-warning" ID="BtnCambiar" Text="Cambiar seña" OnClick="BtnCambiar_Click"></asp:Button>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Button runat="server" CssClass="form-control btn btn-success" ID="BtnGuardar" Text="Guardar" OnClick="BtnGuardar_Click" Visible="false"></asp:Button>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <%--fin  de tabla--%>
                            <%--inicia tabla asp--%>
                            <asp:Table runat="server" ID="contrasenia" Visible="false">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label"  Text="Contraseña:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbClave" placeholder="New Password" TextMode="Password"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Repetir contraseña:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbClave2" placeholder="New Password Again" TextMode="Password"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <asp:Label runat="server" ID="lblErrorClave" CssClass="alert-danger"></asp:Label>
                            <%--fin  de tabla--%>
                        </fieldset>
                    </div>
                </div>
            </div>
        </fieldset>
        <br />
        <br />
        <div class="container d-flex justify-content-end">
            <asp:Button runat="server" class="btn btn-danger" Text="Eliminar cuenta" ID="Eliminar" OnClick="Eliminar_Click" />
        </div>
    </div>

</asp:Content>
