<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change_pass.aspx.cs" Inherits="WebApp.change_pass" %>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <link rel="icon" href="Contents/BNlogo.png"/>
        <title>Change Password</title>
        <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat" />
        <link rel="stylesheet" href="Contents/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="Contents/css/template.css"/>
        <link rel="stylesheet" href="Contents/css/login.css"/>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    </head>
    <body>

        
		<!-- Navigation -->
	    <nav class="navbar navbar-fixed-top navbar-inverse nav2" role="navigation" style="background-color:#307a9e">
			<div class="container-fluid1">

				<!-- Brand and toggle get grouped for better mobile display -->
				<div class="navbar-header">
					<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					</button>
					<a class="navbar-brand" href="#"><img src="Contents\BNlogo.png" width="40" height="40" alt="Sitename" ></a>
				</div>
				<!-- /.navbar-header -->

				<!-- Collect the nav links, forms, and other content for toggling -->
				<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
					<ul class="nav navbar-nav">
                        <li><a href="#" style="color:white; font-size: 18px; font-weight: bold;">Login</a></li>
                        <li><asp:HyperLink ID="hyperHome" runat="server" Text="News" NavigateUrl="~/homepage.aspx?page=1" ForeColor="White" ></asp:HyperLink></li>
                        <li><asp:HyperLink ID="HyperQusetions" runat="server" Text="Questions" NavigateUrl="~/questions.aspx" ForeColor="white" ></asp:HyperLink></li>
                        <li><asp:HyperLink ID="HyperJob" runat="server" Text="Jobs" NavigateUrl="~/jobs.aspx" ForeColor="white" ></asp:HyperLink></li>
                        <li><asp:HyperLink ID="hyperSubmit" runat="server" Text="Submit" NavigateUrl="~/submit.aspx" ForeColor="white" ></asp:HyperLink></li>
					</ul>
				</div>

			</div>
		</nav>
		<!-- /.navbar -->

        <!-- Page Content -->
		<div class="container-fluid">
			<div class="row">
				<div class="col-sm-12">
                        <form id="frmLogin" runat="server" style="margin-top: 2%; margin-left: 1%">
                        <div>
                            <asp:Label ID="lblEmail" runat="server">Enter your Email:</asp:Label>                          
                            <asp:Label runat="server" ID="lblerrNotFound" ForeColor="Red" Text="Email not found" style="display:none" ></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvEmail" ErrorMessage="Enter Email" SetFocusOnError="True" runat="server" ControlToValidate="txtbxEmail" ForeColor="Red"></asp:RequiredFieldValidator> 
                            <div>
                               <asp:TextBox ID="txtbxEmail" TextMode="Email" class="form-control spacing" Width="236px" style="display:inline-block" runat="server" ControlToValidate="txtbxEmail"></asp:TextBox>
                               <asp:Button ID="btnSubmit" runat="server"  Text="Submit" Width="70px" style="display:inline-block; margin-top: -1.5px;" class="btn btn-primary spacing" OnClick="btnSubmit_Click"/>
                            </div>
                            <hr runat="server" id="hr1" visible="false" style="border-color:darkgray"/>
                            <asp:Label ID="lblQ" runat="server" Visible="false" style="margin-top:10px">Answer the security question:</asp:Label>
                            <asp:Label runat="server" ID="lblerrWrong" style="display:none" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvAnswer" ErrorMessage="Enter Answer" SetFocusOnError="True" runat="server" ControlToValidate="txtbxSA" Enabled="False" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ErrorMessage="Wrong format" ControlToValidate="txtbxSA" SetFocusOnError="True" runat="server" ID="revAnswer" ValidationExpression='^[a-zA-Z0-9 ].{3,}$' Enabled="False" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                            <asp:Label ID="lblSQ" style="display:block; margin-top:10px" runat="server" Visible="false"></asp:Label>
                            <div>
                                <asp:TextBox ID="txtbxSA" runat="server" Visible="false" class="form-control spacing" style="display:inline-block" Width="236px"></asp:TextBox>
                                <asp:Button ID="btnAnswer" Visible="false" runat="server"  Text="Answer" Width="70px" style="display:inline-block; margin-top: -1.5px; height: 36px;" class="btn btn-primary spacing" OnClick="btnAnswer_Click"/>
                            </div>
                            <hr runat="server" id="hr2" visible="false" style="border-color:darkgray"/>
                            <asp:Label ID="lblPass" runat="server" Visible="false" style="margin-top:10px">Enter New Password:</asp:Label>
                            <asp:Label runat="server" ID="lblMismatch" Visible="false" ForeColor="Red">Passwords Doesn't match</asp:Label>
                            <asp:RequiredFieldValidator ID="rfvPass" ErrorMessage="Enter new password" SetFocusOnError="True" runat="server" ControlToValidate="txtbxPass1" Enabled="False" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ErrorMessage="Wrong format" ControlToValidate="txtbxPass1" SetFocusOnError="True" runat="server" ID="revpass" ValidationExpression='.{5,20}' Enabled="False" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtbxPass1" runat="server" Visible="false" class="form-control spacing" TextMode="Password" Width="236px"></asp:TextBox>
                            <asp:TextBox ID="txtbxPass2" runat="server" Visible="false" class="form-control spacing" TextMode="Password" Width="236px"></asp:TextBox>
                            <asp:Button ID="btnChange" Visible="false" runat="server"  Text="Change" Width="70px" class="btn btn-primary spacing" OnClick="btnChange_Click"/>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
    </body>
</html>