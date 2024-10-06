<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="Promo_Web.SeleccionarPremio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lista de Productos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2>Lista de Productos</h2>

            <!-- Repeater para mostrar los productos -->
            <asp:Repeater ID="rptPremios" runat="server">
                <HeaderTemplate>
                    <div class="row">
                        <div class="col-3"><strong>Imagen</strong></div>
                        <div class="col-3"><strong>Nombre</strong></div>
                        <div class="col-3"><strong>Descripción</strong></div>
                        <div class="col-3 text-end"><strong>Seleccionar</strong></div>
                    </div>
                </HeaderTemplate>

                <ItemTemplate>
                    <div class="row mb-3">
                        <div class="col-3">
                            <!-- Mostrar la imagen del producto -->
                            <asp:Image ID="imgProducto" runat="server" ImageUrl='<%# Eval("ImagenUrl") %>' CssClass="img-fluid" />
                        </div>
                        <div class="col-3">
                            <!-- Mostrar el nombre del producto -->
                            <%# Eval("Nombre") %>
                        </div>
                        <div class="col-3">
                            <!-- Mostrar la descripción del producto -->
                            <%# Eval("Descripcion") %>
                        </div>
                        <div class="col-3 text-end">
                            <!-- Usar RadioButton para seleccionar solo uno dentro del mismo grupo -->
                            <asp:RadioButton ID="rdbSeleccionar" runat="server" GroupName="Premios" />
                            <asp:HiddenField ID="hfPremioID" runat="server" Value='<%# Eval("PremioID") %>' />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <!-- Botón para enviar el premio seleccionado -->
            <div class="mt-4">
                <asp:Button ID="btnSeleccionarPremio" runat="server" CssClass="btn btn-primary" Text="Seleccionar Premio" OnClick="btnSeleccionarPremio_Click" />
            </div>

            <!-- Etiqueta para mostrar mensajes -->
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
