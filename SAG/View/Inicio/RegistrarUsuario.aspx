<%@ Page Title="Registrar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="SAG.View.Inicio.RegistrarUsuario" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <!-- ===== Iconscout CSS ===== -->
    <link href="../../css/styleLogin.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />

    <!-- jQuery -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

    <!-- Bootstrap-->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>



    <!-- Angular -->
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>

    <!-- ===== CSS ===== -->
    <link href="../../css/styleLogin.css" rel="stylesheet" />


    <title>Registrar Usuario</title>

<body>
    <div class="container" ng-app="appRegistrarUsuario" ng-controller="RegistrarUsuarioController">   
        <div class="forms">
            <div class="form login">
                <span class="title">Registro de Nuevo Usuario</span>
                <form action="#">
                    <div class="input-field">
                        <input type="text" ng-model="fd.nombres" placeholder="Ingresa el nombre y apellido" required>
                        <i class="uil uil-user"></i>
                    </div>
                    <div class="input-field">
                        <input type="text" ng-model="fd.email" placeholder="Ingresa el correo electronico" required>
                        <i class="uil uil-envelope icon"></i>
                    </div>
                    <div class="input-field">
                        <input type="password" ng-model="fd.password" class="password" placeholder="Crea una contraseña" required>
                        <i class="uil uil-lock icon"></i>
                    </div>
                    <div class="input-field">
                        <input type="password" ng-model="fd.confirmPassword" class="password" placeholder="Confirma la contraseña" required>
                        <i class="uil uil-lock icon"></i>
                        <i class="uil uil-eye-slash showHidePw"></i>
                    </div>
                    
                    <div class="input-field button">
                        <input type="button" value="Registrar" ng-click="Registrar()">
                    </div>
                </form>

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
        </div>
        
    </div>
    

</body>
<script>
    var app = angular.module('appRegistrarUsuario', []);



    app.controller('RegistrarUsuarioController', function ($scope, $http, $window) {



        
        $scope.fd = {
            nombres: "",
            email: "",
            password: "",
            confirmPassword : ""
        }

        $scope.Registrar = function () {
            

            try {
                var mydata = {
                    Nombres: $scope.fd.nombres,
                    Usuario: $scope.fd.email,
                    Password: $scope.fd.password
                };

                if ($scope.fd.nombres == "" || $scope.fd.email == "" || $scope.fd.password == "") {
                    $scope.mensajeModal = "Todos los campos son obligatorios.";
                    $('#resultadoModal').modal('show');
                    return;
                }

                if ($scope.fd.password != $scope.fd.confirmPassword) {
                    $scope.mensajeModal = "Las contraseñas no coinciden.";
                    $('#resultadoModal').modal('show');
                    return;
                }

                $http({
                    method: 'POST',
                    url: '/View/Inicio/RegistrarUsuario.aspx/RegistrarUsuar',
                    data: mydata,
                    headers: { 'Content-Type': 'application/json; charset=utf-8' },
                    dataType: 'json'
                }).then(function (response) {
                    var resultado = response.data.d;
                    if (resultado.Result == 1) {
                        $scope.mensajeModal = resultado.Message;
                        //$('#resultadoModal').modal('show');
                        $('#resultadoModal').on('hidden.bs.modal', function () {
                            $window.location.href = '/View/Inicio/Soporte.aspx';
                        });
                        $('#resultadoModal').modal('show');
                        

                    } else {
                        $scope.mensajeModal = resultado.Message;                     

                    }

                }, function (error) {
                    alert("Error al registrar usuario");
                });
            } catch (ex) {
                alert(ex);
            }

        }


    });
</script>

</asp:Content>
