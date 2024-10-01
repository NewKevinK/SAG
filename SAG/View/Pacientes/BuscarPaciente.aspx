<%@ Page Title="Buscar Paciente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarPaciente.aspx.cs" Inherits="SAG.View.Pacientes.BuscarPaciente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <!-- CSS -->
    <link href="../../css/styleBuscarPaciente.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    
    <!-- jQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <!-- Bootstrap-->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <!-- nuevoo -->
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />

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

    <!-- DataTable -->
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>

    <link rel="stylesheet" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css">
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>

    <!-- Angular -->
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>


    <link href="../../css/styleBuscarPaciente.css" rel="stylesheet" />
    <title>Consultar Pacientes</title>

<body>

    <div class="container" ng-app="appConsultar" ng-controller="ConsultarController">
            <header>Consultar Pacientes</header>

            <div class="row mb-3">
                <div class="col-md-4">
                    <label for="tipoPaciente" class="form-label">Tipo de Paciente</label>
                    <select class="form-select" id="tipoPaciente" ng-model="filtro.tipoPaciente">
                        <option value="" disabled selected>Seleccione una opcion.</option>
                        <option value="Hospitalizado">Hospitalizado</option>
                        <option value="Internado">Internado</option>
                        <option value="Egreso">Egreso</option>
                    </select>
                </div>
                <div class="col-md-4">
                    <label for="anio" class="form-label">Año</label>
                    <select class="form-select" id="anio" ng-model="filtro.anio">
                        <option value="" disabled selected>Seleccione un año.</option>
                        <option value="x">Todos los años.</option>

                        <script>
                            for (let i = new Date().getFullYear(); i >= new Date().getFullYear() - 10; i--) {
                                document.write('<option value="' + i + '">' + i + '</option>');
                            }
                        </script>
                    </select>
                </div>
                <div class="col-md-4 d-flex align-items-end">
                    <button class="btn btn-primary w-100" ng-click="filtrarPacientes()">Filtrar</button>
                </div>
            </div>

        <div class="row">
            <div class="col-sm-12">
                <div style="overflow-x: auto;">
                    <table class="table table-striped table-smaller" id="datatable_users">
                        <thead>
                            <tr>
                                <th class="id-col">Id</th>
                                <th class="date-col">FDN</th>
                                <th class="curp-col">CURP</th>
                                <th class="name-col">Apellido Paterno</th>
                                <th class="name-col">Apellido Materno</th>
                                <th class="name-col">Nombres</th>
                                <th class="age-col">Edad</th>
                                <th class="bed-col">Cama</th>
                                <th class="area-col">Area</th>
                                <th class="s1-col">S1</th>
                                <th class="health-col">Edo Salud</th>
                                <th class="diag-col">Diagnostico</th>
                                <th class="date-col">Fecha Ingreso</th>
                                <th class="days-col">Dias</th>
                                <th class="actions-col">Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="x in listaPacientes">
                                <td class="id-col">{{x.IdPaciente}}</td>
                                <td class="date-col">{{x.FechaNacimiento}}</td>
                                <td class="curp-col">{{x.CURP}}</td>
                                <td class="name-col">{{x.ApellidoPaterno}}</td>
                                <td class="name-col">{{x.ApellidoMaterno}}</td>
                                <td class="name-col">{{x.Nombres}}</td>
                                <td class="age-col">{{x.Edad}}</td>
                                <td class="bed-col">{{x.Cama}}</td>
                                <td class="area-col">{{x.Area}}</td>
                                <td class="s1-col">{{x.S1}}</td>
                                <td class="health-col">{{x.EstadoSalud}}</td>
                                <td class="diag-col">{{x.Diagnostico}}</td>
                                <td class="date-col">{{x.FechaIngreso}}</td>
                                <td class="days-col">{{x.Dias}}</td>
                                <td class="actions-col">
                                    <button class="btn btn-sm btn-primary" ng-click="editarPaciente(x.IdPaciente)"><i class="fa-solid fa-pencil"></i></button>
                                    <button class="btn btn-sm btn-secondary" ng-click="verDetalles(x.IdPaciente)">Ver Detalles</button>
                                    <button class="btn btn-sm btn-secondary" ng-click="cambiarEstado(x.IdPaciente)">Cambiar Estado Paciente</button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

       
