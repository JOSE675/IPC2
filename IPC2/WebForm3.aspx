<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="IPC2.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Estilos/Tablero.css" rel="stylesheet" />
    <style type="text/css">
        .cuadros {
            height: 76px;
        }
    </style>
</head>
<body style="background-image:url(IMG/tab.jpg); background-size: 1440px 700px; background-repeat:no-repeat">
    <form id="form1" runat="server">
        <div id="Principal">

        
        <div id="informacion">
            <div style="width: 112px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Guardar partida" Width="97px" />
                <asp:Button ID="Button2" runat="server" Text="Ganar" OnClick="Button2_Click" />
                <asp:Button ID="Button3" runat="server" Text="Perder" OnClick="Button3_Click" />
                <asp:Label ID="Jugador1" runat="server" Text="Label"></asp:Label>
        </div>
        </div>
            <div id="Tablero">
        <div class="cuadros flotar" id="A1">

            <asp:Button ID="a1" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="a1_Click" />

        </div>

        <div class="cuadros flotar" id="B1">

            <asp:Button ID="b1" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="b1_Click" />

        </div>

        <div class="cuadros flotar" id="C1">

            <asp:Button ID="c1" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="c1_Click" />

        </div>

        <div class="cuadros flotar" id="D1">

            <asp:Button ID="d1" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="d1_Click" />

        </div>

        <div class="cuadros flotar" id="E1">

            <asp:Button ID="e1" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="e1_Click" />

        </div>

        <div class="cuadros flotar" id="F1">

            <asp:Button ID="f1" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="f1_Click" />

        </div>

        <div class="cuadros flotar" id="G1">

            <asp:Button ID="g1" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="g1_Click" />

        </div>

        <div class="cuadros flotar" id="H1">

            <asp:Button ID="h1" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="h1_Click" />

        </div>

        <div class="cuadros flotar" id="A2">

            <asp:Button ID="a2" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="a2_Click" />

        </div>

        <div class="cuadros flotar" id="B2">

            <asp:Button ID="b2" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="b2_Click" />

        </div>

        <div class="cuadros flotar" id="C2">

            <asp:Button ID="c2" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="c2_Click" />

        </div>

        <div class="cuadros flotar" id="D2">

            <asp:Button ID="d2" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="d2_Click" />

        </div>

        <div class="cuadros flotar" id="E2">

            <asp:Button ID="e2" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="e2_Click" />

        </div>

        <div class="cuadros flotar" id="F2">

            <asp:Button ID="f2" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="f2_Click" />

        </div>

        <div class="cuadros flotar" id="G2">

            <asp:Button ID="g2" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="g2_Click" />

        </div>

        <div class="cuadros flotar" id="H2">

            <asp:Button ID="h2" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="h2_Click" />

        </div>

        <div class="cuadros flotar" id="A3">

            <asp:Button ID="a3" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="a3_Click" />

        </div>

        <div class="cuadros flotar" id="B3">

            <asp:Button ID="b3" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="b3_Click" />

        </div>

        <div class="cuadros flotar" id="C3">

            <asp:Button ID="c3" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="c3_Click" />

        </div>

        <div class="cuadros flotar" id="D3">

            <asp:Button ID="d3" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="d3_Click" />

        </div>

        <div class="cuadros flotar" id="E3">

            <asp:Button ID="e3" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="e3_Click" />

        </div>

        <div class="cuadros flotar" id="F3">

            <asp:Button ID="f3" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="f3_Click" />

        </div>  

        <div class="cuadros flotar" id="G3">

            <asp:Button ID="g3" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="g3_Click" />

        </div>

        <div class="cuadros flotar" id="H3">

            <asp:Button ID="h3" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="h3_Click" />

        </div>

        <div class="cuadros flotar" id="A4">

            <asp:Button ID="a4" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="a4_Click" />

        </div>

        <div class="cuadros flotar" id="B4">

            <asp:Button ID="b4" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="b4_Click" />

        </div>

        <div class="cuadros flotar" id="C4">

            <asp:Button ID="c4" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="c4_Click" />

        </div>

        <div class="cuadros flotar" id="D4">

            <asp:Button ID="d4" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="d4_Click" />

        </div>

        <div class="cuadros flotar" id="E4">

            <asp:Button ID="e4" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="e4_Click" />

        </div>

        <div class="cuadros flotar" id="F4">

            <asp:Button ID="f4" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="f4_Click" />

        </div>

        <div class="cuadros flotar" id="G4">

            <asp:Button ID="g4" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="g4_Click" />

        </div>

        <div class="cuadros flotar" id="H4">

            <asp:Button ID="h4" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="h4_Click" />

        </div>

        <div class="cuadros flotar" id="A5">

            <asp:Button ID="a5" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="a5_Click" />

        </div>

        <div class="cuadros flotar" id="B5">

            <asp:Button ID="b5" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="b5_Click" />

        </div>

        <div class="cuadros flotar" id="C5">

            <asp:Button ID="c5" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="c5_Click" />

        </div>

        <div class="cuadros flotar" id="D5">

            <asp:Button ID="d5" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="d5_Click" />

        </div>

        <div class="cuadros flotar" id="E5">

            <asp:Button ID="e5" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="e5_Click" />

        </div>

        <div class="cuadros flotar" id="F5">

            <asp:Button ID="f5" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="f5_Click" />

        </div>

        <div class="cuadros flotar" id="G5">

            <asp:Button ID="g5" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="g5_Click" />

        </div>

        <div class="cuadros flotar" id="H5">

            <asp:Button ID="h5" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="h5_Click" />

        </div>

        <div class="cuadros flotar" id="A6">

            <asp:Button ID="a6" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="a6_Click" />

        </div>

        <div class="cuadros flotar" id="B6">

            <asp:Button ID="b6" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="b6_Click" />

        </div>

        <div class="cuadros flotar" id="C6">

            <asp:Button ID="c6" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="c6_Click" />

        </div>

        <div class="cuadros flotar" id="D6">

            <asp:Button ID="d6" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="d6_Click" />

        </div>

        <div class="cuadros flotar" id="E6">

            <asp:Button ID="e6" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="e6_Click" />

        </div>

        <div class="cuadros flotar" id="F6">

            <asp:Button ID="f6" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="f6_Click" />

        </div>

        <div class="cuadros flotar" id="G6">

            <asp:Button ID="g6" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="g6_Click" />

        </div>

        <div class="cuadros flotar" id="H6">

            <asp:Button ID="h6" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="h6_Click" />

        </div>

        <div class="cuadros flotar" id="A7">

            <asp:Button ID="a7" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="a7_Click" />

        </div>

        <div class="cuadros flotar" id="B7">

            <asp:Button ID="b7" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="b7_Click" />

        </div>

        <div class="cuadros flotar" id="C7">

            <asp:Button ID="c7" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="c7_Click" />

        </div>

        <div class="cuadros flotar" id="D7">

            <asp:Button ID="d7" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="d7_Click" />

        </div>

        <div class="cuadros flotar" id="E7">

            <asp:Button ID="e7" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="e7_Click" />

        </div>
        
        <div class="cuadros flotar" id="F7">

            <asp:Button ID="f7" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="f7_Click" />

        </div>

        <div class="cuadros flotar" id="G7">

            <asp:Button ID="g7" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="g7_Click" />

        </div>

        <div class="cuadros flotar" id="H7">

            <asp:Button ID="h7" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="h7_Click" />

        </div>

        <div class="cuadros flotar" id="A8">

            <asp:Button ID="a8" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="a8_Click" />

        </div>

        <div class="cuadros flotar" id="B8">

            <asp:Button ID="b8" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="b8_Click" />

        </div>

        <div class="cuadros flotar" id="C8">

            <asp:Button ID="c8" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="c8_Click" />

        </div>

        <div class="cuadros flotar" id="D8">

            <asp:Button ID="d8" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="d8_Click" />

        </div>

        <div class="cuadros flotar" id="E8">

            <asp:Button ID="e8" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="e8_Click" />

        </div>

        <div class="cuadros flotar" id="F8">

            <asp:Button ID="f8" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="f8_Click" />

        </div>

        <div class="cuadros flotar" id="G8">

            <asp:Button ID="g8" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="g8_Click" />

        </div>

        <div class="cuadros flotar" id="H8">

            <asp:Button ID="h8" CssClass="ficha" runat="server" BackColor="ForestGreen" Height="50px" Width="50px" OnClick="h8_Click" />

        </div>
                </div>
            </div>


    </form>
</body>
</html>
