<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoardPage.aspx.cs" Inherits="AdminWebSite.DashBoardPage" Theme="" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class=" js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio no-localstorage no-sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths">
<head runat="server">
    <title>Gradient Able bootstrap admin template by codedthemes</title>
    <!-- HTML5 Shim and Respond.js IE9 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
      <![endif]-->
    <!-- Meta -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="Gradient Able Bootstrap admin template made using Bootstrap 4. The starter version of Gradient Able is completely free for personal project." />
    <meta name="keywords" content="free dashboard template, free admin, free bootstrap template, bootstrap admin template, admin theme, admin dashboard, dashboard template, admin template, responsive" />
    <meta name="author" content="codedthemes">
    <!-- Favicon icon -->
    <link rel="icon" href="assets/images/favicon.ico" type="image/x-icon" />
    <!-- Google font-->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:400,600" rel="stylesheet" />
    <!-- Required Fremwork -->
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap/css/bootstrap.min.css" />
    <!-- themify-icons line icon -->
    <link rel="stylesheet" type="text/css" href="assets/icon/themify-icons/themify-icons.css" />
    <link rel="stylesheet" type="text/css" href="assets/icon/font-awesome/css/font-awesome.min.css" />
    <!-- ico font -->
    <link rel="stylesheet" type="text/css" href="assets/icon/icofont/css/icofont.css" />
    <!-- Style.css -->
    <link rel="stylesheet" type="text/css" href="assets/css/style.css" />
    <link rel="stylesheet" type="text/css" href="assets/css/jquery.mCustomScrollbar.css" />
