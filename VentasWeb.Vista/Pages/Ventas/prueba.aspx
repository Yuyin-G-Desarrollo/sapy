<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master/Principal.Master" CodeBehind="prueba.aspx.vb" Inherits="VentasWeb.Vista.prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        aqui casual una nueva pagina</p>
    <p>
        <asp:Label ID="lblprueba" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" CellSpacing="5" Font-Names="Arial">
            <HeaderStyle BackColor="#3399FF" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#CCFFFF" Font-Size="Small" ForeColor="#666666" />
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
