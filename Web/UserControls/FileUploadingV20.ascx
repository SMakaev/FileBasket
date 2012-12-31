<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="FileUploadingV20.ascx.cs" Inherits="FileBasket.Web.UserControls.FileUploadingV20" %>



<style type="text/css">
    .auto-style1 { width: 225px; }
</style>



<table  >
    <tr><td >File Tipe</td><td class="auto-style1">
                               <asp:DropDownList CssClass="dropdown" ID="ddlFileType" runat="server" AutoPostBack="True" 
                                                 onselectedindexchanged="DdlFileTypeSelectedIndexChanged">
                               </asp:DropDownList>
                           </td></tr>
    <tr><td >MediaFile Name</td><td class="auto-style1">
                                    <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                ControlToValidate="txtFileName" ErrorMessage="*" ValidationGroup="UploadClickGroup"></asp:RequiredFieldValidator>
                                </td></tr>
    
    <tr><td>Atributes:</td></tr>
 
    <asp:Repeater ID="AttributesRepeater" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ValidationGroup="AddAttributeGroup" ErrorMessage="*" runat="server" ControlToValidate="txtAttributeName" ID="validAttibuteName"></asp:RequiredFieldValidator>
                    <asp:TextBox Visible='<%# (bool) Eval("IsStandard") != true %>' Text='<%#Bind("NameOfAttribute") %>' runat="server" ID="txtAttributeName"></asp:TextBox>
                    <asp:Label Visible='<%# (bool) Eval("IsStandard") %>' Text='<%#Bind("NameOfAttribute") %>' runat="server" ID="lblAttributeName"></asp:Label>
                </td>
                <td>
                    <textarea ID="txtAttributeValue" rows="1"  runat="server"><%#Eval("ValueOfAttribute") %></textarea>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <tr>
        <td>
            <asp:Button ID="btnAddAttribute" CssClass="btn btn-primary" ValidationGroup="AddAttributeGroup" runat="server" onclick="BtnAddAttributeClick" Text="Add Attribute" />
        </td>
       
    </tr>
    <tr>
        <td>File</td>
        <td class="auto-style1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="FileUpload" ErrorMessage="*" ValidationGroup="UploadClickGroup"></asp:RequiredFieldValidator>
            <asp:FileUpload  ID="FileUpload" EnableViewState="True" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Image:</td>
        <td class="auto-style1">
            
            <asp:FileUpload ID="ImageUpload"  EnableViewState="True" runat="server" />
            
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button  runat="server" ID="btnUploadFile" Text="Upload" 
                         onclick="BtnUploadFileClick" ValidationGroup="UploadClickGroup"/>
        </td>
        <td>
            <asp:Label runat="server" ID="lblError"  Font-Size="16" CssClass="alert-danger" Visible="False"></asp:Label>
        </td>
    </tr>
</table>