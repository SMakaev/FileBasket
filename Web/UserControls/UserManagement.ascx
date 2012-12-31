<%@ Control Language="C#" EnableViewState="true" AutoEventWireup="true" CodeBehind="UserManagement.ascx.cs" Inherits="FileBasket.Web.UserControls.UserManagement" %>

<table style="width: 300px" >
    <tr><td >User Name</td><td >
                               <asp:Label ID="lblUserName" CssClass="span3" runat="server" Text="UserName"></asp:Label>
                           </td></tr>
    <tr><td >User Email</td><td >
                                <asp:TextBox ID="txtUserEmail" CssClass="span2" runat="server"></asp:TextBox>
                            </td></tr>
    <tr><td >Date Of Registration</td><td >
                                          <asp:Label ID="lblDateOfRegistration" CssClass="span3" runat="server" Text="DateOfRegistration"></asp:Label>
                                      </td></tr>
    <tr><td >Last Activity</td><td>
                                   <asp:Label ID="lblLastActivity" CssClass="span3" runat="server"></asp:Label>
                               </td></tr>
    <tr><td >Status</td><td>
                            <asp:Label ID="lblIsOnline" CssClass="span3" runat="server" Text="IsOnline"></asp:Label>
                        </td></tr>
    <tr><td >Is Approved</td><td >
                                 <asp:DropDownList CssClass="dropdown span2" ID="ddlIsUserApproved" runat="server">
                                     <asp:ListItem>Approved</asp:ListItem>
                                     <asp:ListItem>Banned</asp:ListItem>
                                 </asp:DropDownList>
                             </td></tr>
    <tr>
        <td>Roles</td>
        <td>
            <asp:CheckBoxList CssClass="checkbox" ID="cbUserRoles" runat="server">
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr><td colspan="2">
            <asp:Label  ID="lblMessage" CssClass="span3" runat="server" Visible="False" Text="Message"></asp:Label>
        </td></tr>
    <tr><td >
            <asp:Button ID="btnUpdateUser"  runat="server" Text="Update" onclick="BtnUpdateUserClick" CssClass="btn btn-primary" 
                />
        </td><td>
                 <asp:Button CssClass="btn btn-inverse" ID="btnDeleteUser" runat="server" Text="Delete" onclick="BtnDeleteUserClick" 
                     />
             </td></tr>
</table>