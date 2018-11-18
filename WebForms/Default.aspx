<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BlogWork._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="postConteiner" class="jumbotron">
        <h1 id="ThemeOfPost" runat="server">Empty Theme</h1>
        <p runat="server" id="DescriptionOfPost" class="lead">Empty desctiption</p>
        <div style="text-align:right; font-size:small">
        <p id ="LabelAuthor" runat="server" class="AuthorLabel">Unknown Author</p>
        <p Id="LabelDateTime" runat="server" class="DateLabel">99.99.9999</p>
            </div>

        <asp:Button class="btn btn-primary btn-lg postButtons" ID="ButtonViewPost" runat="server" Text="Читать"
            OnClick="ButtonViewPost_Click"/>

    </div>
    <div style="text-align: center;">
        <asp:Button class="btn btn-primary btn-lg postButtons" ID="ButtonFirstPost" runat="server" Text="<<"
             OnClick="ButtonFirstPost_Click"/>
        <asp:Button class="btn btn-primary btn-lg postButtons" ID="ButtonPrevPost" runat="server" Text="<"
             OnClick="ButtonPrevPost_Click"/>
        <asp:Button class="btn btn-primary btn-lg postButtons" ID="ButtonNextPost" runat="server" Text=">"
             OnClick="ButtonNextPost_Click"/>
        <asp:Button class="btn btn-primary btn-lg postButtons" ID="ButtonLastPost" runat="server" Text=">>"
             OnClick="ButtonLastPost_Click"/>
    </div>
    <asp:Label ID="LabelState" runat="server"></asp:Label>
</asp:Content>
