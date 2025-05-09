﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaceOrder.aspx.cs" Inherits="Sample.PlaceOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <table align="center" style="margin-top:50px; width:531px; height:563px;" bgcolor="DarkCyan">
    
    <tr>
        <td colspan="2" align="center" style="vertical-align:top">
            <asp:Label ID="Label1" runat="server" Text="Card Details" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
        </td>
    </tr>
    

    <tr>
        <td align="center" style="vertical-align:top">
            <asp:TextBox ID="TextBox1" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px" placeholder="First Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="FirstName is empty" ControlToValidate="TextBox1" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="First Name must be characters" ControlToValidate="TextBox1" ForeColor="Red" ValidationExpression="^[A-Za-z]+$">*</asp:RegularExpressionValidator>
        </td>
        <td align="center" style="vertical-align:top">
            <asp:TextBox ID="TextBox2" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px" placeholder="Last Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name is empty" ControlToValidate="TextBox2" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Last Name must be characters" ControlToValidate="TextBox2" ForeColor="Red" ValidationExpression="^[A-Za-z]+$">*</asp:RegularExpressionValidator>
        </td>
    </tr>
    
   
    <tr>
        <td colspan="2" align="center">
            <asp:ImageButton ID="ImageButton1" runat="server" BorderColor="Black" BorderWidth="2px" Height="118px" ImageUrl="~/Images/Accounts.png" style="margin-bottom: 9px" Width="438px" />
        </td>
    </tr>

    
    <tr>
        <td colspan="2" align="center">
            <asp:Label ID="Label2" runat="server" Text="Card Number" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:TextBox ID="TextBox3" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="442px" placeholder="16 Digits"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Card Number is empty" ControlToValidate="TextBox3" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Card Number must be 16 digits" ControlToValidate="TextBox3" ForeColor="Red" Font-Bold="True" ValidationExpression="^\d{16}$">*</asp:RegularExpressionValidator>
        </td>
    </tr>


    <tr>
        <td align="center">
            <asp:Label ID="Label3" runat="server" Text="Expiry Date" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
        </td>
        <td align="center">
            <asp:Label ID="Label4" runat="server" Text="CVV" Font-Bold="True" Font-Size="Large" ForeColor="White"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" style="vertical-align:top">
            <asp:TextBox ID="TextBox4" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px" placeholder="MM/YY (e.g., 032022)"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Expiry Date is empty" ControlToValidate="TextBox4" ForeColor="Red" >*</asp:RequiredFieldValidator>
        </td>
        <td align="center" style="vertical-align:top">
            <asp:TextBox ID="TextBox5" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px" placeholder="3 Digits"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="CVV is empty" ControlToValidate="TextBox5" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="CVV must be 3 digits" ControlToValidate="TextBox5" ForeColor="Red" Font-Bold="True" ValidationExpression="^\d{3}$">*</asp:RegularExpressionValidator>
        </td>
    </tr>

 
    <tr>
        <td colspan="2" align="center" style="vertical-align:top">
            <asp:TextBox ID="TextBox6" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="50px" Width="442px" placeholder="Billing Address" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Address is empty" ControlToValidate="TextBox6" ForeColor="Red">*</asp:RequiredFieldValidator>
        </td>
    </tr>

    <!-- Submit Button Row -->
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="Button1" runat="server" Text="Submit" BackColor="Black" BorderColor="White" BorderWidth="2px" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="44px" Width="188px" OnClick="Button1_Click" />
        </td>
    </tr>

    <!-- Validation Summary Row -->
    <tr>
        <td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" ForeColor="Red" HeaderText="Fix the following errors" />
        </td>
    </tr>

    <!-- Navigation Links Row -->
    <tr>
        <td colspan="2" align="center">
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/AddToCart.aspx">Previous Page</asp:HyperLink>
            &nbsp; | &nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" NavigateUrl="~/Default.aspx">Home Page</asp:HyperLink>
        </td>
    </tr>
</table>

        </div>
    </form>
</body>
</html>
