<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FileBasket.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" runat="server">
   

    
    <div class="form-inline">
        <asp:TextBox CssClass="input-medium" ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button CssClass="btn btn-primary" runat="server" Text="Search" ID="btnDefaultSearch" OnClick="btnDefaultSearch_Click"></asp:Button>
    </div>
       
    <br/>
    <asp:ListView runat="server"   ID="lvFiles"  ItemPlaceholderID="FilesContainer">
        
        <LayoutTemplate>
            <fieldset style="width: 100%">
                <div class="row">
                    <ul class="thumbnails">
                        <asp:PlaceHolder ID="FilesContainer" runat="server"></asp:PlaceHolder>
                    </ul>
                </div>
            </fieldset>
         
        </LayoutTemplate>
        <EmptyDataTemplate>
            <h2> No match </h2>
        </EmptyDataTemplate>
        <ItemTemplate>
        
                        
                        
            <li class="span3">
                <div class="thumbnail">
                    <asp:Image style="height: 200px; width: 320px;" CssClass="img-rounded" ImageUrl='<%# "~/PublicPages/ImagePresentation.ashx?id=" + Eval("ImageId") %>'  runat="server"></asp:Image>
                    <div class="caption">
                        <h4><%# HttpUtility.HtmlEncode((string) Eval("Name")) %></h4>
                        <dl>
                            <dt>Type</dt>
                            <dd> <%# Eval("FileType") %></dd>
                            <dt>Id</dt>
                            <dd><%#Eval("Id") %></dd>
                            <dt>Size:</dt>
                            <dd> <%#Eval("Size") %></dd>
                            <dt>Posted Date</dt>
                            <dd style="text-align: left"><%# Eval("CreationDate") %></dd>
                            <dt>Raiting:</dt>
                            <dd><%# Eval("Raiting") %></dd>
                                
                        </dl>
                            
                        <p><a href='<%#"/LoggedInPages/DownloadFile.ashx?id=" + Eval("Id") %>' class="btn btn-primary">Download</a> <a href='<%# "/PublicPages/SingleFileInfo.aspx?id=" + Eval("Id") %>' class="btn btn-primary">More...</a></p>
                    </div>
                </div>
            </li>
                
         

        </ItemTemplate>

    </asp:ListView>
    
    
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="leftBottomPlaceHolder" runat="server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="rightBottomPlaceHolder" runat="server">
</asp:Content>