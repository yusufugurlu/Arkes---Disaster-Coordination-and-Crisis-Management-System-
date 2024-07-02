<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site2.Master" AutoEventWireup="true" CodeBehind="wpAddUser.aspx.cs" Inherits="WebForm.Arkes.wpAddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row g-0">
        <div class="row gx-3">
            <div class="col-6">
                <div class="form-floating">
                    <asp:TextBox ID="txtFullName" runat="server" class="form-control"></asp:TextBox>
                    <label for="txtFullName">Tam Adı</label>
                </div>
            </div>
            <div class="col-6">
                <div class="form-floating">
                    <asp:DropDownList ID="drpDevice" runat="server" class="form-select" aria-label="Cihaz"></asp:DropDownList>
                    <label for="drpDeviceType">Cihaz Seçiniz.</label>
                </div>
            </div>
            <div class="col-6 mt-3">
                <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" class="btn btn-primary w-100 h-100" Text="Kaydet" />
            </div>
        </div>
        <div class="row gx-3">
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