<!-- Bootstrap JS Bundle -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
            
            <!-- Modal para cambiar el estado del paciente -->
            <div class="modal fade" id="cambiarEstadoModal" tabindex="-1" role="dialog" aria-labelledby="cambiarEstadoModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="cambiarEstadoModalLabel">Cambiar Estado del Paciente</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <label for="estadoPacienteSelect" class="form-label">Selecciona el nuevo estado del paciente:</label>
                            <select class="form-select" id="estadoPacienteSelect" ng-model="nuevoEstado">
                                <option value="" disabled selected>Seleccione un estado</option>
                                <option value="Hospitalizado">Hospitalizado</option>
                                <option value="Internado">Internado</option>
                                <option value="Egreso">Egreso</option>
                            </select>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                            <button type="button" class="btn btn-primary" ng-click="confirmarCambioEstado()">Aceptar</button>
                        </div>
                    </div>
                </div>
            </div>


            <!-- Modal para mostrar el resultado -->
            <div class="modal fade" id="resultadoModal" tabindex="-1" role="dialog" aria-labelledby="resultadoModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="resultadoModalLabel">Alerta</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            {{mensajeModal}}
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    
</body>


        <!-- Bootstrap-->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
    
    

<script>
    var app = angular.module('appConsultar', []);
    app.controller('ConsultarController', function ($scope, $http, $timeout, $window, $location) {
        
        $scope.listaPacientes = [];

        var mydata = {
            EstadoPaciente: "",
            Anio: ""
        };

        var dataTableOptions = {
            pageLength: 19,
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



        $scope.filtrarPacientes = function () {

            if ($scope.filtro.tipoPaciente == undefined) {
                $scope.mensajeModal = "Seleccione el tipo de paciente";
                $('#resultadoModal').modal('show');

            } else {

                try {
                    
                    mydata.EstadoPaciente = $scope.filtro.tipoPaciente;
                    mydata.Anio = $scope.filtro.anio === "x" ? "" : $scope.filtro.anio;
                    
                    
                    $http({
                        method: 'POST',
                        url: '/View/Pacientes/BuscarPaciente.aspx/GetPacientesFiltro',
                        data: mydata,
                        headers: { 'Content-Type': 'application/json; charset=utf-8' },
                        dataType: 'json'
                    }).then(function (response) {
                        $('#datatable_users').DataTable().clear().destroy();
                        $scope.listaPacientes = response.data.d;

                        //test
                        $timeout(function () {
                            
                            // Destruye la instancia existente de DataTable
                            if ($.fn.DataTable.isDataTable('#datatable_users')) {
                                $('#datatable_users').DataTable().clear().destroy();
                                //alert("entro al timeout");
                            }
                            $('#datatable_users').DataTable(dataTableOptions);
                        });

                        
                    }, function (error) {
                        console.error("Error al obtener los datos: ", error);
                    });
                } catch (ex) {
                    alert(ex);
                }

            }


            

             
            
        }

       
        $scope.cambiarEstado = function (idPaciente) {
            $scope.idPacienteSeleccionado = idPaciente;  
            $scope.nuevoEstado = "";  
            $('#cambiarEstadoModal').modal('show');  
        };

        $scope.confirmarCambioEstado = function () {
            if (!$scope.nuevoEstado) {
                $scope.mensajeModal = "Seleccione un estado.";
                $('#resultadoModal').modal('show');
                return;
            }

            var mydataestado = {
                "IdPaciente": $scope.idPacienteSeleccionado,
                "EstadoPaciente": $scope.nuevoEstado
            };

            try {
                $http({
                    method: 'POST',
                    url: '/View/Pacientes/BuscarPaciente.aspx/PatchEstadoPaciente',
                    data: mydataestado,
                    headers: { 'Content-Type': 'application/json; charset=utf-8' },
                    dataType: 'json'
                }).then(function (response) {
                    var resultado = response.data.d;

                    if (resultado.Result == 1) {
                        $scope.mensajeModal = resultado.Message;
                    } else {
                        $scope.mensajeModal = "Error: " + resultado.Message;
                    }

                    $('#resultadoModal').modal('show');
                    $('#cambiarEstadoModal').modal('hide');  
                    $scope.filtrarPacientes();  
                });
            } catch (ex) {
                alert(ex);
            }
        };




        $scope.editarPaciente = function (idPaciente) {
            
            $window.location.href = 'ModificarPaciente?id=' + idPaciente;
        }
        $scope.verDetalles = function (idPaciente) {
            
            $window.location.href = 'ConsultarDetallesPaciente.aspx?IdPaciente=' + idPaciente;
        }




    });
    $(document).ready(function () {
        //$('#datatable_users').DataTable();
    });

</script>






</asp:Content>
