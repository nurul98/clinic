<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="clinic.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
    InvalidEmailErrorMessage="" RequireEmail="False">
    <WizardSteps>
        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />
        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" >
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="center" colspan="2">
                            Complete</td>
                    </tr>
                    <tr>
                        <td>
                            Your account has been successfully created.</td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" 
                                CommandName="Continue" PostBackUrl="~/profilecreate.aspx" Text="Continue" 
                                ValidationGroup="CreateUserWizard1" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:CompleteWizardStep>
    </WizardSteps>
        <FinishNavigationTemplate>
            <asp:Button ID="FinishPreviousButton" runat="server" CausesValidation="False" 
                CommandName="MovePrevious" Text="Previous" />
            <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" 
                Text="Finish" />
        </FinishNavigationTemplate>
        <StartNavigationTemplate>
            <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" 
                Text="Next" />
        </StartNavigationTemplate>
</asp:CreateUserWizard>
</asp:Content>
