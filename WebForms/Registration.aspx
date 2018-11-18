<%@ Page Title ="Registration Page" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Registration.aspx.cs" Inherits="BlogWork.WebForms.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class=""><%: Title %>.</h2>

    <p>&nbsp;</p>

        <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" SetFocusOnError="true"
        Display="None" ControlToValidate="TextBoxMail" resourceKey="revEmailAddress"
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="register" ErrorMessage="Invalid email"></asp:RegularExpressionValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" 
        ErrorMessage="Email is empty" ControlToValidate="TextBoxMail" ValidationGroup="register"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="Name is empty" ControlToValidate="TextBoxName" ValidationGroup="register"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="Password is empty" ControlToValidate="TextBoxPassowrdOne" ValidationGroup="register"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ErrorMessage="Password is empty" ControlToValidate="TextBoxPasswordTwo" ValidationGroup="register"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Confirm the password" 
        ControlToCompare="TextBoxPassowrdOne" ControlToValidate="TextBoxPasswordTwo" ValidationGroup="register"></asp:CompareValidator>
    
    <div class="div-signin">
    <asp:Label ID="LableState" runat="server"></asp:Label>
    <p>Имя:</p>
    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
    <br />
    <br />
    <p>Электронная почта:</p>
    <asp:TextBox ID="TextBoxMail" runat="server"></asp:TextBox>
    <br />
    <br />
    <p>Пароль:</p>
    <asp:TextBox ID="TextBoxPassowrdOne" TextMode="Password" runat="server"></asp:TextBox>
    <br />
    <br />
    <p>Повторите пароль:</p>
    <asp:TextBox ID="TextBoxPasswordTwo" TextMode="Password" runat="server"></asp:TextBox>
    <br />
    <br />
    <p>&nbsp;</p>
    <p>
        <asp:Button ID="ButtonRegister" OnClick="ButtonRegister_Click" runat="server" Text="Зарегистрироваться" Width="166px"
            class="btn" ValidationGroup="register" CausesValidation="true"/>
    </p>
        <br />
        <asp:ValidationSummary ID="valsumRegister" resourceKey="valsumRegister" runat="server"
                    ShowSummary="false" ShowMessageBox="true" ValidationGroup="register" HeaderText="Registration error" />
        </div>

</asp:Content>
