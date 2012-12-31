<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="FileBasket.Web.PublicPages.RegistrationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftBottomPlaceHolder" runat="server">
    <p>
    </p>
</asp:Content>
<asp:Content  ID="Content3" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <asp:CreateUserWizard CreateUserButtonStyle-CssClass="btn btn-primary" ContinueButtonStyle-CssClass="btn btn-success" ID="CreateUserWizard" 
                          ContinueDestinationPageUrl="~/Default.aspx" runat="server" 
                          Width="291px">
        <ContinueButtonStyle CssClass="btn btn-success"></ContinueButtonStyle>

        <CreateUserButtonStyle CssClass="btn btn-primary"></CreateUserButtonStyle>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" />
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>
    <br />
</asp:Content>