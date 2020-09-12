<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IPC2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Estilos/Login.css" rel="stylesheet" />
    <title></title>
</head>
<body style="background-image:url(IMG/Fond.jpg); background-size:1440px 700px; background-repeat:no-repeat; ">
    <form id="form1" runat="server">
        <div id="login">
            <header>Iniciar sesion</header>
            
            
            
            <asp:Label ID="nom" runat="server" Text="Usuario"></asp:Label>
            <br />
            <asp:TextBox ID="usuario" CssClass="lo" runat="server" Width="145px" ></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Contraseña"></asp:Label>
            <br />
            <asp:TextBox ID="Pass" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Iniciar sesion" BackColor="#FF6600" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
