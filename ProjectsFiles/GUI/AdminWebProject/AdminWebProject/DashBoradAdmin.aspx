<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoradAdmin.aspx.cs" Inherits="AdminWebProject.DashBoradAdmin" %>

<!DOCTYPE html lang="en">

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
<body id="page-top">
    <form id="form1" runat="server">
        <!-- Page Wrapper -->
        <div id="wrapper">

            <!-- Content Wrapper -->
            <div id="content-wrapper" class="d-flex flex-column">

                <!-- Main Content -->
                <div id="content">

                    <!-- Topbar -->
                    <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">

                        <!-- Sidebar Toggle (Topbar) -->


                        <!-- Topbar Search -->
                        <form class="d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search">
                            <div class="input-group">
                                <p class="form-control bg-light border-0 small" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2">
                                    Admin Dashboard
                                </p>
                               
                            </div>
                        </form>

                        <!-- Topbar Navbar -->

                        <!-- Nav Item - Alerts -->

                    </nav>
                    <!-- End of Topbar -->

                    <!-- Begin Page Content -->
                    <div class="container-fluid">

                        <!-- Page Heading -->
                        <div class="d-sm-flex align-items-center justify-content-between mb-4">
                            <h1 class="h3 mb-0 text-gray-800">Dashboard</h1>
                            <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-download fa-sm text-white-50"></i>Generate Report</a>
                        </div>

                        <!-- Content Row -->
                        <div class="row">

                            <!-- Earnings (Monthly) Card Example -->
                            <div class="col-xl-3 col-md-6 mb-4">
                                <div class="card border-left-primary shadow h-100 py-2">
                                    <div class="card-body">
                                        <div class="row no-gutters align-items-center">
                                            <div class="col mr-2">
                                                <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Number of Users registered</div>
                                                <div class="h5 mb-0 font-weight-bold text-gray-800">     
                                                    <asp:Label ID="LabelNumberOfUsers" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Earnings (Monthly) Card Example -->
                            <div class="col-xl-3 col-md-6 mb-4">
                                <div class="card border-left-success shadow h-100 py-2">
                                    <div class="card-body">
                                        <div class="row no-gutters align-items-center">
                                            <div class="col mr-2">
                                                <div class="text-xs font-weight-bold text-success text-uppercase mb-1">Number of towers built</div>
                                                <div class="h5 mb-0 font-weight-bold text-gray-800">
                                                    <asp:Label ID="LabelNumberOfTowers" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Content Row -->

                        <div class="row">

                            <!-- Area Chart -->
                            <div class="col-xl-8 col-lg-7">
                                <div class="card shadow mb-4">
                                    <!-- Card Header - Dropdown -->
                                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                        <h6 class="m-0 font-weight-bold text-primary">Properties</h6>
                                        <div class="dropdown no-arrow">
                                        </div>
                                    </div>
                                    <!-- Card Body -->
                                    <div class="card-body">
                                        <div class="chart-area">

                                            <asp:GridView ID="GridViewPropertes" runat="server" AllowPaging="True" CssClass="table table-bordered table-fit" Width="100%" HeaderStyle-CssClass="table table-bordered" PagerSettings-PageButtonCount="1" PagerSettings-Position="Bottom" PageSize="6" OnPageIndexChanging="GridViewPropertes_PageIndexChanging">
                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="1" FirstPageText="First" LastPageText="Last" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- Pie Chart -->
                            <div class="col-xl-4 col-lg-5">
                                <div class="card shadow mb-4">
                                    <!-- Card Header - Dropdown -->
                                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                        <h6 class="m-0 font-weight-bold text-primary">Percentage</h6>

                                    </div>
                                    <!-- Card Body -->
                                    <div class="card-body">
                                        <div class="card shadow pt-4 pb-2">
                                            <!-- <canvas id="myPieChart"></canvas> -->

                                            <table class="table table-sm">
                                                <tr>
                                                    <th>
                                                        <asp:Label runat="server" CssClass="text-black-50" ID="label">Lowest Winrate</asp:Label>
                                                        <asp:TextBox ID="TextBoxLowestWinrate" class="form-control bg-light border-1 small" runat="server"></asp:TextBox>
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <asp:Label runat="server" CssClass="text-black-50" ID="label1">Highest Current Winrate</asp:Label>
                                                        <asp:TextBox ID="TextBoxHighestCurrentWinrate" class="form-control bg-light border-1 small" runat="server"></asp:TextBox></th>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <asp:Label runat="server" CssClass="text-black-50" ID="label2">Highest Winrate</asp:Label>
                                                        <asp:TextBox ID="TextBoxHighestWinrate" class="form-control bg-light border-1 small" runat="server"></asp:TextBox></th>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <asp:Label runat="server" CssClass="text-black-50" ID="label3">Lowest Current Winrate</asp:Label>
                                                        <asp:TextBox ID="TextBoxLowestCurrentWinrate" class="form-control bg-light border-1 small" runat="server"></asp:TextBox></th>
                                                </tr>
                                                <tr>
                                                    <th>
                                                        <asp:LinkButton ID="LinkButtonCheckInput" ClientIDMode="Inherit"  OnClientClick="return checkInput();" onclick="LinkButton1_Click" runat="server" class="btn btn-success btn-icon-split">               
                                                            <span class="icon text-white-50">
                                                                    <i id="i-Percentage" class="fas fa-check"></i>
                                                            </span>
                                                            <span class="text">Split Button Success</span>
                                                        </asp:LinkButton>
                                                        <p id="p-danger" class="text-danger"></p>
                                                        
                                                    </th>
                                                    
                                                </tr>

                                            </table>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Content Row -->
                        <div class="row">
                            <!-- Content Column -->
                            <div class="col-lg-6 mb-4">                             
                                <!-- Color System -->
                                <div class="row">
                                    <div class="col-lg-6 mb-4">
                                        <div class="card bg-primary text-white shadow">
                                            <div class="card-body">
                                                Primary
                      <div class="text-white-50 small">#4e73df</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 mb-4">
                                        <div class="card bg-success text-white shadow">
                                            <div class="card-body">
                                                Success
                      <div class="text-white-50 small">#1cc88a</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 mb-4">
                                        <div class="card bg-info text-white shadow">
                                            <div class="card-body">
                                                Info
                      <div class="text-white-50 small">#36b9cc</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 mb-4">
                                        <div class="card bg-warning text-white shadow">
                                            <div class="card-body">
                                                Warning
                      <div class="text-white-50 small">#f6c23e</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 mb-4">
                                        <div class="card bg-danger text-white shadow">
                                            <div class="card-body">
                                                Danger
                      <div class="text-white-50 small">#e74a3b</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 mb-4">
                                        <div class="card bg-secondary text-white shadow">
                                            <div class="card-body">
                                                Secondary
                      <div class="text-white-50 small">#858796</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="col-lg-6 mb-4">
                                <!-- Approach -->
                                <div class="card shadow mb-4">
                                    <div class="card-header py-3">
                                        <h6 class="m-0 font-weight-bold text-primary">About this Website</h6>
                                    </div>
                                    <div class="card-body">
                                        <p>This Admin site can allow for the system Admin to change the Percentage that the players need in order for the game to change the coming wave! </p>
                                        <p class="mb-0">A very powerful tool indeed!</p>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                    <!-- /.container-fluid -->

                </div>
                <!-- End of Main Content -->

                <!-- Footer -->
                <footer class="sticky-footer bg-white">
                    <div class="container my-auto">
                        <div class="copyright text-center my-auto">
                            <span>Copyright &copy; Your Website 2019</span>
                        </div>
                    </div>
                </footer>
                <!-- End of Footer -->

            </div>
            <!-- End of Content Wrapper -->

        </div>
        <!-- End of Page Wrapper -->

        <!-- Scroll to Top Button-->
        <a class="scroll-to-top rounded" href="#page-top">
            <i class="fas fa-angle-up"></i>
        </a>

        <!-- Logout Modal-->
        <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
                        <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                    <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
                    <div class="modal-footer">
                        <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                        <a class="btn btn-primary" href="login.html">Logout</a>
                    </div>
                </div>
            </div>
        </div>
    </form>


    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>

    <script>     
        function checkInput() {
            var textBoxList = [];
            textBoxList.push((document.querySelector("#TextBoxLowestWinrate").value));
            textBoxList.push((document.querySelector("#TextBoxHighestCurrentWinrate").value));
            textBoxList.push((document.querySelector("#TextBoxHighestWinrate").value));
            textBoxList.push((document.querySelector("#TextBoxLowestCurrentWinrate").value));

            //console.log("hi all, it's me!");


            for (var i = 0; i < textBoxList.length; i++) {
                //console.log(textBoxList[i]);
                if (isNaN(textBoxList[i])) {
                    changeToWarning();
                    document.getElementById("p-danger").textContent = "you must insert a number!";
                    return false;
                }
                else if (Number(textBoxList[i]) < 0) {
                    changeToWarning();
                    document.getElementById("p-danger").textContent = "you must insert a Positive number!";
                    return false;
                }
            }
            document.getElementById("p-danger").className = "text-info";
            document.getElementById("p-danger").textContent = "Updating ...";
            changeToOk();
            return true;
        }


        function changeToWarning() {
            document.getElementById("LinkButtonCheckInput").className = "btn btn-warning btn-icon-split";
            document.getElementById("i-Percentage").className = "fas fa-exclamation-triangle";
        }

        function changeToOk() {
            document.getElementById("LinkButtonCheckInput").className = "btn btn-success btn-icon-split";
            document.getElementById("i-Percentage").className = "fas fa-check";
        }


        //checking if all are numbers
    </script>


</body>
</html>
