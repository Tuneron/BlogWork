<%@ Page Title ="Your profile"
    Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="Profile.aspx.cs"
    Inherits="BlogWork.Secure.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <asp:Label ID="LabelName" runat="server" Text="Unknown user"></asp:Label>
    <br />
    <asp:Image ID="UserAvatar" runat="server" ImageUrl="~/Resources/UnknownUserAvatar.jpg" Height="128px" Width="128px"/>
    <br />
    <br />
    <asp:Label ID="LabelRank" runat="server" Text="User"></asp:Label>
    
    </asp:Content>
