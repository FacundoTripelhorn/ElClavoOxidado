<%@ Page Title="Carrito" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Carrito.aspx.vb" Inherits="ElClavoOxidado.Carrito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
      <h1>Mi Carrito</h1>
    
    
       <asp:GridView runat="server" ID="gvShoppingCart" AutoGenerateColumns="false" EmptyDataText="Su carrito se encuentra vacío." GridLines="None" Width="100%" CellPadding="5" ShowFooter="true" DataKeyNames="Codigo" >
                <HeaderStyle HorizontalAlign="Left" BackColor= "#cc9933" ForeColor="#FFFFFF" />
                <FooterStyle HorizontalAlign="Right" BackColor= "#cc9933" ForeColor="#FFFFFF" />
                <AlternatingRowStyle BackColor="#F8F8F8" />
                <Columns>
 
                    <asp:BoundField DataField="Descripcion" HeaderText="Producto" />
                     <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                   <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" >
                        <ItemTemplate>
                                $<%# FormatNumber(Eval("Precio"), 2)%>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" >
                        <ItemTemplate>
                                $<%# FormatNumber(Eval("Total"), 2)%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                </Columns>
           
            </asp:GridView> 
    <div style="float:left;">
        <h4>Calcular Costo de envío</h4>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="CABA" />
            <asp:ListItem Text="Buenos Aires" />
            <asp:ListItem Text="Córdoba" />
        </asp:DropDownList>
        <asp:Button CssClass="btn btn-default" Text="Calcular" runat="server"  onclick="CalcularEnvio_Click"/>
        <asp:TextBox cssclass="BuscarTxt" ID="txtCosto" runat="server" readonly="true"/>
    </div>
</asp:Content>
