<%@ Page Title="Consultar Detalles Paciente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarDetallesPaciente.aspx.cs" Inherits="SAG.View.Pacientes.ConsultarDetallesPaciente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    

    <!-- Angular -->
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>
    <!-- Bootstrap-->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous" />
    <!-- DataTable -->
    <link rel="stylesheet" href="https://cdn.datatables.net/1.12.1/css/dataTables.bootstrap5.min.css" />
    <!-- jQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <!-- DataTable -->
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap5.min.js"></script>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css">
    <script src="https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>
    

    <link href="../../css/styleDetallesPaciente.css" rel="stylesheet" />
    <title>Consultar Detalles del Paciente</title>

<body>
    <div class="container" ng-app="appConsultarDetalles" ng-controller="ConsultarDetallesController" >
        <header>Consultar detalles del paciente</header>
        <div class="row"></div>
        <div class="row">
            <!-- Columna izquierda del formulario -->
            <div class="col-lg-6">
                <div class="form-group d-flex mb-2">
                    <label  class="col-sm-3">Tipo de Atención:</label>
                    <input type="text" class="form-control custom-input" ng-model="PacienteDetalles.TipoAtencion"  readonly>
                </div>
                <div class="form-group d-flex mb-2">
                    <label  class="col-sm-3">Apellido Paterno:</label>
                    <input type="text" class="form-control custom-input" ng-model="PacienteDetalles.ApellidoPaterno" readonly>
                </div>
                <div class="form-group d-flex mb-2">
                    <label class="col-sm-3">Apellido Materno:</label>
                    <input type="text" class="form-control custom-input" ng-model="PacienteDetalles.ApellidoMaterno"  readonly>
                </div>
                <div class="form-group d-flex mb-2">
                    <label  class="col-sm-3 col-form-label" >Nombres:</label>
                    <input type="text" class="form-control custom-input" ng-model="PacienteDetalles.Nombres"  readonly>
                </div>
                <div class="form-group d-flex mb-2">
                    <label  class="col-sm-3 col-form-label">Nacionalidad:</label>
                    <input type="text" class="form-control custom-input" ng-model="PacienteDetalles.Nacionalidad"   readonly>
                </div>
            </div>

            <!-- Columna derecha del formulario -->
            <div class="col-lg-6">
                <div class="form-group d-flex mb-2">
                    <label  class="col-sm-3">CURP: </label>
                    <input type="text" class="form-control" ng-model="PacienteDetalles.CURP"  readonly>
                </div>
                <div class="form-group d-flex mb-2">
                    <label  class="col-sm-3">Numero Expediente:</label>
                    <input type="text" class="form-control" ng-model="PacienteDetalles.NumeroExpediente"  readonly>
                </div>
                <div class="form-group d-flex mb-2">
                    <label class="col-sm-3">Fecha Nacimiento:</label>
                    <input type="text" class="form-control" ng-model="PacienteDetalles.FechaNacimiento"  readonly>
                </div>
                <div class="form-group d-flex mb-2">
                    <label  class="col-sm-3">Edad:</label>
                    <input type="text" class="form-control" ng-model="PacienteDetalles.Edad" readonly>
                </div>
                <div class="form-group d-flex mb-2">
                    <label  class="col-sm-3">Sexo:</label>
                    <input type="text" class="form-control" ng-model="PacienteDetalles.Sexo" readonly>
                </div>
                <!-- Agrega más campos de formulario según sea necesario -->
            </div>

            

        </div>

        <div class="row">
            <div class="col-lg-6">
                <div class="form-group d-flex mb-2">
                    <label class="col-sm-4">Fecha de Admision:</label>
                    <input type="text" class="form-control custom-input" ng-model="PacienteDetalles.FechaAdmision"  readonly>
                </div>
                <div class="form-group d-flex mb-2">
                    <label  class="col-sm-4">Fecha de Modificacion:</label>
                    <input type="text" class="form-control custom-input" ng-model="PacienteDetalles.FechaModificacion"  readonly>
                </div>
                <div class="form-group d-flex mb-2">
                    <label class="col-sm-4">Ambulancia:</label>
                    <input type="checkbox"  ng-model="ngAmbulancia" >
                </div>

            </div>
        </div>


        <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
            <li class="nav-item" role="presentation">
                <button class="nav-link active" id="pills-home-tab" data-bs-toggle="pill" data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home" aria-selected="true">Ver Informacion del Paciente</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="pills-profile-tab" data-bs-toggle="pill" data-bs-target="#pills-profile" type="button" role="tab" aria-controls="pills-profile" aria-selected="false">Ver Diagnosticos</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="pills-contact-tab" data-bs-toggle="pill" data-bs-target="#pills-contact" type="button" role="tab" aria-controls="pills-contact" aria-selected="false">Ver Alergias</button>
            </li>
        </ul>


