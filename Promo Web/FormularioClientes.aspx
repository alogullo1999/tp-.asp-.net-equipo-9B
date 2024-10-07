<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioClientes.aspx.cs" Inherits="Promo_Web.FormularioClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-4">
            <h2>Buscar Cliente</h2>


            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>


            <div class="mb-3">
                <label for="txtDNI" class="form-label">DNI</label>
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" />
            </div>


            <div class="mb-3">
                <asp:Button ID="btnBuscarDNI" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscarDNI_Click" />
            </div>


            <asp:Panel ID="panelFormulario" runat="server" Visible="false">

                <h3>Ingresa tu DNI</h3>


                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>


                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                </div>



                <div class="mb-3">
                    <label for="txtDireccion" class="form-label">Direccion</label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
                </div>


                 <div class="mb-3">
                     <label for="txtCiudad" class="form-label">Ciudad</label>
                     <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
                 </div>


                 <div class="mb-3">
                     <label for="txtCP" class="form-label">CP</label>
                     <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" />
                 </div>


         
                <div class="form-check">
                    <asp:CheckBox ID="chkTerminos" runat="server" CssClass="form-check-input" />
                    <label class="form-check-label" for="chkTerminos">
                        Acepto los términos y condiciones
                    </label>
                </div>

   
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

                <asp:Label ID="lblSuceso" runat="server" ForeColor="Red"></asp:Label> 

            </asp:Panel>

            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="Participar" OnClick="btnAceptar_Click" Visible="false" />
            </div>


        </div>
</asp:Content>
