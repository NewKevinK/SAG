<%@ Page Title="Registrar Paciente" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="SAG.View.Pacientes.RegistrarPaciente" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <!-- CSS -->
    <link href="../../css/stylePaciente.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>

    <!-- Bootstrap-->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    

    <!-- Angular -->
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>


    <link href="../../css/stylePaciente.css" rel="stylesheet" />
    

<body>
    <div class="container" ng-app="appFormulario">
        <header>Registrar nuevo Paciente</header>

        <form action="#">
            <div class="form first"  ng-controller="ctrlFormulario" ng-submit="login()">
                <div class="details personal">
                    <span class="title">Informacion del Paciente</span>

                    <div class="fields">
                        <div class="input-field">
                            <label>Nombres</label>
                            <input type="text" id="txtNombres" ng-model="ngNombres" placeholder="Primeros nombres" required>
                        </div>
                        <div class="input-field">
                            <label>Apellido Paterno</label>
                            <input type="text" id="txtApellidoPaterno" ng-model="ngApellidoPaterno" placeholder="Apellido Paterno" required>
                        </div>
                        <div class="input-field">
                            <label>Apellido Materno</label>
                            <input type="text" id="txtApellidoMaterno" ng-model="ngApellidoMaterno" placeholder="Apellido Materno">
                        </div>
                        <div class="input-field">
                            <label>CURP</label>
                            <input type="text" id="txtCURP" ng-model="ngCURP" placeholder="CURP" required>
                        </div>
                        <div class="input-field">
                            <label>Fecha de Nacimiento</label>
                            <input type="date" id="txtFechaNacimiento" ng-model="ngFechaNacimiento" placeholder="Fecha de Nacimiento" >
                        </div>
                        <div class="input-field">
                            <label>Sexo</label>
                            <input type="text" id="txtSexo" ng-model="ngSexo" placeholder="Sexo de nacimiento" >
                        </div>
                        <div class="input-field">
                            <label>Entidad de Nacimiento</label>
                            <input type="text" ng-model="ngEntidadNacimiento" placeholder="Ciudad donde nacio" >
                        </div>
                        <div class="input-field">
                            <label>Afiliacion</label>
                            <input type="text" ng-model="ngAfiliacion" placeholder="Afiliacion" >
                        </div>
                        <div class="input-field">
                            <label>Numero de afiliacion</label>
                            <input type="text" ng-model="ngNumeroAfiliacion" placeholder="Num Afiliacion">
                        </div>

                    </div>
                </div>

                <div class="details ID">
                    <span class="title">Direccion del Paciente</span>

                    <div class="fields">
                        <div class="input-field">
                            <label>Direccion</label>
                            <input type="text" ng-model="ngDireccion" placeholder="Direccion" >
                        </div>
                        <div class="input-field">
                            <label>Numero exterior</label>
                            <input type="text" ng-model="ngNumeroExterior" placeholder="Numero exterior" >
                        </div>
                        <div class="input-field">
                            <label>Numero interior</label>
                            <input type="text" ng-model="ngNumeroInterior" placeholder="Numero interior" >
                        </div>
                        <div class="input-field">
                            <label>Colonia</label>
                            <input type="text" ng-model="ngColonia" placeholder="Colonia" >
                        </div>
                        <div class="input-field">
                            <label>Codigo Postal</label>
                            <input type="text" ng-model="ngCodigoPostal" placeholder="CP" >
                        </div>
                        <div class="input-field">
                            <label>Municipio</label>
                            <input type="text" ng-model="ngMunicipio" placeholder="Municipio" >
                        </div>
                        <div class="input-field">
                            <label>Estado</label>
                            <input type="text" ng-model="ngEstado" placeholder="Estado" >
                        </div>
                        <div class="input-field">
                            <label>Pais</label>
                            <input type="text" ng-model="ngPais" placeholder="Pais" >
                        </div>
                        <div class="input-field">
                            <label>Telefono Trabajo</label>
                            <input type="text" ng-model="ngTelefonoTrabajo" ng-pattern="/^[0-9]+$/" placeholder="Tel Trabajo">
                            
                            
                        </div>
                        <div class="input-field">
                            <label>Telefono Casa</label>
                            <input type="text" ng-model="ngTelefonoCasa" ng-pattern="/^[0-9]+$/" placeholder="Tel Casa" >
                            
                            
                        </div>
                        <div class="input-field">
                            <label>Telefono Celular</label>
                            <input type="text" ng-model="ngTelefonoCelular" ng-pattern="/^[0-9]+$/" placeholder="Tel Celular" >
                            
                        </div>
                        <div class="input-field">
                            <label>Correo electronico</label>
                            <input type="text" ng-model="ngCorreoElectronico" placeholder="Email" >
                        </div>
                        <div class="input-field">
                            <label>Ocupacion</label>
                            <input type="text" ng-model="ngOcupacion" placeholder="Ocupacion del Paciente" >
                        </div>

                    </div>

                    


                </div>

                <div class="details responsable">
                    <span class="title">Informacion del Responsable del Paciente</span>

                    <div class="fields">
                        <div class="input-field">
                            <label>Nombres</label>
                            <input type="text" ng-model="ngNombresResponsable" placeholder="Nombres del responsable" >
                        </div>
                        <div class="input-field">
                            <label>Apellido Paterno</label>
                            <input type="text" ng-model="ngApellidoPaternoResponsable" placeholder="Apellido paterno del responsable" >
                        </div>
                        <div class="input-field">
                            <label>Apellido Materno</label>
                            <input type="text" ng-model="ngApellidoMaternoResponsable" placeholder="Apellido Materno del responsable" >
                        </div>
                        <div class="input-field">
                            <label>Parentesco</label>
                            <input type="text" ng-model="ngParentescoResponsable" placeholder="Parentesco con el Paciente" >
                        </div>
                        <div class="input-field">
                            <label>Domicilio</label>
                            <input type="text" ng-model="ngDomicilioResponsable" placeholder="Domicilio del responsable" >
                        </div>
                        <div class="input-field">
                            <label>Telefono</label>
                            <input type="text" ng-model="ngTelefonoResponsable" ng-pattern="/^[0-9]+$/" placeholder="Telefono del responsable" >
                        </div>
                        
                        <button class="nextBtn" ng-click="RegistrarPaciente()" type="button">
                            <span class="btnText">Siguiente</span>
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


