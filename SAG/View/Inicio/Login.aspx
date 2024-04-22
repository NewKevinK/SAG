<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SAG.View.Inicio.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <!-- ===== Iconscout CSS ===== -->
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.0/css/line.css"/>
    <!-- ===== CSS ===== -->
    <link href="../../css/styleLogin.css" rel="stylesheet" />
         
    <title>Login & Registration Form</title> 

    
</head>
<body>

    <div class="container">
        <div class="forms">
            <div class="form login">
                <span class="title">Inicio de Sesion</span>
                <form action="#">
                    <div class="input-field">
                        <input type="text" placeholder="Ingresa el correo" required>
                        <i class="uil uil-envelope icon"></i>
                    </div>
                    <div class="input-field">
                        <input type="password" class="password" placeholder="Ingresa tu contraseña" required>
                        <i class="uil uil-lock icon"></i>
                        <i class="uil uil-eye-slash showHidePw"></i>
                    </div>
                    <div class="checkbox-text">
                        <div class="checkbox-content">
                            <input type="checkbox" id="logCheck">
                            <label for="logCheck" class="text">Recordar</label>
                        </div>
                        
                        <a href="#" class="text">Soporte</a>
                    </div>
                    <div class="input-field button">
                        <input type="button" value="Login">
                    </div>
                </form>
                
            </div>
            
        </div>
    </div>
    
</body>
</html>
