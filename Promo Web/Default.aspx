<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Promo_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>Promo Gana!</h1>
    <p>Hola, te doy la bienvenida a Promo Web(Equipo 9B - Franco Santiago Bonzi y Adriel Logullo). Tengo un voucher para validar</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="container">
    <asp:Button ID="btnComenzar" runat="server" Text="Comenzar" CssClass="btn-comenzar" OnClick="btnComenzar_Click" />
    </div> 
    
</asp:Content>
