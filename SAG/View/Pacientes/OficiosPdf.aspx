<%@ Page Title="Generar Oficios"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OficiosPdf.aspx.cs" Inherits="SAG.View.Pacientes.OficiosPdf" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <!-- CSS -->
    <link href="../../css/stylePdf.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />

    <!-- jQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <!-- Bootstrap-->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    

    <!-- Angular -->
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>

    <link href="../../css/stylePdf.css" rel="stylesheet" />
    <body>
        <div class="container" ng-app="appFormulario" ng-controller="OficiosPdfController">
            <header>Generar Oficios</header>
            <div class="row"></div>

            <div class="row">
                <div class="col-lg-6">
                    <label  class="col-sm" > Selecciona el tipo de reporte: </label>
                </div>
                <div class="col-lg-6">
                    <select class="form-select" ng-model="tipoReporte">
                        <option value="" disabled selected>Seleccione una opción</option>
                        <option value="1">Lista de Pacientes Hospitalizados</option>
                        <option value="2">Pacientes Internados</option>
                        <option value="3">Ingresos del dia de ayer</option>
                        <option value="4">Ocupacion por Areas</option>
                    </select>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-lg-12 d-flex justify-content-center">
                    <button class="btn btn-primary" ng-click="generarReportePDF()">Generar</button>
                </div>
                
            </div>
            <!-- Modal para mostrar el resultado -->
            <div class="modal fade" id="resultadoModal" tabindex="-1" role="dialog" aria-labelledby="resultadoModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="resultadoModalLabel">Alerta</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            {{mensajeModal}}
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>


    </body>
<script>

    var app = angular.module('appFormulario', []);
    app.controller('OficiosPdfController', function ($scope, $http, $window) {

        $scope.tipoReporte = "";
        var mydata = { "": "" };
        $scope.File = [];
        $scope.File2 = {};

        // Función para obtener el JWT de la cookie
        function getCookie(name) {
            let matches = document.cookie.match(new RegExp(
                "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
            ));
            return matches ? decodeURIComponent(matches[1]) : undefined;
        }
        

        $scope.generarReportePDF = function () {

            
            
            if ($scope.tipoReporte == undefined) {
                //alert("Seleccione un tipo de reporte");
                $scope.mensajeModal = "Seleccione un tipo de Oficio.";
                $('#resultadoModal').modal('show');

            } else {
                var url = "";
                switch ($scope.tipoReporte) {
                    case "1":
                        //alert("entro al case 1");
                        url = '/View/Pacientes/OficiosPdf.aspx/GetOficioListaPacientesHopitalizados';
                        break;
                    case "2":
                        url = '/View/Pacientes/OficiosPdf.aspx/GetOficioListaPacientesInternados';
                        break;
                    case "3":
                        url = '/View/Pacientes/OficiosPdf.aspx/GetListaIngresosAyer';
                        break;
                    case "4":
                        url = '/View/Pacientes/OficiosPdf.aspx/GetListaAreas';
                        break;
                }

                var token = getCookie("JWTToken");

                $http({
                    method: 'POST',
                    url: url,
                    data: mydata,
                    headers: {
                        'Content-Type': 'application/json; charset=utf-8',
                        'Authorization': 'Bearer ' + token 
                    },
                    dataType: 'json'
                }).then(function (response) {
                    
                    //alert("esta en responde");
                    //$scope.File2 = response.data.d;
                    //alert($scope.File2.Name);

                    var fileData = response.data.d[0];

                    var base64String2 = fileData.Data;
                    var fileName2 = fileData.Name;
                    
                    var link = document.createElement('a');
                    link.href = 'data:application/pdf;base64,' + base64String2;
                    link.download = fileName2;
                    link.click();


                    
                }, function (error) {
                    alert(error);
                });
            }
        }




    });




</script>

</asp:Content>


