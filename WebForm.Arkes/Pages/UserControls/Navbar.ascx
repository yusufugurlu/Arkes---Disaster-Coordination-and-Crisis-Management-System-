<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="WebForm.Arkes.Pages.UserControls.Navbar" %>
<!-- Navbar Start -->
<nav class="navbar navbar-expand-lg bg-white navbar-light shadow-sm px-5 py-3 py-lg-0">
    <a href="../Index.aspx" class="navbar-brand p-0">
        <h1 class="m-0 text-uppercase text-primary">
            <img src="../../img/logo.png" width="60" height="60" />
            ARKES</h1>
    </a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarCollapse">
        <div class="navbar-nav ms-auto py-0 me-n3">
            <a href="../Index.aspx" class="nav-item nav-link active">Anasayfa</a>
            <a href="../wpMap.aspx" class="nav-item nav-link">HARİTA</a>
            <div class="nav-item dropdown">
                <a href="#" class="nav-link dropdown-toggle" data-bs-toggle="dropdown">CİHAZLAR</a>
                <div class="dropdown-menu m-0">
                    <a href="../wpGetDevices.aspx" class="dropdown-item">Cihazlar</a>
                    <a href="../wpAddDevice.aspx" class="dropdown-item">Cihaz Ekle</a>
                </div>
            </div>
            <div class="nav-item dropdown">
                <a href="#" class="nav-link dropdown-toggle" data-bs-toggle="dropdown">KİŞİLER</a>
                <div class="dropdown-menu m-0">
                    <a href="../wpGetUsers.aspx" class="dropdown-item">Kişiler</a>
                    <a href="../wpAddUser.aspx" class="dropdown-item">Kişi Ekle</a>
                </div>
            </div>
        </div>
    </div>
</nav>
<!-- Navbar End -->
