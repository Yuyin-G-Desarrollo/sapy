<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master/Principal.Master" CodeBehind="formularioVariables.aspx.vb" Inherits="VentasWeb.Vista.formularioVariables"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
     
       #cmbClasificacion {
            width: 265px;
            height: 22px;
            margin-left: 0px;
            margin-top: 0px;
        }


        #cmbAgente {
           width: 264px;
            height: 22px;
            margin-left: 0px;
            margin-top: 0px;
        }

         #cmbMarcas {
           width: 269px;
            height: 22px;
            margin-left: 0px;
            margin-top: 0px;
        }
        
        #cmbTipoCategoria {
           width: 266px;
            height: 22px;
            margin-left: 0px;
            margin-top: 0px;
        }
         
         #cmbColecciones {
           width: 182px;
            height: 22px;
            margin-left: 0px;
            margin-top: 6px;
        }
         
        .modalTablaCliente {
            box-shadow: 0 0 10px 2px #a1a1a1;
            border-radius: 5px;
            margin: 0 auto;
            display: none;
            position: relative ;
            background: #eefcff;
            padding: 10px;
            width: 50%;
            height: 400PX;
            opacity: 30;
            position: absolute;
            top: 80%;
            left: 25%;            
            /*-webkit-transform: scale(1,1);
            -webkit-transition-timing-function: ease-out;
            -webkit-transition-duration: 250ms;
            -moz-transform: scale(1,1);
            -moz-transition-timing-function: ease-out;
            -moz-transition-duration: 250ms;*/
            }

        /*.modalTablaCliente:hover  { 
        -webkit-transform: scale(1.05,1.07);
        -webkit-transition-timing-function: ease-out;
        -webkit-transition-duration: 250ms;
        -moz-transform: scale(1.05,1.07);
        -moz-transition-timing-function: ease-out;
        -moz-transition-duration: 250ms;
        }*/

        .modalSombraTablaCliente {
            height: 350%;
            width: 100%;
            position: absolute;
            top: 0;
            left: 0;
            background: #a1a1a1;
            -moz-opacity: .50;
            filter: alpha(opacity=30);
            opacity: .30;
            display: none;
            z-index: 0;
        }



       .modalTablaModelo {
            box-shadow: 0 0 10px 2px #a1a1a1;
            border-radius: 5px;
            margin: 0 auto;
            display: none;
            position: relative;
            background: #eefcff;
            position: absolute;
            top: 80%;
            left: 25%;
            width: 50%;
            height: 400PX;
            opacity: 30;
            /*-webkit-transform: scale(1,1);
            -webkit-transition-timing-function: ease-out;
            -webkit-transition-duration: 250ms;
            -moz-transform: scale(1,1);
            -moz-transition-timing-function: ease-out;
            -moz-transition-duration: 250ms;*/
            }

        /*.modalTablaModelo:hover  { 
        -webkit-transform: scale(1.05,1.07);
        -webkit-transition-timing-function: ease-out;
        -webkit-transition-duration: 250ms;
        -moz-transform: scale(1.05,1.07);
        -moz-transition-timing-function: ease-out;
        -moz-transition-duration: 250ms;
        }*/

        .modalSombraTablaModelo {
            height: 350%;
            width: 100%;
            position: absolute;
            top: 0;
            left: 0;
             background: #a1a1a1;
            -moz-opacity: .30;
            filter: alpha(opacity=30);
            opacity: .50;
            display: none;
            z-index: 0;
        }


         .modalTablaDescripcion {
            box-shadow: 0 0 10px 2px #a1a1a1;
            border-radius: 5px;
            margin: 0 auto;
            display: none;
           position: absolute;
            top: 80%;
            left: 25%;
            background: #eefcff;
            padding: 10px;
            width: 50%;
            height: 400PX;
            opacity: 30;
            /*-webkit-transform: scale(1,1);
            -webkit-transition-timing-function: ease-out;
            -webkit-transition-duration: 250ms;
            -moz-transform: scale(1,1);
            -moz-transition-timing-function: ease-out;
            -moz-transition-duration: 250ms;*/
            }


        /*.modalTablaDescripcion:hover  { 
        -webkit-transform: scale(1.05,1.07);
        -webkit-transition-timing-function: ease-out;
        -webkit-transition-duration: 250ms;
        -moz-transform: scale(1.05,1.07);
        -moz-transition-timing-function: ease-out;
        -moz-transition-duration: 250ms;
        }*/

        .modalSombraTablaDescripcion {
            height: 350%;
            width: 100%;
            position: absolute;
            top: 0;
            left: 0;
             background: #a1a1a1;
            -moz-opacity: .30;
            filter: alpha(opacity=30);
            opacity: .50;
            display: none;
            z-index: 0;
        }


         .modalTablaColecciones {
            box-shadow: 0 0 10px 2px #a1a1a1;
            border-radius: 5px;
            margin: 0 auto;
            display: none;
            position: absolute;
            top: 80%;
            left: 25%;
             background: #eefcff;
            padding: 10px;
            width: 50%;
            height: 400PX;
            opacity: 30;
            /*-webkit-transform: scale(1,1);
            -webkit-transition-timing-function: ease-out;
            -webkit-transition-duration: 250ms;
            -moz-transform: scale(1,1);
            -moz-transition-timing-function: ease-out;
            -moz-transition-duration: 250ms;*/
            }

        /*.modalTablaColecciones:hover  { 
        -webkit-transform: scale(1.05,1.07);
        -webkit-transition-timing-function: ease-out;
        -webkit-transition-duration: 250ms;
        -moz-transform: scale(1.05,1.07);
        -moz-transition-timing-function: ease-out;
        -moz-transition-duration: 250ms;
        }*/

        .modalSombraTablaColecciones{
            height: 350%;
            width: 100%;
            position: absolute;
            top: 0;
            left: 0;
             background: #a1a1a1;
            -moz-opacity: .30;
            filter: alpha(opacity=30);
            opacity: .50;
            display: none;
            z-index: 0;
        }

         .modalTablaCorridas {
            box-shadow: 0 0 10px 2px #a1a1a1;
            border-radius: 5px;
            margin: 0 auto;
            display: none;
            position: absolute;
            top: 80%;
            left: 25%;
            background: #eefcff;
            padding: 10px;
            width: 50%;
            height: 400PX;
            opacity: 30;
            /*-webkit-transform: scale(1,1);
            -webkit-transition-timing-function: ease-out;
            -webkit-transition-duration: 250ms;
            -moz-transform: scale(1,1);
            -moz-transition-timing-function: ease-out;
            -moz-transition-duration: 250ms;*/
            }

        /*.modalTablaCorridas:hover  { 
        -webkit-transform: scale(1.05,1.07);
        -webkit-transition-timing-function: ease-out;
        -webkit-transition-duration: 250ms;
        -moz-transform: scale(1.05,1.07);
        -moz-transition-timing-function: ease-out;
        -moz-transition-duration: 250ms;
        }*/

        .modalSombraTablaCorridas{
            height: 350%;
            width: 100%;
            position: absolute;
            top: 0;
            left: 0;
             background: #a1a1a1;
            -moz-opacity: .30;
            filter: alpha(opacity=30);
            opacity: .50;
            display: none;
            z-index: 0;
        }

        .modalTablaFamilias {
            box-shadow: 0 0 10px 2px #a1a1a1;
            border-radius: 5px;
            margin: 0 auto;
            display: none;
            position: absolute;
            top: 80%;
            left: 25%;
            background: #eefcff;
            padding: 10px;
            width: 50%;
            height: 400PX;
            opacity: 30;
            /*-webkit-transform: scale(1,1);
            -webkit-transition-timing-function: ease-out;
            -webkit-transition-duration: 250ms;
            -moz-transform: scale(1,1);
            -moz-transition-timing-function: ease-out;
            -moz-transition-duration: 250ms;*/
            }

        /*.modalTablaFamilias:hover  { 
        -webkit-transform: scale(1.05,1.07);
        -webkit-transition-timing-function: ease-out;
        -webkit-transition-duration: 250ms;
        -moz-transform: scale(1.05,1.07);
        -moz-transition-timing-function: ease-out;
        -moz-transition-duration: 250ms;
        }*/

        .modalSombraTablaFamilias{
            height: 350%;
            width: 100%;
            position: absolute;
            top: 0;
            left: 0;
             background: #a1a1a1;
            -moz-opacity: .30;
            filter: alpha(opacity=30);
            opacity: .50;
            display: none;
            z-index: 0;
        }

        .modalMensajeEspera {
            box-shadow: 0 0 10px 2px #a1a1a1;
            border-radius: 5px;
            margin: 0 auto;
            display: none;
            position: relative;
            background: #eefcff;
            padding: 10px;
            width: 34%;
            height: 234px;
            opacity: 30;
            position: absolute;
            top: 25%;
            left: 25%;
            /*-webkit-transform: scale(1,1);
            -webkit-transition-timing-function: ease-out;
            -webkit-transition-duration: 250ms;
            -moz-transform: scale(1,1);
            -moz-transition-timing-function: ease-out;
            -moz-transition-duration: 250ms;*/
            }

               .modalSombraMensajeEspera {
            height: 350%;
            width: 100%;
            position: absolute;
            top: 0;
            left: 0;
            background: #a1a1a1;
            -moz-opacity: .50;
            filter: alpha(opacity=30);
            opacity: .30;
            display: none;
            z-index: 0;
        }

        /*-------------------------*/
         .modalAlerta {
            box-shadow: 0 0 10px 2px #a1a1a1;
            border-radius: 5px;
            margin: 0 auto;
            display: none;
            position: relative;
            background: #f16039;
            padding: 10px;
            width: 25%;
            height: 200PX;
            opacity: 30;         
            }

        /*-------------------------*/
        .tablaScrollModal {
            position: relative;
            width: 100%;
            height: 350PX;
            overflow-x: hidden ;
            overflow-y: scroll;
        }

        #btnMostrarClientes {
            margin-left: 52px;
        }

      
        #btnVerClientes {
            margin-left: 0px;
            height: 21px;
            width: 20px;
            margin-top: 0px;
        }

        #txtClienteSeleccionado {
            width: 258px;
            margin-left: 0px;
            margin-top: 0px;
        }
    
         #txtModeloSeleccionado {
            width: 257px;
            margin-left: 0px;
            margin-top: 0px;
        }
        #btnVerTablaModelos {
            width: 19px;
            height: 21px;
            margin-left: 0px;
        }
    
        #txtColeccionesSeleccion {
            width: 256px;
            margin-top: 0px;
            margin-left: 0px;
        }
               
        #btnVerColecciones {
            width: 19px;
            margin-left: 0px;
            height: 22px;
        }
                
             #btnVerCorridas {
            height: 22px;
            width: 22px;
        }

        #txtCorridasSeleccion {
            width: 255px;
            margin-top: 0px;
        }

        #cmbFamilias {
            width: 262px;
            height: 23px;
            margin-top: 0px;
        }
         
        #rdoYclasificacion {
            margin-bottom: 0px;
        }
      
        #txtClasificacionCadena {
            width: 37px;
            margin-left: 4px;
            margin-top: 0px;
        }
                         
         #selectContenedorOpciones {
            width: 100px;
            margin-left: 0px;
            margin-top: 0px;
            height: 96px;
        }
         
        #selectColumnas {
            width: 100px;
            margin-left: 0px;
            margin-top: 0px;
            height: 96px;
        }
             
        #selectFilas {
            width: 100px;
            margin-left: 0px;
            margin-top: 0px;
            height: 96px;
        }

        #selectOperaciones {
            width: 100px;
            margin-left: 0px;
            margin-top: 1px;
            height: 96px;
        }
         
        #txtClasificacionCadena0 {
            width: 44px;
        }
        #txtCadenaAgente {
            width: 37px;
        }
          
        #txtCadenaAgente0 {
            width: 37px;
        }
         
        #txtCadenaMarcas {
            width: 27px;
        }
        #txtCadenaMarcas0 {
            width: 27px;
        }
        #txtCadenaMarcas1 {
            width: 27px;
        }
        #txtCadenaCategoria {
            width: 30px;
        }
        #txtCadenaFamilia {
            width: 35px;
        }
                              
        #btnCrearConsulta {
            margin-left: 52px;
            margin-top: 12px;
        }
          
        #btnVerDescripciones {
            width: 19px;
            height: 23px;
        }
       
        #txtDescripcionSeleccionados {
            width: 243px;
            height: 23px;
            margin-left: 0px;
        }

        .checkboxIzquierda {
     
              height :15px;
              border-radius :100%;
        }

       .estiloTablaChecks {
	margin:0px;padding:0px;
	width:98%;
	/*border:1px solid #999999;*/
	
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
            height: 312px;

}
        .estiloTablaChecks table{
    border-collapse: collapse;
        border-spacing: 0;
	width:100%;
	height:100%;
	margin:0px;padding:0px;
}
         .estiloTablaChecks tr:last-child td:last-child {
	-moz-border-radius-bottomright:8px;
	-webkit-border-bottom-right-radius:8px;
	border-bottom-right-radius:8px;
}
         .estiloTablaChecks table tr:first-child td:first-child {
	-moz-border-radius-topleft:8px;
	-webkit-border-top-left-radius:8px;
	border-top-left-radius:8px;
}
         .estiloTablaChecks table tr:first-child td:last-child {
	-moz-border-radius-topright:8px;
	-webkit-border-top-right-radius:8px;
	border-top-right-radius:8px;
}
         .estiloTablaChecks tr:last-child td:first-child{
	-moz-border-radius-bottomleft:8px;
	-webkit-border-bottom-left-radius:8px;
	border-bottom-left-radius:8px;
}
          .estiloTablaChecks td:hover td{
	background-color:#ffffff;
}
          .estiloTablaChecks td{
	vertical-align:middle;
	
	/*background-color:#f7f9fc;*/

	/*border:1px solid #999999;*/
	border-width:0px 1px 1px 0px;
	text-align:left;
	padding:7px;
	font-size:12px;
	font-family:Arial;
	font-weight:normal;
	color:#000000;
}.estiloTablaChecks tr:last-child td{
	border-width:0px 1px 0px 0px;
}.estiloTablaChecks tr td:last-child{
	border-width:0px 0px 1px 0px;
}.estiloTablaChecks tr:last-child td:last-child{
	border-width:0px 0px 0px 0px;
}
.estiloTablaChecks tr:first-child td{
		background:-o-linear-gradient(bottom, #005fbf 5%, #003f7f 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #005fbf), color-stop(1, #003f7f) );
	background:-moz-linear-gradient( center top, #005fbf 5%, #003f7f 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#005fbf", endColorstr="#003f7f");	background: -o-linear-gradient(top,#005fbf,003f7f);

	background-color:#005fbf;
	border:0px solid #999999;
	text-align:center;
	border-width:0px 0px 1px 1px;
	font-size:15px;
	font-family:Arial;
	font-weight:bold;
	color:#ffffff;
}
.estiloTablaChecks tr:first-child:hover td{
	background:-o-linear-gradient(bottom, #005fbf 5%, #003f7f 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #005fbf), color-stop(1, #003f7f) );
	background:-moz-linear-gradient( center top, #005fbf 5%, #003f7f 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#005fbf", endColorstr="#003f7f");	background: -o-linear-gradient(top,#005fbf,003f7f);

	background-color:#005fbf;
}
.estiloTablaChecks tr:first-child td:first-child{
	border-width:0px 0px 1px 0px;
}
.estiloTablaChecks tr:first-child td:last-child{
	border-width:0px 0px 1px 1px;
}

.btnAceptarGenerarReporte {
	-moz-box-shadow:inset 0px 1px 0px 0px #bbdaf7;
	-webkit-box-shadow:inset 0px 1px 0px 0px #bbdaf7;
	box-shadow:inset 0px 1px 0px 0px #bbdaf7;
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#79bbff', endColorstr='#378de5');
	background-color:#79bbff;
	-webkit-border-top-left-radius:20px;
	-moz-border-radius-topleft:20px;
	border-top-left-radius:20px;
	-webkit-border-top-right-radius:20px;
	-moz-border-radius-topright:20px;
	border-top-right-radius:20px;
	-webkit-border-bottom-right-radius:20px;
	-moz-border-radius-bottomright:20px;
	border-bottom-right-radius:20px;
	-webkit-border-bottom-left-radius:20px;
	-moz-border-radius-bottomleft:20px;
	border-bottom-left-radius:20px;
	text-indent:0;
	border:1px solid #84bbf3;
	display:inline-block;
	color:#ffffff;
	font-family:Arial;
	font-size:15px;
	font-weight:bold;
	font-style:normal;
	line-height:65px;
	width:86px;
	text-align:center;
	text-shadow:1px 1px 0px #528ecc;
            margin-top: 0px;
        }
.classname:hover {
	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #378de5), color-stop(1, #79bbff) );
	background:-moz-linear-gradient( center top, #378de5 5%, #79bbff 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#378de5', endColorstr='#79bbff');
	background-color:#378de5;
}.classname:active {
	position:relative;
	top:1px;
}
				    
        #txtDescripcionSeleccionado {
            width: 258px;
        }
				    
        #Text1 {
            width: 11px;
        }
				    
        #txtColumnas {
            width: 0px;
        }
				    
        #txtColumnas0 {
            width: 191px;
        }
				    
        #txtColumnas0 {
            width: 191px;
        }
				    
        #txtFilas {
            width: 0px;
        }
        #txtOperaciones {
            width: 0px;
        }
				    
        </style>


