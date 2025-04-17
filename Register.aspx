<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Sample.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" 
        style="width: 760px; height: 760px; background-color: #00ffff;">
        <tr>
            <td align ="center" colspan="2">
                <h>Registration Page</h></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:50%">
                <b>First Name:</b></td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="164px"></asp:TextBox>
                        <!-- Fixed: Keeping the RequiredFieldValidator to ensure the field is not empty -->
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name is empty" ControlToValidate="TextBox1" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox1" ValidationExpression="^[a-zA-Z]+$" ErrorMessage="First Name can only contain letters" ForeColor="Red"></asp:RegularExpressionValidator>  

            </td>
        </tr>
        <tr>
            <td style="width:50%">
                <b>Last Name:</b></td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="164px" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name is empty" ControlToValidate="TextBox2" ForeColor="Red">*</asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ValidationExpression="^[a-zA-Z]+$" ErrorMessage="Last Name can only contain letters" ForeColor="Red"></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td style="width:50%">
                <b>Email_ID</b></td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Height="30px" Width="164px"  TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ErrorMessage="Email_Id is empty" ControlToValidate="TextBox3" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <b>Gender:</b></td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
                    <asp:ListItem>Select Gender</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  ErrorMessage="Gender is empty" ControlToValidate="DropDownList1" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:50%">
                <b>Address:</b></td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Height="30px"  TextMode="MultiLine" Width="164px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ErrorMessage="Address is empty" ControlToValidate="TextBox4" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox2" ErrorMessage="Only Characters" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:50%">
                <b>Phone_No:</b></td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Height="30px" Width="164px" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Phone_No is empty" ControlToValidate="TextBox5" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="TextBox5" ValidationExpression="^\d{10}$" ErrorMessage="Phone number must be exactly 10 digits" ForeColor="Red"></asp:RegularExpressionValidator>

                        

            </td>
        </tr>
        <tr>
            <td style="width:50%">
                <b>Password</b></td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Height="30px" TextMode="Password" Width="164px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  ErrorMessage="Password  is empty" ControlToValidate="TextBox6" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:50%">
                <b>Confirm Password</b></td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" Height="30px" TextMode="Password" Width="164px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  ErrorMessage="Confirm Password field" ControlToValidate="TextBox7" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox6" ControlToValidate="TextBox7" ErrorMessage="Password is not match" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
           
        </tr>
    </table>
        <div>
        </div>
    </form>
</body>
</html>
