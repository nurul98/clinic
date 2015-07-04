<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="clinic.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:Login ID="Login2" runat="server" 
                CreateUserText="Register to be an authorized user" 
                CreateUserUrl="Register.aspx" DestinationPageUrl="~/home.aspx">
            </asp:Login>
            <br /><br />
           
        </AnonymousTemplate>
        <LoggedInTemplate>
            You are already logged in
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
