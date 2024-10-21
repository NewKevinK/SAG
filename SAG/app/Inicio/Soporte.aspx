<%@ Page Title="Soporte" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Soporte.aspx.cs" Inherits="SAG.app.Inicio.Soporte" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <link href="../../css/styleSoporte.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css" />
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link href="../../css/styleSoporte.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>

    <title>Soporte</title>

    <body>

    <div class="container" ng-app="soporteApp" ng-controller="SoporteController">
        <div class="support">
            <span class="title">Soporte</span>
            <div class="buttons">
                <button class="btn btn-primary" ng-click="registrarUsuario()">Registrar Usuario</button>
                <!-- <button class="btn btn-secondary" ng-click="cambiarContrasena()">Cambiar Contraseña</button> -->
            </div>
        </div>
    </div>

    <script>
        var app = angular.module('soporteApp', []);
        app.controller('SoporteController', function ($scope, $window) {
            $scope.registrarUsuario = function () {
                try {
                    $window.location.href = '/app/Inicio/RegistrarUsuario.aspx';
                    //alert("Funcionalidad para registrar usuario2.");
                } catch (ex) {
                    alert(ex);
                }

                
                

                
            };
            $scope.cambiarContrasena = function () {
                alert("Funcionalidad para cambiar contraseña.");
            };
        });
    </script>

</body>


</asp:Content>
