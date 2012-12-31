<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassWord.aspx.cs" Inherits="FileBasket.Web.PublicPages.ChangePassword.ChangePassWord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftBottomPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <asp:ChangePassword CancelButtonStyle-CssClass="btn btn-warning" ContinueButtonStyle-CssClass="btn btn-success" ChangePasswordButtonStyle-CssClass="btn btn-primary" ContinueDestinationPageUrl="~/Default.aspx" ID="ChangePassword1" runat="server">
    </asp:ChangePassword>
</asp:Content>