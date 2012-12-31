<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master"  ValidateRequest="false" AutoEventWireup="true" CodeBehind="SingleFileInfo.aspx.cs" Inherits="FileBasket.Web.PublicPages.SingleFileInfo" 
    %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftBottomPlaceHolder" runat="server">
    <h2>Comments:</h2>
    <asp:ListView ID="lvCommentList" ItemPlaceholderID="CommentsContainer" runat="server">
        <LayoutTemplate>
            <fieldset style="width: 100%">
                <asp:PlaceHolder ID="CommentsContainer" runat="server"></asp:PlaceHolder>
            </fieldset>
        </LayoutTemplate>
        <ItemTemplate>
            <fieldset style="float: left; width: 90%;">
                
                <div class="media">
                    <label class="pull-left"><%# Eval("User") %></label>
                    <asp:Image  runat="server" CssClass="media-object pull-left" ></asp:Image>
                  
                    <div class="media-body">
                        <h4 class="media-heading"><%# Eval("CreationDate") %></h4>
                        <%# HttpUtility.HtmlEncode((string) Eval("CommentText")) %>
                      
                    </div>
                    <hr/>
                </div>
                

            </fieldset>

        </ItemTemplate>
    </asp:ListView>

    <asp:LoginView ID="lvAddComment" runat="server">
        <AnonymousTemplate>
            <div class="alert">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <strong>Warning!</strong> You must be registred,if you want make a comment
            </div>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <div>
                <textarea runat="server" style="width: 80%" ID="txtComment" placeholder="Write your commetn for this file" rows="10" >
     </textarea>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Make Comment" ID="btnAddComment" OnClick="btnAddComment_Click"/>
        </LoggedInTemplate>
    </asp:LoginView>
    
     

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightBottomPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <asp:ListView runat="server" ID="lvSingleFile"  ItemPlaceholderID="FilesContainer">
        <EmptyDataTemplate>
            <h2>File Not Found</h2>
        </EmptyDataTemplate>
        <LayoutTemplate>
            <fieldset style="width: 100%">
                <asp:PlaceHolder ID="FilesContainer" runat="server"></asp:PlaceHolder>
            </fieldset>
        </LayoutTemplate>
        <ItemTemplate>
            <fieldset style="float: left; width: 90%;">
                <h2> <%#  HttpUtility.HtmlEncode((string) Eval("Name")) %></h2>
                     
       
                <div class="media">
               
                    <asp:Image CssClass="img-rounded pull-left" runat="server" ImageUrl='<%# "~/PublicPages/ImagePresentation.ashx?id=" + Eval("ImageId") %>' ID="imgFileImage" Width="300" Height="200"/>
                           
                  
                      
                    <div class="media-body">
                    
                        <dl class="dl-horizontal">
                            <dt>Id:</dt>       
                            <dd>   
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Id") %>' Font-Size="Small" Font-Bold="False" Font-Italic="True"></asp:Label>  
                            </dd>  

                            <dt>Size:</dt>
                      
                                
                            <dd>   <%#Eval("Size") %></dd>
                              
                            <dt>CreationDate:</dt> 

                            <dd> <asp:Label ID="Label2" runat="server" Text='<%# Eval("CreationDate") %>' > </asp:Label></dd>      

                            <dt>Raiting:</dt>  
                              
                            <dd>  <%# Eval("Raiting") %></dd>  
                           
                                        
                            <asp:Repeater runat="server" ID="repetAttributes" DataSource='<%# Eval("AttributeValue") %>'>
                                <ItemTemplate>
                                    <dt><%# HttpUtility.HtmlEncode((string) Eval("Type.Name")) %></dt>
                          
                                       
                                    <dd> <%# HttpUtility.HtmlDecode((string) Eval("Value")) %></dd>
                              

                          

                                              
                                     
                                </ItemTemplate>
                            </asp:Repeater>
                        </dl>       
                    </div>           
                </div>
                <p><a href='<%#"/LoggedInPages/DownloadFile.ashx?id=" + Eval("Id") %>' class="btn btn-primary">Download</a></p>
            </fieldset>

        </ItemTemplate>

    </asp:ListView>
</asp:Content>