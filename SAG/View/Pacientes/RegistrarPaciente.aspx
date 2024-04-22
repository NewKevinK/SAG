<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="SAG.View.Pacientes.RegistrarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <!-- CSS -->
    <link href="../../css/stylePaciente.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.8.2/angular.min.js"></script>


    <link href="../../css/stylePaciente.css" rel="stylesheet" />
    <title>Registrar Paciente</title>
</head>
<body>
    <div class="container">
        <header>Registrar nuevo Paciente</header>

        <form action="#">
            <div class="form first">
                <div class="details personal">
                    <span class="title">Informacion del Paciente</span>

                    <div class="fields">
                        <div class="input-field">
                            <label>Nombres</label>
                            <input type="text" id="txtNombres" placeholder="Primeros nombres" required>
                        </div>
                        <div class="input-field">
                            <label>Apellido Paterno</label>
                            <input type="text" id="txtApellidoPaterno" placeholder="Apellido Paterno" required>
                        </div>
                        <div class="input-field">
                            <label>Apellido Materno</label>
                            <input type="text" id="txtApellidoMaterno" placeholder="Apellido Materno" required>
                        </div>
                        <div class="input-field">
                            <label>CURP</label>
                            <input type="text" id="txtCURP" placeholder="CURP" required>
                        </div>
                        <div class="input-field">
                            <label>Fecha de Nacimiento</label>
                            <input type="date" id="txtFechaNacimiento" placeholder="Fecha de Nacimiento" required>
                        </div>
                        <div class="input-field">
                            <label>Sexo</label>
                            <input type="text" id="txtSexo" placeholder="Sexo de nacimiento" required>
                        </div>
                        <div class="input-field">
                            <label>Entidad de Nacimiento</label>
                            <input type="text" placeholder="Ciudad donde nacio" required>
                        </div>
                        <div class="input-field">
                            <label>Afiliacion</label>
                            <input type="text" placeholder="Afiliacion" required>
                        </div>
                        <div class="input-field">
                            <label>Numero de afiliacion</label>
                            <input type="number" placeholder="Num Afiliacion" required>
                        </div>

                    </div>
                </div>

                <div class="details ID">
                    <span class="title">Direccion del Paciente</span>

                    <div class="fields">
                        <div class="input-field">
                            <label>Direccion</label>
                            <input type="text" placeholder="Direccion" required>
                        </div>
                        <div class="input-field">
                            <label>Numero exterior</label>
                            <input type="number" placeholder="Numero exterior" required>
                        </div>
                        <div class="input-field">
                            <label>Numero interior</label>
                            <input type="number" placeholder="Numero interior" required>
                        </div>
                        <div class="input-field">
                            <label>Colonia</label>
                            <input type="text" placeholder="Colonia" required>
                        </div>
                        <div class="input-field">
                            <label>Codigo Postal</label>
                            <input type="number" placeholder="CP" required>
                        </div>
                        <div class="input-field">
                            <label>Municipio</label>
                            <input type="text" placeholder="Municipio" required>
                        </div>
                        <div class="input-field">
                            <label>Estado</label>
                            <input type="text" placeholder="Estado" required>
                        </div>
                        <div class="input-field">
                            <label>Pais</label>
                            <input type="text" placeholder="Pais" required>
                        </div>
                        <div class="input-field">
                            <label>Telefono Trabajo</label>
                            <input type="number" placeholder="Tel Trabajo" required>
                        </div>
                        <div class="input-field">
                            <label>Telefono Casa</label>
                            <input type="number" placeholder="Tel Casa" required>
                        </div>
                        <div class="input-field">
                            <label>Telefono Celular</label>
                            <input type="number" placeholder="Tel Celular" required>
                        </div>
                        <div class="input-field">
                            <label>Correo electronico</label>
                            <input type="text" placeholder="Email" required>
                        </div>
                        <div class="input-field">
                            <label>Ocupacion</label>
                            <input type="text" placeholder="Ocupacion del Paciente" required>
                        </div>

                    </div>

                    


                </div>

                <div class="details responsable">
                    <span class="title">Informacion del Responsable del Paciente</span>

                    <div class="fields">
                        <div class="input-field">
                            <label>Nombres</label>
                            <input type="text" placeholder="Nombres del responsable" required>
                        </div>
                        <div class="input-field">
                            <label>Apellido Paterno</label>
                            <input type="text" placeholder="Apellido paterno del responsable" required>
                        </div>
                        <div class="input-field">
                            <label>Apellido Materno</label>
                            <input type="text" placeholder="Apellido Materno del responsable" required>
                        </div>
                        <div class="input-field">
                            <label>Parentesco</label>
                            <input type="text" placeholder="Parentesco con el Paciente" required>
                        </div>
                        <div class="input-field">
                            <label>Domicilio</label>
                            <input type="text" placeholder="Domicilio del responsable" required>
                        </div>
                        <div class="input-field">
                            <label>Telefono</label>
                            <input type="number" placeholder="Telefono del responsable" required>
                        </div>
                        
                        <button class="nextBtn" OnClick="btnSiguiente_Click">
                            <span class="btnText">Siguiente</span>
                            <i class="uil uil-navigator"></i>
                        </button>
                    </div>
                </div>

                

            </div>
        </form>
            
                
    </div>


</body>
</html>
