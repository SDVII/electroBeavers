<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="WebApp.reg" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

 
<head runat="server">
    <title></title>
    <style type="text/css">


    .auto-style1 {
        width: 100%;
    }
    .auto-style3 {
        width: 219px;
    }
    .auto-style4 {
        height: 23px;
        width: 219px;
    }
    .auto-style2 {
        height: 23px;
    }
    </style>
</head>
   
<body>
    <form id="form2" runat="server">
        <div>
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
                    <td class="auto-style3">Name :</td>
                    <td>
                        <asp:TextBox ID="nametxt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Surname :</td>
                    <td>
                        <asp:TextBox ID="surnametxt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Password :</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="passtxt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Username :</td>
                    <td>
                        <asp:TextBox ID="usernametxt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">E-Mail :</td>
                    <td>
                        <asp:TextBox ID="emailtxt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style2"></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>
                        <asp:Button ID="send" runat="server" OnClick="send_Click" Text="Validate" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Reset" runat="server" Text="Reset" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/login.aspx">Login</asp:HyperLink>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" BackColor="White" BorderColor="#009933" ForeColor="#009933" Text="Label" Visible="False"></asp:Label>
                    &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
    
</body>

        
        
</html>
