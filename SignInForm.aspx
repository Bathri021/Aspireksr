<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInForm.aspx.cs" Inherits="Online_Book_Shopping_System.SignInForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
        <h2 class="formTitle">Sign In</h2>
        <form id="loginForm" runat="server">
            <div>
                <table>
                    <tr>
                        <td>User Name</td>
                        <td>
                            <asp:TextBox ID="txtUserNameLogin" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="txtPasswordLogin" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </form>
</body>
</html>
