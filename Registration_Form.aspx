<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration_Form.aspx.cs" Inherits="School_Project.Registration_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Registration Form</title>
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
        input[type="text"], input[type="email"], input[type="date"], select {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
        }
        textarea {
            width: 100%;
            height: 60px;
            padding: 8px;
            box-sizing: border-box;
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
            <h2>Student Registration Form</h2>
            
            <!-- Full Name -->
            <div class="form-group">
                <label for="txtFullName">Full Name</label>
                <input type="text" id="txtFullName" runat="server" required />
            </div>
            
            <!-- Date of Birth -->
            <div class="form-group">
                <label for="txtDateOfBirth">Date of Birth</label>
                <input type="date" id="txtDateOfBirth" runat="server" required />
            </div>
            
            <!-- Gender -->
            <div class="form-group">
                <label for="ddlGender">Gender</label>
                <select id="ddlGender" runat="server" required>
                    <option value="">Select Gender</option>
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                    <option value="Other">Other</option>
                </select>
            </div>
            
            <!-- Class -->
            <div class="form-group">
                <label for="txtClass">Class</label>
                <input type="text" id="txtClass" runat="server" required />
            </div>
            
            <!-- Address -->
            <div class="form-group">
                <label for="txtAddress">Address</label>
                <textarea id="txtAddress" runat="server" required></textarea>
            </div>
            
            <!-- Phone Number -->
            <div class="form-group">
                <label for="txtPhoneNumber">Phone Number</label>
                <input type="text" id="txtPhoneNumber" runat="server" required maxlength="15" />
            </div>
            
            <!-- Email -->
            <div class="form-group">
                <label for="txtEmail">Email</label>
                <input type="email" id="txtEmail" runat="server" required />
            </div>
            
            <!-- Registration Date (Read-Only) -->
            <div class="form-group">
                <label for="txtRegistrationDate">Registration Date</label>
              <input type="text" id="txtRegistrationDate" runat="server" readonly />

            </div>
            
            <!-- Submit and Reset Buttons -->
           <div class="btn-container">
    <input type="submit" value="Register" id="btnSubmit" runat="server" OnServerClick="btnSubmit_ServerClick" />
    <input type="reset" value="Clear" />
</div>

        </div>
    </form>
</body>
</html>