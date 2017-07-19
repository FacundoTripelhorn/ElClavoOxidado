<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ErrorPage.aspx.vb" Inherits="ElClavoOxidado.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="Content/estilo.css" />
    <div class="container">
        <asp:Label ID="Label1" runat="server" Text="Error en la base de datos, algunos campos fueron modificados manualmente" Font-Size="XX-Large"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GrillaError" runat="server"  >
            <HeaderStyle BackColor="#BB9241" Height="30px" />
        </asp:GridView>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Nombre" CssClass="col-md-2 control-label">Nombre del archivo</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Nombre" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Nombre" CssClass="text-danger" ErrorMessage="Ingrese el nombre del archivo" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Restaurar base de datos" CssClass="btn btn-default" ID="RestoreBtn" />
            </div>
        </div>
    </div>
</asp:Content>