<div class="tab-content" id="pills-tabContent">
    <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
        <div class="container">
            <header>Informacion del Paciente</header>
            <div class="row">
                <!-- Columna izquierda: Información del paciente -->
                <div class="col-lg-8">
                    <div class="row">
                        <!-- Primera columna de la información del paciente -->
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Estado de Salud:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.EstadoSalud" readonly>
                            </div>
                            <div class="form-group">
                                <label>Fecha de Ingreso:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.FechaIngreso" readonly>
                            </div>
                            <div class="form-group">
                                <label>Cama:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.Cama" readonly>
                            </div>
                            <div class="form-group">
                                <label>Area:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.Area" readonly>
                            </div>
                            <div class="form-group">
                                <label>Diagnostico:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.Diagnostico" readonly>
                            </div>
                            <div class="form-group">
                                <label>Tipo de Seguro:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.TipoSeguro" readonly>
                            </div>
                            <div class="form-group">
                                <label>Folio:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.Folio" readonly>
                            </div>
                            <div class="form-group">
                                <label>Estado del paciente:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.EstadoPaciente" readonly>
                            </div>
                            <div class="form-group">
                                <label>Fecha de alta:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.FechaAlta" readonly>
                            </div>
                            <div class="form-group">
                                <label>Fecha de egreso:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.FechaEgreso" readonly>
                            </div>
                            <div class="form-group">
                                <label>Motivo de egreso:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.MotivoEgreso" readonly>
                            </div>
                            <!-- Agrega más campos de la primera columna según sea necesario -->
                        </div>

                        <!-- Segunda columna de la información del paciente -->
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>Sonda instalada:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.SondaInstalada" readonly >
                            </div>
                            <div class="form-group">
                                <label>Fecha instalacion:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.FechaSondaInstalacion" readonly>
                            </div>
                            <div class="form-group">
                                <label>Cirugia programada:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.CirugiaProgramada" readonly>
                            </div>
                            <div class="form-group">
                                <label>Procedimiento:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.Procedimiento" readonly>
                            </div>
                            <div class="form-group">
                                <label>Fecha de cirugia:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.FechaCirugia" readonly>
                            </div>
                            <div class="form-group">
                                <label>Observaciones:</label>
                                <input type="text" class="form-control" ng-model="PacienteInformacion.ObservacionCirugia" readonly>
                            </div>
                            <!-- Agrega más campos de la segunda columna según sea necesario -->
                        </div>
                    </div>

                    <!-- Otras secciones de la información del paciente -->
                    <!-- Puedes añadir más filas de información del paciente aquí -->
                </div>

                <!-- Columna derecha: Tabla de servicios -->
                <div class="col-lg-4">
                    <table class="table table-bordered" id="datatable_Servicios">
                        <thead>
                            <tr>
                                <th>Servicio</th>
                                <th>FechaRegistro</th>
                            </tr>
                        </thead>
                        <tbody>
                            <!-- Aquí irán las filas de la tabla de servicios -->
                            <tr ng-repeat="x in ListaPacienteInformacionServicios">
                                <td>{{x.Servicio}}</td>
                                <td>{{x.FechaRegistro}}</td>
                            </tr>
                            <!-- Agrega más filas según sea necesario -->
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        





    </div>
    <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">

        <div class="container">
            <header>Diagnósticos del Paciente</header>

            <div class="row">
                <!-- Columna izquierda para la tabla de diagnósticos -->
                <div class="col-lg-6">
                    <table class="table table-bordered" id="datatable_Diagnosticos">
                        <thead>
                            <tr>
                                <th>Fecha</th>
                                <th>Diagnóstico</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="x in ListaPacienteDiagnosticos " ng-click="seleccionarDiagnostico(x)" >
                                <td>{{x.FechaRegistro}}</td>
                                <td>{{x.DiagnosticoNombre}}</td>
                            </tr>
                            <!-- Agrega más filas según sea necesario -->
                        </tbody>
                    </table>
                </div>

                <!-- Columna derecha para detalles del diagnóstico -->
                <div class="col-lg-6">
                    <div class="form-group d-flex mb-3">
                        <label  class="me-2">Medico encargado:</label>
                        <input type="text" class="form-control" id="ngMedicoEncargado" ng-model="diagnosticoSeleccionado.NombreMedico"  readonly>
                    </div>
                    <div class="form-group d-flex mb-3">
                        <label  class="me-2">Diagnóstico:</label>
                        <input type="text" class="form-control" id="ngDiagnostico" ng-model="diagnosticoSeleccionado.DiagnosticoNombre"  readonly>
                    </div>
                    <div class="form-group d-flex mb-3">
                        <label  class="me-2">Tipo de Diagnóstico:</label>
                        <input type="text" class="form-control" id="ngTipoDiagnostico" ng-model="diagnosticoSeleccionado.TipoDiagnostico"  readonly>
                    </div>
                    <div class="form-group d-flex mb-3">
                        <label  class="me-2">Observaciones:</label>
                        <input type="text" class="form-control" id="ngObservaciones" ng-model="diagnosticoSeleccionado.Observacion"  readonly>
                    </div>
                </div>
            </div>






        </div>
    </div>
    <div class="tab-pane fade" id="pills-contact" role="tabpanel" aria-labelledby="pills-contact-tab">
        
        <div class="container">
        <header>Alergias del Paciente</header>

            <div class="row">
                <!-- Columna izquierda para la tabla  -->
                <div class="col-lg">
                    <table class="table table-bordered" id="datatable_Alergias">
                        <thead>
                            <tr>
                                <th>Fecha</th>
                                <th>Tipo Alergia</th>
                                <th>Causante</th>
                                <th>Detalles</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="x in ListaPacienteAlergias">
                                <td>{{x.FechaRegistro}}</td>
                                <td>{{x.TipoAlergia}}</td>
                                <td>{{x.Causante}}</td>
                                <td>{{x.Detalles}}</td>
                            </tr>
                            <!-- Agrega más filas según sea necesario -->
                        </tbody>
                    </table>
                </div>

                <!-- Columna derecha para detalles del alergia -->
               <!-- <div class="col-lg-6">
                    <div class="form-group d-flex mb-3">
                        <label class="me-2">Tipo Alergia:</label>
                        <input type="text" class="form-control" id="ngTipoAlergia" readonly>
                    </div>
                    <div class="form-group d-flex mb-3">
                        <label class="me-2">Causante:</label>
                        <input type="text" class="form-control" id="ngCausante" readonly>
                    </div>
                    <div class="form-group d-flex mb-3">
                        <label class="me-2">Detalles:</label>
                        <input type="text" class="form-control" id="ngDetalles" readonly>
                    </div>
                    
                </div> -->
            </div>






        </div>

    </div>
