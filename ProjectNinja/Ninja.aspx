<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ninja.aspx.cs" Inherits="ProjectNinja.Ninja" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="Scripts/Ninja.js" type="text/javascript"></script> 
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="AspButton" Text="Button" class="btn btn-primary btn-lg" />

<input id="btnGetTime" type="button" value="Show Current Time" 
    onclick = "NinjaFunctions.InsertData2()" />
        
        <asp:Button ID="Button2" runat="server" OnClick="DBConnectionTest" Text="Test" />
        
    </div>


       
    </form>
</body>
</html>
