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

        </div>


    </body>
<script>

    var app = angular.module('appFormulario', []);
    app.controller('OficiosPdfController', function ($scope, $http, $window) {

        $scope.tipoReporte = "";
        var mydata = { "": "" };
        $scope.File = [];
        $scope.File2 = {};

        var base64String = "JVBERi0xLjQKJeLjz9MKNCAwIG9iago8PC9MZW5ndGggMTExOS9GaWx0ZXIvRmxhdGVEZWNvZGU+PnN0cmVhbQp4nJVX23LbNhR811fgMZ2pYdxB5s2JL3Umzji1+gGIxLjsSKJC0mmbP+5D/6EACaiUcI7GnPHYHu2eBXD2LAkxwskFJ4zoUvvfq+3i2+LdciEN0boky/WCkQuhwj+Xt5xwQ5ZfF28+1l3vyLoij25VV7u+6sgvTbeve7epf7h10/20/MMXslCmS0514dfQo4ggnA0i2/qfdtVsqu5nIgTZur8bIphfivO3onjrP9pTsqVB6SJqsLgfXoxSknAxSJHJegFnA+FmufjsT8Oo1aJU5PRv+xxOqYwgSlNREsVIWy2+nuMXfCDOKeHCUD23xnJaFPNqBLeUz60xgio7r0YyS+3YNmOp/+w1NVZTy+eto8TcAmNmm6M5n22O1ma2OYaJ2eYYZZM5r2605ZqqmX2zhsHmhOwI8sEH6s7Xa/InFJenCMHJSCgSggMMz3uCkdE+wPAUJxgZ2AMMz2aCoTE8YPDEJRgZrgMMz1GCkZE5wPB0JBgZhAMMe/408Vmc9RlBk88YHH1G4OQzBkefETj5LM77jFQPPmNY9BmBk88YHH1G4OQzBkefkVMln5Hq5DPWMkNkkBwgUeQ+Y2j0GYVHnzE4+ozCo88YHH0O8NiRE3j0GasOPqPY6DMGR59RePQZg6PPKDz6jJ0q+oxVR59z+HO4y4XbHfPXPC2o0UT5TS6309vT/XW4Pvnb0oRbKCoswP3UkJu/9jmfS0NLDhTcXn8C2NZSLQH2+99+fczpQvh5EgD9al9tNvU6VBy40k+PH3Q/Ip77poHkfIc5tFdIzhpqi//lHnI56cdZga3afmmrDijwzZVQxc3arXO6Ehb27b3bOoDudwxad9VWAF1zT4c281S13+tVPW2GFppOWks4IGc47Cwk5x8TfKoncj3D/OAXYK+aJ7eZyhleUP8lI8m9AK00mlHI+OvaPe+arq9XTV5keUktNH231ep3dz/dQqLGLeyevf+Qoj+4hBz1++iO9Iyixh707v03rXbnjhjebROuCWpgrIHVpIfV6UqAdYUc3hA5VUggwaIYXnoZm/FL/8One0xcOZ6iLBn0RJDDWzLTC08EYLPCd5pD/MeqrX5AmVfDezTj37l2VQO5kKwcrhNZwYcXtwPo/okW3rQZXSoo0RJgXgHHVKaATbmrdlV7NAmJGru8gaIuYc8eqvVpNCM1ih3PXAKFOp3Kk/V0gXjq2nXdHIU3ceOCzfO/gKBhCjb9puvdl00FVKgSsb2t9wDfhmc5ZGMYa3EpjsM+cuOWGRQT6+8y4FhwIAMhqOyUCDwTY1AzqtIGD2rG5vqSGTCosoxBLTQe1EwvBBXYbApqxv/Y7M8FNeM/uLavd9XRy3nkpv0CainFkBqY+hjjjC8LJMYZ8x3QhJTNjPzok+f6FshxOhSUgxTA18hF7lm5mL1M7rpqt64HYprUms35oGaKd637fiameTPbZvftpe5r4BqV8pdHRodXEJTVtO+zWQWSEsn/AR8Ub9YKZW5kc3RyZWFtCmVuZG9iago2IDAgb2JqCjw8L1R5cGUvUGFnZS9NZWRpYUJveFswIDAgNTk1IDg0Ml0vUmVzb3VyY2VzPDwvRm9udDw8L0YxIDEgMCBSL0YyIDIgMCBSL0YzIDMgMCBSPj4+Pi9Sb3RhdGUgOTAvQ29udGVudHMgNCAwIFIvUGFyZW50IDUgMCBSPj4KZW5kb2JqCjEgMCBvYmoKPDwvVHlwZS9Gb250L1N1YnR5cGUvVHlwZTEvQmFzZUZvbnQvSGVsdmV0aWNhLUJvbGQvRW5jb2RpbmcvV2luQW5zaUVuY29kaW5nPj4KZW5kb2JqCjIgMCBvYmoKPDwvVHlwZS9Gb250L1N1YnR5cGUvVHlwZTEvQmFzZUZvbnQvSGVsdmV0aWNhLU9ibGlxdWUvRW5jb2RpbmcvV2luQW5zaUVuY29kaW5nPj4KZW5kb2JqCjMgMCBvYmoKPDwvVHlwZS9Gb250L1N1YnR5cGUvVHlwZTEvQmFzZUZvbnQvSGVsdmV0aWNhL0VuY29kaW5nL1dpbkFuc2lFbmNvZGluZz4+CmVuZG9iago1IDAgb2JqCjw8L1R5cGUvUGFnZXMvQ291bnQgMS9LaWRzWzYgMCBSXT4+CmVuZG9iago3IDAgb2JqCjw8L1R5cGUvQ2F0YWxvZy9QYWdlcyA1IDAgUj4+CmVuZG9iago4IDAgb2JqCjw8L1Byb2R1Y2VyKGlUZXh0U2hhcnCSIDUuNS4xMy4zIKkyMDAwLTIwMjIgaVRleHQgR3JvdXAgTlYgXChBR1BMLXZlcnNpb25cKSkvQ3JlYXRpb25EYXRlKEQ6MjAyNDA1MjIyMzI4MjItMDYnMDAnKS9Nb2REYXRlKEQ6MjAyNDA1MjIyMzI4MjItMDYnMDAnKT4+CmVuZG9iagp4cmVmCjAgOQowMDAwMDAwMDAwIDY1NTM1IGYgCjAwMDAwMDEzNDIgMDAwMDAgbiAKMDAwMDAwMTQzNSAwMDAwMCBuIAowMDAwMDAxNTMxIDAwMDAwIG4gCjAwMDAwMDAwMTUgMDAwMDAgbiAKMDAwMDAwMTYxOSAwMDAwMCBuIAowMDAwMDAxMjAyIDAwMDAwIG4gCjAwMDAwMDE2NzAgMDAwMDAgbiAKMDAwMDAwMTcxNSAwMDAwMCBuIAp0cmFpbGVyCjw8L1NpemUgOS9Sb290IDcgMCBSL0luZm8gOCAwIFIvSUQgWzxhNTkzNDY2YjljN2E5Njg1MWRhOTU5M2FlNjM3ZWE4OT48YTU5MzQ2NmI5YzdhOTY4NTFkYTk1OTNhZTYzN2VhODk+XT4+CiVpVGV4dC01LjUuMTMuMwpzdGFydHhyZWYKMTg4MAolJUVPRgo=";
        var fileName = "ListaPacientesHospitalizados.pdf";

        $scope.generarReportePDF = function () {
            
            if ($scope.tipoReporte == undefined) {
                alert("Seleccione un tipo de reporte");
            } else {
                var url = "";
                switch ($scope.tipoReporte) {
                    case "1":
                        alert("entro al case 1");
                        //url = "https://localhost:44377/View/Pacientes/OficiosPdf.aspx/GetOficioListaPacientesHopitalizados";
                        break;
                    case "2":
                        //url = "http://localhost:8080/SAG/View/Pacientes/OficiosPdf.aspx/GenerarReportePacientesInternados";
                        break;
                    case "3":
                        //url = "http://localhost:8080/SAG/View/Pacientes/OficiosPdf.aspx/GenerarReporteIngresosAyer";
                        break;
                    case "4":
                        //url = "http://localhost:8080/SAG/View/Pacientes/OficiosPdf.aspx/GenerarReporteOcupacionAreas";
                        break;
                }
                $http({
                    method: 'POST',
                    url: '/View/Pacientes/OficiosPdf.aspx/GetOficioListaPacientesHopitalizados',
                    data: mydata,
                    headers: { 'Content-Type': 'application/json; charset=utf-8' },
                    dataType: 'json'
                }).then(function (response) {
                    //alert(response.data.d.FileName);
                    alert("esta en responde");
                    //$scope.File2 = response.data.d;
                    //alert($scope.File2.Name);

                    var fileData = response.data.d[0];

                    var base64String2 = fileData.Data;
                    var fileName2 = fileData.Name;
                    
                    alert("esta en responde2");

                    // Crear un enlace temporal para descargar el PDF
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


