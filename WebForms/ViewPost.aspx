<%@ Page
    Title="View post page"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ViewPost.aspx.cs"
    Inherits="BlogWork.WebForms.ViewPost" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        textarea{
            min-height:256px;
            min-width: 900px;
            resize:none;
        }
    </style>

    <div id="postConteiner" class="jumbotron">
        <h1 id="ThemeOfPost" runat="server">Empty Theme</h1>
        <p runat="server" id="DescriptionOfPost" class="lead">Empty desctiption</p>
        <textarea runat="server" id="PostBodyText">Empty body</textarea>
        <div style="text-align: right; font-size: small">
            <p id="LabelAuthor" runat="server" class="AuthorLabel">Unknown Author</p>
            <p id="LabelDateTime" runat="server" class="DateLabel">99.99.9999</p>
        </div>
    </div>

    <div id="div1" runat="server">
    </div>

    <asp:Label ID="LabelState" runat="server"></asp:Label>
</asp:Content>
