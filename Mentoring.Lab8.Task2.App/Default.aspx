<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mentoring.Lab8.Task2.App.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mentoring.Lab8.Aliaksandr_Liashkevich</title>
</head>
<style>
#form {
    display: flex;
    flex-direction: column;
    align-items: center;
}

#submit {
    border: 1px solid;
    border-radius: 20px;
    height: 40px;
}

.title {
    text-align: center;
}

.label {
    background-color: #2196F3;
    color: white;
    font-size: 20px;
    width: 500px;
    text-align: center;
}

.input {
    width: 500px;
    margin: 10px;
    font-size: 18px;
}
</style>
<body>
    <h1 class="title">Mentoring - Lab 8. Task 2.</h1>
    <form id="form" name="form" runat="server" method="post">
        <span class="label">
            Customer id:
        </span>
        <input class="input" type="text" name="customerId">

        <span class="label">
            Date from:
        </span>
        <input class="input" type="date" name="dateFrom">


        <span class="label">
            Date to:
        </span>
        <input class="input" type="date" name="dateTo">
        
        <span class="label">
            Skip:
        </span>
        <input class="input" type="number" name="skip" min="0">

        <span class="label">
            Take:
        </span>
        <input class="input" type="number" name="take" min="0">
        
        <span class="label">
            Document type:
        </span>
        <select class="input" name="acceptType">
            <option value="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet">Excel</option>
            <option value="text/xml">Xml</option>
        </select>
            
        <input id="submit" type="button" class="input" onclick="submitform()" value="Take report">
    </form>

<script src="/download.js" type="text/javascript"></script>
<script type="text/javascript">
    function uuidv4() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }

    function submitform() {
        var form = document.forms["form"];
        var formValues = {
            customerId: form["customerId"].value,
            dateFrom: form["dateFrom"].value,
            dateTo: form["dateTo"].value,
            skip: form["skip"].value,
            take: form["take"].value,
        };
        var acceptType = form["acceptType"].value;

        fetch('./ReporterHandler.ashx', {
                method: 'POST',
                headers: {
                    'Accept': acceptType,
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formValues)
            })
            .then((resp) => {
                return resp.blob();
            }).then((blob) => {
                download(blob, 'report_' + uuidv4());
            });
    }
</script>
</body>
</html>
