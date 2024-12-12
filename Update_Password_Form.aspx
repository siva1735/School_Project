<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update_Password_Form.aspx.cs" Inherits="School_Project.Update_Password_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Password</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0 auto;
            width: 50%;
            padding: 20px;
        }
        .form-container {
            border: 1px solid #ccc;
            padding: 20px;
            border-radius: 10px;
            background-color: #f9f9f9;
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
        }
        input[type="text"]:disabled {
            background-color: #e9e9e9;
        }
        .btn-container {
            text-align: center;
            margin-top: 20px;
        }
        input[type="submit"], input[type="reset"] {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        input[type="submit"] {
            background-color: #4CAF50;
            color: white;
        }
        input[type="reset"] {
            background-color: #f44336;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Update Password</h2>

            <!-- Username -->
            <div class="form-group">
                <label for="txtUsername">Username</label>
                <input type="text" id="txtUsername" runat="server" disabled="disabled" />
            </div>

            <!-- New Password -->
            <div class="form-group">
                <label for="txtNewPassword">New Password</label>
                <input type="password" id="txtNewPassword" runat="server" required />
            </div>

            <!-- Confirm Password -->
            <div class="form-group">
                <label for="txtConfirmPassword">Confirm Password</label>
                <input type="password" id="txtConfirmPassword" runat="server" required />
            </div>
            <br />
            <br />
            <!-- Submit and Reset Buttons -->
            <div class="btn-container">
                <input type="submit" value="Update Password" id="btnUpdatePassword" runat="server" OnServerClick="Button1_Click" />
                <input type="reset" value="Clear" />
            </div>

            <br />
            <center>
                <asp:Label ID="lblSuccessMsg" ForeColor="Green" runat="server"></asp:Label>
                <asp:Label ID="lblErrorMsg" ForeColor="Red" runat="server"></asp:Label>
                <br />
                Go To <a href="Login_Page.aspx">Login</a>
            </center>
              
        </div>
    </form>
</body>
</html>
