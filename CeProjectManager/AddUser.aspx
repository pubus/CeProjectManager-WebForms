<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="CeProjectManager.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal" style="margin-top: 20px">
      <div class="form-group">
        <label class="col-sm-2 control-label">Name</label>
        <div class="col-sm-10">
            <input runat="server" type="text" class="form-control" ID="UserName" placeholder="Name"/>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">Surname</label>
        <div class="col-sm-10">
            <input runat="server" type="text" class="form-control" ID="UserSurname" placeholder="Surname"/>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">For group</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="GroupDropDownList" runat="server" class="form-control">
            </asp:DropDownList>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">Text</label>
        <div class="col-sm-10">
            <asp:TextBox ID="NewsTextBox" runat="server" class="form-control" Rows="10" TextMode="MultiLine"></asp:TextBox>    
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">Submit</label>
        <div class="col-sm-10">
            <asp:Button ID="SubmitButton" runat="server" class="form-control" Text="OK" />
        </div>
      </div>   
    </div>
</asp:Content>
