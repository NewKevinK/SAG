<%@ Page Title="Consultar Pacientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarPacientes.aspx.cs" Inherits="SAG.View.Pacientes.ConsultarPacientes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../css/styleConsultarPacientes.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />

        <!-- Bootstrap-->
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous" />
        <!-- DataTable -->
        <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />
        <!-- Font Awesome -->
        <link
            rel="stylesheet"
            href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css"
            integrity="sha512-xh6O/CkQoPOWDdYTDqeRdPCVd1SpvCA9XXcUnZS2FmJNp1coAFzvtCN9BmamE+4aHK8yyUHUSCcJHgXloTyT2A=="
            crossorigin="anonymous"
            referrerpolicy="no-referrer"
        />
    <link href="../../css/styleConsultarPacientes.css" rel="stylesheet" />
    <title>Consultar Pacientes</title>

<body>
    <div class="container" ng-app="appConsultar" ng-controller="ConsultarController">
        <header>Consultar Pacientes</header>

        

        <div class="row">
            <div class="table-responsive">
                <table class="table table-striped" id="datatable_users">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Hora Registro</th>
                            <th>CURP</th>
                            <th>Apellido Paterno</th>
                            <th>Apellido Materno</th>
                            <th>Nombres</th>
                            <th>Diagnosticos</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr ng-repeat="x in listaPacientes">
                            <td>{{x.IdPaciente}}</td>
                            <td>{{x.FechaRegistro}}</td>
                            <td>{{x.CURP}}</td>
                            <td>{{x.ApellidoPaterno}}</td>
                            <td>{{x.ApellidoMaterno}}</td>
                            <td>{{x.Nombres}}</td>
                            <td>{{x.Diagnostico}}</td>
                            <td>
                                <button class="btn btn-sm btn-primary" ng-click="editarPaciente(x.IdPaciente)"  ><i class="fa-solid fa-pencil"></i></button>
                                <button class="btn btn-sm btn-secondary" ng-click="verDetalles(x.IdPaciente)">Ver Detalles</button>
                                
                            </td>
                        </tr>
                    </tbody>
                    
                </table>

                

            </div>

        </div>
        

    </div>
    
    <!-- Bootstrap-->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
    <!-- jQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <!-- DataTable -->
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>

    <link rel="stylesheet" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css">
<script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>

    <!-- Angular -->
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>
    <!-- Custom JS -->
    
    <script>

        

        var app = angular.module('appConsultar', []);
        

        app.controller('ConsultarController', function ($scope, $http, $timeout, $window, $location) {
            
            $scope.listaPacientes = [];
            var mydata = { "": "" };

            

            $scope.dataTable = "";

            var dataTableOptions = {
                pageLength: 9,
                destroy: true,
                language: {
                    lengthMenu: "Mostrar _MENU_ registros por página",
                    zeroRecords: "Ningún Paciente encontrado",
                    info: "Mostrando de _START_ a _END_ de un total de _TOTAL_ registros",
                    infoEmpty: "Ningún Paciente encontrado",
                    infoFiltered: "(filtrados desde _MAX_ registros totales)",
                    search: "Buscar:",
                    loadingRecords: "Cargando...",
                    paginate: {
                        first: "Primero",
                        last: "Último",
                        next: "Siguiente",
                        previous: "Anterior"
                    }
                }
            };
            
            
                try {
                    $http({
                        method: 'POST',
                        url: '/View/Pacientes/ConsultarPacientes.aspx/ConsultarPacientesSAG',
                        data: mydata,
                        headers: { 'Content-Type': 'application/json; charset=utf-8' },
                        dataType: 'json'
                    }).then(function (response) {
                        $scope.listaPacientes = response.data.d;
                        
                        $timeout(function () {
                            //alert("entro al timeout");
                            $('#datatable_users').DataTable(dataTableOptions);
                            // Inicializa DataTables en la tabla
                            
                        });
                        
                    });
                } catch (ex) {
                    alert(ex);
            }
            
            
            $scope.editarPaciente = function (idPaciente) {
                //alert("entro al edit");
                // Construir la URL de redirección con el ID del paciente
                var url = $location.protocol() + '://' + $location.host() + ':' + $location.port() + '/View/Pacientes/ModificarPaciente?id=' + idPaciente;
                // Redirigir a la página de edición
                $window.location.href = url;
            };

            $scope.verDetalles = function (idPaciente) {
                $window.location.href = 'ConsultarDetallesPaciente.aspx?IdPaciente=' + idPaciente;
            };

            

            

            
        });



            $(document).ready(function () {
                //dtUsers2();

            });

        
    </script>


</body>
</asp:Content>
