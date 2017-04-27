<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApp.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link rel="icon" href="Contents/BNlogo.png"/>
        <title>Login</title>
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
                        <li><a href="#ask" style="color:white;">Questions</a></li>
                        <li><a href="#jobs" style="color:white;">Jobs</a></li>
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
                        <div style="padding-left:39%";>
                            <div style="margin-bottom:1%"><img src="Contents\BNlogo.png" width="241" height="241" alt="logo"/></div>
                            <asp:Label runat="server" ID="lblName" Text="Username:" ></asp:Label>
                            <asp:Label runat="server" ID="lblErr1" Text="Invalid Username" CssClass="red" Visible="false" ></asp:Label>                       
                            <asp:TextBox ID="txtUser" runat="server" Width="236px" class="form-control spacing"></asp:TextBox>                            
                            <asp:Label runat="server" ID="lblPass" Text="Password:" ></asp:Label>
                            <asp:Label runat="server" ID="lblErr2" Text="Invalid Password" CssClass="red" Visible="false" ></asp:Label>
                            <asp:TextBox ID="txtPass" runat="server" Width="236px" class="form-control spacing" TextMode="Password"></asp:TextBox>                            
                            <asp:Button ID="btnSubmit" runat="server"  Text="Login" Width="236px" class="btn btn-primary spacing" OnClick="btnSubmit_Click"/>
                            <asp:Button ID="btnRegister" runat="server"  Text="Register" Width="236px" class="btn btn-default spacing " style="display: block; margin-bottom:10px" OnClick="btnRegister_Click" />
                            <asp:HyperLink runat="server" ID="hlForget" Text =" Forgot your password? " style="margin-left:5%" NavigateUrl="~/change_pass.aspx"></asp:HyperLink>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
    </body>
</html>
