<%@ Page Title="Create new post" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="BlogWork.Secure.NewPost" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .div-newPost {
            border: double 12px;
            border-color: black;
            width: 100%;
            max-width: 800px;
            padding: 15px;
            margin: auto;
            padding-right: 15px;
            padding-left: 15px;
            font: menu;
            font-size: 16px;
        }

        textarea {
            min-width: 600px;
            min-height: 256px;
            resize: none;
        }
    </style>

    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTheme" runat="server"
        ErrorMessage="Theme is empty" ControlToValidate="TextBoxTheme" ValidationGroup="newPost"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" runat="server"
        ErrorMessage="Description is empty" ControlToValidate="TextBoxDescription" ValidationGroup="newPost"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBody" runat="server"
        ErrorMessage="Body is empty" ControlToValidate="PostBody" ValidationGroup="newPost"></asp:RequiredFieldValidator>

    <br />
    <div class="div-newPost">
        <asp:Label ID="LabelState" runat="server"></asp:Label>
        <p>Тема поста</p>
        <asp:TextBox ID="TextBoxTheme" runat="server"></asp:TextBox>
        <br />
        <br />
        <p>Краткое содержание:</p>
        <asp:TextBox ID="TextBoxDescription" runat="server"></asp:TextBox>
        <br />
        <br />
        <p>Добавить картинку</p>
        <asp:FileUpload ID="FileUploadImage" runat="server" />
        <br />
        <br />
        <p>Тело</p>
        <textarea id="PostBody" runat="server"></textarea>
        <br />
        <br />
        <p>&nbsp;</p>
        <p>
            <asp:Button ID="ButtonAddPost" runat="server" Text="Добавить пост" Width="166px"
                class="btn" ValidationGroup="newPost" CausesValidation="true" OnClick="ButtonAddPost_Click" />
        </p>
        <br />
    </div>
    <asp:ValidationSummary ID="valsumNewPost" resourceKey="valsumNewPost" runat="server"
        ShowSummary="false" ShowMessageBox="true" ValidationGroup="newPost" HeaderText="Post error" />

</asp:Content>
