<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ErrorPage.aspx.vb" Inherits="ElClavoOxidado.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:GridView ID="GrillaError" runat="server"  >
            <HeaderStyle BackColor="#BB9241" Height="30px" />
        </asp:GridView>
    </div>
</asp:Content>
