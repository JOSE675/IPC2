<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="IPC2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Estilos/Principal.css" rel="stylesheet" type="text/css" />
    <title></title>
    
    <style type="text/css">
        .form1 {
            height: 199px;
            width: 999px;
        }
    </style>
    
</head>
<body body style="background-image:url(IMG/Fond.jpg); background-size:1440px 700px; background-repeat:no-repeat; ">
    
    <div id="general">
         <form class="form1" runat="server">
        <div id="Modos">
        <header class="Title">Modos de juego</header>
       
            <asp:Button CssClass="BotonesP" ID="Single" runat="server" Text="Partida JCJ" OnClick="Single_Click"  />
            <br />
            <asp:Button CssClass="BotonesP" ID="SingleM" runat="server" Text="Partida JCM" OnClick="SingleM_Click"  />
            <br />
            <asp:Button CssClass="BotonesP" ID="Multi" runat="server" Text="Multijugador"  />
            <br />
            <asp:Button CssClass="BotonesP" ID="Inverso" runat="server" OnClick="Button4_Click" Text="Button" />
            <br />
            <asp:Button CssClass="BotonesP" ID="Tor" runat="server" Text="Torneos" />
            </div>
    <div id="Registro">
        <header class="Title">Usuario</header>
        
            <asp:Button CssClass="BotonesP" ID="Button1" runat="server" Text="Registrarse" OnClick="Button1_Click1" />
            <br />
            <asp:Button CssClass="BotonesP" ID="Button2" runat="server" Text="Iniciar sesion" OnClick="Button2_Click"  />
            <br />
    </div>

    <div id="Partidas">
        <header class="Title">Partidas</header>
        
            <asp:Button CssClass="BotonesP" ID="Button3" runat="server" Text="Cargar Partida" OnClick="Button3_Click" />
            <br />
            
            <asp:Button CssClass="BotonesP" runat="server" Text="Historial" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>
    
    <div id="Ayuda">
        <header class="Title">Ayuda</header>
        <asp:Button CssClass="BotonesP" runat="server" Text="Reglas del juego" />

    </div>

    

        </form>
    </div>

   
</body>
</html>
