<%@ Page Title ="Log in Page" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LogIn.aspx.cs" Inherits="BlogWork.WebForms.LogIn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="div-signin">
    <asp:Label ID ="LabelState" runat="server"></asp:Label>
    <br />
    <p>Введите имя</p>
    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
    <br />
    <br />
    <p>Введите пароль</p>
    <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button CssClass="btn" ID="ButtonLogIn" Text="Авторизироваться" OnClick="ButtonLogIn_Click" runat="server"/>
    <asp:Label ID ="LabelLogin" runat="server"></asp:Label>
        </div>
</asp:Content>

