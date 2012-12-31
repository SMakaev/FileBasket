<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PasswordRecoveryPage.aspx.cs" Inherits="FileBasket.Web.PublicPages.PasswordRecoveryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftBottomPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <asp:PasswordRecovery  TextBoxStyle-CssClass="input"  SubmitButtonStyle-CssClass="btn btn-primary" ID="PasswordRecovery" runat="server">
    </asp:PasswordRecovery>
</asp:Content>