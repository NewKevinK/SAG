<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarDetallesPaciente.aspx.cs" Inherits="SAG.View.Pacientes.ConsultarDetallesPaciente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="../../css/styleDetallesPaciente.css" rel="stylesheet" />
    
    <title>Consultar Detalles del Paciente</title>

<body>
    <div class="container">
        <header>Consultar detalles del paciente</header>

        <form action="#">
            <div class="form first">
                <div class="details personal">
                    <div class="fields">

                        <div class="input-field">
                            <label>Tipo de Atencion: </label>
                            <input type="text" placeholder="" readonly required>
                        </div>
                        <div class="input-field">
                            <label>CURP: </label>
                            <input type="text" placeholder="" required>
                        </div>
                        <div class="input-field">
                            <label>Apellido Paterno: </label>
                            <input type="text" placeholder="" required>
                            
                        </div>
                        <div class="input-field">
                            <label>Numero de Expediente: </label>
                            <input type="text" placeholder="e" required>
                        </div>
                        <div class="input-field">
                            <label>Apellido Materno: </label>
                            <label>test</label>
                        </div>
                        <div class="input-field">
                            <label>Fecha de Nacimiento:</label>
                            <input type="date" placeholder="Enter your name" readonly >
                        </div>
                        <div class="input-field">
                            <label>Nombres: </label>
                            <input type="text" value="car99" readonly>
                        </div>
                        <div class="input-field">
                            <label>Edad: </label>
                            <input type="text"  required>
                        </div>
                        
                        <div class="input-field">
                            <label>Nacionalidad: </label>
                            <input type="text"  required>
                        </div>
                        <div class="input-field">
                            <label>Sexo: </label>
                            <input type="text" readonly required>
                        </div>

                    </div>




                </div>
                

                
            </div>

            

        </form>

        <div class="container">
        <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
            <li class="nav-item" role="presentation">
                <button class="nav-link active" id="pills-home-tab" data-bs-toggle="pill" data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home" aria-selected="true">Ver Informacion del Paciente</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="pills-profile-tab" data-bs-toggle="pill" data-bs-target="#pills-profile" type="button" role="tab" aria-controls="pills-profile" aria-selected="false">Ver Diagnosticos</button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="pills-contact-tab" data-bs-toggle="pill" data-bs-target="#pills-contact" type="button" role="tab" aria-controls="pills-contact" aria-selected="false">Ver Alergias</button>
            </li>
        </ul>
        <div class="tab-content" id="pills-tabContent">
            <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                Hola
                //Aqui va una tabla a la izquierda solo muestra los servicios del paciente y del lado derecho se muestran informacion general del paciente (Estado de salud, fecha de ingreso, cama, area, diagnostico )
                <div class="row">
                    <div class="col-4">
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th scope="col">Servicio</th>
                                    <th scope="col">Fecha</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>Urgencias</td>
                                    <td>12/12/2021</td>
                                </tr>
                                <tr>
                                    <td>Urgencias</td>
                                    <td>12/12/2021</td>
                                </tr>
                                <tr>
                                    <td>Urgencias</td>
                                    <td>12/12/2021</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="row g-3">
                        <div class="input-field">
                            <label>Estado de Salud: col-6 </label>
                            <input type="text" value="PQX DE LAV MEC MUSLO IQZUIERDA" readonly>
                        </div>
                        <div class="input-field">
                            <label>Fecha de Ingreso: </label>
                            <input type="text" placeholder="Enter your name" required>
                        </div>
                        <div class="input-field">
                            <label>Cama: </label>
                            <input type="text" placeholder="Enter your name" required>
                        </div>
                        <div class="input-field">
                            <label>Area: </label>
                            <input type="text" placeholder="Enter your name" required>
                        </div>
                        <div class="input-field">
                            <label>Diagnostico: </label>
                            <input type="text" placeholder="Enter your name" required>
                        </div>
                        <div class="input-field">
                            <label>Tipo de Seguro: </label>
                            <input type="text" placeholder="Enter your name" required>
                        </div>
                        <div class="input-field">
                            <label>Folio: </label>
                            <input type="text" placeholder="Enter your name" required>
                        </div>
                        <div class="input-field">
                            <label>Estado del Paciente: </label>
                            <input type="text" placeholder="Enter your name" required>
                        </div>
                        <div class="input-field">
                            <label>Fecha de Alta: </label>
                            <input type="text" placeholder="Enter your name" required>
                        </div>


                    </div>
                </div>



            </div>
            <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab">...</div>
            <div class="tab-pane fade" id="pills-contact" role="tabpanel" aria-labelledby="pills-contact-tab">.x
                s
                ss

                s
                s
                s
                s
                s
                <div class="input-field">
                    <label>Full Name</label>
                    <input type="text" placeholder="Enter your name" required>
                </div>

            </div>
        </div>
        </div>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    </div>
</body>

</asp:Content>
