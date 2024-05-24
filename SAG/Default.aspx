<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SAG._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <!-- CSS -->
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

    <!-- Angular -->
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>

    <link href="css/styleDashboard.css" rel="stylesheet" />

    <body>


        <div class="container" ng-app="appDashboard" ng-controller="DashboardController">

            <header>Inicio</header>
            <div class="row">
                <div class="col-md-4">
                    <div class="card text-white bg-primary mb-3">
                        <div class="card-body">
                            <h5 class="card-title">Pacientes Registrados Hoy</h5>
                            <p class="card-text">{{ numPacientesRegistrados }}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card text-white bg-success mb-3">
                        <div class="card-body">
                            <h5 class="card-title">Pacientes Internados Hoy</h5>
                            <p class="card-text">{{ numPacientesInternados }}</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card text-white bg-danger mb-3">
                        <div class="card-body">
                            <h5 class="card-title">Pacientes Egresados Hoy</h5>
                            <p class="card-text">{{ numPacientesEgresados }}</p>
                        </div>
                    </div>
                </div>
            </div>
            
    </body>

<script>
            var app = angular.module('appDashboard', []);

            app.controller('DashboardController', function($scope) {
                // Simulando datos para las tarjetas
                $scope.numPacientesRegistrados = 5;  // Reemplazar con datos reales
                $scope.numPacientesInternados = 2;   // Reemplazar con datos reales
                $scope.numPacientesEgresados = 1;    // Reemplazar con datos reales
            });
</script>


</asp:Content>
