<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site2.Master" AutoEventWireup="true" CodeBehind="wpGetUsers.aspx.cs" Inherits="WebForm.Arkes.wpGetUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptUser" runat="server" OnItemCommand="rptDevice_ItemCommand">
        <HeaderTemplate>
            <table class="table table-striped table-hover ">
                <thead>
                    <tr class="warning">
                        <th>Adı Soyadı</th>
                        <th>Cihaz Adı</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="active">
                <td><%# Eval("FullName") %></td>
                <td><%# Eval("DeviceName") %></td>
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
