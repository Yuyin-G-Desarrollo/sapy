<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="VentasWeb.Vista._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   

    <section class="container">
        <div class="login">
            <h1>Sistema de Administraci&oacute;n Yuyin</h1>
            
                <table>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblerror" Text="" runat="server" Font-Bold="True" ForeColor="#FF6600"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Usuario
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsuario" runat="server" Width="198px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contrase&ntilde;a
                        </td>
                        <td>
                            <asp:TextBox ID="txtContrasena" TextMode="password" runat="server" Width="198px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <p class="submit">
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" /></p>
        </div>

        <div class="login-help">
            <p>&copy Grupo Yuyin</p>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

