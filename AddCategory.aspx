<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Sample.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="navbar" style="border-width:3px; border-color: #33333333;">
            <table align="center" style="width:380px; height:430px;">
                <!-- Heading for Add Category -->
                <tr>
                    <td colspan="2" align="center">
                        <h2 style="font-size: 24px; font-weight: bold; color: #333;">Add Category</h2>
                        <br />
                    </td>
                </tr>

                <!-- Category Text and TextBox -->
                <tr>
                    <td style="font-size: 16px; font-weight: normal; color: #333;">
                        <label for="TextBox1">Category: </label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Height="44px" Width="230px" CausesValidation="true"
                            placeholder="Category Name" BorderColor="#333333" BorderWidth="2px" Font-Bold="true" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" 
                            ErrorMessage="Enter Category Name" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <!-- Add Button centered -->
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Add" Height="44px" Width="80px" Font-Bold="true" Font-Size="Medium" 
                            BackColor="Aqua" BorderColor="#333333" OnClick="Button1_Click"/>
                    </td>
                </tr>

                <!-- Spacing -->
                <tr>
                    <td colspan="2"><br /></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#333333" BorderWidth="2px" CssClass="button" DataKeyNames="CategoryId" EmptyDataText="No record to display" Font-Bold="True" HeaderStyle-BorderColor="#333333" HeaderStyle-BorderWidth="3px" Font-Size="Larger" PageSize="4" Width="257px" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                             <Columns>
                                 <asp:TemplateField HeaderText="Category">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" Text='<%# Eval("CategoryName") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                     </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" />
                                 </asp:TemplateField>
                                 <asp:CommandField HeaderText="Operation" ShowDeleteButton="True" ShowEditButton="True">
                                 <ItemStyle HorizontalAlign="Center" />
                                 </asp:CommandField>
                             </Columns>
<HeaderStyle BorderColor="#333333" BorderWidth="3px"></HeaderStyle>
                         </asp:GridView>
                    </td>
                    
            </table>
        </div>
    </center>
</asp:Content>

