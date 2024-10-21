<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SAG._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <!-- CSS -->
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>

    <!-- Angular -->
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    <link href="css/styleDashboard.css" rel="stylesheet" />

    <body>
        <div class="container" ng-app="appDashboard" ng-controller="DashboardController">
            <header>Inicio</header>
            <div class="row"></div>


            <!-- Dashboard principal en dos columnas -->
            <div class="row">
                <!-- Columna izquierda: Estadísticas y gráfico -->
                <div class="col-md-6">
                    <!-- Estadísticas -->
                    <div class="dashboard-row">
                        <div class="dashboard-box">
                            <div class="icon">
                                <img src="css/icon/triage-01.png" alt="Ingresos Icon" />
                            </div>
                            <div class="details">
                                <h3>{{totalIngresosHoy}}</h3>
                                <p>Pacientes Ingresados Hoy</p>
                            </div>
                        </div>

                        <div class="dashboard-box">
                            <div class="icon">
                                <img src="css/icon/egreso-01.png" alt="Egresos Icon" />
                            </div>
                            <div class="details">
                                <h3>{{totalEgresosHoy}}</h3>
                                <p>Pacientes Egresados Hoy</p>
                            </div>
                        </div>
                    </div>

                    <!-- Gráfico -->
                    <div class="chart-container">
                        <h8>Pacientes registrados los ultimos 7 dias</h8>
                        <canvas id="patientChart"></canvas>
                    </div>
                </div>

                <!-- Columna derecha: Tabla de pacientes -->
                <div class="col-md-6">
                    <h6>Pacientes Registrados Hoy {{formatearFechaActual()}}</h6>
                    <table class="table table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Nombres</th>
                                <th>CURP</th>
                                <th>Estado</th>
                                <th>Acción</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr ng-repeat="paciente in listaPacientesHoy">
                                <td>{{paciente.NumeroExpediente}}</td>
                                <td>{{paciente.Nombres}}</td>
                                <td>{{paciente.CURP}}</td>
                                <td>{{paciente.EstadoPaciente}}</td>
                                <td>
                                    <button class="btn btn-primary" ng-click="verPaciente(paciente.NumeroExpediente)">Ver Información</button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </body>


<script>
    var app = angular.module('appDashboard', []);
 
    app.controller('DashboardController', function ($scope, $http) {
        $scope.fechaActual = new Date();
        // Función para formatear la fecha en español
        $scope.formatearFechaActual = function () {
            var diasSemana = ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'];
            var meses = ['enero', 'febrero', 'marzo', 'abril', 'mayo', 'junio', 'julio', 'agosto', 'septiembre', 'octubre', 'noviembre', 'diciembre'];

            var dia = diasSemana[$scope.fechaActual.getDay()];
            var diaMes = $scope.fechaActual.getDate();
            var mes = meses[$scope.fechaActual.getMonth()];
            var año = $scope.fechaActual.getFullYear();

            return dia + ' ' + diaMes + ' de ' + mes + ' de ' + año;
        };
        var mydata = { "": "" };
        var idPaciente = "";
        $scope.listaPacientesHoy = [];

        //Semana
        try {
            $http({
                method: 'POST',
                url: 'Default.aspx/GetEstadisticaSemanalHome',
                data: mydata,
                headers: { 'Content-Type': 'application/json; charset=utf-8' },
                dataType: 'json'
            }).then(function (response) {
                var labels = response.data.d.dates; // Fechas
                var data = response.data.d.pacientesIngresados; // Pacientes ingresados
                
                // Grafica
                var ctx = document.getElementById('patientChart').getContext('2d');
                var patientChart = new Chart(ctx, {
                    type: 'line',
                    data: {
                        labels: labels, 
                        datasets: [{
                            label: 'Pacientes',
                            data: data, // Array con los valores de los pacientes ingresados
                            borderColor: '#FFA500', // Color de la línea (similar al de la imagen)
                            backgroundColor: 'rgba(255, 165, 0, 0.1)', // Color de fondo transparente
                            fill: true, // Rellenar el área bajo la línea
                            tension: 0.4, // Curva suave
                            pointBackgroundColor: '#FF4500',
                            pointBorderColor: '#FF4500',
                        }]
                    },
                    options: {
                        responsive: true,
                        plugins: {
                            title: {
                                display: true,
                                text: 'Pacientes registrados los últimos 7 días', // Título del gráfico
                                font: {
                                    size: 18
                                }
                            }
                        },
                        scales: {
                            y: {
                                beginAtZero: true 
                            }
                        },
                        plugins: {
                            legend: {
                                display: false 
                            }
                        }
                    }
                });

            });
        } catch (ex) {
            alert(ex);
        }

        //PacientesDia
        try {
            $http({
                method: 'POST',
                url: 'Default.aspx/GetTablaHome',
                data: mydata,
                headers: { 'Content-Type': 'application/json; charset=utf-8' },
                dataType: 'json'
            }).then(function (response) {
                $scope.listaPacientesHoy = response.data.d;

                $scope.verPaciente = function (idPaciente) {
                    window.location.href = "/app/Pacientes/ConsultarDetallesPaciente.aspx?IdPaciente=" + idPaciente;
                };

            });
        } catch (ex) {
            alert(ex);
        }

        //Dia
        try {
            $http({
                method: 'POST',
                url: 'Default.aspx/GetEstadisticaDiariaHome',
                data: mydata,
                headers: { 'Content-Type': 'application/json; charset=utf-8' },
                dataType: 'json'
            }).then(function (response) {
                $scope.totalIngresosHoy = response.data.d.PacientesIngresados;
                $scope.totalEgresosHoy = response.data.d.PacientesEgresados;
            });
        } catch (ex) {
            alert(ex);
        }



    });
</script>


</asp:Content>
