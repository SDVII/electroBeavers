<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="discuss.aspx.cs" Inherits="WebApp.discuss" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
    <head id="Head1" runat="server">
        <link rel="icon" href="Contents/BNlogo.png"/>    
        <title>Beavers News</title>
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
					<a class="navbar-brand" href="#"><img src="Contents\BNlogo.png" width="40" height="40" alt="Sitename" /></a>
				</div>
				<!-- /.navbar-header -->

				<!-- Collect the nav links, forms, and other content for toggling -->
				<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
					<ul class="nav navbar-nav">
                        <li><a href="#" style="color:white; font-size: 18px; font-weight: bold;">Discuss</a></li>
                        <li><asp:HyperLink ID="hyperHome" runat="server" Text="News" NavigateUrl="~/homepage.aspx?page=1" ForeColor="White" ></asp:HyperLink></li>
                        <li><asp:HyperLink ID="HyperJob" runat="server" Text="Jobs" NavigateUrl="~/jobs.aspx" ForeColor="white" ></asp:HyperLink></li>
                        <li><asp:HyperLink ID="HyperQusetions" runat="server" Text="Questions" NavigateUrl="~/questions.aspx" ForeColor="white" ></asp:HyperLink></li>
                        <li><asp:HyperLink ID="hyperSubmit" runat="server" Text="Submit" NavigateUrl="~/submit.aspx" ForeColor="white" ></asp:HyperLink></li>
                        <li><asp:HyperLink ID="hyperLogin" runat="server" Text="Login" NavigateUrl="~/login.aspx" ForeColor="white"></asp:HyperLink></li>
					</ul>
                        <asp:HyperLink ID="hyperlinkLogout" runat="server" NavigateUrl="~/logout.aspx" class="fa fa-sign-out" style="color: white;font-size: 26px;margin-top: 13px;float: right;margin-right: 15px; position: relative;" ForeColor="#307A9E" Visible="True"></asp:HyperLink>
				</div>
			</div>
		</nav>
		<!-- /.navbar -->

		<!-- Page Content -->
		<div class="container-fluid" style="height:100%">
			<div class="row">
				<div class="col-sm-12">
					 <div class="item-laptop">
                         <!-- Article -->
                         <div style="padding-top:2%; padding-left:1% ">
                            <div><asp:HyperLink runat ="server" ID ="articleLink" Font-Size="18px"></asp:HyperLink></div>
                            <div><asp:Label runat="server" ID="articleDiscription"></asp:Label></div>
                            <div class="subtext-laptop">
                                 <span>Writen by  <span style="font-weight:bold"><asp:Label runat="server" ID="articleAuthor"></asp:Label></span>
                                 </span> <span> at <asp:Label runat="server" ID="articleDate"></asp:Label>  </span>
                            </div></div>
                         <hr style="border-color:darkgray"/>
                         <!-- /Article -->
                         <!-- Write a comment -->
                         <div style="padding-left:1% ">
                            <form runat="server">
                                <div><span style="color:GrayText">*The comment will be submitted under this name: <asp:Label runat="server" ID="userID"></asp:Label></span></div>
                                <div class="input-group" style="width:100%; margin-top:1%">
                                    <asp:TextBox runat="server" ID="commText" TextMode="MultiLine" class="form-control custom-control" rows="3" style="width:99%;height:3%;resize:none"></asp:TextBox>     
                                </div>
                                 <asp:Button ID="btnComment" runat="server"  Text="Comment" style="margin-top:1%" class="btn btn-primary spacing" OnClick="btnComment_Click"/>
                            </form>
                         </div>
                         <hr style="border-color:darkgray"/>
                         <!-- /Write a comment -->
                        <ol type="1">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </ol>
                    </div>
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

