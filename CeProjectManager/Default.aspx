<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CeProjectManager._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2 ID="jumbotronHeader" runat="server"></h2> 
    </div>
    
    <!--<div class="row">
        
        <div class="col-sm-5" id="left">
            <div class="jumbotron">
                <p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p><p>Left contents</p>
            </div>
        </div>
        
        <div class="col-sm-5" id="right">
            <div class="jumbotron">
                <p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p><p>Right contents</p>
            </div>
        </div>
    </div>-->

    <div style="height: 800px">
        
        <asp:Panel ID="NewsPanel" runat="server" Height="39%" Width="49.9%" style="float: left; margin-bottom: 5px" BorderStyle="Dotted" BorderColor="#666699" BackColor="#AFB9BC" ScrollBars="Auto">
            <h4  style="margin-left: 10px">News</h4>
            <div ID="NewsContener" runat="server" class="col-lg-12">
            <!--<p class="text-justify">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur congue arcu at sapien pretium, vel tincidunt nisl imperdiet. Vivamus interdum elit a arcu accumsan, quis ultricies mi pretium. Sed ante turpis, vestibulum in lorem vel, vestibulum volutpat justo. Ut nulla urna, accumsan nec condimentum maximus, dictum eget enim. Nam dictum eros luctus elementum luctus. Morbi fermentum condimentum nulla, in malesuada odio dignissim id. Aenean lacus sapien, condimentum et arcu vitae, gravida commodo mi. Curabitur eleifend mauris eleifend urna varius, in suscipit ligula porta. Vestibulum molestie ac arcu quis scelerisque.
            </p>
            <p class="text-justify">
                Pellentesque quis fringilla ante. Etiam dapibus congue ipsum, dapibus porttitor mi hendrerit ut. Integer id ultricies nisi. Curabitur convallis auctor vehicula. Vestibulum sed metus accumsan, malesuada leo in, pretium leo. Vestibulum gravida quam quis metus cursus ultricies. Morbi molestie velit a scelerisque pellentesque. Morbi vel massa finibus, volutpat odio sed, sodales libero. Sed elementum enim lacus, eget mattis lorem venenatis nec. Donec quis metus dolor. Quisque vestibulum vel enim ac condimentum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Sed sit amet sagittis augue. Donec arcu nisi, tristique sit amet condimentum et, sollicitudin sed nisi. Vivamus a ante nunc. Aliquam ac vehicula magna.
            </p>
            <p class="text-justify">
                Phasellus et metus dictum, aliquam felis quis, lacinia ligula. Donec sapien tortor, rhoncus quis lorem et, eleifend iaculis quam. Ut vel tempus orci. Donec id facilisis orci. Sed commodo turpis at sapien vehicula bibendum. Sed convallis tellus consectetur viverra mattis. Donec non mattis sem, a tincidunt mi. Vivamus dapibus vehicula commodo. Pellentesque rutrum arcu sed sapien convallis, ac euismod metus auctor. Sed tincidunt diam quis luctus mollis. Cras condimentum nec erat et aliquam. Pellentesque turpis diam, malesuada ut vulputate nec, hendrerit et orci. Vestibulum hendrerit leo erat, at ornare ex pharetra congue. Integer ornare faucibus tortor, at scelerisque purus vulputate ut. Vestibulum a nibh tempus, lacinia erat ac, sollicitudin enim. Maecenas id faucibus libero, eget dignissim metus.
            </p>
            <p class="text-justify">
                Vestibulum viverra, massa eget hendrerit ultrices, enim ligula bibendum ligula, et euismod sem tellus ut sapien. Donec venenatis quis est vitae condimentum. Aliquam iaculis id ligula at vestibulum. Proin quis justo nec arcu elementum volutpat. Mauris malesuada finibus turpis, eget interdum nisi placerat a. Aenean vitae velit quis ligula suscipit euismod. Vestibulum urna libero, hendrerit nec lorem vel, posuere vestibulum libero. Sed sagittis lacinia tortor in iaculis. Proin tincidunt magna nulla, malesuada commodo enim pulvinar ut. Sed nibh sapien, feugiat quis lorem rhoncus, ultrices sagittis augue. Suspendisse potenti. Pellentesque eleifend risus neque, eu ultrices diam condimentum non. Sed molestie lacus in massa auctor, fermentum lobortis enim eleifend. Sed at mauris finibus nisl tristique eleifend eget eget orci. Nunc auctor tincidunt ligula, quis ultricies lacus convallis et. Nunc tincidunt nisl neque, ut accumsan tellus posuere ac.
            </p>
            <p class="text-justify">
                Morbi mi libero, posuere ut justo vel, feugiat vehicula risus. Phasellus accumsan eget justo sed ultricies. Vivamus enim lectus, fermentum quis lacus at, rhoncus hendrerit nibh. Morbi vel convallis felis. Nam congue nibh a feugiat malesuada. Duis non auctor purus. Sed malesuada est velit, id finibus felis facilisis ut.
            </p>
            <p class="text-justify">
                Vestibulum aliquet lacinia scelerisque. Aenean at sodales risus. Vestibulum nec fermentum ligula, at bibendum arcu. Morbi vitae eros neque. Aenean ut odio id tellus vestibulum sodales sed eu ex. Nunc gravida fringilla erat, ac rutrum massa tempus nec. Aliquam erat metus, accumsan sit amet tortor et, rhoncus auctor elit. Nulla facilisi. Quisque feugiat tempor urna quis rutrum. 
            </p>-->
            </div>
        </asp:Panel>
        
        <asp:Panel ID="MessagePanel" runat="server" Height="39%" Width="49.9%" style="float: right; margin-bottom: 5px" BorderStyle="Dotted" BorderColor="#666699" BackColor="#BABA98" ScrollBars="Auto">
            <h4 style="margin-left: 10px">Messages</h4>
            <div ID="MessagesContainer" runat="server" class="col-lg-12">
            </div>
        </asp:Panel>
        
        <asp:Panel ID="Panel3" runat="server" Height="39%" Width="49.9%" style="float: left" BorderStyle="Dotted" BorderColor="#666699" BackColor="#BABA98" ScrollBars="Auto">
            <h4 style="margin-left: 10px">Tasks</h4>
            <div ID="TasksContainer" runat="server" class="col-lg-12">
            </div>
        </asp:Panel>
        
        <asp:Panel ID="Panel4" runat="server" Height="39%" Width="49.9%" style="float: right" BorderStyle="Dotted" BorderColor="#666699" BackColor="#AFB9BC">
            <h4 style="margin-left: 10px">??????????</h4>
            <div ID="Div3" runat="server" class="col-lg-12">
            </div>
        </asp:Panel>
    </div>
</asp:Content>
