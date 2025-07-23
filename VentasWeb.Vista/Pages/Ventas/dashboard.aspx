<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master/Principal.Master" CodeBehind="dashboard.aspx.vb" Inherits="VentasWeb.Vista.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style >
        .estiloTablaReporte {
	margin:0px;padding:0px;
	box-shadow: 10px 10px 5px #888888;
	border:1px solid #666666;
	
	-moz-border-radius-bottomleft:8px;
	-webkit-border-bottom-left-radius:8px;
	border-bottom-left-radius:8px;
	
	-moz-border-radius-bottomright:8px;
	-webkit-border-bottom-right-radius:8px;
	border-bottom-right-radius:8px;
	
	-moz-border-radius-topright:8px;
	-webkit-border-top-right-radius:8px;
	border-top-right-radius:8px;
	
	-moz-border-radius-topleft:8px;
	-webkit-border-top-left-radius:8px;
	border-top-left-radius:8px;
}.estiloTablaReporte table{
    border-collapse: collapse;
        border-spacing: 0;
	width:100%;
	height:100%;
	margin:0px;padding:0px;
}.estiloTablaReporte tr:last-child td:last-child {
	-moz-border-radius-bottomright:8px;
	-webkit-border-bottom-right-radius:8px;
	border-bottom-right-radius:8px;
}
.estiloTablaReporte table tr:first-child td:first-child {
	-moz-border-radius-topleft:8px;
	-webkit-border-top-left-radius:8px;
	border-top-left-radius:8px;
}
.estiloTablaReporte table tr:first-child td:last-child {
	-moz-border-radius-topright:8px;
	-webkit-border-top-right-radius:8px;
	border-top-right-radius:8px;
}.estiloTablaReporte tr:last-child td:first-child{
	-moz-border-radius-bottomleft:8px;
	-webkit-border-bottom-left-radius:8px;
	border-bottom-left-radius:8px;
}.estiloTablaReporte tr:hover td{
	
}
.estiloTablaReporte tr:nth-child(odd){ background-color:#d3e8ff; }
.estiloTablaReporte tr:nth-child(even)    { background-color:#f4f9fc; }.estiloTablaReporte td{
	vertical-align:middle;
	
	
	border:1px solid #666666;
	border-width:0px 1px 1px 0px;
	text-align:left;
	padding:7px;
	font-size:11px;
	font-family:Arial;
	font-weight:normal;
	color:#000000;
}.estiloTablaReporte tr:last-child td{
	border-width:0px 1px 0px 0px;
}.estiloTablaReporte tr td:last-child{
	border-width:0px 0px 1px 0px;
}.estiloTablaReporte tr:last-child td:last-child{
	border-width:0px 0px 0px 0px;
}
.estiloTablaReporte tr:first-child td{
		background:-o-linear-gradient(bottom, #2f84ed 5%, #66a7e8 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #2f84ed), color-stop(1, #66a7e8) );
	background:-moz-linear-gradient( center top, #2f84ed 5%, #66a7e8 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#2f84ed", endColorstr="#66a7e8");	background: -o-linear-gradient(top,#2f84ed,66a7e8);

	background-color:#2f84ed;
	border:0px solid #666666;
	text-align:center;
	border-width:0px 0px 1px 1px;
	font-size:14px;
	font-family:Arial;
	font-weight:bold;
	color:#ffffff;
}
.estiloTablaReporte tr:first-child:hover td{
	background:-o-linear-gradient(bottom, #2f84ed 5%, #66a7e8 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #2f84ed), color-stop(1, #66a7e8) );
	background:-moz-linear-gradient( center top, #2f84ed 5%, #66a7e8 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#2f84ed", endColorstr="#66a7e8");	background: -o-linear-gradient(top,#2f84ed,66a7e8);

	background-color:#2f84ed;
}
.estiloTablaReporte tr:first-child td:first-child{
	border-width:0px 0px 1px 0px;
}
        .estiloTablaReporte tr:first-child td:last-child {
            border-width: 0px 0px 1px 1px;
        }

        .divTablaDashboard {

        position:relative;
        background:#e6e59c;
        overflow-x: scroll;
        overflow-y: scroll;  
        width: 92%;
        height: 100%;
            top: 0px;
            left: 0px;
        }

       
    </style>
    <div style="position:absolute; top:10%; left :1%; width :98%; height :85%; margin-right: 7px;">
    <div class="divTablaDashboard">
        <asp:GridView ID="grdDatosDetalles" runat="server" CssClass="estiloTablaReporte" Height="161px" >
        </asp:GridView>
    </div>
        <div style="position:absolute; top:1%; left :92%; width :7%; height :99%; margin-right: 7px;">
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" />
        </div>
    </div> 
     </asp:Content>
