<%@ Page
    Title="View post page"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ViewPost.aspx.cs"
    Inherits="BlogWork.WebForms.ViewPost"%>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .Posttextarea{
            min-height:256px;
            min-width: 900px;
            resize:none;
        }

                .Commenttextarea{
            min-height:128px;
            min-width: 900px;
            resize:none;
        }

        .commentAvatar {
            border:solid;
            border-color:dimgrey;
            border-width: 1px;
            display: inline-block;
            Width:38px; 
            Height:38px;
            float: left;
        }

        .commentName {
    color:Highlight;
    display: inline-block;
    float: left;
    text-align:left;
    border-right: 2px;
    border-color:black;
}

        .commentBody{
            color:white;
            background-color:darkgrey;
            width:60%;
        }

        .commentDiv{
            background-color:darkgrey;
            padding-top:10px;
            padding-left:6px;
        }

        .postImage{
            border:solid;
            border-width: 4px;
            border-color:dimgrey;
            max-height:600px;
            max-width:900px;
        }
    </style>


    <div id="postConteiner" class="jumbotron">
        <h1 id="ThemeOfPost" runat="server">Empty Theme</h1>
        <p runat="server" id="DescriptionOfPost" class="lead">Empty desctiption</p>
        <asp:Image id="PostImage" runat="server" CssClass="postImage"/>
        <br />
        <br />
        <textarea runat="server" id="PostBodyText" class="Posttextarea">Empty body</textarea>
        <div style="text-align: right; font-size: small">
            <p id="LabelAuthor" runat="server" class="AuthorLabel">Unknown Author</p>
            <p id="LabelDateTime" runat="server" class="DateLabel">99.99.9999</p>
        </div>
    </div>
    <br />
    <div id="div1" runat="server" class="jumbotron">
        <div id="div2" runat="server"></div>
    </div>

    <div id="CommentBox" runat="server" class="jumbotron">
        <textarea class="Commenttextarea" runat="server" id="CommentTextArea"></textarea>
        <br />
        <asp:Button id="ButtonAddComment" runat="server" CssClass="btn" Text="Оставить коментарий" OnClick="ButtonAddComment_Click"/>
        </div>
        

    <asp:Label ID="LabelState" runat="server"></asp:Label>
</asp:Content>
