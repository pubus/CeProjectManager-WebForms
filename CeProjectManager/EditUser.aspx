<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="CeProjectManager.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal" style="margin-top: 20px">
      <div class="form-group">
        <label class="col-sm-2 control-label">Name</label>
        <div class="col-sm-10">
            <input runat="server" type="text" class="form-control" ID="UserName" placeholder="Name"/>
            <asp:RequiredFieldValidator ID="reqName" runat="server" ErrorMessage="This field is reqired." ControlToValidate="UserName"></asp:RequiredFieldValidator>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">Surname</label>
        <div class="col-sm-10">
            <input runat="server" type="text" class="form-control" ID="UserSurname" placeholder="Surname"/>
            <asp:RequiredFieldValidator ID="reqSurname" runat="server" ErrorMessage="This field is reqired." ControlToValidate="UserSurname"></asp:RequiredFieldValidator>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">Login</label>
        <div class="col-sm-10">
            <input runat="server" type="text" class="form-control" ID="UserLogin" placeholder="Login" disabled/>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">Email adress</label>
        <div class="col-sm-10">
            <input runat="server" type="email" class="form-control" ID="UserEmail" placeholder="email"/>
            <asp:RequiredFieldValidator ID="reqEmail" runat="server" ErrorMessage="This field is reqired." ControlToValidate="UserEmail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="mailValidator" runat="server" ErrorMessage="Invalid email adress." ControlToValidate="UserEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">Old password</label>
        <div class="col-sm-10">
            <input runat="server" type="password" class="form-control" ID="OldPassword" placeholder="Old password"/>
            <asp:CustomValidator ID="OldPasswordValidator" runat="server" ErrorMessage="Invalid password." ControlToValidate="OldPassword" OnServerValidate="OldPasswordValidator_ServerValidate"></asp:CustomValidator>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">Password</label>
        <div class="col-sm-10">
            <input runat="server" type="password" class="form-control" ID="UserPassword1" placeholder="Password"/>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">Repeat password</label>
        <div class="col-sm-10">
            <input runat="server" type="password" class="form-control" ID="UserPassword2" placeholder="Repeat password"/>
            <asp:CompareValidator ID="comparePassword" runat="server" ErrorMessage="No match." ControlToValidate="UserPassword2" ControlToCompare="UserPassword1"></asp:CompareValidator>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">Submit</label>
        <div class="col-sm-10">
            <asp:Button ID="SubmitButton" runat="server" class="form-control" Text="OK" OnClick="SubmitButton_Click" />
        </div>
      </div>   
      <div class="form-group">
          <asp:CheckBoxList ID="PrivilegesCheckboxList" runat="server" CssClass="checkbox"></asp:CheckBoxList>
      </div>
    </div>
</asp:Content>
