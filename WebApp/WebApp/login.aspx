<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApp.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            width: 197px;
        }
        .auto-style4 {
            height: 23px;
            width: 197px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Surname :</td>
                <td>
                    <asp:TextBox ID="usernameTXT" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Password :</td>
                <td>
                    <asp:TextBox ID="passwordTXT" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="Validate" runat="server" OnClick="Button1_Click" Text="Validate" />
&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Reset" />
&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/reg.aspx">Register</asp:HyperLink>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Label ID="Label123" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
