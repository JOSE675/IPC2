<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="IPC2.Historial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Estilos/Historial.css" rel="stylesheet" />
    <title></title>
</head>
<body body style="background-image:url(IMG/Fond.jpg); background-size:1440px 700px; background-repeat:no-repeat; ">
    <form id="form1" runat="server">
        <div id="encerrar">
            <asp:GridView ID="Datos" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