</asp:Content>
<asp:Content ID="contenedorFormulario" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    
    <script type="text/javascript" src ="../../Scripts/jquery-1.6.1.min.js"></script>
    <script type="text/javascript" src ="../../Scripts/jquery-ui-1.8.13.custom.min.js" ></script>
    <script type="text/javascript" src="../../Scripts/ui.dropdownchecklist-1.4-min.js"></script>
<%--    <%
                    Dim objVentSicy As New Ventas.Negocios.VentasSicyBU
                    Dim listaClas As System.Data.DataTable = objVentSicy.verListaClasificacionesSicy
                    Dim opciones As String = ""
                    For Each rowDtas As System.Data.DataRow In listaClas.Rows
                %>--%>
    

  <div style="position:absolute; top:10%; left :3%; width :77%; height :298%; margin-right: 7px;"  id="divPanelesChecksRdos">
        <div style="width: 925px; height: 378px; margin-top: 1px;">
            <table class="estiloTablaChecks">
                <tr>
                    <td>
                        <asp:Label ID="lblModeloTitulo" runat="server" Font-Size="Medium" Font-Strikeout="False" Text="Modelo" Font-Italic="False" Font-Names="Century Gothic" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblVentasTitulo" runat="server" Font-Size="Medium" Font-Strikeout="False" Text="Ventas" Font-Italic="False" Font-Names="Century Gothic" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEstiloTitulo" runat="server" Font-Size="Medium" Font-Strikeout="False" Text="Estilo" Font-Italic="False" Font-Names="Century Gothic" Font-Bold="true"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblOperaciones" runat="server" Font-Size="Medium" Font-Strikeout="False" Text="Valores a Mostrar" Font-Italic="False" Font-Names="Century Gothic" Font-Bold="true"></asp:Label>
                    </td>
                    <td colspan="3">
                        ESTRUCTURA DEL REPORTE
                    </td>
                </tr>

                <tr>
                    <td>
                        <input id="ckbMarca" type="checkbox" class="checkboxIzquierda" />Marca</td>
                    <td>
                        <input id="ckbClasificacion" type="checkbox" class="checkboxIzquierda" />Clasificación</td>
                    <td>
                        <input id="ckbFamilia" type="checkbox" class="checkboxIzquierda" />Familia</td>
                    <td>
                        <input id="ckbSumaPares" type="checkbox" class="checkboxIzquierda" />Suma de Pares</td>
                    <td rowspan="2">
                        <select id="selectContenedorOpciones" name="selectContenedorOpciones" multiple="multiple"></select></td>
                    <td rowspan="2">
                        <input id="btnEnviarColumnas" type="button" style="background: url('../../Images/pasarDerecha.png') no-repeat; height: 36px; width: 31px;" /></td>
                    <td rowspan="2">
                        <select id="selectColumnas" name="selectColumnas" multiple="multiple" aria-selected="false" draggable="true"></select><input id="txtColumnas" name="txtColumnas" type="text" hidden="hidden" /></td>
                </tr>

                <tr>
                    <td>
                        <input id="ckbCategoria" type="checkbox" class="checkboxIzquierda" />Categoría</td>
                    <td>
                        <input id="ckbCliente" type="checkbox" class="checkboxIzquierda" />Cliente</td>
                    <td>
                        <input id="ckbCorrida" type="checkbox" class="checkboxIzquierda" />Corrida</td>
                    <td>
                        <input id="ckbArticulos" type="checkbox" class="checkboxIzquierda" />Cantidad de Articulos</td>
                </tr>

                <tr>
                    <td>
                        <input id="ckbColeccion" type="checkbox" class="checkboxIzquierda" />
                        Colección</td>
                    <td>
                        <input id="ckbAgente" type="checkbox" class="checkboxIzquierda" />Agente</td>
                    <td>
                    </td>
                    <td>
                        <input id="ckbColecciones" type="checkbox" class="checkboxIzquierda" />Cantidad de Colecciones</td>
                    <td>
                        <input id="btnEnviarFilas" type="button" style="background: url('../../Images/bajar.png')no-repeat; width: 37px; height: 30px;" /></td>
                </tr>
                <tr>
                    <td>
                        <input id="ckbDescripcion" type="checkbox" class="checkboxIzquierda" />Descripción</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <select id="selectFilas" name="selectFilas" multiple="multiple"></select><input id="txtFilas" name="txtFilas" type="text" hidden="hidden" /></td>
                    <td></td>
                    <td>
                        <select id="selectOperaciones" name="selectOperaciones" multiple="multiple"></select>
                        <input id="txtOperaciones" name="txtOperaciones" type="text" hidden="hidden" /></td>
                </tr>
                <tr>
                    <td>
                        <input id="ckbModelo" type="checkbox" class="checkboxIzquierda" />
                        Modelo</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGenerarConsulta" runat="server" Text="Aceptar" OnClientClick="javascript:return FuncionValidaVariablesVacias()" />
                    </td>
                </tr>
            </table>
       </div>
     </div>
    <div style="position: absolute; top: 85%; left: 3%; width: 72%; height: 688px; margin-right: 5px; margin-left: 0px;" id="DivVariablesFiltro">
        <table class ="estiloTablaChecks" >
                <tr>
                    <td colspan="5">
                        FILTROS
                    </td>
                  </tr>
                <tr>
                    <td>
                        VENTAS
                    </td>  
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>                  
                </tr>
                 
                <tr>
                    <td></td>
                    <td></td>
                   
                    <td >De: <input id="AbrirCalendarioFechaUno" name="AbrirCalendarioFechaUno" type="text" class="ll-skin-nigran" />
                       
                    </td>
                    
                    <td colspan ="2"> a <input id="AbrirCalendarioFechaDos" name="AbrirCalendarioFechaDos" type="text" /></td>
                    
                </tr>
              
             <tr>
                 <td><input id="rdoYclasificacion" type="radio" name="radiosClasificacion" value="AND" checked="checked"/> Y
                     <input id="rdoOClasificacion" type="radio" name="radiosClasificacion" value="OR"/> O</td>
                 <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                 <td><asp:Label ID="lblPorClasificacion" runat="server" Font-Names="Century Gothic" Font-Size="8pt" Text="Clasificación"></asp:Label></td>
                 <td>
                     <select id="cmbClasificacion" name="cmbClasificacion" multiple="multiple">
                <%
                    Dim objVentSicy As New Ventas.Negocios.VentasSicyBU
                    Dim listaClas As System.Data.DataTable = objVentSicy.verListaClasificacionesSicy
                    Dim opciones As String = ""
                    For Each rowDtas As System.Data.DataRow In listaClas.Rows
                %>
                <option id='<%Response.Write(rowDtas.Item("IdClasificacion").ToString())%>'>
                    <%Response.Write(rowDtas.Item("IdClasificacion").ToString())%></option>
                <%
                Next
                %>
            </select>
                 </td>
              </tr>
                <tr>
                    <td><input id="rdoYagente" type="radio" name="radiosAgente" checked="checked" value="AND"/> Y
                        <input id="rdoOagente" type="radio" name="radiosAgente" value="OR"/> O
                    </td>
                    <td></td>
                     <td>
                        <asp:Label ID="lblAgente" runat="server" Font-Names="Century Gothic" Font-Size="8pt" Text="Agente"></asp:Label>
                    </td>
                    <td>
                 <select id="cmbAgente" name="cmbAgente" multiple="multiple">
                <%
                    Dim objVentSicyAgentes As New Ventas.Negocios.VentasSicyBU
                    Dim dtAgentesTabDT As System.Data.DataTable = objVentSicy.verListaAgentesSicy
                    For Each rowDtClts As System.Data.DataRow In dtAgentesTabDT.Rows
                %>
                <option id='<%Response.Write(rowDtClts.Item("IdAgente").ToString())%>'><%Response.Write(rowDtClts.Item("Nombre").ToString())
                %></option>
                <%
                Next
                %>
              </select>
               </td>
                </tr>
                <tr>
                    <td>
                        <input id="rdoYcliente" type="radio" name="radiosCliente" checked="checked" value="AND" /> Y
                        <input id="rdoOcliente" type="radio" name="radiosCliente" value="OR"/> O
                    </td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblPorCliente" runat="server" Font-Names="Century Gothic" Font-Size="8pt" Text="Cliente"></asp:Label>
                    </td>
                    <td>
                        <input id="txtClienteSeleccionado" name="txtClienteSeleccionado" type="text" readonly="true" />
                    </td>
                    <td>
                        <input id="btnVerClientes" type="button" class="showModalTabla" />
                    </td>
                </tr>
                <tr>
                    <td>
                        MODELOS
                    </td>                    
                </tr>
                <tr>
                   <td>
                    <input id="rdoYModelo" type="radio" name="radiosModelos" checked="checked" value="AND"/> Y
                       <input id="rdoOModelo" type="radio" name="radiosModelos" value="OR"/> O
                    </td>
                    <td>                    
                    </td>
                     <td>
                     <asp:Label ID="lblPormModelo" runat="server" Font-Names="Century Gothic" Font-Size="8pt" Text="Modelo"></asp:Label>
                    </td>
                     <td>
                    <input id="txtModeloSeleccionado" name="txtModeloSeleccionado" type="text" readonly="true" />
                    </td>
                     <td>
                    <input id="btnVerTablaModelos" type="button" class="showModalTablaModelos" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="rdoYDescripcion" type="radio" name="radiosDescripcion" checked="checked" value="AND"/> Y
                       <input id="rdoODescripcion" type="radio" name="radiosDescripcion" value="OR"/> O
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="lblDescripcion" runat="server" Font-Names="Century Gothic" Font-Size="8pt" Text="Descripcion"></asp:Label>
                    </td>
                    <td>
                    <input id="txtDescripcionSeleccionado" name="txtDescripcionSeleccionado" type="text" readonly="true" />
                    </td>
                    <td>
                    <input id="btnVerDescripciones" type="button" class="showModalTablaDescripcion" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="rdoYMarca" type="radio" name="radiosMarcas" checked="checked" value="AND"/> Y            
                        <input id="rdoOMarca" type="radio" name="radiosMarcas" value="OR"/> O
                    </td>
                    <td></td>
                     <td>
                         <asp:Label ID="lblMarca" runat="server" Font-Names="Century Gothic" Font-Size="8pt" Text="Marcas"></asp:Label>
                    </td>
                     <td>
                         <select id="cmbMarcas" multiple="multiple" name="cmbMarcas">
                <%
                    Dim objVentSicyMarcas As New Ventas.Negocios.VentasSicyBU
                    Dim dtMarcasSicy As System.Data.DataTable = objVentSicyMarcas.verListaMarcasSicy
                    For Each rowMarcaDT As System.Data.DataRow In dtMarcasSicy.Rows
                %>
                <option id='<%Response.Write(rowMarcaDT.Item("IdMarca").ToString())%>'><%
                        Response.Write(rowMarcaDT.Item("Marca").ToString())
                    %></option>
                <%
                Next
                %>
            </select>
                    </td>
                   
                </tr>
                <tr>
                    <td>
                        <input id="rdoYColeccion" type="radio" name="radiosColeccion" checked="checked" value="AND"/> Y
                    <input id="rdoOColeccion" type="radio" name="radiosColeccion" value="OR"/> O
                    </td>
                    <td></td>
                    <td>
                        <asp:Label ID="lblColeccion" runat="server" Font-Names="Century Gothic" Font-Size="8pt" Text="Colecciones"></asp:Label>
                    </td>
                    <td>
                        <input id="txtColeccionesSeleccion" name="txtColeccionesSeleccion" type="text" readonly="true" />
                    </td>
                    <td>
                        <input id="btnVerColecciones" type="button" class="showModalTablaColecciones" />
                    </td>
                </tr>
                <tr>
                    <td>
                   <input id="rdoYCategoria" type="radio" name="radiosCategoria" checked="checked" value="AND" /> Y
                   <input id="rdoOCategoria" type="radio" name="radiosCategoria" value="OR"/> O
                    </td>
                    <td></td>
                    <td>
                    <asp:Label ID="lblTipoCategoria" runat="server" Font-Names="Century Gothic" Font-Size="8pt" Text="Categoría"></asp:Label>
                    </td>
                    <td>
                    <select id="cmbTipoCategoria" name="cmbTipoCategoria" multiple="multiple">
                    <%
                     Dim objCategoriaSay As New Programacion.Negocios.CategoriasBU
                     Dim dtCategoriasDTS As System.Data.DataTable = objCategoriaSay.verListaCategorias(True)
                     For Each rowCatDT As System.Data.DataRow In dtCategoriasDTS.Rows
                    %>
                    <option>
                    <%
                        Response.Write(rowCatDT.Item("tica_descripcion").ToString())
                    %>
                    </option>
                    <%
                    Next
                    %>
            </select>
                    </td>
                    
                    </tr>
                <tr>
                    <td>
                        ESTILO
                    </td>                    
                </tr>
                 <tr>
                    <td>
                        <input id="rdoYCorrida" type="radio" name="radiosCorrida" checked="checked" value="AND"/> Y  
                        <input id="rdoOCorrida" type="radio" name="radiosCorrida" value="OR"/> O
                    </td>
                     <td></td>
                    <td>
                        <asp:Label ID="lblCorrida" runat="server" Font-Names="Century Gothic" Font-Size="8pt" Text="Corrida"></asp:Label>
                    </td>
                    <td>
                        <input id="txtCorridasSeleccion" name="txtCorridasSeleccion" type="text" readonly="true" />
                    </td>
                    <td>
                        <input id="btnVerCorridas" type="button" class="showModalTablaCorridas" />
                    </td>                   
                 </tr>
                <tr>
                    <td>
                        <input id="rdoYFamilia" type="radio" name="radiosFamilia" checked="checked" value="AND"/> Y
                        <input id="rdoOFamilia" type="radio" name="radiosFamilia" value="OR"/> O
                    </td> 
                    <td></td> 
                    <td>
                <asp:Label ID="lblFamilia" runat="server" Font-Names="Century Gothic" Font-Size="8pt" Text="Familia"></asp:Label>
                    </td>
                    <td>
                          <select id="cmbFamilias" multiple="multiple" name="cmbFamilias">
                            <%
                                Dim objFamiliasSay As New Programacion.Negocios.FamiliasBU
                                Dim dtFamiliasDTS As System.Data.DataTable = objFamiliasSay.ListarFamilias("", "", True)
                                For Each rowFamDT As System.Data.DataRow In dtFamiliasDTS.Rows
                            %>
                            <option><%
                                        Response.Write(rowFamDT.Item("fami_descripcion").ToString())
                                %></option>
                            <%
                            Next
                            %>
                            </select>
                    </td>
                </tr>
               </table>    
    </div>
        <%--inicia modal cliente--%>
    <div class="modalSombraTablaCliente" onclick="hideModalTablaCliente();">
    </div>
    <div class="modalTablaCliente">
        <div class="tablaScrollModal">
            <%
                Dim objVentSicyClienteTDBU As New Ventas.Negocios.VentasSicyBU
                Dim dtListaClientesTB As System.Data.DataTable
                dtListaClientesTB = objVentSicyClienteTDBU.verListaClientesSicy
            %>
            <table>
                <tr>
                    <th>Selección</th>
                    <th>Id</th>
                    <th>Nombre</th>
                </tr>
                <%
                    For Each rowClienteDT As System.Data.DataRow In dtListaClientesTB.Rows
                %>
                <tr>
                    <td>
                        <input type="checkbox" name="nombreCliente" value="<%Response.Write(rowClienteDT.Item("nombre").ToString())%>" /></td>
                    <%
                        Response.Write("<td>" + rowClienteDT.Item("IdCadena").ToString() + "</td>")
                        Response.Write("<td>" + rowClienteDT.Item("nombre").ToString() + "</td>")
                    %>
                </tr>
                <%
                Next
                %>
            </table>
        </div>
        <input type="button" id="btnSubmitCliente" value="Aceptar" />
    </div>
    <%--termina modal cliente--%>

   <%--  comienza modal modelo--%>
    <div class="modalSombraTablaModelo" onclick="hideModalTablaModelos();">
    </div>
    <div class="modalTablaModelo">
        <div class="tablaScrollModal">
            <%
                Dim objVentSicyModeloTDBU As New Ventas.Negocios.VentasSicyBU
                Dim dtListaModeloTB As System.Data.DataTable
                dtListaModeloTB = objVentSicyModeloTDBU.verListaModelosSicy
            %>
            <table>
                <tr>
                    <th>Selección</th>
                    <th>Descripción</th>
                </tr>
                <%
                    For Each rowModelosDT As System.Data.DataRow In dtListaModeloTB.Rows
                %>
                <tr>
                    <td>
                        <input type="checkbox" name="nombreModelo" value="<%Response.Write(rowModelosDT.Item("ModeloDesc").ToString())%>" /></td>
                    <%
                        Response.Write("<td>" + rowModelosDT.Item("ModeloDesc").ToString() + "</td>")
                    %>
                </tr>
                <%
                Next
                %>
            </table>

        </div>
        <input type="button" id="btnSubmitModelos" value="Aceptar" />
    </div>
    <%--  termina modal modelo--%>

   <%--  comienza modal descripcion--%>
    <div class="modalSombraTablaDescripcion" onclick="hideModalTablaDescripcion();">
    </div>
    <div class="modalTablaDescripcion">
        <div class="tablaScrollModal">
            <%
                Dim objVentSicyDescripcionTDBU As New Ventas.Negocios.VentasSicyBU
                Dim dtListaDescripcionTB As System.Data.DataTable
                dtListaDescripcionTB = objVentSicyModeloTDBU.verListaDescripcionesSicy
            %>
            <table>
                <tr>
                    <th>Selección</th>
                    <th>Código</th>
                    <th>Descripción</th>
                </tr>
                <%
                    For Each rowDescripcionDT As System.Data.DataRow In dtListaDescripcionTB.Rows
                %>
                <tr>
                    <td>
                        <input type="checkbox" name="nombreDescripcion" value="<%Response.Write(rowDescripcionDT.Item("Descripcion").ToString())%>" /></td>
                    <%
                        Response.Write("<td>" + rowDescripcionDT.Item("IdCodigo").ToString() + "</td>")
                        Response.Write("<td>" + rowDescripcionDT.Item("Descripcion").ToString() + "</td>")
                    %>
                </tr>
                <%
                Next
                %>
            </table>

        </div>
        <input type="button" id="btnSubmitDescripcion" value="Aceptar" />
    </div>
    <%--  termina modal descripcion--%>

   <%--inicia modal colecciones--%>
    <div class="modalSombraTablaColecciones" onclick="hideModalTablaColecciones();">
    </div>
    <div class="modalTablaColecciones">
        <div class="tablaScrollModal">
            <%
                Dim objVentSicyColeccionesTDBU As New Ventas.Negocios.VentasSicyBU
                Dim dtListaColeccionesTB As System.Data.DataTable
                dtListaColeccionesTB = objVentSicyClienteTDBU.verListaColeccionesSicy
            %>
            <table>
                <tr>
                    <th>Selección</th>
                    <th>Id</th>
                    <th>Nombre Colección</th>
                </tr>
                <%
                    For Each rowColccionesDT As System.Data.DataRow In dtListaColeccionesTB.Rows
                %>
                <tr>
                    <td>
                        <input type="checkbox" name="nombreColeccion" value="<%Response.Write(rowColccionesDT.Item("Coleccion").ToString())%>" /></td>
                    <%
                        Response.Write("<td>" + rowColccionesDT.Item("IdColeccion").ToString() + "</td>")
                        Response.Write("<td>" + rowColccionesDT.Item("Coleccion").ToString() + "</td>")
                    %>
                </tr>
                <%
                Next
                %>
            </table>
        </div>
        <input type="button" id="btnSubmitColeccion" value="Aceptar" />
    </div>
    <%--termina modal colecciones--%>


    
      <%--inicia modal Corridas--%>
    <div class="modalSombraTablaCorridas" onclick="hideModalTablaCorridas();">
    </div>
    <div class="modalTablaCorridas">
        <div class="tablaScrollModal">
            <%
                Dim objVentSicyCorridasTDBU As New Ventas.Negocios.VentasSicyBU
                Dim dtListaCorridasTB As System.Data.DataTable
                dtListaCorridasTB = objVentSicyClienteTDBU.verListaCorridasSicy
            %>
                   <table>
                
                <tr>
                    <th>Selección</th>
                    <th>Id</th>
                    <th>Nombre Corrida</th>
                </tr>
                <%
                    For Each rowCorridasDT As System.Data.DataRow In dtListaCorridasTB.Rows
                %>
                <tr>
                    <td>
                        <input type="checkbox" name="nombreCorrida" value="<%Response.Write(rowCorridasDT.Item("Talla").ToString())%>" /></td>
                    <%
                        Response.Write("<td>" + rowCorridasDT.Item("IdTalla").ToString() + "</td>")
                        Response.Write("<td>" + rowCorridasDT.Item("Talla").ToString() + "</td>")
                    %>
                </tr>
                <%
                Next
                %>
            </table>
        </div>
        
        <input type="button" id="Button1" value="Aceptar" />
    </div>
    <%--termina modal Corridas--%>

    <%-- Comienza modal mensaje de espera--%>    
    <div class="modalSombraMensajeEspera"></div>

    <div class="modalMensajeEspera">
        <asp:Panel ID="pnlMensaje" runat="server" Height="232px" Width="443px">
            &nbsp;<br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMensajeUno" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Century Gothic" Font-Size="Large" Text="Éste proceso puede tardar algunos minutos."></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img src="../../Images/loading.gif" width="50" height="50"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Panel>
    </div>
    <%-- Termina modal mensaje de espera--%>
  

    <%--Comineza modal alerta--%>
