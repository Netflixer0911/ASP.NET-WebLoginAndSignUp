<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css"/>
    <title></title>
</head>
<body><div class="bg">
    <form id="form1" runat="server">
    <div class = "bigbox">
        <div class = "head">
            <h1>登录/注册</h1>
        </div>
        <div class ="middle">
            <div class = "column text">
                <p>用户名：</p>
                <p>密码：</p>
            </div>
            <div class = "column box">
            <p><asp:TextBox placeholder="输入用户名" ID="TextBox1" runat="server"></asp:TextBox></p>
            <p><asp:TextBox TextMode="Password" placeholder="输入密码" ID="TextBox2" runat="server"></asp:TextBox></p>
                <p>
                    <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="注册" OnClick="Button2_Click" />
                </p>
            </div>
        </div>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:login_webhw_ConnectionString %>" SelectCommand="SELECT * FROM [logindb]"></asp:SqlDataSource>
        <asp:Label ID="Label1" runat="server" Text="&gt;v&lt;" ForeColor="White"></asp:Label>
            <center><div class="success"><p runat="server" id="welcome">登录成功！欢迎您！</p></div></center>
            <br/>
            <br/>
            <center><asp:Button ID="Button3" runat="server" Text="退出登录" OnClick="Button3_Click" />
                <br />
        </center>
    </form>
    
</div></body>
</html>
