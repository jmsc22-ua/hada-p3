<%@ Page Title="Products management" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="hada_p3.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="color:#B9848C; padding:10px;">
        Products Management
    </h1>

    <div class="form-group">
        <label for="txtCode">Code:</label>
        <asp:TextBox ID="code" runat="server" CssClass="form-control"/>
    </div>
     
    <div class="form-group">
        <label for="txtName">Name:</label>
        <asp:TextBox ID="name" runat="server" CssClass="form-control"/>
    </div>
     
    <div class="form-group">
        <label for="txtC">Amount:</label>
        <asp:TextBox ID="amount" runat="server" CssClass="form-control"/>
    </div>
    
    <div class="form-group">
        <label for="txtCode">Category:</label>
        <asp:DropDownList ID="category" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione una opción"/>
            <asp:ListItem Text="Computing" Value="0" />
            <asp:ListItem Text="Telephony" Value="1" />
            <asp:ListItem Text="Gaming" Value="2" />
            <asp:ListItem Text="Home appliances" Value="3" />
        </asp:DropDownList>
    </div>
    
    <div class="form-group">
        <label for="txtCode">Price:</label>
        <asp:TextBox ID="price" runat="server" CssClass="form-control"/>
    </div>
     
    <div class="form-group">
        <label for="txtCode"> Creation Date:</label>
        <asp:TextBox ID="creationDate" runat="server" CssClass="form-control"/>
    </div>

    <div class="button-group">
        <asp:Button ID="create" runat="server" Text="Create" OnClick="create_Click" CssClass="btn"/>
        <asp:Button ID="update" runat="server" Text="Update" OnClick="update_Click" CssClass="btn"/>
        <asp:Button ID="delete" runat="server" Text="Delete" OnClick="delete_Click" CssClass="btn"/>
        <asp:Button ID="read" runat="server" Text="Read" OnClick="read_Click" CssClass="btn"/>
        <asp:Button ID="readFirst" runat="server" Text="Read First" OnClick="readFirst_Click" CssClass="btn" />
        <asp:Button ID="readPrev" runat="server" Text="Read Prev" OnClick="readPrev_Click" CssClass="btn"/>
        <asp:Button ID="readNext" runat="server" Text="Read Next" OnClick="readNext_Click" CssClass="btn"/>
    </div>

    <asp:Panel ID="panelProducto" runat="server" CssClass="producto-panel" Visible="false">
        <asp:Label ID="lblCode" runat="server" CssClass="producto-label" /><br />
        <asp:Label ID="lblName" runat="server" CssClass="producto-label" /><br />
        <asp:Label ID="lblAmount" runat="server" CssClass="producto-label" /><br />
        <asp:Label ID="lblPrice" runat="server" CssClass="producto-label" /><br />
        <asp:Label ID="lblCategory" runat="server" CssClass="producto-label" /><br />
        <asp:Label ID="lblDate" runat="server" CssClass="producto-label" /><br />
    </asp:Panel>

    <asp:Label ID="lblError" runat="server" ForeColor="Red" />
  
</asp:Content>