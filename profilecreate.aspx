<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="profilecreate.aspx.cs" Inherits="clinic.profilecreate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Registration Form</h1><br />
        <table class="style1">
            
            <tr>
                <td class="style2">
                    First Name:
                </td>
                <td>
                    <asp:TextBox ID="TxtFirstName" runat="server" CssClass="style2" Width="390px"></asp:TextBox>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtFirstName" CssClass="ErrorMessage">Please enter your first name</asp:RequiredFieldValidator> </td>
            </tr>
            <tr>
                <td class="style2">
                    Last Name:</td>
                <td>
                    <asp:TextBox ID="TxtLastName" runat="server" CssClass="style2" Width="390px"></asp:TextBox>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredLastName" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtLastName" CssClass="ErrorMessage">Please enter your last name</asp:RequiredFieldValidator> </td>
            </tr>
            <tr>
                <td class="style2">
                    IC No:</td>
                <td>
                    <asp:TextBox ID="TxtIC1" runat="server" CssClass="style2" Width="124px"></asp:TextBox>
                &nbsp; -&nbsp;&nbsp;
                    <asp:TextBox ID="TxtIC2" runat="server" Width="29px"></asp:TextBox>
&nbsp; -&nbsp;
                    <asp:TextBox ID="TxtIC3" runat="server" Width="76px"></asp:TextBox>
                </td> 
                <td> <asp:RegularExpressionValidator ID="RangeIC1" runat="server" 
        ErrorMessage="Please enter valid IC" ForeColor="Red" ControlToValidate="TxtIC1" ValidationExpression="^[0-9]{6}$"></asp:RegularExpressionValidator>
    <br />
    <asp:RegularExpressionValidator ID="RangeIC2" runat="server" 
        ErrorMessage="Please enter valid IC" ForeColor="Red" ControlToValidate="TxtIC2" ValidationExpression="^[0-9]{2}$"></asp:RegularExpressionValidator>
  <br />
   <asp:RegularExpressionValidator ID="RangeIC3" runat="server" 
        ErrorMessage="Please enter valid IC" ForeColor="Red" ControlToValidate="TxtIC3" ValidationExpression="^[0-9]{4}$"></asp:RegularExpressionValidator></td>
            </tr>
           <tr>
                <td class="style2">
                    Passport No:
                </td>
                <td>
                    <asp:TextBox ID="TxtPassport" runat="server" CssClass="style2" Width="124px"></asp:TextBox>
                </td>
                 <td> <asp:RequiredFieldValidator ID="RequiredPassport" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtPassport" CssClass="ErrorMessage">Please enter your passport no</asp:RequiredFieldValidator> </td>
            </tr>
            <tr>
                <td class="style2">
                    Address:
                </td>
                <td>
                    <asp:TextBox ID="TxtAddress" runat="server" CssClass="style2" Height="86px" 
                        Width="390px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredAddress" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtAddress" CssClass="ErrorMessage">Please enter your address</asp:RequiredFieldValidator> </td>
            </tr>
    <tr>
                <td class="style2">
                    E-mail:
                </td>
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="style2" Width="170px"></asp:TextBox>
                </td>
                 <td>
                     <asp:RegularExpressionValidator ID="RegularEmail" runat="server" 
        ErrorMessage="Please enter a valid e-mail" ForeColor="Red" 
        ControlToValidate="TxtEmail" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> </td>
            </tr>
           
            <tr>
                <td class="style2">
                    Phone:</td>
                <td>
                    <asp:DropDownList ID="DropDownListPhone" runat="server">
                        <asp:ListItem>010</asp:ListItem>
                        <asp:ListItem>011</asp:ListItem>
                        <asp:ListItem>012</asp:ListItem>
                        <asp:ListItem>013</asp:ListItem>
                        <asp:ListItem>014</asp:ListItem>
                        <asp:ListItem>015</asp:ListItem>
                        <asp:ListItem>016</asp:ListItem>
                        <asp:ListItem>017</asp:ListItem>
                        <asp:ListItem>018</asp:ListItem>
                        <asp:ListItem>019</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtPhone" runat="server"  
                        CssClass="style2" Width="123px"></asp:TextBox>
                </td>
                <td> <asp:RegularExpressionValidator ID="RegularExpressionPhone" runat="server" 
        ErrorMessage="Please enter valid phone number" ForeColor="Red" ControlToValidate="TxtPhone" ValidationExpression="^[0-9]{7}$"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td class="style2">
                    Age:</td>
                <td>
                    <asp:TextBox ID="Age" runat="server" CssClass="style2" Width="40px"></asp:TextBox>
                    &nbsp;yrs</td>
                    <td> <asp:RegularExpressionValidator ID="RegularExpressionAge" runat="server" 
        ErrorMessage="Please enter valid age" ForeColor="Red" ControlToValidate="Age" ValidationExpression="^[0-9]{2}$"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td class="style2">
                    Gender:</td>
                <td>
                <asp:RadioButtonList ID="Gender" runat="server">
                        <asp:ListItem id="option1" runat="server" value="Male"/>
                        <asp:ListItem id="option2" runat="server" Value="Female"/>
                    </asp:RadioButtonList>     
                </td>
            </tr>
        </table>
        <br />
       
        <asp:Button ID="Submit_Register" runat="server" Text="Submit" onclick="Submit_Register_Click" Width="85px"  />
       &nbsp&nbsp
        <asp:Button ID="Submit_Clear" runat="server" Text="Clear" 
        onclick="Clear_Click" Width="85px"  />
       
  
</asp:Content>

