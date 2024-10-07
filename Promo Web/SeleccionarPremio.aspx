<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="Promo_Web.SeleccionarPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <h2>Lista de Premios</h2>


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

                        <asp:Image ID="imgProducto" runat="server" ImageUrl='<%# Eval("ImagenUrl") %>' CssClass="img-fluid" />
                    </div>
                    <div class="col-3">

                        <%# Eval("Nombre") %>
                    </div>
                    <div class="col-3">
   
                        <%# Eval("Descripcion") %>
                    </div>
                    <div class="col-3 text-end">

                        <asp:Button ID="btnQuieroEste" runat="server" CssClass="btn btn-success" Text="¡Quiero este!" OnClick="btnQuieroEste_Click" CommandArgument='<%# Eval("PremioID") %>' />
                        <asp:HiddenField ID="hfPremioNombre" runat="server" Value='<%# Eval("Nombre") %>' />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>


        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </div>

</asp:Content>
