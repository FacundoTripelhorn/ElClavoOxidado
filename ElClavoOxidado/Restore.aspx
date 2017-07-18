<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Restore.aspx.vb" Inherits="ElClavoOxidado.Restore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
</asp:Content>
