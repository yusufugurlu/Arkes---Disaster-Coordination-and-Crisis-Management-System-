<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site2.Master" AutoEventWireup="true" CodeBehind="wpMap.aspx.cs" Inherits="WebForm.Arkes.wpMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCaV4kh-IfS3cA1RwM48oE6XujEHNhUK88&sensor=true"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="ltMap" runat="server"></asp:Literal>


    <asp:Panel ID="pnlAlert" runat="server" CssClass="alert alert-secondary" role="alert">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </asp:Panel>
    <div class="row g-0">
        <div class="row gx-3">
            <div class="col-6">
                <div class="form-floating">
                    <asp:DropDownList ID="drpDeviceType" runat="server" CssClass="form-select" aria-label="Cihaz Tipi"></asp:DropDownList>
                    <label for="drpDeviceType">Cihaz Tipi Seçiniz.</label>
                </div>
            </div>
            <div class="col-6 mt-3">
                <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-primary w-100 h-100" Text="Getir" />
            </div>
        </div>
        <div class="mt-3">
        </div>
        <div id="dvMap" style="width: 100%; height: 1000px">
        </div>
    </div>

</asp:Content>
