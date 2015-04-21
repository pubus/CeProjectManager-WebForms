<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewMessage.aspx.cs" Inherits="CeProjectManager.NewMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal" style="margin-top: 20px">
        <div class="form-group">
            <label class="col-sm-2 control-label">Recipient</label>
            <div class="col-lg-10">
                <asp:DropDownList ID="UsersDropDownList" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
        </div>  
        
        <div class="form-group">
            <label class="col-sm-2 control-label">Subject</label>
            <div class="col-lg-10">
                <input runat="server" type="text" class="form-control" ID="MessageSubject"/>
                <asp:RequiredFieldValidator ID="reqSubject" runat="server" ErrorMessage="This field is reqired." ControlToValidate="MessageSubject"></asp:RequiredFieldValidator>
            </div>
        </div>
      
        <div class="form-group">
            <label class="col-sm-2 control-label">Message</label>
            <div class="col-lg-10">
                <asp:TextBox ID="MessageTextBox" runat="server" class="form-control" style="resize: none" Rows="12" TextMode="MultiLine" MaxLength="1024"></asp:TextBox>    
            </div>
        </div>
      
        <div class="form-group">
            <label class="col-sm-2 control-label">Submit</label>
            <div class="col-lg-10">
                <asp:Button ID="SendButton" runat="server" class="form-control col-sm-8" Text="Send" OnClick="SendButton_Click" />
            </div>
        </div>   
    </div>
</asp:Content>
