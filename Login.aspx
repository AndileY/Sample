<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sample.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" style="height: 275px; width: 352px; background-color: #800080;" >
        <tr>
            <td colspan="2" align="center">
                <h2>Login Page</h2></td>
            
        </tr>
        <tr>
            <td align="center" style="width:50%">
                <b>Email Id:</b></td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Height="34px" Width="154px" ForeColor="#CC6699" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" style="width:50%">
                <b>Password:</b></td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Height="34px" Width="154px" ForeColor="#CC6699" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Height="40px" Text="Login" Width="127px" Font-Size="Large" ForeColor="#CC6699" OnClick="Button1_Click" />
                </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                
                </td>
            
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Register Here" ForeColor="#CC6699" OnClick="LinkButton1_Click1" />

            </td>
        </tr>
   

        
       
    </table>
        <div>
        </div>
    </form>
</body>
</html>
