<%@ Page Title="Gestión de usuarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="UserManager.aspx.vb" Inherits="ElClavoOxidado.UserManager" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="Content/estilo.css" />
    <h2>Lista de usuarios</h2><br />
    <asp:GridView ID="GrillaUsuarios" runat="server">
        <HeaderStyle BackColor="#BB9241" />
    </asp:GridView>
    <br />
    <br />
    <div class="asignar_rol_container">
        <div class="rol_container">
            <div class="rol_container_left">
                <asp:Label runat="server" ID="UsuarioLbl" AssociatedControlID="Username" CssClass="control-label">Usuario</asp:Label>
                <asp:TextBox runat="server" ID="Username" CssClass="form-control" />
            </div>
            <div class="rol_container_right">
                <asp:Label runat="server" ID="FamiliaLbl" AssociatedControlID="Familia" CssClass="control-label FamiliaLbl">Rol</asp:Label>
                <asp:DropDownList ID="Familia" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="asignar_rol">
            <asp:Button ID="UpdateUsuarioBtn" runat="server" Text="Asignar rol" CssClass="btn btn-default" ValidationGroup="UserRole" />
        </div>
    </div>
    <br />
    
    <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
            CssClass="text-danger" ErrorMessage="Ingrese el nombre de usuario." ValidationGroup="UserRole"/>
    <br />
        
</asp:Content>
