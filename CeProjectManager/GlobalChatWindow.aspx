<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlobalChatWindow.aspx.cs" Inherits="CeProjectManager.GlobalChatWindow" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css"/>
</head>
<body>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/jquery.signalR-2.2.0.min.js"></script>
    <script src="signalr/hubs"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            //var _name = window.prompt("Please enter your name");
            $("#spnName").text('<%=name %>');  //_name);
            $('#txtMsg').val('');
            $('.chatbox').css('height', $(window).height() - 145);
            $('.container').css('width', $(window).width());

            var chatProxy = $.connection.chatHub;

            $.connection.hub.start().done(function () {
                $("#btnSend").click(function () {
                    var txt = document.getElementById("txtMsg").value;

                    if (txt != "") {
                        chatProxy.server.broadcastMessage($("#spnName").text(), $("#txtMsg").val());
                        $('#txtMsg').val('').focus();
                    }
                });
            });

            chatProxy.client.receiveMessage = function (msgFrom, msg) {
                $('#divChat').append('<li><strong>' + msgFrom + '<strong>:&nbsp;' + msg + '</li>');
                $('#divChat').scrollTop = $('#divChat').height;
            };
        });

    </script>

    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <a class="navbar-brand">Global Chat</a>
            </div>
        </div>
    </div>
    <div class="container chatbox" style="margin-top: 60px; margin-bottom: 30px;">
        <span id="spnName"></span>
        <div class="text-left" style="height: 100%; width: 100%; overflow-y: scroll;" id="divChat"></div>
    
    <footer style="margin-top: 10px">
        <div class="form-inline">
            <div class="form-group" style="width: 94%">
                <input type="text" class="form-control" style="width: 100%" id="txtMsg" placeholder="Type message here" onkeydown="if (event.keyCode == 13) document.getElementById('btnSend').click()"/>
            </div>
            <button type="button" class="btn btn-default" id="btnSend">Send</button>
        </div>
    </footer>
    </div>
</body>
</html>
