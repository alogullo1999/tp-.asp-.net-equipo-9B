<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Promo_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="container" style="text-align: center;">

<h6 class="text-center fw-bold">
    Hola, te doy la bienvenida a Promo Web (Equipo 9B - Franco Santiago Bonzi y Adriel Logullo). Tengo un voucher para validar
</h6>
    <br><br /> 
    <asp:Button ID="btnComenzar" runat="server" Text="Comenzar" CssClass="btn btn-primary" OnClick="btnComenzar_Click" />
    </div> 
    
</asp:Content>
