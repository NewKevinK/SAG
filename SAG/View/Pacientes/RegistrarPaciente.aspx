<%@ Page Title="Registrar Paciente" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="SAG.View.Pacientes.RegistrarPaciente" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <!-- CSS -->
    <link href="../../css/stylePaciente.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />

    <!-- Angular -->
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>


    <link href="../../css/stylePaciente.css" rel="stylesheet" />
    

<body>
    <div class="container">
        <header>Registrar nuevo Paciente</header>

        <form action="#">
            <div class="form first" ng-app="appFormulario" ng-controller="ctrlFormulario" ng-submit="login()">
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
                            <input type="text" id="txtApellidoMaterno" ng-model="ngApellidoMaterno" placeholder="Apellido Materno" required>
                        </div>
                        <div class="input-field">
                            <label>CURP</label>
                            <input type="text" id="txtCURP" ng-model="ngCURP" placeholder="CURP" required>
                        </div>
                        <div class="input-field">
                            <label>Fecha de Nacimiento</label>
                            <input type="date" id="txtFechaNacimiento" ng-model="ngFechaNacimiento" placeholder="Fecha de Nacimiento" required>
                        </div>
                        <div class="input-field">
                            <label>Sexo</label>
                            <input type="text" id="txtSexo" ng-model="ngSexo" placeholder="Sexo de nacimiento" required>
                        </div>
                        <div class="input-field">
                            <label>Entidad de Nacimiento</label>
                            <input type="text" ng-model="ngEntidadNacimiento" placeholder="Ciudad donde nacio" required>
                        </div>
                        <div class="input-field">
                            <label>Afiliacion</label>
                            <input type="text" ng-model="ngAfiliacion" placeholder="Afiliacion" required>
                        </div>
                        <div class="input-field">
                            <label>Numero de afiliacion</label>
                            <input type="text" ng-model="ngNumeroAfiliacion" placeholder="Num Afiliacion" required>
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
                        
                        <button class="nextBtn" ng-click="RegistrarPaciente()" type="submit">
                            <span class="btnText">Siguiente</span>
                            <i class="uil uil-navigator"></i>
                            
                        </button>
                    </div>
                </div>

                

            </div>
        </form>
            
                
    </div>


