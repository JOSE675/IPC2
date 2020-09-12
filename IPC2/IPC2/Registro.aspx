<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="IPC2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="Estilos/RegistroE.css" rel="stylesheet" type="text/css">
    <title>Formulario de Registro</title>
</head>
    
<body>
    <header>
        <asp:Label ID="Title" runat="server" Text="Formulario de Registro"></asp:Label></header>
    <br />
        <br />
    <div id="divCenter">
        
    
    <form id="form1" runat="server">
        
        <fieldset class="Sep">
            <legend id="Datos2">Datos Personales</legend>
            <label id="Nombre">Nombre:</label>
            <label id="Apel">Apellido:</label>
            <br />
            <asp:TextBox ID="Nombre" runat="server"></asp:TextBox>
&nbsp;<asp:TextBox ID="Ape" runat="server"></asp:TextBox>
&nbsp;</fieldset>
        
        <br />
        <br />
        <fieldset class="Sep"> 
            <legend id="Datos2">Datos Obligatorios</legend>
            <label id="U">Usuario</label>
            <label id="P">Contraseña</label>
            <br />
            <asp:TextBox ID="Usi" runat="server"></asp:TextBox>
&nbsp;<asp:TextBox ID="Con" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;</fieldset>
        
        <br />

        <fieldset class="Sep"> 
            <legend id="Datos2">Fecha de Nacimiento</legend>
            
            <br />
            <asp:TextBox ID="Nac" runat="server" TextMode="Date"></asp:TextBox>
&nbsp;</fieldset>
        
       
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <br />
        <fieldset class="Sep">
            <legend id="Datos2">Correo y Pais</legend>
            <label id="Cor">Correo Electronico</label>
            <label id="Pai">Pais</label>
            <br />
            <asp:TextBox ID="C" runat="server" TextMode="Email"></asp:TextBox>
&nbsp;<asp:DropDownList ID="Pa" runat="server">
            </asp:DropDownList>
&nbsp;</fieldset class="Sep">
        <br />
        <br />
        <div id="Su" >
            <asp:Button ID="Bo" runat="server" Text="Enviar formulario" OnClick="Bo_Click1" />
&nbsp;</div>
       
        

       
        
        
    </form>
    </div>
    
</body>
</html>
