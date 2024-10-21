<%@ Page Title="Modificar Paciente"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs" Inherits="SAG.app.Pacientes.ModificarPaciente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>

    <!-- Bootstrap-->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <!-- Angular -->
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>

    <link href="../../css/stylePaciente.css" rel="stylesheet" />
    <title>Modificar Paciente</title>

<body>
    <div class="container" ng-app="appFormulario">
        <header>Modificar Paciente</header>

        <form action="#">
            <div class="form first"  ng-controller="ctrlFormulario" >
                <div class="details personal">
                    <span class="title">Informacion del Paciente</span>

                    <div class="fields">
                        <div class="input-field">
                            <label>Nombres</label>
                            <input type="text" ng-model="Paciente.Nombres" placeholder="Primeros nombres" >
                        </div>
                        <div class="input-field">
                            <label>Apellido Paterno</label>
                            <input type="text" ng-model="Paciente.ApellidoPaterno" placeholder="Apellido Paterno">
                        </div>
                        <div class="input-field">
                            <label>Apellido Materno</label>
                            <input type="text" ng-model="Paciente.ApellidoMaterno" placeholder="Apellido Materno" >
                        </div>
                        <div class="input-field">
                            <label>CURP</label>
                            <input type="text" ng-model="Paciente.CURP" placeholder="CURP" >
                        </div>
                        <div class="input-field">
                            <label>Fecha de Nacimiento</label>
                            <input type="date" ng-model="ngFechaNacimiento"  >
                        </div>
                        <div class="input-field">
                            <label>Sexo</label>
                            
                            <select id="txtSexo" ng-model="Paciente.Sexo" class="custom-select">
                                <option value="">Seleccionar Sexo</option>
                                <option value="Masculino">Masculino</option>
                                <option value="Femenino">Femenino</option>
                            </select>
                        </div>
                        <div class="input-field">
                            <label>Entidad de Nacimiento</label>
                            <input type="text" ng-model="Paciente.EntidadNacimiento" placeholder="Ciudad donde nacio" >
                        </div>
                        <div class="input-field">
                            <label>Afiliacion</label>
                            <input type="text" ng-model="Paciente.Afiliacion" placeholder="Afiliacion">
                        </div>
                        <div class="input-field">
                            <label>Numero de afiliacion</label>
                            <input type="text" ng-model="Paciente.NumeroAfiliacion" placeholder="Num Afiliacion">
                        </div>

                    </div>
                </div>

                <div class="details ID">
                    <span class="title">Direccion del Paciente</span>

                    <div class="fields">
                        <div class="input-field">
                            <label>Direccion</label>
                            <input type="text" ng-model="Paciente.Direccion" placeholder="Direccion" >
                        </div>
                        <div class="input-field">
                            <label>Numero exterior</label>
                            <input type="text" ng-model="Paciente.NumeroExterior" placeholder="Numero exterior" >
                        </div>
                        <div class="input-field">
                            <label>Numero interior</label>
                            <input type="text"  ng-model="Paciente.NumeroInterior" placeholder="Numero interior" >
                        </div>
                        <div class="input-field">
                            <label>Colonia</label>
                            <input type="text" ng-model="Paciente.Colonia" placeholder="Colonia" >
                        </div>
                        <div class="input-field">
                            <label>Codigo Postal</label>
                            <input type="text" ng-model="Paciente.CodigoPostal" placeholder="CP" >
                        </div>
                        <div class="input-field">
                            <label>Municipio</label>
                            <input type="text" ng-model="Paciente.Municipio" placeholder="Municipio" >
                        </div>
                        <div class="input-field">
                            <label>Estado</label>
                            <input type="text" ng-model="Paciente.Estado" placeholder="Estado" >
                        </div>
                        <div class="input-field">
                            <label>Pais</label>
                            <input type="text" ng-model="Paciente.Pais" placeholder="Pais" >
                        </div>
                        <div class="input-field">
                            <label>Telefono Trabajo</label>
                            <input type="text" ng-model="Paciente.TelefonoTrabajo"  placeholder="Tel Trabajo">
                        </div>
                        <div class="input-field">
                            <label>Telefono Casa</label>
                            <input type="text" ng-model="Paciente.TelefonoCasa"  placeholder="Tel Casa" >
                        </div>
                        <div class="input-field">
                            <label>Telefono Celular</label>
                            <input type="text" ng-model="Paciente.TelefonoCelular"  placeholder="Tel Celular" >
                        </div>
                        <div class="input-field">
                            <label>Correo electronico</label>
                            <input type="text" ng-model="Paciente.CorreoElectronico" placeholder="Email" >
                        </div>
                        <div class="input-field">
                            <label>Ocupacion</label>
                            <input type="text" ng-model="Paciente.Ocupacion" placeholder="Ocupacion del Paciente">
                        </div>

                    </div>

                    


                </div>

                <div class="details responsable">
                    <span class="title">Informacion del Responsable del Paciente</span>

                    <div class="fields">
                        <div class="input-field">
                            <label>Nombres</label>
                            <input type="text" ng-model="Paciente.NombresResponsable" placeholder="Nombres del responsable" >
                        </div>
                        <div class="input-field">
                            <label>Apellido Paterno</label>
                            <input type="text" ng-model="Paciente.ApellidoPaternoResponsable" placeholder="Apellido paterno del responsable" >
                        </div>
                        <div class="input-field">
                            <label>Apellido Materno</label>
                            <input type="text" ng-model="Paciente.ApellidoMaternoResponsable" placeholder="Apellido Materno del responsable" >
                        </div>
                        <div class="input-field">
                            <label>Parentesco</label>
                            <input type="text" ng-model="Paciente.ParentescoResponsable" placeholder="Parentesco con el Paciente" >
                        </div>
                        <div class="input-field">
                            <label>Domicilio</label>
                            <input type="text" ng-model="Paciente.DomicilioResponsable" placeholder="Domicilio del responsable" >
                        </div>
                        <div class="input-field">
                            <label>Telefono</label>
                            <input type="text" ng-model="Paciente.TelefonoResponsable"  placeholder="Telefono del responsable" >
                        </div>

                        <button class="nextBtn" ng-click="ModificarPaciente()" type="button">
                            <span class="btnText">Modificar</span>
                            <i class="uil uil-navigator"></i>
                        </button>
                        

                    </div>
                </div>

                <!-- Modal para mostrar el resultado -->
                <div class="modal fade" id="resultadoModal" tabindex="-1" role="dialog" aria-labelledby="resultadoModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="resultadoModalLabel">Resultado del Registro</h5>
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
        </form>
            
                
    </div>

