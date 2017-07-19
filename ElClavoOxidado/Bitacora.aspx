    <%@ Page Title="Bitácora" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Bitacora.aspx.vb" Inherits="ElClavoOxidado.Bitacora" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <link rel="stylesheet" href="Content/estilo.css" />
   
    <div class="container">
        <div class="Filtro">
            <asp:TextBox ID="txtDate" runat="server" ReadOnly = "true" CssClass="FiltroTxt"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Filtrar" CssClass="btn btn-default" Width="74px" />
        </div>
        <br />
        <br />
        <asp:GridView ID="GrillaBitacora" runat="server"  >
            <HeaderStyle BackColor="#BB9241" Height="30px" />
        </asp:GridView>
    </div>

    <style type="text/css">
        .ui-datepicker-trigger {
            height:30px;
        }
        .FiltroTxt {
            display: inline-block;
            width:150px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.428571429;
            color: #555555;
            vertical-align: middle;
            background-color: #ffffff;
            border: 1px solid #cccccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
            -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
            transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
        }

        .Filtro {
            float: right;
        }
    </style>
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

