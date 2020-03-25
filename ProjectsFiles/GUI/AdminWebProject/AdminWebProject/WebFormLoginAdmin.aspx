<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormLoginAdmin.aspx.cs" Inherits="AdminWebProject.WebFormLoginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Admin - login</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet"/>

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet"/>
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet"/>
</head>
<body class="bg-gradient-primary">

  <div class="container">
    <!-- Outer Row -->
    <div class="row justify-content-center">
      <div class="col-xl-10 col-lg-9 col-md-9">
        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">
              <div class="col-lg-6 d-none d-lg-block " >
                    <img src="https://i.imgur.com/CQQpqBm.png"   style="background-position: center;
    background-size: cover"/>
              </div>              
              <div class="col-lg-6" >
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Admin Login
                    </h1>
                  </div>
                  <form id="form1" runat="server" class="user">
                    <div class="form-group">
                        <asp:TextBox ID="TextBoxName" CssClass="form-control form-control-user"  placeholder="User Name" runat="server"></asp:TextBox>          
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TextBoxPassword" placeholder="Password" CssClass="form-control form-control-user" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                      <div class="custom-control custom-checkbox small">
                          <asp:Label ID="LabelError" runat="server" ></asp:Label>
                      </div>
                    </div>
                     <asp:Button ID="ButtonLogin" CssClass="btn btn-primary btn-user btn-block" runat="server" Text="Button" OnClick="Button1_Click" />                 
                  </form >          
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <!-- Bootstrap core JavaScript-->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="js/sb-admin-2.min.js"></script>

</body>
</html>
