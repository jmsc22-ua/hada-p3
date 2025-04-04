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
         <asp:Label ID="errorCode" runat="server" ForeColor="Red" CssClass="error"/>
    </div>
     
    <div class="form-group">
        <label for="txtName">Name:</label>
        <asp:TextBox ID="name" runat="server" CssClass="form-control"/>
        <asp:Label ID="errorName" runat="server" ForeColor="Red" CssClass="error" />
    </div>
     
    <div class="form-group">
        <label for="txtC">Amount:</label>
        <asp:TextBox ID="amount" runat="server" CssClass="form-control"/>
        <asp:Label ID="errorAmount" runat="server" ForeColor="Red" CssClass="error" />
    </div>
    
    <div class="form-group">
        <label for="txtCode">Category:</label>
        <asp:DropDownList ID="category" runat="server" CssClass="form-control">
        </asp:DropDownList>
        <asp:Label ID="errorCategory" runat="server" ForeColor="Red" CssClass="error"/>
    </div>
    
    <div class="form-group">
        <label for="txtCode">Price:</label>
        <asp:TextBox ID="price" runat="server" CssClass="form-control"/>
        <asp:Label ID="errorPrice" runat="server" ForeColor="Red" CssClass="error"/>
    </div>
     
    <div class="form-group">
        <label for="txtCode"> Creation Date:</label>
        <asp:TextBox ID="creationDate" runat="server" CssClass="form-control"/>
        <asp:Label ID="errorDate" runat="server" ForeColor="Red" CssClass="error"/>
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
    <asp:Label ID="lblError" runat="server" ForeColor="Red"/>
  
</asp:Content>