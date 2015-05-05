<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="CeProjectManager.UploadFile" %>
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
            </div>
        </div>
      
        <div class="form-group">
            <label class="col-sm-2 control-label">Message</label>
            <div class="col-lg-10">
                <asp:TextBox ID="MessageTextBox" runat="server" class="form-control" style="resize: none" Rows="12" TextMode="MultiLine" MaxLength="1024"></asp:TextBox>    
            </div>
        </div>
      
        <div class="form-group">
            <label class="col-sm-2 control-label">Choose file</label>
            <div class="col-lg-10">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
        </div> 

        <div class="form-group">
            <label class="col-sm-2 control-label">Submit</label>
            <div class="col-lg-10">
                <asp:Button ID="UploadButton" runat="server" Text="Upload" OnClick="UploadButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
