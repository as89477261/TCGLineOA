<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LineOABackend.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta name="generator" content="">
    <title>AdminUX - Admin, Dashboard, Web Application HTML template, UI kit, UI templates</title>

    <!-- manifest meta -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <link rel="manifest" href="manifest.json" />

    <!-- Favicons -->
    <link rel="apple-touch-icon" href="img/favicon180.png" sizes="180x180">
    <link rel="icon" href="img/favicon32.png" sizes="32x32" type="image/png">
    <link rel="icon" href="img/favicon16.png" sizes="16x16" type="image/png">

    <!-- Google fonts-->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>

    <!-- bootstrap icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.8.1/font/bootstrap-icons.css">

    <!-- swiper carousel css -->
    <link rel="stylesheet" href="vendor/swiper-7.3.1/swiper-bundle.min.css">

    <!-- style css for this template -->
    <link href="styles/style.css" rel="stylesheet" id="style">
</head>
    <body class="d-flex flex-column h-100 sidebar-pushcontent sidebar-filled" data-sidebarstyle="sidebar-pushcontent">
    <!-- sidebar-pushcontent, sidebar-overlay , sidebar-fullscreen  are classes to switch UI here-->

    <!-- page loader -->
    <div class="container-fluid h-100 position-fixed loader-wrap bg-blur">
        <div class="row justify-content-center h-100">
            <div class="col-auto align-self-center text-center px-5 leaf">
                <h2 class="mb-1">Admin<b class="fw-bold">UX</b></h2>
                <h6 class="mb-4 text-secondary">Admin Dashboard UIUX</h6>
                <div class="logo-square animated mb-4">
                    <div class="icon-logo">
                        <img src="img/logo-icon.png" alt="" />
                    </div>
                </div>
                <p class="text-secondary small">Petal of flower being ready to <span class="text-gradient">blossom</span></p>

                <div class="dotslaoder">
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                    <div></div>
                </div>
                <br>
            </div>
        </div>
    </div>
    <!-- page loader ends -->

    <!-- background -->
    <div class="coverimg h-100 w-100 top-0 start-0 position-absolute" id="image-daytime">
        <div class="overlay"></div>
        <img src="img/bg-1.jpg" alt="" class="w-100" />
    </div>
    <!-- background ends  -->

    <!-- header -->
    <header class="header">
        <!-- Fixed navbar -->
        <nav class="navbar fixed-top">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">
                    <div class="row">
                        <div class="col-auto"><span class="logo-icon"><img src="img/logo-icon.png" class="mx-100" alt="" /></span></div>
                        <div class="col ps-0 align-self-center">
                            <h5 class="fw-normal text-dark">AdminUX</h5>
                            <p class="small text-secondary">Admin App UI</p>
                        </div>
                    </div>
                </a>
                <div>
                    <button type="button" class="btn btn-link text-secondary text-center" id="addtohome"><i class="bi bi-cloud-download-fill me-0 me-lg-1"></i> <span class="d-none d-lg-inline-block">Install</span></button>
                    <a href="signup.html" class="btn btn-link text-secondary text-center"><i class="bi bi-person-circle me-0 me-lg-1"></i> <span class="d-none d-lg-inline-block">Sign up</span></a>
                </div>
            </div>
        </nav>
    </header>
    <!-- header ends -->

    <!-- Begin page content -->
    <form class="main mainheight container-fluid" id="form1" runat="server">

       
    </>
        <!-- time and temperature -->
        <div class="row text-white my-2">
            <div class="col">
                <p class="display-3 mb-0"><span id="time"></span><small><span class="h4 text-uppercase" id="ampm"></span></small></p>
                <p class="lead fw-normal" id="date"></p>
            </div>
            <div class="col-auto text-end">
                <p class="display-3 mb-0">
                    <img src="img/cloud-sun.png" alt="" class="vm me-0 tempimage" id="tempimage" />
                    <span id="temperature">46</span><span class="h4 text-uppercase"> <sup>0</sup>C</span>
                </p>

                <a href="javascript:void()" class="btn btn-link text-white dd-arrow-none dropdown-toggle" id="selectCity" data-bs-toggle="dropdown" aria-expanded="false">
                    <span class="h5 fw-normal" id="city">New York</span> <i class="bi bi-pencil-square small fw-light"></i>
                </a>
                <ul class="dropdown-menu" aria-labelledby="selectCity" id="citychange">
                    <li class="dropdown-item" data-value="New York">New York</li>
                    <li class="dropdown-item active" data-value="London">London</li>
                    <li class="dropdown-item" data-value="Qatar">Qatar</li>
                    <li class="dropdown-item" data-value="Delhi">Delhi</li>
                    <li class="dropdown-item" data-value="Sydney">Sydney</li>
                </ul>
            </div>
        </div>
        <!-- time and temperature ends -->

        <div class="row align-items-center justify-content-center">
            <div class="col-12 col-sm-8 col-md-6 col-lg-5 col-xl-4 col-xxl-3 text-center text-white">
                <h1 class="display-4 mb-3 mb-lg-4">Welcome,</h1>
               
                <div class="mb-4 text-start">
                    <!-- alert messages -->
                    <div class="alert alert-danger fade show d-none mb-2 global-alert" role="alert">
                        <div class="row">
                            <div class="col"><strong>Requierd!</strong> Please enter valid data.</div>
                        </div>
                    </div>
                    <div class="alert alert-success fade show d-none mb-2 global-success" role="alert">
                        <div class="row">
                            <div class="col-auto align-self-center ">
                                <div class="spinner-border spinner-border-sm text-success me-2" role="status">
                                    <span class="visually-hidden">Loading...</span>
                                </div>
                            </div>
                            <div class="col ps-0">
                                <strong>Awesome!</strong> Taking you to the next page.
                            </div>
                        </div>
                    </div>
                    <!-- Form elements -->
                    <div class="form-group mb-2 position-relative check-valid text-dark">
                        <div class="input-group input-group-lg">
                            <span class="input-group-text text-theme border-end-0"><i class="bi bi-envelope"></i></span>
                            <div class="form-floating">
                                <input runat="server" type="text" placeholder="TCG Username" value="" required class="form-control border-start-0" autofocus id="txtUsername">
                                <label>Username</label>
                            </div>
                         
                        </div>
                    </div>
                    <div class="invalid-feedback">Add .com at last to insert valid data </div>
                </div>
                   <div class="mb-4 text-start">
                    <!-- alert messages -->
                    <div class="alert alert-danger fade show d-none mb-2 global-alert" role="alert">
                        <div class="row">
                            <div class="col"><strong>Requierd!</strong> Please enter valid data.</div>
                        </div>
                    </div>
                    <div class="alert alert-success fade show d-none mb-2 global-success" role="alert">
                        <div class="row">
                            <div class="col-auto align-self-center ">
                                <div class="spinner-border spinner-border-sm text-success me-2" role="status">
                                    <span class="visually-hidden">Loading...</span>
                                </div>
                            </div>
                            <div class="col ps-0">
                                <strong>Awesome!</strong> Taking you to the next page.
                            </div>
                        </div>
                    </div>
                    <!-- Form elements -->
                    <div class="form-group mb-2 position-relative check-valid text-dark">
                        <div class="input-group input-group-lg">
                            <span class="input-group-text text-theme border-end-0"><i class="bi bi-envelope"></i></span>
                            <div class="form-floating">
                                <input runat="server" type="text" placeholder="Password" value="" required class="form-control border-start-0" autofocus id="txtPassword">
                                <label>Password</label>
                            </div>
                            <!-- submit button -->
                               </div>
                    </div>
                    <div class="invalid-feedback">Add .com at last to insert valid data </div>
                </div>
                <asp:Button runat="server" class="btn btn-lg btn-theme z-index-5 btn-square-lg" type="button" id="btnSubmit" OnClick="btnSubmit_Click"></asp:Button>
                     
            </div>
        </div>
    </form>

    <!-- footer -->
    <footer class="footer text-white mt-auto container-fluid">
        <div class="row">
            <div class="col-12 col-md-12 col-lg py-2">
                <span class="text-secondary small">Copyright @2022, Creatively designed by <a href="https://maxartkiller.com" target="_blank">Maxartkiller</a> on Earth ❤️</span>
            </div>
            <div class="col-12 col-md-12 col-lg-auto align-self-center">
                <ul class="nav small">
                    <li class="nav-item"><a class="nav-link" href="help-center.html">Help</a></li>
                    <li class="nav-item">|</li>
                    <li class="nav-item"><a class="nav-link" href="terms-of-use.html">Terms of Use</a></li>
                    <li class="nav-item">|</li>
                    <li class="nav-item"><a class="nav-link" href="privacy-policy.html">Privacy Policy</a></li>
                </ul>
            </div>
        </div>
    </footer>
    <!-- footer ends -->



    <!-- Required jquery and libraries -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="vendor/bootstrap-5/dist/js/bootstrap.bundle.js"></script>

    <!-- Customized jquery file  -->
    <script src="js/main.js"></script>
    <script src="js/color-scheme.js"></script>

    <!-- PWA app service registration and works -->
    <script src="js/pwa-services.js"></script>

    <!-- Chart js script -->
    <script src="vendor/chart-js-3.3.1/chart.min.js"></script>

    <!-- Progress circle js script -->
    <script src="vendor/progressbar-js/progressbar.min.js"></script>

    <!-- swiper js script -->
    <script src="vendor/swiper-7.3.1/swiper-bundle.min.js"></script>

    <!-- page level script -->
    <script src="js/login.js"></script>

</body>
</html>
