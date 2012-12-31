<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserAdministration.aspx.cs" Inherits="FileBasket.Web.AdminPages.UserAdministration" %>
<%@Register tagPrefix="uc" tagName="UserManagementControl" src="~/UserControls/UserManagement.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftBottomPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3"  ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <div class="form-search">
        <asp:TextBox ID="txtSearchKeyWord" CssClass="search-query" runat="server" Width="163px"></asp:TextBox>
        <asp:Button ID="btnSearch" CssClass="btn btn-info" runat="server" Text="Search"/>
    </div>
    <br/>
    <div class="row">
        <div class="span5">
            <asp:GridView  CssClass="table-hover" PageSize="10" AllowSorting="True" SelectMethod="SelectMethod" ID="gvUserGridView" runat="server" 
                           AutoGenerateSelectButton="True" Height="38px" Width="508px" 
                           AutoGenerateColumns="False" AllowPaging="true" 
                               
                           onselectedindexchanged="GvUserGridViewSelectedIndexChanged" 
                           DataKeyNames="UserName" >
                <Columns>
                   
                    
                    <asp:BoundField  SortExpression="UserName" DataField="UserName" HeaderText="User Name"/>
                    <asp:BoundField  SortExpression="Email"  DataField="Email" HeaderText="Email Adress"/>
                    <asp:BoundField  SortExpression="CreationDate" DataField="CreationDate" HeaderText="Date of Registration"/>
                    
                </Columns>
                <SelectedRowStyle BackColor="#999999" />
        
            </asp:GridView>
        </div>
        <div  class="span4">
            <uc:UserManagementControl runat="server" ID="ucUserManagement"/>
        </div>

    </div>
    
</asp:Content>