</body>
<script>
    var app = angular.module('appFormulario', []);

    app.controller('ctrlFormulario', function ($scope, $http, $window) {

        /*$scope.validarCampos = function () {
            // Define un arreglo para almacenar los nombres de los campos que están vacíos
            var camposVacios = [];

            // Verifica cada campo requerido y agrega su nombre al arreglo si está vacío
            if (!$scope.ngNombres) camposVacios.push('Nombres');
            if (!$scope.ngApellidoPaterno) camposVacios.push('Apellido Paterno');
            if (!$scope.ngApellidoMaterno) camposVacios.push('Apellido Materno');
            if (!$scope.ngCURP) camposVacios.push('CURP');
            if (!$scope.ngFechaNacimiento) camposVacios.push('Fecha de Nacimiento');
            if (!$scope.ngSexo) camposVacios.push('Sexo');
            if (!$scope.ngEntidadNacimiento) camposVacios.push('Entidad de Nacimiento');
            if (!$scope.ngAfiliacion) camposVacios.push('Afiliacion');
            if (!$scope.ngNumeroAfiliacion) camposVacios.push('Numero de afiliacion');
            if (!$scope.ngDireccion) camposVacios.push('Direccion');
            if (!$scope.ngNumeroExterior) camposVacios.push('Numero exterior');
            if (!$scope.ngNumeroInterior) camposVacios.push('Numero interior');
            if (!$scope.ngColonia) camposVacios.push('Colonia');
            if (!$scope.ngCodigoPostal) camposVacios.push('Codigo Postal');
            if (!$scope.ngMunicipio) camposVacios.push('Municipio');    
            if (!$scope.ngEstado) camposVacios.push('Estado');
            if (!$scope.ngPais) camposVacios.push('Pais');
            if (!$scope.ngTelefonoTrabajo) camposVacios.push('Telefono Trabajo');
            if (!$scope.ngTelefonoCasa) camposVacios.push('Telefono Casa');
            if (!$scope.ngTelefonoCelular) camposVacios.push('Telefono Celular');
            if (!$scope.ngCorreoElectronico) camposVacios.push('Correo electronico');
            if (!$scope.ngOcupacion) camposVacios.push('Ocupacion');
            if (!$scope.ngNombresResponsable) camposVacios.push('Nombres del responsable');
            if (!$scope.ngApellidoPaternoResponsable) camposVacios.push('Apellido Paterno del responsable');
            if (!$scope.ngApellidoMaternoResponsable) camposVacios.push('Apellido Materno del responsable');
            if (!$scope.ngParentescoResponsable) camposVacios.push('Parentesco');
            if (!$scope.ngDomicilioResponsable) camposVacios.push('Domicilio');
            if (!$scope.ngTelefonoResponsable) camposVacios.push('Telefono');

            // Agrega más campos según sea necesario...

            // Si hay campos vacíos, muestra un mensaje de alerta y retorna false
            if (camposVacios.length > 0) {
                var mensaje = 'Los siguientes campos son obligatorios y no pueden estar vacíos:\n';
                mensaje += camposVacios.join('\n');
                alert(mensaje);
                return false;
            }

            // Si todos los campos requeridos están llenos, retorna true
            return true;
        }*/



        $scope.RegistrarPaciente = function () {
            alert("Registrar Paciente");
            
            var mydata = {
                Nombres: $scope.ngNombres,
                ApellidoPaterno: $scope.ngApellidoPaterno,
                ApellidoMaterno: $scope.ngApellidoMaterno,
                CURP: $scope.ngCURP,
                //FechaNacimiento: $scope.ngFechaNacimiento,
                //FechaNacimiento: new Date($scope.ngFechaNacimiento),
                FechaNacimiento: new Date($scope.ngFechaNacimiento).toISOString(),
                Sexo: $scope.ngSexo,
                EntidadNacimiento: $scope.ngEntidadNacimiento,
                Afiliacion: $scope.ngAfiliacion,
                NumeroAfiliacion: $scope.ngNumeroAfiliacion,
                Direccion: "", Direccion: $scope.ngDireccion,
                NumeroExterior: "", NumeroExterior: $scope.ngNumeroExterior,
                NumeroInterior: "", NumeroInterior: $scope.ngNumeroInterior,
                Colonia:"", Colonia: $scope.ngColonia,
                CodigoPostal:"",CodigoPostal: $scope.ngCodigoPostal,
                Municipio:"",Municipio: $scope.ngMunicipio,
                Estado:"",Estado: $scope.ngEstado,
                Pais:"",Pais: $scope.ngPais,
                TelefonoTrabajo: $scope.ngTelefonoTrabajo,
                 TelefonoCasa: $scope.ngTelefonoCasa,
                 TelefonoCelular: $scope.ngTelefonoCelular,
                CorreoElectronico:"",CorreoElectronico: $scope.ngCorreoElectronico,
                Ocupacion:"",Ocupacion: $scope.ngOcupacion,
                NombresResponsable:"", NombresResponsable: $scope.ngNombresResponsable,
                ApellidoPaternoResponsable: "", ApellidoPaternoResponsable: $scope.ngApellidoPaternoResponsable,
                ApellidoMaternoResponsable: "", ApellidoMaternoResponsable: $scope.ngApellidoMaternoResponsable,
                ParentescoResponsable: "", ParentescoResponsable: $scope.ngParentescoResponsable,
                DomicilioResponsable:"", DomicilioResponsable: $scope.ngDomicilioResponsable,
                TelefonoResponsable:"", TelefonoResponsable: $scope.ngTelefonoResponsable
            };
            alert("va aentrar ");
            //if (!$scope.ngNumeroInterior) mydata.NumeroInterior: "test";
            alert(mydata.FechaNacimiento);
            alert(mydata.NumeroInterior);
            //Wed May 15 2024 00:00:00 GMT-0600 (hora estándar central)
            //Falta la validacion solamente
            try {
                alert("entro al");
                $http({
                    method: 'POST',
                    url: 'https://localhost:44377/View/Pacientes/RegistrarPaciente.aspx/InsertarPaciente',
                    data: mydata,
                    headers: { 'Content-Type': 'application/json; charset=utf-8' },
                    dataType: 'json'
                }).then(function (response) {
                    //var paciente = response.data.d[0];
                    alert(response.data.d);

                    //alert(paciente.Nombres);
                    //alert(paciente.FechaNacimiento);
                    //$scope.ngFechaNacimiento = new Date(paciente.FechaNacimiento); // Formatear la fecha

                    //$scope.Paciente = paciente;

                });
            } catch (ex) {
                alert(ex);
            }

            

        }

    });


    
</script>


</asp:Content>
