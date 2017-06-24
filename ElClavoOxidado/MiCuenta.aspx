<%@ Page Title="Mi cuenta" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MiCuenta.aspx.vb" Inherits="ElClavoOxidado.MiCuenta" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %>.</h2>

     <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%:SuccessMessageText %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="span7">
            <section id="passwordForm">
               <asp:PlaceHolder runat="server" ID="changePasswordHolder">
                    <p>Ha iniciado sesión como <strong><%: User.Identity.Name%></strong>.</p>
                    <div class="form-horizontal">
                        <h4>Reestablezca su contraseña</h4>
                        <hr />
                        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                        <div class="form-group">
                            <asp:Label runat="server" ID="ContraseñaLbl" AssociatedControlID="ContraseñaActual" CssClass="col-md-2 control-label">Contraseña actual</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="ContraseñaActual" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ContraseñaActual"
                                    CssClass="text-danger" ErrorMessage="Ingrese su contraseña actual."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="ContraseñaNuevaLbl" AssociatedControlID="ContraseñaNueva" CssClass="col-md-2 control-label">Contraseña nueva</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="ContraseñaNueva" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ContraseñaNueva"
                                    CssClass="text-danger" ErrorMessage="Ingrese la nueva contraseña."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="ConfirmarContraseñaLbl" AssociatedControlID="ConfirmarContraseña" CssClass="col-md-2 control-label">Vuelva a ingresar la nueva contraseña</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="ConfirmarContraseña" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmarContraseña"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Ingrese nuevamente la nueva contraseña."
                                    ValidationGroup="ChangePassword" />
                                <asp:CompareValidator runat="server" ControlToCompare="ContraseñaNueva" ControlToValidate="ConfirmarContraseña"
                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden."
                                    ValidationGroup="ChangePassword" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" Text="Cambiar contraseña" CssClass="btn btn-default" OnClientClick="javascript:getHash()" ValidationGroup="ChangePassword" ID="CambiarContraseñaBtn" />
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>
            </section>
         </div>
    </div>

     <script type="text/javascript" src="Scripts/sha.js"></script>
    <script type="text/javascript">
        function getHash() {
        var hashInput = document.getElementById("<%=ContraseñaActual.ClientID%>");
        var hash = new jsSHA(hashInput.value, "TEXT");
        var hashOutput = document.getElementById("<%=ContraseñaActual.ClientID%>");

        var hash2Input = document.getElementById("<%=ContraseñaNueva.ClientID%>");
        var hash2 = new jsSHA(hash2Input.value, "TEXT");
        var hash2Output = document.getElementById("<%=ContraseñaNueva.ClientID%>");

        var hash3Input = document.getElementById("<%=ConfirmarContraseña.ClientID%>");
        var hash3 = new jsSHA(hash2Input.value, "TEXT");
        var hash3Output = document.getElementById("<%=ConfirmarContraseña.ClientID%>");

        hashOutput.value = hash.getHash("SHA-256", "HEX");
        hash2Output.value = hash2.getHash("SHA-256", "HEX");
        hash3Output.value = hash3.getHash("SHA-256", "HEX");
      }</script>
</asp:Content>
