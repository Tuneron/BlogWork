<%@ Page Title ="Your profile"
    Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="Profile.aspx.cs"
    Inherits="BlogWork.Secure.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
       .UserName{
           border:solid;
           border-width: 1px;
           border-color:Highlight;
           color:Highlight;
           font-size:16px;
           padding: 5px;
       }

               .commentAvatar {
            border:solid;
            border-color:dimgrey;
            border-width: 2px;
            display: inline-block;
            Width:128px; 
            Height:128px;
        }
    </style>
    <br />
    <asp:Label ID="LabelName" runat="server" Text="Unknown user" CssClass="UserName"></asp:Label>
    <br />
    <br />
    <asp:Image ID="UserAvatar" runat="server" ImageUrl="~/Resources/UnknownUserAvatar.jpg" CssClass="commentAvatar"/>
    <br />
    <br />
    <p style="padding:5px">Rank: <asp:Label ID="LabelRank" runat="server" Text="User" CssClass="UserName"></asp:Label></p>
    <br />
    <div>
        <asp:FileUpload ID="UploadAvatar" runat="server"/>
        <br />
        <asp:Button ID="ButtonUploadAvatar" runat="server" cssClass="btn" Text="Обновить аватар" OnClick="ButtonUploadAvatar_Click"/>
    </div>
    
    
    </asp:Content>