<script>
    var app = angular.module('appFormulario', []);

    app.controller('ctrlFormulario', function ($scope, $http, $window) {
        var urlParams = new URLSearchParams(window.location.search);
        var idPaciente = urlParams.get('id');
        var mydata = { IdPaciente : idPaciente };
        //alert(mydata.IdPaciente);
        $scope.Paciente = {};

        $scope.ModificarPaciente = function () {
            if (!$scope.Paciente.Nombres || !$scope.Paciente.ApellidoPaterno || !$scope.Paciente.Sexo || !$scope.Paciente.CURP || !$scope.ngFechaNacimiento) {
                $scope.mensajeModal = "Los campos Nombres, Apellido Paterno, Sexo, CURP y FechaNacimiento son obligatorios.";
                $('#resultadoModal').modal('show');
                return;
            }

            try {
                var mydata = {
                    IdPaciente: idPaciente,
                    Nombres: $scope.Paciente.Nombres,
                    ApellidoPaterno: $scope.Paciente.ApellidoPaterno,
                    ApellidoMaterno: $scope.Paciente.ApellidoMaterno || "",
                    CURP: $scope.Paciente.CURP,
                    FechaNacimiento: $scope.ngFechaNacimiento,
                    Sexo: $scope.Paciente.Sexo,
                    EntidadNacimiento: $scope.Paciente.EntidadNacimiento || "",
                    Afiliacion: $scope.Paciente.Afiliacion || "",
                    NumeroAfiliacion: $scope.Paciente.NumeroAfiliacion || "",
                    Direccion: $scope.Paciente.Direccion || "",
                    NumeroExterior: $scope.Paciente.NumeroExterior || "",
                    NumeroInterior: $scope.Paciente.NumeroInterior || "",
                    Colonia: $scope.Paciente.Colonia || "",
                    CodigoPostal: $scope.Paciente.CodigoPostal || "",
                    Municipio: $scope.Paciente.Municipio || "",
                    Estado: $scope.Paciente.Estado || "",
                    Pais: $scope.Paciente.Pais || "",
                    TelefonoTrabajo: $scope.Paciente.TelefonoTrabajo || "",
                    TelefonoCasa: $scope.Paciente.TelefonoCasa || "",
                    TelefonoCelular: $scope.Paciente.TelefonoCelular || "",
                    CorreoElectronico: $scope.Paciente.CorreoElectronico || "",
                    Ocupacion: $scope.Paciente.Ocupacion || "",
                    NombresResponsable: $scope.Paciente.NombresResponsable || "",
                    ApellidoPaternoResponsable: $scope.Paciente.ApellidoPaternoResponsable || "",
                    ApellidoMaternoResponsable: $scope.Paciente.ApellidoMaternoResponsable || "",
                    ParentescoResponsable: $scope.Paciente.ParentescoResponsable || "",
                    DomicilioResponsable: $scope.Paciente.DomicilioResponsable || "",
                    TelefonoResponsable: $scope.Paciente.TelefonoResponsable || ""
                };


                $http({
                    method: 'POST',
                    url: '/app/Pacientes/ModificarPaciente.aspx/UpdatePaciente',
                    data: mydata,
                    headers: { 'Content-Type': 'application/json; charset=utf-8' },
                    dataType: 'json'
                }).then(function (response) {
                    var resultado = response.data.d;

                    if (resultado.Result == 1) {
                        $scope.mensajeModal = resultado.Message;
                        setTimeout(function () {
                            window.location.href = '/Default.aspx';
                        }, 2000);
                        
                    } else {
                        alert("entro al 0");
                        $scope.mensajeModal = "Error: " + resultado.Message;
                    }
                    $('#resultadoModal').modal('show');

                });
            } catch (ex) {
                alert(ex);
            }
        }

        try {
            $http({
                method: 'POST',
                url: '/app/Pacientes/ModificarPaciente.aspx/GetPaciente',
                data: mydata,
                headers: { 'Content-Type': 'application/json; charset=utf-8' },
                dataType: 'json'
            }).then(function (response) {
                var paciente = response.data.d[0];
                $scope.ngFechaNacimiento = new Date(paciente.FechaNacimiento + 'T00:00:00'); // Formatear la fecha
                
                $scope.Paciente = paciente;

            });
        } catch (ex) {
            alert(ex);
        }

        // Función para formatear la fecha
        function formatDate(dateString) {
            var parts = dateString.split('/');
            // parts[2] contiene el año, parts[1] contiene el mes y parts[0] contiene el día
            return parts[2] + '-' + parts[1] + '-' + parts[0];
        }
        

    });

</script>

</body>
</asp:Content>
