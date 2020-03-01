<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminForm.aspx.cs" Inherits="AdminWebSite.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>admin login page</title>
      <meta charset="utf-8"/>
      <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui"/>
      <meta http-equiv="X-UA-Compatible" content="IE=edge" />
      <meta name="description" content="Gradient Able Bootstrap admin template made using Bootstrap 4. The starter version of Gradient Able is completely free for personal project." />
      <meta name="keywords" content="free dashboard template, free admin, free bootstrap template, bootstrap admin template, admin theme, admin dashboard, dashboard template, admin template, responsive" />
      <meta name="author" content="codedthemes"/>
      <!-- Favicon icon -->
      <link rel="icon" href="assets/images/favicon.ico" type="image/x-icon"/>
      <!-- Google font-->
      <link href="https://fonts.googleapis.com/css?family=Open+Sans:400,600" rel="stylesheet"/>
      <!-- Required Fremwork -->
      <link rel="stylesheet" type="text/css" href="assets/css/bootstrap/css/bootstrap.min.css"/>
      <!-- themify-icons line icon -->
      <link rel="stylesheet" type="text/css" href="assets/icon/themify-icons/themify-icons.css"/>
	  <link rel="stylesheet" type="text/css" href="assets/icon/font-awesome/css/font-awesome.min.css"/>
      <!-- ico font -->
      <link rel="stylesheet" type="text/css" href="assets/icon/icofont/css/icofont.css"/>
      <!-- Style.css -->
      <link rel="stylesheet" type="text/css" href="assets/css/style.css"/>
      <link rel="stylesheet" type="text/css" href="assets/css/jquery.mCustomScrollbar.css"/>
</head>
<body>
    

    
    <section class="login p-fixed d-flex text-center bg-primary common-img-bg">
        <!-- Container-fluid starts -->
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <!-- Authentication card start -->
                    <div class="login-card card-block auth-body mr-auto ml-auto">
                        <form class="md-float-material" runat="server">
                            <div class="text-center">
                                <img src="assets/images/pinterest_profile_image.png" alt="pinterest_profile_image.png" height="150" width="150" />
                            </div>
                            <div class="auth-box">
                                <div class="row m-b-20">
                                    <div class="col-md-12">
                                        <h3 class="text-left txt-primary">Sign In</h3>
                                    </div>
                                </div>
                                <hr/>
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox1" type="email" class="form-control" placeholder="Your Email Address" runat="server"></asp:TextBox>
                                   
                                    <span class="md-line"></span>
                                </div>
                                <div class="input-group" >
                                    <asp:TextBox ID="TextBox2" type="password" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                    <span class="md-line"></span>
                                </div>
                                
                                <div class="row m-t-30">
                                    <div class="col-md-12">
                                        <br />
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-md btn-block waves-effect text-center m-b-20" Text="Sign In" OnClick="Button1_Click" > </asp:Button >                                 

                                    </div>
                                </div>
                                <hr/>
                                <div class="row">
                                    <div class="col-md-10">
                                        <p class="text-inverse text-left m-b-0">Thank you and enjoy our website.</p>
                                        <p class="text-inverse text-left"><b>Your Authentication Team</b></p>
                                    </div>
                                   
                                </div>

                            </div>
                        </form>
                        <!-- end of form -->
                    </div>
                    <!-- Authentication card end -->
                </div>
                <!-- end of col-sm-12 -->
            </div>
            <!-- end of row -->
        </div>
        <!-- end of container-fluid -->
    </section>
        
</body>
</html>
