<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site2.Master" AutoEventWireup="true" CodeBehind="wpGetDevices.aspx.cs" Inherits="WebForm.Arkes.Pages.wpGetDevices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="rptDevice" runat="server" OnItemCommand="rptOrnek_ItemCommand">
        <HeaderTemplate>
            <table class="table table-striped table-hover ">
                <thead>
                    <tr class="warning">
                         <th>Cihaz Kodu</th>
                        <th>Cihaz Adı</th>
                        <th>Cihaz Türü</th>
                        <th>Şehir</th>
                         <th></th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="active">
                  <td><%# Eval("ID") %></td>
                <td><%# Eval("Name") %></td>
                <td><%# Eval("DeviceTypeName") %></td>
                 <td><%# Eval("City") %></td>
                <td>
                    <asp:LinkButton ID="lnkSil" runat="server" CssClass="btn btn-xs btn-danger" CommandArgument='<%# Eval("ID") %>' CommandName="Duzenle" Text="Düzenle"></asp:LinkButton></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
    </table> 
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
