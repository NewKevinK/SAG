<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SAG.View.Inicio.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <!-- ===== Iconscout CSS ===== -->
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css"/>
    <!-- ===== CSS ===== -->
    <link href="../../css/styleLogin.css" rel="stylesheet" />

   
         
    <title>Login</title> 

    
</head>
<body >

    <div class="container" ng-controller="LoginController" >
        <div class="forms">
            <div class="form login" >
                <span class="title">Inicio de Sesion</span>
                <form ng-submit="login()">
                <form action="#">
                    <div class="input-field">
                        <input type="text" ng-model="fd.correo" placeholder="Ingresa el correo" required>
                        <i class="uil uil-envelope icon"></i>
                    </div>
                    <div class="input-field">
                        <input type="password" ng-model="fd.password" class="password" placeholder="Ingresa tu contraseña" required/>
                        <i class="uil uil-lock icon"></i>
                        <i class="uil uil-eye-slash showHidePw"></i>
                    </div>
                    <div class="checkbox-text">
                        <div class="checkbox-content">
                            <input type="checkbox" id="logCheck"/>
                            <label for="logCheck" class="text">Recordar</label>
                        </div>
                        
                        <a href="#" class="text">Soporte</a>
                    </div>
                    <div class="input-field button">
                        <a href="../../Default.aspx"  ng-click="InicioSesion();" >
                            <input type="button" value="Iniciar">Login</input>

                        </a>
                    </div>
                    
                </form>
                </form>
            </div>
            
        </div>
    </div>
        <!-- Angular -->
<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>
<script>
    var app = angular.module('myApp', []);

   

    app.controller('LoginController', function ($scope, $http, $window) {
        //$window.location.href = "../../Site.Master";

        function __login() {
            $http.post("../../Default.aspx", $scope.fd).then(function (response) {
                if (response.data == "1") {
                    $window.location.href = "../../Site.Master";
                } else {
                    alert("Usuario o contraseña incorrectos");
                }
            });
        }

        $scope.fd = {
            correo: "",
            password: ""
        }

        $scope.IniciarSesion = function () {
            $console.log("hola");
            alert("hola");
            //$window.location.href = "../../Site.Master";
        }

        $scope.login = function () {
            $console.log("hola");
            //$window.location.href = "../../Site.Master";
             
             
        }
    });
</script>

    
    
</body>
</html>
