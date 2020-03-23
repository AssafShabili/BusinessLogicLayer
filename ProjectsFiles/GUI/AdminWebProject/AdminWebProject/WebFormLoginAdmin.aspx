<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormLoginAdmin.aspx.cs" Inherits="AdminWebProject.WebFormLoginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Admin - Dashboard</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet">
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
</head>
<body style="background-color:#4e73df">
    <article class="login text-center bg-primary common-img-bg">
        <!-- Container-fluid starts -->
        <div class="container">
            <div class="row">
                 <div class="card-body">
                                        <div class="card shadow pt-4 pb-2">
                        <div class="card-body">
                            <form class="md-float-material" runat="server">
                                <div class="text-center">
                                    <img src="img/pinterest_profile_image.png" alt="pinterest_profile_image.png" height="150" width="150" />
                                </div>
                                <div class="auth-box">
                                    <div class="row m-b-20">
                                        <div class="col-md-12">
                                            <h3 class="text-left txt-primary">Sign In</h3>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBoxName" type="" CssClass="form-control" placeholder="Your User-Name" runat="server"></asp:TextBox>

                                        <span class="md-line"></span>
                                    </div>
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBoxPassword" type="password" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                        <span class="md-line"></span>
                                    </div>

                                    <div class="row m-t-30">
                                        <div class="col-md-12">
                                            <br />
                                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-md btn-block waves-effect text-center m-b-20" Text="Sign In" OnClick="Button1_Click"></asp:Button>

                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-md-10">
                                            <asp:Label ID="LabelError" runat="server" CssClass="text-inverse text-left m-b-0" Text=""></asp:Label>
                                            <br />

                                        </div>
                                    
                                </div>
                        </div>
                        </form>
                                </div>
                        <!-- end of form -->
                    </div>
                    <!-- Authentication card end -->
                </div>
                <!-- end of col-sm-12 -->
            </div>
            <!-- end of row -->
        </div>
        <!-- end of container-fluid -->
    </article>
</body>
</html>
