<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Seleccion de colores.aspx.cs" Inherits="IPC2.Seleccion_de_colores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="SeleccionColor.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
</head>
<body style="background-image:url(IMG/Fond.jpg); background-size:1440px 700px; background-repeat:no-repeat; ">
    
    <form id="form1" runat="server">
        <div id="principal">
            <h1> Colores Jugador 1 </h1>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Text="Amarillo" Value="Yellow"></asp:ListItem>
                <asp:ListItem Text="Blanco" Value="White"></asp:ListItem>
                <asp:ListItem Text="Rojo" Value="Red"></asp:ListItem>
                <asp:ListItem Text="Negro" Value="Black"></asp:ListItem>
            </asp:CheckBoxList>

            <h1> Posiciones Jugador 1 </h1>
            <asp:CheckBoxList ID="Pos" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="D4" Value="d4"></asp:ListItem>
                <asp:ListItem Text="D5" Value="d5"></asp:ListItem>
                <asp:ListItem Text="E4" Value="e4"></asp:ListItem>
                <asp:ListItem Text="E5" Value="e5"></asp:ListItem>
            </asp:CheckBoxList>

            <asp:Button ID="Button1" runat="server" Text="Comenzar!" OnClick="Button1_Click" />
        </div>
    </form>
        
</body>
</html>
