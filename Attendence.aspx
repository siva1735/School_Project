<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="School_Project.Attendance" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance Form</title>

    <!-- Include jQuery and jQuery UI -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>

    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
            padding: 0;
            background-color: #f4f4f4;
        }

        .container {
            max-width: 900px;
            margin: 0 auto;
            background: #fff;
            padding: 20px;
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            border: 1px solid #ddd;
        }

        h1 {
            text-align: center;
            color: #333;
            font-size: 24px;
        }

        .form-group-container {
            display: flex;
            justify-content: space-between;
            gap: 10px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            color: #333;
        }

        .datepicker-btn {
            background: url('Scripts/pngwing.com.png') no-repeat center center;
            background-size: cover;
            width: 30px;
            height: 30px;
            border: 1px solid #ccc;
            cursor: pointer;
            display: inline-block;
            vertical-align: middle;
        }

        .error {
            color: red;
            font-size: 14px;
            margin-top: 5px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            padding: 10px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
            color: #333;
        }

        tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        tr:hover {
            background-color: #f1f1f1;
        }

        .btn-submit {
            background-color: #4CAF50;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

        .btn-submit:hover {
            background-color: #45a049;
        }

        .label-container {
            margin-top: 15px;
        }

        .label-container span {
            font-weight: bold;
            display: inline-block;
            margin-right: 10px;
            color: #555;
        }

        .ui-datepicker {
            font-size: 0.8em;
            width: 180px;
            height: auto;
        }

        .ui-datepicker-header {
            font-size: 1em;
        }

        .ui-datepicker-calendar {
            width: 100%;
        }
    </style>

    <script>
        $(document).ready(function () {
            $(".datepicker-btn").click(function () {
                const hiddenFieldId = $(this).data("hidden");
                const labelId = $(this).data("label");

                $("#" + hiddenFieldId).datepicker({
                    dateFormat: "yy-mm-dd",
                    onSelect: function (dateText) {
                        $("#" + hiddenFieldId).val(dateText);
                        $("#" + labelId).text(dateText);
                    },
                    changeMonth: true,
                    changeYear: true,
                    showButtonPanel: true
                }).datepicker("show");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Student Attendance</h1>

            <!-- Date Range Selection Using Calendar Button -->
            <div class="form-group-container">
                <div class="form-group">
                    <label>Start Date:</label>
                    <asp:HiddenField ID="hdnStartDate" runat="server" />
                    <button type="button" class="datepicker-btn" data-hidden="hdnStartDate" data-label="lblStartDate"></button>
                    <asp:Label ID="lblStartDate" runat="server" ></asp:Label>
                </div>

                <div class="form-group">
                    <label>End Date:</label>
                    <asp:HiddenField ID="hdnEndDate" runat="server" />
                    <button type="button" class="datepicker-btn" data-hidden="hdnEndDate" data-label="lblEndDate"></button>
                    <asp:Label ID="lblEndDate" runat="server" ></asp:Label>
                </div>
            </div>

            <asp:Button ID="btnSubmit" runat="server" CssClass="btn-submit" Text="Fetch Attendance" OnClick="btnSubmit_Click" />

            <!-- Error Message -->
            <asp:Label ID="dateError" runat="server" CssClass="error"></asp:Label>

            <!-- Attendance Table -->
            <asp:Table ID="studentTable" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Text="Student ID" />
                    <asp:TableHeaderCell Text="Student Name" />
                    <asp:TableHeaderCell Text="Date" />
                    <asp:TableHeaderCell Text="Status" />
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>


