<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Credentials.aspx.cs" Inherits="School_Project.Student_Credentials" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Your Credentials</title>
    <style>
        .body
        {
            background-color:white;
            color:black;
        }
        .user_creds
        {
            height:400px;
            width:350px;
            border:dashed;
            border-radius:30px;
            border-color:lawngreen;
            align-content:center;
        }
    </style>
</head>
<body class="body">
    <form id="form1" runat="server">
       <center>
            <div class="user_creds">
                <h2>Your Login Credentials</h2>
                <h5>Your account has been successfully created</h5>
                <asp:Label ID="Label1" runat="server" Text="Your User ID :"></asp:Label>
                <asp:Label ID="lbl_usrnm" runat="server" ></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server"  Text="Your Password :"></asp:Label>
                <asp:Label ID="lbl_pasrd" runat="server"></asp:Label>
                <h5>Thank you for Registering!</h5>
            </div>
            Go to <a href="Login_Page.aspx">Login</a>
     </center>
    </form>
</body>
</html>
