    <%@ Page Title="Bitácora" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Bitacora.aspx.vb" Inherits="ElClavoOxidado.Bitacora" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <asp:TextBox ID="txtDate" runat="server" ReadOnly = "true"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Filtrar" cssclass="btn btn-default" Width="74px" />
    <link rel="stylesheet" href="Content/estilo.css" />
    <br />
    <div class="container">
        <asp:GridView ID="GrillaBitacora" runat="server"  >
            <HeaderStyle BackColor="#BB9241" Height="30px" />
        </asp:GridView>
    </div>

    <style type="text/css">.ui-datepicker-trigger{height:20px;}</style>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<% = txtDate.ClientID %>").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'https://s-media-cache-ak0.pinimg.com/736x/c0/74/6d/c0746d1a59f56b5147e1d71c385c2cef--save-the-date-calendar-icon-png.jpg',
                dateformat: "dd-mm-yy",
            });
        });
    </script>
</asp:Content>

