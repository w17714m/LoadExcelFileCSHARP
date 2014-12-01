<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="uploadFile_ExcelABD._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>


</head>
<body>
    <form id="form1" enctype="multipart/form-data" method="post" runat="server">
    <div>
    <asp:FileUpload ID="file1" runat ="server" />
    <br />
    <br />
    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" onclick="btnEnviar_Click" />
    <br />
    <asp:Label ID="Resultado" style="color:Red" Text = "" runat="server" ></asp:Label>
    <br />
    
    </div>
    </form>
</body>
</html>
