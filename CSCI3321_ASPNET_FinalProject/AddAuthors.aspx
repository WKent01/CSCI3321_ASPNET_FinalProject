<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAuthors.aspx.cs" Inherits="CSCI3321_ASPNET_FinalProject.AddAuthors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="row">
        <div class="col-md-12">
            <h3>Add New Author</h3>
        </div>
    </div>
    <div class ="row">
        <div class="col-md-3">
            Last Name:
        </div>
        <div class="col-md-9">
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="col-md-3">
            First Name:
        </div>
        <div class="col-md-9">
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="col-md-3">
            Gender:
        </div>
        <div class="col-md-9">
            <!--drop down -->
            <asp:DropDownList ID="dropDownGender" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="col-md-3">
            Birthday:
        </div>
        <div class="col-md-9">
            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" TextMode = "Date"></asp:TextBox>
        </div>

        <div class="col-md-12">
            
            <asp:Button ID="btnAddAuthor" runat="server" Text="Add Author" OnClick="btnAddAuthor_Click" />
            
        </div>

    </div>
</asp:Content>
