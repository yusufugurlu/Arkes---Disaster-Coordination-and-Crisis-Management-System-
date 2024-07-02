<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site2.Master" AutoEventWireup="true" CodeBehind="wpUpdateDevice.aspx.cs" Inherits="WebForm.Arkes.wpUpdateDevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row g-0">
        <div class="row gx-3">
            <div class="col-6">
                <div class="form-floating">
                    <asp:TextBox ID="txtCode" runat="server" CssClass="form-control"></asp:TextBox>
                    <label for="txtCode">Kodu</label>
                </div>
            </div>
            <div class="col-6">
                <div class="form-floating">
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                    <label for="txtFullName">Tam Adı</label>
                </div>
            </div>
        </div>
        <div class="row gx-3 mt-2">
            <div class="col-6 mt-2 mb-2">
                <div class="form-floating">
                    <asp:TextBox ID="txtCity" placeholder="Adres" runat="server" CssClass="form-control"></asp:TextBox>
                    <label for="form-floating-4">Şehir</label>
                </div>
            </div>

            <div class="col-6 mt-2 mb-2">
                <div class="form-floating">
                    <asp:TextBox ID="txtAddress" placeholder="Adres" runat="server" CssClass="form-control"></asp:TextBox>
                    <label for="form-floating-4">Adres</label>
                </div>
            </div>

            <div class="col-6">
                <div class="form-floating">
                    <asp:DropDownList ID="drpDeviceType" runat="server" class="form-select" aria-label="Cihaz Tipi"></asp:DropDownList>
                    <label for="drpDeviceType">Cihaz Tipi Seçiniz.</label>
                </div>
            </div>



            <div class="col-6 mt-3">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" class="btn btn-primary w-100 h-100" Text="Kaydet" />
            </div>
        </div>
        <div class="row gx-3">
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
