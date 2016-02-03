<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ninja.aspx.cs" Inherits="ProjectNinja.Ninja" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="Scripts/jquery-1.10.2.min.js" type="text/javascript"></script>
        <script type ="text/javascript">
            function ShowName() {
               // alert("start");

                $.ajax({
                    type: "POST",
                    url: "Ninja.aspx/GetName",
                    data: JSON.stringify({name: 'Ricom'}),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    }
                    
                });

            }
            function OnSuccess(response) {
                alert(response.d);
            }
            function TestRico() {
                alert("OK");
            }

        </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="AspButton" Text="Button" class="btn btn-primary btn-lg" />

<input id="btnGetTime" type="button" value="Show Current Time" 
    onclick = "ShowName()" />
        
    </div>


       
    </form>
</body>
</html>
