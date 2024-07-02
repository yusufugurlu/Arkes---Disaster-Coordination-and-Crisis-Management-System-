<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebForm.Arkes.Pages.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Carousel Start -->
    <div class="container-fluid p-0">
        <div id="header-carousel" class="carousel slide carousel-fade" data-bs-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img class="w-100" src="img/map2.png" alt="Image" />
                    <div class="carousel-caption d-flex flex-column align-items-center justify-content-center" />
                        <div class="p-3" style="max-width: 900px;">
                            <h5 class="text-white text-uppercase">ARKES</h5>
                            <h1 class="display-1 text-white mb-md-4">Afet Koordinasyon ve Kriz Yönetim Sistemi</h1>
                        </div>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#header-carousel"
                data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#header-carousel"
                data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
    </div>
    <!-- Carousel End -->
    <!-- Team Start -->
    <div class="container-fluid py-6 px-5">
        <div class="text-center mx-auto mb-5" style="max-width: 600px;">
            <h1 class="display-5 mb-0">Arkes Takımı Üyeleri</h1>
            <hr class="w-25 mx-auto bg-primary" />
        </div>
        <div class="row g-5">
            <div class="col-lg-3">
                <div class="team-item position-relative overflow-hidden">
                    <img class="img-fluid w-100" src="img/Arkes-Cengiz Sertkaya.jpeg" alt="" />
                    <div class="team-text w-100 position-absolute top-50 text-center bg-primary p-4">
                        <h3 class="text-white">Cengiz Sertkaya</h3>
                        <p class="text-white text-uppercase mb-0">Donanım</p>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="team-item position-relative overflow-hidden">
                    <img class="img-fluid w-100" src="img/Arkes-Yusuf Uğurlu.jpeg" alt="" />
                    <div class="team-text w-100 position-absolute top-50 text-center bg-primary p-4">
                        <h3 class="text-white">Yusuf Uğurlu</h3>
                        <p class="text-white text-uppercase mb-0">Yazılım</p>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="team-item position-relative overflow-hidden">
                    <img class="img-fluid w-100" src="img/Arkes-Emirhan Arıkan.jpeg" alt="" />
                    <div class="team-text w-100 position-absolute top-50 text-center bg-primary p-4">
                        <h3 class="text-white">Emirhan Arıkan</h3>
                        <p class="text-white text-uppercase mb-0">Donanım</p>
                    </div>
                </div>
            </div>

            <div class="col-lg-3">
                <div class="team-item position-relative overflow-hidden">
                    <img class="img-fluid w-100" src="img/Arkes-Eray Muhammet Gür.jpeg" alt="" />
                    <div class="team-text w-100 position-absolute top-50 text-center bg-primary p-4">
                        <h3 class="text-white">Eray Muhammet Gür</h3>
                        <p class="text-white text-uppercase mb-0">Yazılım</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Team End -->
</asp:Content>
