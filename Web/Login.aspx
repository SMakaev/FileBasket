<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FileBasket.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Sign in &middot; FileBasket</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="">
        <meta name="author" content="">
        <link href="<%= ResolveUrl("~/Content/Bootstrap/css/bootstrap.css") %>" rel="stylesheet" />
        <style type="text/css">
            body {
                background-color: #f5f5f5;
                padding-bottom: 40px;
                padding-top: 40px;
            }

            .form-signin {
                -moz-border-radius: 5px;
                -moz-box-shadow: 0 1px 2px rgba(0, 0, 0, .05);
                -webkit-border-radius: 5px;
                -webkit-box-shadow: 0 1px 2px rgba(0, 0, 0, .05);
                background-color: #fff;
                border: 1px solid #e5e5e5;
                border-radius: 5px;
                box-shadow: 0 1px 2px rgba(0, 0, 0, .05);
                horiz-align: center;
                margin: 0 auto 20px;
                max-width: 300px;
                padding: 19px 29px 29px;
            }

            .form-signin .form-signin-heading,
            .form-signin .checkbox { margin-bottom: 10px; }

            .form-signin input[type="text"],
            .form-signin input[type="password"] {
                font-size: 16px;
                height: auto;
                margin-bottom: 15px;
                padding: 7px 9px;
            }

        </style>

        <link href="<%= ResolveUrl("~/Content/Bootstrap/css/bootstrap-responsive.css") %>" rel="stylesheet" />
    </head>
    <body>
        <form id="form1" class="form-signin" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Path="~/Scripts/jquery-1.8.3.js"/>
                    <asp:ScriptReference Path="~/Content/Bootstrap/js/bootstrap.js"/>
                </Scripts>
            </asp:ScriptManager>
            <div class="container">
                <asp:Login ID="LoginOnLoginPage" runat="server" CreateUserText="Registration" 
                           CreateUserUrl="~/PublicPages/RegistrationPage.aspx" 
                           PasswordRecoveryText="Forgot your password?" 
                           PasswordRecoveryUrl="~/PublicPages/PasswordRecoveryPage.aspx" 
                           Width="250px" FailureTextStyle-CssClass="alert alert-error">
                    <LayoutTemplate>
                        <form class="form-signin">
                            <h2 class="form-signin-heading">Please sign in</h2>
 
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                           
                            <asp:TextBox CssClass="input" ID="UserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LoginOnLoginPage">*</asp:RequiredFieldValidator>

                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                       
                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LoginOnLoginPage">*</asp:RequiredFieldValidator>
         
                            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />

                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
      
                            <asp:Button ID="LoginButton"  CssClass="btn btn-primary" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginOnLoginPage" />
                            <br/>
                            <asp:HyperLink ID="CreateUserLink" runat="server" NavigateUrl="~/PublicPages/RegistrationPage.aspx">Registration</asp:HyperLink>
                            <br />
                            <asp:HyperLink ID="PasswordRecoveryLink" runat="server" NavigateUrl="~/PublicPages/PasswordRecoveryPage.aspx">Forgot your password?</asp:HyperLink>
                        </form>
                    </LayoutTemplate>
                    <FailureTextStyle CssClass="alert alert-error"></FailureTextStyle>
                </asp:Login>
            </div>
        </form>
    </body>
</html>