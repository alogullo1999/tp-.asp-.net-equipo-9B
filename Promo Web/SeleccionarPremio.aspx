<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeleccionarPremio.aspx.cs" Inherits="Promo_Web.SeleccionarPremio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listado de Artículos</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Repeater ID="rptPremios" runat="server">
            <ItemTemplate>
                <div class="articulo">
                    <h3><%# Eval("Nombre") %></h3>
                    <img src='<%# Eval("ImagenUrl") %>' alt='<%# Eval("Nombre") %>' style="width: 200px; height: 200px;" />
                    <p><%# Eval("Descripcion") %></p>
                    <p><strong>Precio:</strong> <%# Eval("Precio", "{0:C}") %></p>
                    <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CommandArgument='<%# Eval("IdArticulo") %>' OnClick="btnEjemplo_Click" />
                   
                </div>
                <hr />
            </ItemTemplate>
        </asp:Repeater>
        <asp:Label ID="lblMessage2" runat="server" ForeColor="Red" />
    </form>
</body>
</html>
