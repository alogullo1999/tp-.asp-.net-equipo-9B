<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioClientes.aspx.cs" Inherits="Promo_Web.FormularioClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="row">
        <h1>Ingresá tus datos</h1>

        <div class="col-6">

            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="lblSuceso" runat="server" ForeColor="Blue"></asp:Label>


            <div class="mb-3">
                <label for="txtDNI" class="form-label">DNI</label>
                <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDNI_TextChanged" />
            </div>
            <asp:Label ID="Lbl1" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Lbl2" runat="server" ForeColor="Blue"></asp:Label>


            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <asp:Label ID="Lbl3" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Lbl4" runat="server" ForeColor="Blue"></asp:Label>


            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>
            <asp:Label ID="Lbl5" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Lbl6" runat="server" ForeColor="Blue"></asp:Label>


            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <asp:Label ID="Lbl7" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Lbl8" runat="server" ForeColor="Blue"></asp:Label>
        </div>
        <div class="col-6">

            <div class="mb-3">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" />
            </div>
            <asp:Label ID="Lbl9" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Lbl10" runat="server" ForeColor="Blue"></asp:Label>


            <div class="mb-3">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" />
            </div>
            <asp:Label ID="Label13" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label14" runat="server" ForeColor="Blue"></asp:Label>


            <div class="mb-3">
                <label for="txtCP" class="form-label">Código Postal</label>
                <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" />
            </div>
            <asp:Label ID="Label15" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Label16" runat="server" ForeColor="Blue"></asp:Label>



            <div class="form-check">
                <asp:CheckBox runat="server" ID="chkTerminos" CssClass="form-check-input" />
                <label class="form-check-label" for="flexCheckDefault">
                    Acepto los términos y condiciones
                </label>
            </div>



        </div>

    </div>

     <div class="mb-3">
        <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
    </div>
    <div class="mb-3">
        <asp:Button Text="Vaciar Formulario" ID="btnVaciar" CssClass="btn btn-secondary" OnClick="btnVaciar_Click" runat="server" />
    </div>


    

    
</asp:Content>
