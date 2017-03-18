<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="WebApp.homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
    <head runat="server">
        <link rel="icon" href="Contents/BNlogo.png"/>    
        <title>Bearvers News</title>
        <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <link rel="stylesheet" href="Contents/css/bootstrap.min.css"/>
        <link  rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat"/>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
        <link rel="stylesheet" href="Contents/css/template.css"/>
        <link rel="stylesheet" href="Contents/css/homepage.css"/>
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
                        <li><a href="#" style="color:white; font-size: 18px; font-weight: bold;">Beaver News</a></li>
						<li><a href="#new" style="color:white;">New</a></li>
                        <li><a href="#comment" style="color:white;">Comments</a></li>
                        <li><a href="#show" style="color:white;">Show</a></li>
                        <li><a href="#ask" style="color:white;">Ask</a></li>
                        <li><a href="#jobs" style="color:white;">Jobs</a></li>
                        <li><a href="submit.aspx" style="color:white;">Submit</a></li>
                        <li><a href="#login" style="color:white;">Login</a></li>
					</ul>
				</div>
			</div>
		</nav>
		<!-- /.navbar -->

		<!-- Page Content -->
		<div class="container-fluid">
			<div class="row">
				<div class="col-sm-12">
					 <div class="item-laptop">
                        <ol type="1"/>
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </div>
    	            <nav class="nav1">
						<ul class="pager">
							<li class="previous"><a href="#"><span class="glyphicon glyphicon-menu-left" aria-hidden="true"></span> Prev</a></li>
							<li class="next"><a href="#">Next <span class="glyphicon glyphicon-menu-right" aria-hidden="true"></span></a></li>
						</ul>
					</nav>
					<hr/>
                    <footer>
                        <div class="">
                            <div style="color:grey;">
                                <a href="#guidelines" style="color:black;">Guidelines</a> |
                                <a href="#faq" style="color:black;">FAQ</a> |
                                <a href="#support" style="color:black;">Support</a> |
                                <a href="#contact" style="color:black;">Contact</a>
                            </div>
                        </div>
                    </footer>
				</div>
			</div>
        </div>

  </body>
</html>