</head>
<body>
    <script>
        // פעולה לבדיקת הנתונים של השדות של האחוזים בצד המשתמש
        function checkInput() {
            var textBoxList = [];
            textBoxList.push((document.querySelector("#TextBoxLowestWinrate").value));
            textBoxList.push((document.querySelector("#TextBoxHighestCurrentWinrate").value));
            textBoxList.push((document.querySelector("#TextBoxHighestWinrate").value));
            textBoxList.push((document.querySelector("#TextBoxLowestCurrentWinrate").value));

          

            for (var i = 0; i < textBoxList.length; i++) {
                if (Number(textBoxList[i]) != NaN) {
                    if (Number(textBoxList[i]) <= 0) {
                        alert("Inputs must be positive numbers ");
                        return false;
                    }
                }
                else {
                    alert("Inputs must be numbers no characters allow! ");
                    return false;
                }
            }
            return true;
        }
    </script>

    <form id="form1" runat="server">
        <div class="theme-loader">
            <div class="loader-track">
                <div class="loader-bar"></div>
            </div>
        </div>
        <!-- Pre-loader end -->
        <div id="pcoded" class="pcoded iscollapsed">
            <div class="pcoded-overlay-box"></div>
            <div class="pcoded-container navbar-wrapper">

               

                <div class="pcoded-main-container">
                    <div class="pcoded-wrapper">
                        <div class="pcoded-content">
                            <div class="pcoded-inner-content">
                                <div class="main-body">
                                    <div class="page-wrapper">
                                        <div class="page-body">
                                            <div class="row">
                                                <!-- order-card start -->
                                                <div class="col-md-6 col-xl-3">
                                                    <div class="card bg-c-blue order-card">
                                                        <div class="card-block">
                                                            <h6 class="m-b-20">Number Of Users</h6>
                                                            <h2 class="text-right"><i class="ti-shopping-cart f-left"></i><span>
                                                                <asp:Label ID="LabelNUmberOfUsers" runat="server" Text=""></asp:Label></span></h2>

                                                        </div>
                                                    </div>
                                                </div>
                                               
                                                <div class="col-md-6 col-xl-3">
                                                    <div class="card bg-c-green order-card">
                                                        <div class="card-block">
                                                            <h6 class="m-b-20">Number Of Waves That Users Won At</h6>
                                                            <h2 class="text-right"><i class="ti-tag f-left"></i><span>1641</span></h2>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-xl-3">
                                                    <div class="card bg-c-yellow order-card">
                                                        <div class="card-block">
                                                            <h6 class="m-b-20">Number Of Waves That Users Lost At  </h6>
                                                            <h2 class="text-right"><i class="ti-reload f-left"></i><span>42,562</span></h2>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 col-xl-3">
                                                    <div class="card bg-c-pink order-card">
                                                        <div class="card-block">
                                                            <h6 class="m-b-20">Number of Towers built</h6>
                                                            <h2 class="text-right"><i class="ti-wallet f-left"></i><span>
                                                                <asp:Label ID="LabelNumberOfTowers" runat="server" Text=""></asp:Label></span></h2>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- order-card end -->

                                                <!-- statustic and process start -->
                                                <div class="col-lg-12 col-md-12">
                                                    <div class="card">
                                                        <div class="card-header">
                                                            <h5>Statistics of the Game Waves</h5>
                                                            <div class="card-header-right">
                                                                <ul class="list-unstyled card-option">
                                                                    <li><i class="fa fa-chevron-left"></i></li>
                                                                    <li><i class="fa fa-window-maximize full-card"></i></li>
                                                                    <li><i class="fa fa-minus minimize-card"></i></li>
                                                                    <li><i class="fa fa-refresh reload-card"></i></li>
                                                                    <li><i class="fa fa-times close-card"></i></li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                        <div class="card-block">
                                                            <%--<canvas id="Statistics-chart" height="200"></canvas>--%>
                                                            <asp:GridView ID="GridViewProperties" CssClass="table" runat="server"></asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div>
                                                </div>
                                                <div class="col-md-12 col-lg-4">
                                                 
                                                </div>
                                                <!-- statustic and process end -->
                                                <!-- tabs card start -->
                                                <div class="col-sm-12">
                                                    <div class="card tabs-card">
                                                        <div class="card-block p-0">

                                                            <!-- Tab panes -->
                                                            <div class="tab-content card-block">
                                                                <div class="tab-pane active" id="home3" role="tabpanel">

                                                                    <div class="table-responsive">
                                                                        <table class="table">
                                                                            <tr>
                                                                                <th>AdminPercentage_Lowest_winrate</th>
                                                                                <th>AdminPercentage_Highest_winrate</th>
                                                                                <th>AdminPercentage_Lowest_Current_Winrate</th>
                                                                                <th>AdminPercentage_Highest_Current_Winrate</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox CssClass="form-control" ID="TextBoxLowestWinrate" runat="server"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox CssClass="form-control" ID="TextBoxHighestCurrentWinrate" runat="server"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox CssClass="form-control" ID="TextBoxHighestWinrate" runat="server"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox CssClass="form-control" ID="TextBoxLowestCurrentWinrate" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>

                                                                        </table>
                                                                        <%-- <asp:GridView ID="GridView1" CssClass="table" runat="server" BorderStyle="None"></asp:GridView>--%>
                                                                    </div>

                                                                    <div class="text-center">
                                                                        <p id="inputP" class="text-inverse text-left m-b-0">                                           
                                                                        </p>
                                                                        <asp:Label ID="LabelError" CssClass="text-inverse text-left m-b-0" runat="server" Text=""></asp:Label>                                          
                                                                        <asp:Button ID="ButtonUpdate" CssClass="btn btn-outline-primary btn-round btn-sm" runat="server" Text="Update" OnClick="ButtonUpdate_Click" OnClientClick="checkInput()" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- tabs card end -->



                                                </div>

                                                <div id="styleSelector">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                               
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- Warning Section Ends -->
    <!-- Required Jquery -->
    <script type="text/javascript" src="assets/js/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="assets/js/jquery-ui/jquery-ui.min.js"></script>
    <script type="text/javascript" src="assets/js/popper.js/popper.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap/js/bootstrap.min.js"></script>
    <!-- jquery slimscroll js -->
    <script type="text/javascript" src="assets/js/jquery-slimscroll/jquery.slimscroll.js"></script>
    <!-- modernizr js -->
    <script type="text/javascript" src="assets/js/modernizr/modernizr.js"></script>
    <!-- am chart -->
    <script src="assets/pages/widget/amchart/amcharts.min.js"></script>
    <script src="assets/pages/widget/amchart/serial.min.js"></script>
    <!-- Chart js -->
    <script type="text/javascript" src="assets/js/chart.js/Chart.js"></script>
    <!-- Todo js -->
    <script type="text/javascript " src="assets/pages/todo/todo.js "></script>
    <!-- Custom js -->
    <script type="text/javascript" src="assets/pages/dashboard/custom-dashboard.min.js"></script>
    <script type="text/javascript" src="assets/js/script.js"></script>
    <script type="text/javascript " src="assets/js/SmoothScroll.js"></script>
    <script src="assets/js/pcoded.min.js"></script>
    <script src="assets/js/vartical-demo.js"></script>
    <script src="assets/js/jquery.mCustomScrollbar.concat.min.js"></script>
</body>
</html>
