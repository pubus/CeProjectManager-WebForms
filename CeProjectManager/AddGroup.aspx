<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGroup.aspx.cs" Inherits="CeProjectManager.AddGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal" style="margin-top: 20px">
      <div class="form-group">
        <label class="col-sm-2 control-label">Group name</label>
        <div class="col-sm-10">
            <input runat="server" type="text" class="form-control" ID="GroupName" placeholder="Name"/>
            <asp:RequiredFieldValidator ID="reqName" runat="server" ErrorMessage="This field is reqired." ControlToValidate="GroupName"></asp:RequiredFieldValidator>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">Description</label>
        <div class="col-sm-10">
            <asp:TextBox ID="DescriptionTextBox" runat="server" class="form-control" Rows="10" TextMode="MultiLine" MaxLength="1024"></asp:TextBox>   
            <asp:RequiredFieldValidator ID="reqDescritpion" runat="server" ErrorMessage="This field is reqired." ControlToValidate="DescriptionTextBox"></asp:RequiredFieldValidator>
        </div>
      </div>
      <div class="form-group">
        <label class="col-sm-2 control-label">For group</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="UsersDropDownList" runat="server" class="form-control">
            </asp:DropDownList>
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