<div class="modalAlerta">
    errorsote
    <a id="cerrarModalAlerta" href="#" >Cerrar</a>
</div>

    <%--Termina modal alerta--%>

    <%--::::::::::::::::::::::::::::::::::::::::::::COMIENZAN SCRIPTS ::::::::::::::::::::::::::::::::::::::::--%>
       <script type="text/javascript" >
           var modalAlertaV = $(".modalAlerta")

           $("#cerrarModalAlerta").click(function () {
               hideModalAlert();
           });

           function hideModalAlert() {
               modalAlertaV.fadeOut(500);
           }

           function FuncionValidaVariablesVacias() {
              
               var Columnas = document.getElementById('txtColumnas');
               var Filas = document.getElementById('txtFilas');
               var operaciones = document.getElementById('txtOperaciones');
               var modelos = document.getElementById('txtModeloSeleccionado');
               var marca = document.getElementById('cmbMarcas');
               var fechaInicial = $("#AbrirCalendarioFechaUno").val();             
               var fechaFinal = $("#AbrirCalendarioFechaDos").val();
               var diasTotal=0
               var columnasValues = "";
               var filasValues = "";
               var operacionesValues = "";
               
               if ($("#AbrirCalendarioFechaDos").val() != '' && $("#AbrirCalendarioFechaUno").val() != '')
               {                   
                   var arregloFechaUno = fechaInicial.split('/');
                   var fechaUnoConcatena = arregloFechaUno[1] + "/" + arregloFechaUno[0] + "/" + arregloFechaUno[2]
                   var arregloFechaDos = fechaFinal.split('/');
                   var fechaDosConcatena = arregloFechaDos[1] + "/" + arregloFechaDos[0] + "/" + arregloFechaDos[2]
                   var fechaInicio = new Date(fechaUnoConcatena);
                   var fechaFin = new Date(fechaDosConcatena);
                   diasTotal = fechaFin - fechaInicio;
                   diasTotal = Math.floor((((diasTotal / 1000) / 60) / 60) / 24);
               }

               $("#selectColumnas option").each(function () {
                   columnasValues = columnasValues + $(this).attr('value') + ",";
               });
               $("#txtColumnas").val(columnasValues.substring(0, columnasValues.length - 1));

               $("#selectFilas option").each(function () {
                   filasValues = filasValues + $(this).attr('value') + ",";
               });
               $("#txtFilas").val(filasValues.substring(0, filasValues.length - 1));

               $("#selectOperaciones option").each(function () {
                   operacionesValues = operacionesValues + $(this).attr('value') + ",";
               });
               $("#txtOperaciones").val(operacionesValues.substring(0, operacionesValues.length - 1));

               var columnasCombo = document.getElementById("selectColumnas")
               var filasCombo = document.getElementById("selectFilas")
               var operacionesCombo = document.getElementById("selectOperaciones")
               var feInil = document.getElementById("AbrirCalendarioFechaUno")
               var feFin = document.getElementById("AbrirCalendarioFechaDos")
               if (columnasValues == '' || filasValues == '' || operacionesValues == '' || fechaInicial == '' || fechaFinal == '' || diasTotal > 365 || diasTotal < 0) {

                   if (columnasValues == '') {
                       columnasCombo.style.borderColor = "RED"
                   }
                   else {
                       columnasCombo.style.borderColor = "BLACK"
                   }

                   if (filasValues == '') {
                       filasCombo.style.borderColor = "RED"
                   }
                   else {
                       filasCombo.style.borderColor = "BLACK"
                   }

                   if (operacionesValues == '') {
                       operacionesCombo.style.borderColor = "RED"
                   }
                   else {
                       operacionesCombo.style.borderColor = "BLACK"
                   }

                   if (fechaInicial == '') {
                       feInil.style.borderColor = "RED"
                   }
                   else {
                       feInil.style.borderColor = "BLACK"
                   }

                   if(fechaFinal==''){                       
                       feFin.style.borderColor = "RED"
                   }
                   else {
                       feFin.style.borderColor = "BLACK"
                   }
                   modalAlertaV.fadeIn(500)
                                  return false
               }
               else {
                   columnasCombo.style.borderColor = "BLACK"
                   filasCombo.style.borderColor = "BLACK"
                   operacionesCombo.style.borderColor = "BLACK"
                   feInil.style.borderColor = "BLACK"
                   feFin.style.borderColor = "BLACK"
               }


               //              // Check inputs
               //if (Columnas.value == '') {
               //    modalAlertaV.fadeIn(500);
               //    //alert('Es necesario agregar al menos un campo para columnas');
               //    return false;
               //}               
               //if (Filas.value == "") {
               //    var filasCombo = document.getElementById("selectFilas")
               //    filasCombo.style.borderColor = "#2EFEF7"
               //    alert("Es necesario agregar al menos un campo para filas");
               //                      return false;
               //}       
               //if (operaciones.value == "") {
               //    alert("Es necesario agregar al menos un campo para operaciones");
               //    return false;
               //}
               if ($("#ckbModelo").attr("checked") && marca.value == "") {
                   alert("Si selecciona el campo de modelos debe de filtrar por marca.");
                   return false;
               }
               if ($("#ckbDescripcion").attr("checked") && marca.value == "") {
                   alert("Si selecciona el campo de descripcion debe de filtrar por marca.");
                   return false;
               }
               //if (fechaInicial.value == '')
               //{
               //    alert("Debe seleccionar una fecha inicial.");
               //    return false;
               //}
               //if (fechaFinal.value == '')
               //{
               //    alert("Debe seleccioar una fecha final");
               //    return false
               //}
               //if (diasTotal > 365) {
               //    alert("El intervalo de fechas no puede ser mayor a un año.");
               //    return false
               //}
               //if (diasTotal <= 0) {
               //    alert("Intervalo de fechas no valido.");
               //    return false
               //}
                   
               //else {
               abrirMensajeEspera();
                   return true;
               //}

           }           
           //inicia modal mensaje espera

           var tablaSombraMensajeEspera = $(".modalSombraMensajeEspera");
           var tablaMensajeEspera = $(".modalMensajeEspera");

           function abrirMensajeEspera(){
               tablaSombraMensajeEspera.fadeIn(500);
               tablaMensajeEspera.fadeIn(500);
           };

           //$(".hideModalMensajeEspera").click(function () {
           //  hideModalMensajeEspera();
           //});

           //function hideModalMensajeEspera() {
           //    var selectedLanguage = new Array();
           //    tablaSombraMensajeEspera.fadeOut(500);
           //    tablaMensajeEspera.fadeOut(500);
           //}
           // termina modal mensaje espera
         
          var modalbgTab = $(".modalSombraTablaCliente");
           var modalTab = $(".modalTablaCliente");

          $(function () {
              $("#AbrirCalendarioFechaUno").datepicker();
              $("#AbrirCalendarioFechaUno").datepicker({
                  showAnim: function () { "Drop", showButtonPanel; true}
              });
          });

          $(function () {
              $("#AbrirCalendarioFechaDos").datepicker();
              $("#AbrirCalendarioFechaDos").datepicker({
                  showAnim: function () { "Drop", showButtonPanel; true }
              });
          });

          $("#ckbClasificacion").change(function () {
              if ($('#ckbClasificacion').attr('checked')) {
                  $("#selectContenedorOpciones").append("<option value='optClasificacion'>Clasificación</option>");

              }
              else {
                  $("#selectContenedorOpciones").find("[value='optClasificacion']").remove();
                  $("#selectColumnas").find("[value='optClasificacion']").remove();
                  $("#selectFilas").find("[value='optClasificacion']").remove();

                  var columnasValues = "";
                  var filasValues = "";

                  $("#selectColumnas option").each(function () {
                      columnasValues = columnasValues + $(this).text() + ",";
                  });
                  $("#txtColumnas").val(columnasValues.substring(0, columnasValues.length - 1));

                  $("#selectFilas option").each(function () {
                      filasValues = filasValues + $(this).text() + ",";
                  });
                  $("#txtFilas").val(filasValues.substring(0, filasValues.length - 1));
              }
              
           });

          $("#ckbCliente").change(function () {
              if ($("#ckbCliente").attr("checked")) {
                  $("#selectContenedorOpciones").append("<option value='optCliente'>Cliente</option>");
              }
              else {
                  $("#selectContenedorOpciones").find("[value='optCliente']").remove();
                  $("#selectColumnas").find("[value='optCliente']").remove();
                  $("#selectFilas").find("[value='optCliente']").remove();
              }
          });

          $("#ckbAgente").change(function () {
              if ($("#ckbAgente").attr("checked")) {
                  $("#selectContenedorOpciones").append("<option value='optAgente'>Agente</option>");
              }
              else {
                  $("#selectContenedorOpciones").find("[value='optAgente']").remove();
                  $("#selectColumnas").find("[value='optAgente']").remove();
                  $("#selectFilas").find("[value='optAgente']").remove();
              }
          });

          $("#ckbMarca").change(function () {
              if ($("#ckbMarca").attr("checked")) {
                  $("#selectContenedorOpciones").append("<option value='optMarca'>Marca</option>");
              }
              else {
                  $("#selectContenedorOpciones").find("[value='optMarca']").remove();
                  $("#selectColumnas").find("[value='optMarca']").remove();
                  $("#selectFilas").find("[value='optMarca']").remove();
              }
          });

          $("#ckbCategoria").change(function () {
              if ($("#ckbCategoria").attr("checked")) {
                  $("#selectContenedorOpciones").append("<option value='optCategoria'>Categoría</option>");
              }
              else {
                  $("#selectContenedorOpciones").find("[value='optCategoria']").remove();
                  $("#selectColumnas").find("[value='optCategoria']").remove();
                  $("#selectFilas").find("[value='optCategoria']").remove();
              }
          });

          $("#ckbColeccion").change(function () {
              if ($("#ckbColeccion").attr("checked")) {
                  $("#selectContenedorOpciones").append("<option value='optColeccion'>Colección</option>");
              }
              else {
                  $("#selectContenedorOpciones").find("[value='optColeccion']").remove();
                  $("#selectColumnas").find("[value='optColeccion']").remove();
                  $("#selectFilas").find("[value='optColeccion']").remove();
              }
          });

          $("#ckbModelo").change(function () {
              if ($("#ckbModelo").attr("checked")) {
                  $("#selectContenedorOpciones").append("<option value='optModelo'>Modelo</option>");
              }
              else {
                  $("#selectContenedorOpciones").find("[value='optModelo']").remove();
                  $("#selectColumnas").find("[value='optModelo']").remove();
                  $("#selectFilas").find("[value='optModelo']").remove();
              }
          });
           
          $("#ckbDescripcion").change(function () {
              if ($("#ckbDescripcion").attr("checked")) {
                  $("#selectContenedorOpciones").append("<option value='optDescripcion'>Descripción</option>");
              }
              else {
                  $("#selectContenedorOpciones").find("[value='optDescripcion']").remove();
                  $("#selectColumnas").find("[value='optDescripcion']").remove();
                  $("#selectFilas").find("[value='optDescripcion']").remove();
              }
          });

          $("#ckbFamilia").change(function () {
              if ($("#ckbFamilia").attr("checked")) {
                  $("#selectContenedorOpciones").append("<option value='optFamilia'>Familia</option>");
              }
              else {
                  $("#selectContenedorOpciones").find("[value='optFamilia']").remove();
                  $("#selectColumnas").find("[value='optFamilia']").remove();
                  $("#selectFilas").find("[value='optFamilia']").remove();
              }
           });


          $("#ckbCorrida").change(function () {
              if ($("#ckbCorrida").attr("checked")) {
                  $("#selectContenedorOpciones").append("<option value='optCorrida'>Corrida</option>");
              }
              else {
                  $("#selectContenedorOpciones").find("[value='optCorrida']").remove();
                  $("#selectColumnas").find("[value='optCorrida']").remove();
                  $("#selectFilas").find("[value='optCorrida']").remove();
              }
          });

          $("#ckbSumaPares").change(function () {
              if ($("#ckbSumaPares").attr("checked")) {
                  $("#selectOperaciones").append("<option value='optSuma'>Suma de Pares</option>");
              }
              else {
                  $("#selectOperaciones").find("[value='optSuma']").remove();
              }
          });

          $("#ckbArticulos").change(function () {
              if ($("#ckbArticulos").attr("checked")) {
                  $("#selectOperaciones").append("<option value='optCantArt'>Cantidad de Articulos</option>");
              }
              else {
                  $("#selectOperaciones").find("[value='optCantArt']").remove();
              }
          });

          $("#ckbColecciones").change(function () {
              if ($("#ckbColecciones").attr("checked")) {
                  $("#selectOperaciones").append("<option value='optCantCole'>Cantidad de Colecciones</option>");
              }
              else {
                  $("#selectOperaciones").find("[value='optCantCole']").remove();
              }
          });
            
          $(document).ready(function () {
              $("#btnEnviarColumnas").click(function () {
                  var columnasValues = "";
                  var filasValues = "";
                  return !$('#selectContenedorOpciones option:selected').remove().appendTo('#selectColumnas');
                               });             
            });

          
          $(document).ready(function () {
              $("#btnEnviarFilas").click(function () {
                  return !$('#selectContenedorOpciones option:selected').remove().appendTo('#selectFilas');
              });
          });


          $(document).ready(function () {
              $("#btnImageEnviarFilas").click(function () {
                  return !$('#selectContenedorOpciones option:selected').remove().appendTo('#selectFilas');
              });
          });
                     
              $(function () {
                  $("#cmbClasificacion").dropdownchecklist();
              });

              $(function () {
                  $("#cmbAgente").dropdownchecklist();
              });

              $(function () {
                  $("#cmbMarcas").dropdownchecklist();
              });

              $(function () {
                  $("#cmbColecciones").dropdownchecklist();
              });

              $(function () {
                  $("#cmbTipoCategoria").dropdownchecklist();
              });
             
              $(function () {
                  $("#cmbFamilias").dropdownchecklist();
              });

          
              //inicia Modal Clientes
                      
              $(".showModalTabla").click(function () {
                  modalbgTab.fadeIn(500);
                  modalTab.fadeIn(500);
              });

              $(".hideModalTablaCliente").click(function () {
                  hideModalTablaCliente();
              });

              function hideModalTablaCliente() {
                  var selectedLanguage = new Array();
                  $('input[name="nombreCliente"]:checked').each(function () {
                      selectedLanguage.push(this.value);
                  });

                  $("#txtClienteSeleccionado").val(selectedLanguage);
                  modalbgTab.fadeOut(500);
                  modalTab.fadeOut(500);

              }
       
              $(document).ready(function () {
                  $("#btnSubmitCliente").click(function () {
                      var selectedLanguage = new Array();
                      $('input[name="nombreCliente"]:checked').each(function () {
                          selectedLanguage.push(this.value);
                      });

                      $("#txtClienteSeleccionado").val(selectedLanguage);
                      hideModalTablaCliente();
                    
                  });
              });
              //termina modal cliente


              //inicia modal modelos
              var tablaSombraModelo = $(".modalSombraTablaModelo");
              var tablaModelo = $(".modalTablaModelo");

              $(".showModalTablaModelos").click(function () {
                  tablaSombraModelo. fadeIn(500);
                  tablaModelo.fadeIn(500);
              });

              $(".hideModalTablaModelos").click(function () {
                 hideModalTablaModelos();
              });

              function hideModalTablaModelos() {
                  var selectedLanguage = new Array();
                  $('input[name="nombreModelo"]:checked').each(function () {
                      selectedLanguage.push(this.value);
                  });

                  $("#txtModeloSeleccionado").val(selectedLanguage);
                  tablaSombraModelo.fadeOut(500);
                  tablaModelo.fadeOut(500);

              }

              $(document).ready(function () {
                  $("#btnSubmitModelos").click(function () {
                      var selectedLanguage = new Array();
                      $('input[name="nombreModelo"]:checked').each(function () {
                          selectedLanguage.push(this.value);
                      });

                      $("#txtModeloSeleccionado").val(selectedLanguage);
                      hideModalTablaModelos();

                  });
              });
           //termina modal modelos

              //inicia modal Descripcion
              var tablaSombraDescripcion = $(".modalSombraTablaDescripcion");
              var tablaDescripcion = $(".modalTablaDescripcion");

              $(".showModalTablaDescripcion").click(function () {
                  tablaSombraDescripcion.fadeIn(500);
                  tablaDescripcion.fadeIn(500);
              });

              $(".hideModalTablaDescripcion").click(function () {
                  hideModalTablaDescripcion();
              });

              function hideModalTablaDescripcion() {
                  var selectedLanguage = new Array();
                  $('input[name="nombreDescripcion"]:checked').each(function () {
                      selectedLanguage.push(this.value);
                  });

                  $("#txtDescripcionSeleccionado").val(selectedLanguage);
                  tablaSombraDescripcion.fadeOut(500);
                  tablaDescripcion.fadeOut(500);

              }

              $(document).ready(function () {
                  $("#btnSubmitDescripcion").click(function () {
                      var selectedLanguage = new Array();
                      $('input[name="nombreDescripcion"]:checked').each(function () {
                          selectedLanguage.push(this.value);
                      });

                      $("#txtDescripcionSeleccionado").val(selectedLanguage);
                      hideModalTablaDescripcion();

                  });
              });
           //termina modal Descripcion

              //inicia modal colecciones
              var tablaSombraColeccion = $(".modalSombraTablaColecciones");
              var tablaColeccion = $(".modalTablaColecciones");

              $(".showModalTablaColecciones").click(function () {
                  tablaSombraColeccion.fadeIn(500);
                  tablaColeccion.fadeIn(500);
              });

              $(".hideModalTablaColecciones").click(function () {
               hideModalTablaColecciones();
              });

              function hideModalTablaColecciones() {
                  var selectedLanguage = new Array();
                  $('input[name="nombreColeccion"]:checked').each(function () {
                      selectedLanguage.push(this.value);
                  });

                  $("#txtColeccionesSeleccion").val(selectedLanguage);
                  tablaSombraColeccion.fadeOut(500);
                  tablaColeccion.fadeOut(500);

              }

              $(document).ready(function () {
                  $("#btnSubmitColeccion").click(function () {
                      var selectedLanguage = new Array();
                      $('input[name="nombreColeccion"]:checked').each(function () {
                          selectedLanguage.push(this.value);
                      });

                      $("#txtColeccionesSeleccion").val(selectedLanguage);
                      hideModalTablaColecciones();

                  });
              });
              //termina modal colecciones

              //inicia modal corridas
              var tablaSombraCorridas = $(".modalSombraTablaCorridas");
              var tablaCorridas = $(".modalTablaCorridas");

              $(".showModalTablaCorridas").click(function () {
                  tablaSombraCorridas.fadeIn(500);
                  tablaCorridas.fadeIn(500);
              });

              $(".hideModalTablaCorridas").click(function () {
               hideModalTablaCorridas();                  
              });

              function hideModalTablaCorridas() {
                  var selectedLanguage = new Array();
                  $('input[name="nombreCorrida"]:checked').each(function () {
                      selectedLanguage.push(this.value);
                  });

                  $("#txtCorridasSeleccion").val(selectedLanguage);
                  tablaSombraCorridas.fadeOut(500);
                  tablaCorridas.fadeOut(500);

              }

              $(document).ready(function () {
                  $("#btnSubmitCorridas").click(function () {
                      var selectedLanguage = new Array();
                      $('input[name="nombreCorrida"]:checked').each(function () {
                          selectedLanguage.push(this.value);
                      });

                      $("#txtCorridasSeleccion").val(selectedLanguage);
                      hideModalTablaCorridas();

                  });
              });
   
              $(document).ready(function(){
                  $("#chkFiltroClasificacion").change(function () {
                      if ($("#chkFiltroClasificacion").is(":checked")) {
                      document.getElementById('cmbClasificacion').disabled = true;
                      }
                      else {
                      document.getElementById('cmbClasificacion').disabled = false;
                      }

                  });
              });

                     $(function ($) {
                  $.datepicker.regional['es'] = {
                      closeText: 'Cerrar',
                      prevText: 'Ant-',
                      nextText: 'Sig',
                      currentText: 'Hoy',
                      monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                      monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                      dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                      dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
                      dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
                      weekHeader: 'Sm',
                      dateFormat: 'dd/mm/yy',
                      firstDay: 1,
                      isRTL: false,
                      showMonthAfterYear: false,
                      yearSuffix: ''
                  };
                  $.datepicker.setDefaults($.datepicker.regional['es']);
              });

            </script>
    
            </asp:Content>


