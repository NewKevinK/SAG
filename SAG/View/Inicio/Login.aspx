<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SAG.View.Inicio.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <!-- ===== Iconscout CSS ===== -->
    <link href="../../css/styleLogin.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    
    
    
    <!-- Angular -->
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>

    <!-- ===== CSS ===== -->
    <link href="../../css/styleLogin.css" rel="stylesheet" />
         
    <title>Login</title> 

    
</head>
<body >

    <div class="container" ng-app="appLogin" ng-controller="LoginController">
        <div class="forms">
            <div class="form login">
                <span class="title">Inicio de Sesion</span>
                
                <form action="#">
                    <div class="input-field">
                        <input type="text" ng-model="fd.correo" placeholder="Ingresa el correo" required />
                        <i class="uil uil-envelope icon"></i>
                    </div>
                    <div class="input-field">
                        <input type="password" ng-model="fd.password" class="password" placeholder="Ingresa tu contraseña" required />
                        <i class="uil uil-lock icon"></i>
                        <i class="uil uil-eye-slash showHidePw"></i>
                    </div>
                    <div class="checkbox-text">
                        <div class="checkbox-content">
                            <input type="checkbox" id="logCheck" />
                            <label for="logCheck" class="text">Recordar</label>
                        </div>
                        
                        <a href="#" class="text">Soporte</a>
                    </div>
                    <div class="input-field button">
                        <input type="button" value="Login" ng-click="InicioSesion()">
                    </div>
                </form>
                
            </div>
        </div>
    </div>
  
</body>
<script>
    var app = angular.module('appLogin', []);



    app.controller('LoginController', function ($scope, $http, $window) {



        
        $scope.fd = {
            correo: "",
            password: ""
        }

        $scope.InicioSesion = function () {
            var mydata = {
                Usuario: $scope.fd.correo,
                Password: $scope.fd.password
            };

            try {

                $http({
                    method: 'POST',
                    url: '/View/Inicio/Login.aspx/LoginSAG',
                    data: mydata,
                    headers: { 'Content-Type': 'application/json; charset=utf-8' },
                    dataType: 'json'
                }).then(function (response) {
                    var resultado = response.data.d;
                    if (resultado.Result == 1) {
                        $window.location.href = '/../Default.aspx'; 
                    } else {
                        alert("Credenciales invalidas: "+resultado.Message); 
                    }

                }, function (error) {
                    alert("Error al iniciar sesion");
                });
            } catch (ex) {
                alert(ex);
            }

        }


    });
</script>

</html>
