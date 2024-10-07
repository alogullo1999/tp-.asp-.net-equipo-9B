<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Voucher.aspx.cs" Inherits="Promo_Web.Voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<h1 style="text-align: center;">INGRESA TU VOUCHER Y LLEVATE TU PREMIO!!</h1>
 <br />

<div style="text-align: center;">
    <asp:TextBox ID="txtCodigoVoucher" runat="server" CssClass="form-control" Style="width: 50%;" />
    <br />
    <asp:Button ID="btnValidateVoucher" runat="server" Text="Validar Código" OnClick="btnValidateVoucher_Click" CssClass="btn btn-primary" Style="margin-top: 20px;" />
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
    <br />
    <asp:Button ID="btnInicio" runat="server" Text="Volver a inicio" OnClick="btnInicio_Click" CssClass="btn btn-primary" Style="margin-top: 20px;" visible="false"/>


</div>
</asp:Content>
