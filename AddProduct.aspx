<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Sample.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div style="height:510px">
    <table style="width:700px; height:330px; background-color:aqua;" align="center">
        <tr>
            <td align="center" width="50%" colspan="2">
                <h1>Adding Product</h1><hr />
            </td>
        </tr>
        <tr>
            <td align="center" width="50%" >
                <h3>Product Id:</h3>
            </td>
            <td width="50%">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" width="50%">
                <h3>Product Name:</h3>
            </td>
            <td width="50%">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" width="50%">
                <h3>Product Description:</h3>
            </td>
            <td width="50%">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td align="center" width="50%">
                <h3>Product Image:</h3>
            </td>
            <td width="50%">
                <asp:FileUpload ID="FileUpload1" runat="server"/>
            </td>
        </tr>
        <tr>
            <td align="center" width="50%">
                <h3>Price:</h3>
            </td>
            <td width="50%">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" width="50%" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Add" Font-Bold="True" ForeColor="Black" Height="36px" OnClick="Button1_Click" Width="88px" />
            </td>
           
        </tr>
        <tr>
            <td align="center" width="50%" colspan="2">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

            </td>
        </tr>
    </table>
</div>


</asp:Content>
