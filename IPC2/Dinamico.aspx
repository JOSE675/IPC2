<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dinamico.aspx.cs" Inherits="IPC2.Dinamico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Xtreme.css" rel="stylesheet" />
    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body id="cuerpo">
    <form id="form1" runat="server" >
        <div id="general">
            <asp:Label ID="lblcantidad" CssClass="texto" runat="server" Text="Ingrese cantidad de filas y columnas"></asp:Label>
            <br />
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtCantidad2" runat="server"></asp:TextBox>
            <asp:Button ID="btnProceso" runat="server" Text="Button" onclick="btnProceso_Click" />
            <br />
            <h1 class="texto"> Colores Jugador 1 </h1>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" CssClass="lista">
            <asp:ListItem Text="Rojo" Value="Red"></asp:ListItem>
                <asp:ListItem Text="Amarillo" Value="Yellow"></asp:ListItem>
                <asp:ListItem Text="Azul" Value="Blue"></asp:ListItem>
                <asp:ListItem Text="Anaranjado" Value="Orange"></asp:ListItem>
                 <asp:ListItem Text="Verde" Value="Green"></asp:ListItem>
            </asp:CheckBoxList>

            <h1 class="texto"> Colores jugador 2 </h1>
            <asp:CheckBoxList ID="Pos" runat="server" RepeatDirection="Horizontal" CssClass="lista">
                
                <asp:ListItem Text="Violeta" Value="Violet"></asp:ListItem>
                <asp:ListItem Text="Blanco" Value="White"></asp:ListItem>
                <asp:ListItem Text="Negro" Value="Black"></asp:ListItem>
                <asp:ListItem Text="Celeste" Value="lightblue"></asp:ListItem>
                <asp:ListItem Text="Gris" Value="Gray"></asp:ListItem>

            </asp:CheckBoxList>
            <br />
            <asp:FileUpload ID="carga" runat="server" ForeColor="Yellow" />
             <asp:Button ID="Button3" runat="server" Text="Cargar Partida" OnClick="Button3_Click" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Apertura personalizada" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Modo inverso" OnClick="Button2_Click" />
            
        </div>
        <div>
            <h1 id="titulo" class="texto">OTHELLO XTREME</h1>
        </div>
    </form>
</body>
</html>
