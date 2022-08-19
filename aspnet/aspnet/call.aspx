<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="call.aspx.cs" Inherits="aspnet.call" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Call</title>

     <style>
       
        li {
            display: block;
            font-size: 14px;
            border-bottom: 1px solid transparent;
        }

        li:hover {
            /*background-color: #ccc;*/
            color: green;
            cursor: pointer;
            border-bottom: 1px solid #b6ff00;
        }

        li:active {
            border-bottom: 1px solid #ff6a00;
        }
             
    </style>

    <script>
        var connectString = "Data Source=wnl;Initial Catalog=eldb;User ID=sa;Password=Sa12345@";
        
        function get_data() {
            
            $("#demo .content").remove();
            $('#demo').append('<div class="content" />');

            $('#demo .content').load('apps/master/division.html?v=101');
        }

        function add_record() {

        }

        function update_record() {

        }

        function delete_record() {

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                 <asp:ServiceReference Path="~/services/shares/mas.svc" />

            </Services>
        </asp:ScriptManager>
      <div>
        <ui>
            <Li onclick="get_data()"> Get Data</Li>
            <Li onclick="add_record()"> Add  Record </Li>
            <Li onclick="update_record()"> Update</Li>
            <Li onclick="delete_record()"> Delete </Li>
         
        </ui>
          
        <div id="demo">
            <div class="content">

            </div>
        </div>

          </div>
    </form>
</body>
</html>
