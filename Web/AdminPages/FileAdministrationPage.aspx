<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FileAdministrationPage.aspx.cs" Inherits="FileBasket.Web.AdminPages.FileAdministrationPage" %>
<%@Register tagPrefix="uc" tagName="FileUploadingV20" src="~/UserControls/FileUploadingV20.ascx"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftBottomPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightBottomPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainPlaceHolder" runat="server">
  
       
    <asp:GridView  AutoGenerateSelectButton="True" PageSize="10"  AllowSorting="True" SelectMethod="SelectMethod" AutoGenerateColumns="False" 
                   ID="gvFileGrid" runat="server"  AllowPaging="True" DataKeyNames="ID" CssClass="table table-hover "> 
        <Columns>
                       
            <asp:BoundField SortExpression="Id" DataField="Id" HeaderText="Id Number" />
            <asp:BoundField SortExpression="Name" DataField="Name" HeaderText="StoredFile Name" />
            <asp:BoundField SortExpression="Size" DataField="Size" HeaderText="StoredFile Size" />
            <asp:BoundField SortExpression="CreationDate" DataField="CreationDate" HeaderText="Creation Date" />
                       
        </Columns> 
        <EmptyDataTemplate><h2> No Files In Database </h2></EmptyDataTemplate>
            
        <SelectedRowStyle BackColor="#666666" />
    </asp:GridView>
          
    <asp:Button ID="btnDelete" CssClass="btn btn-primary pull-right" runat="server" onclick="BtnDeleteClick" 
                Text="Delete" />
 
    
      
    <uc:FileUploadingV20 runat="server" ID="ucFileUploadV20"  /> 
        
    
    
               

    
    
</asp:Content>