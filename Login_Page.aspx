<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Page.aspx.cs" Inherits="School_Project.Login_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .login-container {
            background-color: #fff;
            padding: 20px 30px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 400px;
        }

        .login-container h2 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }

        .login-container label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            color: #555;
        }

        .login-container input[type="text"],
        .login-container input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .login-container input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: #4CAF50;
            border: none;
            color: white;
            font-size: 16px;
            border-radius: 5px;
            cursor: pointer;
        }

        .login-container input[type="submit"]:hover {
            background-color: #45a049;
        }

        .error-message {
            color: red;
            font-size: 14px;
            text-align: center;
            margin-top: -10px;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Student Login</h2>
            <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
            <label for="txtUserID">User ID</label>
            <asp:TextBox ID="txt_UserID" runat="server" placeholder="Enter your User ID"></asp:TextBox>

            <label for="txtPassword">Password</label>
            <asp:TextBox ID="txt_Password" runat="server" TextMode="Password" placeholder="Enter your Password"></asp:TextBox>
             <asp:Label ID="lbl_msg" ForeColor="red" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <br />
            <center>
                New user?<a href="Registration_Form.aspx">Sign Up</a>
            </center>
        </div>
    </form>
</body>
</html>