</body>
<script>
    var app = angular.module('appFormulario', []);

    app.controller('ctrlFormulario', function ($scope, $http, $window) {

        


        $scope.RegistrarPaciente = function () {
            try {
                var mydata = {
                    Nombres: $scope.ngNombres,
                    ApellidoPaterno: $scope.ngApellidoPaterno,
                    ApellidoMaterno: $scope.ngApellidoMaterno || "",
                    CURP: $scope.ngCURP || "",
                    //FechaNacimiento: $scope.ngFechaNacimiento,
                    //FechaNacimiento: new Date($scope.ngFechaNacimiento),
                    FechaNacimiento: new Date($scope.ngFechaNacimiento).toISOString() || "",
                    Sexo: $scope.ngSexo || "",
                    EntidadNacimiento: $scope.ngEntidadNacimiento || "",
                    Afiliacion: $scope.ngAfiliacion || "",
                    NumeroAfiliacion: $scope.ngNumeroAfiliacion || "",
                    Direccion: $scope.ngDireccion || "",
                    NumeroExterior: $scope.ngNumeroExterior || "",
                    NumeroInterior: $scope.ngNumeroInterior || "",
                    Colonia: $scope.ngColonia || "",
                    CodigoPostal: $scope.ngCodigoPostal || "",
                    Municipio: $scope.ngMunicipio || "",
                    Estado: $scope.ngEstado || "",
                    Pais: $scope.ngPais || "",
                    TelefonoTrabajo: $scope.ngTelefonoTrabajo || "",
                    TelefonoCasa: $scope.ngTelefonoCasa || "",
                    TelefonoCelular: $scope.ngTelefonoCelular || "",
                    CorreoElectronico: $scope.ngCorreoElectronico || "",
                    Ocupacion: $scope.ngOcupacion || "",
                    NombresResponsable: $scope.ngNombresResponsable || "",
                    ApellidoPaternoResponsable: $scope.ngApellidoPaternoResponsable || "",
                    ApellidoMaternoResponsable: $scope.ngApellidoMaternoResponsable || "",
                    ParentescoResponsable: $scope.ngParentescoResponsable || "",
                    DomicilioResponsable: $scope.ngDomicilioResponsable || "",
                    TelefonoResponsable: $scope.ngTelefonoResponsable || ""
                };
            } catch (ex) {
                alert(ex);
            }

            //InsertarPaciente
            try {
                
                //alert("entro al post");
                $http({
                    method: 'POST',
                    url: 'https://localhost:44377/View/Pacientes/RegistrarPaciente.aspx/InsertarPaciente',
                    data: mydata,
                    headers: { 'Content-Type': 'application/json; charset=utf-8' },
                    dataType: 'json'
                }).then(function (response) {
                    var resultado = response.data.d;
                    
                    if (resultado.Result == 1) {
                        $scope.mensajeModal = "Paciente registrado exitosamente.";
                        $scope.resetForm(); 
                    } else {
                        //alert("entro al 0");
                        $scope.mensajeModal = "Error: " + resultado.Message;
                    }
                    $('#resultadoModal').modal('show');
                    setTimeout(function () {
                        window.location.href = '/Default.aspx';
                    }, 2000);

                });
            } catch (ex) {
                $scope.mensajeModal = "Error en el registro: " + error.message;
                $('#resultadoModal').modal('show');
                alert(ex);
            }
        }

        $scope.resetForm = function () {
            $scope.ngNombre = '';
            $scope.ngApellidoPaterno = '';
            $scope.ngApellidoMaterno = '';
            $scope.ngCURP = '';
            $scope.ngFechaNacimiento = '';
            $scope.ngSexo = '';
            $scope.ngEntidadNacimiento = '';
            $scope.ngAfiliacion = '';
            $scope.ngNumeroAfiliacion = '';
            $scope.ngDireccion = '';
            $scope.ngNumeroExterior = '';
            $scope.ngNumeroInterior = '';
            $scope.ngColonia = '';
            $scope.ngCodigoPostal = '';
            $scope.ngMunicipio = '';
            $scope.ngEstado = '';
            $scope.ngPais = '';
            $scope.ngTelefonoTrabajo = '';
            $scope.ngTelefonoCasa = '';
            $scope.ngTelefonoCelular = '';
            $scope.ngCorreoElectronico = '';
            $scope.ngOcupacion = '';
            $scope.ngNombresResponsable = '';
            $scope.ngApellidoPaternoResponsable = '';
            $scope.ngApellidoMaternoResponsable = '';
            $scope.ngParentescoResponsable = '';
            $scope.ngDomicilioResponsable = '';
            $scope.ngTelefonoResponsable = '';
        };

    });


    
</script>


</asp:Content>
