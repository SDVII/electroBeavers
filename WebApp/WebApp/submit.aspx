﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="submit.aspx.cs" Inherits="WebApp.submit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <link rel="icon" href="Contents/BNlogo.png">
  <title>Hacker News</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="Contents/css/bootstrap.min.css">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
  <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <style>
      body
{
        margin: 0 auto;
        background:white;
}

#tbl-form{
  width: 40%;
}

#tbl-form tr{
  width: 90%;
}

td, th {
    padding: 0 0 18px 0;
}

.td-left{
  width: 20%;
}

.td-left{
  width: 10%;
}

.form-inp{
  width: 100%;
}

#div-form{
  padding: 5px;
}

.prg{
  margin-left: 46px;
}


.container-fluid
{
        margin-top: 49px;
    margin-bottom: 0px;
    margin-right: inherit;
    margin-left: inherit;
        width:90%;

        height: 1080px;
        background:#f2f3ff;
}
      footer {
    position: fixed;
     padding-left: 39%;
     padding-right: 0;
     bottom: 0px;
     height: 30px;
     width: 100%;
}
      nav1 {

    position: fixed;
          left:250px;
          bottom: 50px;
          height: 100;
          width: 100%;

      }

    .navbar-nav {
        float: left;
        margin: 0 0 0px -21px;
    }

      .navbar-fixed-top{

        margin-right: 5%;
        margin-left: 5%;
        width: 90%;

      }

      .navbar-brand {
        float: left;
        height: 50px;
        padding: 6px 15px;
        font-size: 18px;
        line-height: 20px;
}

      .pager{
        padding-right: 5%;
        padding-left: 5%;
        margin: 0 0px 20px 0px;
        text-align: center;
        list-style: none;
        position: fixed;
        bottom: 33px;
        height: 30px;
        width: 88%;
      }

/* IE 6 */
* html #footer {
   position:absolute;
   top:expression((0-(footer.offsetHeight)+(document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body.clientHeight)+(ignoreMe = document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop))+'px');
}

  </style>
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
            <li><a href="#" style="color:white; font-size: 18px; font-weight: bold;">Submit</a></li>
					</ul>
				</div>

			</div>
		</nav>
		<!-- /.navbar -->

		<!-- Page Content -->
		<div class="container-fluid">
			<div class="row">
				<div class="col-sm-12">

          <form runat="server" style="margin-top: 2%; margin-left: 3%;">
      			<table id="tbl-form">
      				<tr>
      					<td class="td-left">title</td>
      					<td class="td-right">
      						 <asp:TextBox ID="title" runat="server" Width="236px"></asp:TextBox>
      					</td>
      				</tr>
      				<tr>
      					<td class="td-left">url</td>
      					<td class="td-right">
      						<asp:TextBox ID="URL" runat="server" Width="236px" TextMode="Url"></asp:TextBox>
      					</td>
      				</tr>
      				<tr>
      					<td>&nbsp;</td>
      					<td style="font-weight: bold;">or</td>
      				</tr>
      				<tr>
      					<td class="td-left">text</td>
      					<td class="td-right">
      						<asp:TextBox ID="txt" runat="server" Height="91px" TextMode="MultiLine" Width="240px"></asp:TextBox>
      					</td>
      				</tr>
      				<tr>
      					<td class="td-left">&nbsp;</td>
      					<td class="td-right">
      						<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
      					    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
      					</td>
      				</tr>
      			</table>
      		</form>
          <div>
      			<p class="prg">Leave url blank to submit a question for discussion. If there is no url, the next (if any) will appear at the top of the thread.</p>
      			<p class="prg">You can also submit via <a style="color:#000" href="#">bookmarklet</a></p>
      		</div>
        </div>

					<hr>
<footer><div class="">
     <div style="color:grey;">
  <a href="#guidelines" style="color:black;">Guidelines</a> |
  <a href="#faq" style="color:black;">FAQ</a> |
  <a href="#support" style="color:black;">Support</a> |
  <a href="#contact" style="color:black;">Contact</a>

  </div>
    </div></footer>
				</div>
			</div>


  </body>
</html>