</div>
</div>

        
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
<script>
    var app = angular.module('appConsultarDetalles', []);
    app.controller('ConsultarDetallesController', function ($scope, $http, $timeout, $window, $location) {

        var urlParams = new URLSearchParams(window.location.search);
        var idPaciente = urlParams.get('IdPaciente');
        //alert(idPaciente);
        var mydata = { IdPaciente: idPaciente };

        $scope.PacienteDetalles = {};

        $scope.PacienteInformacion = {};
        $scope.ListaPacienteInformacionServicios = [];

        $scope.ListaPacienteDiagnosticos = [];
        $scope.PacienteDiagnostico = {};

        $scope.ListaPacienteAlergias = [];

        try {
            $http({
                method: 'POST',
                url: '/View/Pacientes/ConsultarDetallesPaciente.aspx/GetDetallesPaciente',
                data: mydata,
                headers: { 'Content-Type': 'application/json; charset=utf-8' },
                dataType: 'json'
            }).then(function (response) {
                var paciente = response.data.d[0];
                //alert(paciente.Nombres);
                //alert(paciente.Nombres);
                //alert(paciente.FechaNacimiento);
                //$scope.ngFechaNacimiento = new Date(paciente.FechaNacimiento); // Formatear la fecha

                $scope.PacienteDetalles = paciente;

            });
        } catch (ex) {
            alert(ex);
        }

        try {
            $http({
                method: 'POST',
                url: '/View/Pacientes/ConsultarDetallesPaciente.aspx/GetInformacionPaciente',
                data: mydata,
                headers: { 'Content-Type': 'application/json; charset=utf-8' },
                dataType: 'json'
            }).then(function (response) {
                var paciente = response.data.d[0];
                
                //alert(paciente.FechaNacimiento);
                //$scope.ngFechaNacimiento = new Date(paciente.FechaNacimiento); // Formatear la fecha

                $scope.PacienteInformacion = paciente;

            });
        } catch (ex) {
            alert(ex);
        }

        try {
            $http({
                method: 'POST',
                url: '/View/Pacientes/ConsultarDetallesPaciente.aspx/GetInformacionPacienteServicio',
                data: mydata,
                headers: { 'Content-Type': 'application/json; charset=utf-8' },
                dataType: 'json'
            }).then(function (response) {
                $scope.ListaPacienteInformacionServicios = response.data.d;
                //alert($scope.ListaPacienteInformacionServicios.Servicio);

                var dataTableOptions = {
                    pageLength: 9,
                    destroy: true,
                    language: {
                        lengthMenu: "Mostrar _MENU_ registros por página",
                        zeroRecords: "Ningún Paciente encontrado",
                        info: "Mostrando de _START_ a _END_ de un total de _TOTAL_ registros",
                        infoEmpty: "Ningún Paciente encontrado",
                        infoFiltered: "(filtrados desde _MAX_ registros totales)",
                        
                        loadingRecords: "Cargando...",
                        paginate: {
                            first: "Primero",
                            last: "Último",
                            next: "Siguiente",
                            previous: "Anterior"
                        }
                    }
                };

                $timeout(function () {
                    //alert("entro al timeout");
                    //$('#datatable_Servicios').DataTable(dataTableOptions);
                    // Inicializa DataTables en la tabla

                });
                
                //$scope.ngFechaNacimiento = new Date(paciente.FechaNacimiento); // Formatear la fecha

                //$scope.PacienteInformacion = paciente;

            });
        } catch (ex) {
            alert(ex);
        }

        try {
            $http({
                method: 'POST',
                url: '/View/Pacientes/ConsultarDetallesPaciente.aspx/GetDiagnosticosPaciente',
                data: mydata,
                headers: { 'Content-Type': 'application/json; charset=utf-8' },
                dataType: 'json'
            }).then(function (response) {
                $scope.ListaPacienteDiagnosticos = response.data.d;
               

            });
        } catch (ex) {
            alert(ex);
        }

        $scope.seleccionarDiagnostico = function (diagnostico) {
            $scope.diagnosticoSeleccionado = angular.copy(diagnostico);
        };



        try {
            $http({
                method: 'POST',
                url: '/View/Pacientes/ConsultarDetallesPaciente.aspx/GetAlergiasPaciente',
                data: mydata,
                headers: { 'Content-Type': 'application/json; charset=utf-8' },
                dataType: 'json'
            }).then(function (response) {
                $scope.ListaPacienteAlergias = response.data.d;
                //alert($scope.ListaPacienteInformacionServicios.Servicio);

                var dataTableOptions = {
                    pageLength: 9,
                    destroy: true,
                    language: {
                        lengthMenu: "Mostrar _MENU_ registros por página",
                        zeroRecords: "Ninguna alergia encontrada",
                        info: "Mostrando de _START_ a _END_ de un total de _TOTAL_ registros",
                        infoEmpty: "Ninguna alergia encontrada",
                        infoFiltered: "(filtrados desde _MAX_ registros totales)",

                        loadingRecords: "Cargando...",
                        paginate: {
                            first: "Primero",
                            last: "Último",
                            next: "Siguiente",
                            previous: "Anterior"
                        }
                    }
                    
                };

                $timeout(function () {
                    
                    $('#datatable_Alergias').DataTable(dataTableOptions);
                    // Inicializa DataTables en la tabla

                });

                //$scope.ngFechaNacimiento = new Date(paciente.FechaNacimiento); // Formatear la fecha


            });
        } catch (ex) {
            alert(ex);
        }

    });
   


</script>

</body>

</asp:Content>
