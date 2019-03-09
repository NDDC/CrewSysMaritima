<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="CrewSys.Login" EnableEventValidation="false" %>

<!DOCTYPE html>
<html lang="en">

<!-- Mirrored from html.codedthemes.com/gradient-able/default/auth-normal-sign-in.html by HTTrack Website Copier/3.x [XR&CO'2014], Fri, 25 May 2018 05:59:07 GMT -->
<head runat="server">
    <title>CrewSys™ |</title>


    <!--[if lt IE 10]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
      <![endif]-->

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0, minimal-ui">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="description" content="Maritima De Manila Management Systems, Inc. is a small-sized company engaged in crewing business with a history of more than ten years in the international market. " />
    <meta name="keywords" content="maritima, maritima de manila, systems" />
    <meta name="author" content="ayic08" />

    <link rel="shortcut icon" href="Logo/favicon.ico" type="image/x-icon" />
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600" rel="stylesheet">

    <link rel="stylesheet" type="text/css" href="bower_components/bootstrap/css/bootstrap.min.css">

    <link rel="stylesheet" type="text/css" href="assets/icon/themify-icons/themify-icons.css">

    <link rel="stylesheet" type="text/css" href="assets/icon/icofont/css/icofont.css">

    <link rel="stylesheet" type="text/css" href="assets/icon/font-awesome/css/font-awesome.min.css">

    <link rel="stylesheet" type="text/css" href="assets/css/style.css">


    <!--[if lt IE 10]>
<div class="ie-warning">
    <h1>Warning!!</h1>
    <p>You are using an outdated version of Internet Explorer, please upgrade <br/>to any of the following web browsers to access this website.</p>
    <div class="iew-container">
        <ul class="iew-download">
            <li>
                <a href="http://www.google.com/chrome/">
                    <img src="assets/images/browser/chrome.png" alt="Chrome">
                    <div>Chrome</div>
                </a>
            </li>
            <li>
                <a href="https://www.mozilla.org/en-US/firefox/new/">
                    <img src="assets/images/browser/firefox.png" alt="Firefox">
                    <div>Firefox</div>
                </a>
            </li>
            <li>
                <a href="http://www.opera.com">
                    <img src="assets/images/browser/opera.png" alt="Opera">
                    <div>Opera</div>
                </a>
            </li>
            <li>
                <a href="https://www.apple.com/safari/">
                    <img src="assets/images/browser/safari.png" alt="Safari">
                    <div>Safari</div>
                </a>
            </li>
            <li>
                <a href="http://windows.microsoft.com/en-us/internet-explorer/download-ie">
                    <img src="assets/images/browser/ie.png" alt="">
                    <div>IE (9 & above)</div>
                </a>
            </li>
        </ul>
    </div>
    <p>Sorry for the inconvenience!</p>
</div>
<![endif]-->
</head>
<body class="fix-menu">
    <form id="form1" runat="server">
        
        <section class="login p-fixed d-flex text-center bg-primary common-img-bg">

            <div class="container">
                <div class="row">
                    <div class="col-sm-12">

                        <div class="login-card card-block auth-body mr-auto ml-auto">
                            <form class="md-float-material">
                                <%--                            <div class="text-center">
                                <img src="assets/images/logo.png" alt="logo.png">
                            </div>--%>
                                <div class="auth-box">
                                    <div class="row m-b-20">
                                        <div class="col-md-12">
                                            <h3 class="text-center txt-primary">Sign In</h3>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="input-group">
                                        <asp:TextBox ID="txtLoginEmail" runat="server" placeholder="Username" class="form-control"></asp:TextBox>
                                        <span class="md-line"></span>
                                    </div>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" placeholder="Password" class="form-control"></asp:TextBox>
                                        <span class="md-line"></span>
                                    </div>
                                    <%--                                <div class="row m-t-25 text-left">
                                    <div class="col-12">
                                        <div class="checkbox-fade fade-in-primary d-">
                                            <label>
                                                <input type="checkbox" value="">
                                                <span class="cr"><i class="cr-icon icofont icofont-ui-check txt-primary"></i></span>
                                                <span class="text-inverse">Remember me</span>
                                            </label>
                                        </div>
                                        <div class="forgot-phone text-right f-right">
                                            <a href="auth-reset-password.html" class="text-right f-w-600 text-inverse">Forgot Password?</a>
                                        </div>
                                    </div>
                                </div>--%>
                                    <div class="row m-t-30">
                                        <div class="col-md-12">
                                            <asp:Button ID="btnLogin" runat="server" Text="Sign in" CssClass="btn btn-primary btn-md btn-block waves-effect text-center m-b-20" />
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <p class="text-inverse text-center m-b-0">CrewSys™</p>
                                            <p class="text-inverse text-center"><b>&copy; <%=DateTime.Now.Year  %></b></p>
                                        </div>
                                    </div>
                                </div>
                            </form>

                        </div>

                    </div>

                </div>

            </div>

        </section>


    </form>
</body>

<!-- Mirrored from html.codedthemes.com/gradient-able/default/auth-normal-sign-in.html by HTTrack Website Copier/3.x [XR&CO'2014], Fri, 25 May 2018 05:59:07 GMT -->
</html>

