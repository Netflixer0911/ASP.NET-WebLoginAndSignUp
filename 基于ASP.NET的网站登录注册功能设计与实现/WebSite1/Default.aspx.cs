using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

public partial class _Default : System.Web.UI.Page
{   
    private SqlConnection conn = null;
    private SqlCommand cmd = null;
    private string sql = null;
    public void openDatabase()
    {
        conn = new SqlConnection();
        conn.ConnectionString = "Integrated Security=SSPI;Data Source=(local);initial catalog=test;User ID =sa;password=123456";//SQL Server用户名为sa，密码是123456 数据库名称是test，表名称是test3
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
    }

    public void load()
    {
        openDatabase();
        cmd = new SqlCommand("select * from test3 where id=7", conn);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            TextBox1.Text = (String)dr[1].ToString().Trim();
            TextBox2.Text = (String)dr[2].ToString().Trim();
        }
        conn.Close();

    }
    //根据sql语句加载信息，重载两个Textbox
    public void load(String sql)
    {
        openDatabase();
        cmd = new SqlCommand(sql, conn);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            TextBox1.Text = (String)dr[1].ToString().Trim();
            TextBox2.Text = (String)dr[2].ToString().Trim();
        }
        conn.Close();
    }
    //封装的数据库语句执行的方法
    public void execute(String sql)
    {
        openDatabase();
        cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();

    }


    //页面加载时ASP.NET首先会调用这个方法
    protected void Page_Load(object sender, EventArgs e)
    { 
        welcome.Visible = false;
        Button3.Visible = false;
        Response.Write("当前在线人数：" + Application["count"].ToString());
        if (!IsPostBack) { load(); }
    }
    
    protected void Button1_Click(object sender, EventArgs e)//登录按钮事件
    {   
        if (TextBox1.Text == "")
        {
            Response.Write("<script>window.alert('没有输入用户名');</script>");
            return;
        }

        else if (TextBox2.Text == "")
        {
            Response.Write("<script>window.alert('没有输入密码');</script>");
            return;
        }
        conn = new SqlConnection();
        conn.ConnectionString = "Integrated Security=SSPI;Data Source=(local);initial catalog=test;User ID =sa;password=123456";
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        SqlCommand cmd = new SqlCommand("SELECT *FROM test3 where userID = '" + TextBox1.Text.Trim() + "' and userPWD = '" + TextBox2.Text.Trim() + "'", conn);
        // 这句话创建一个指令
        SqlDataReader sdr = cmd.ExecuteReader();//指令传给reader
        Label1.Text = cmd.CommandText.ToString();
        sdr.Read();
        if (sdr.HasRows)
        {
            Response.Write("<script>window.alert('登录成功');</script>");
            welcome.Visible = true;
            Button3.Visible = true;
        }
            
        else
        {
            sdr.Close();
            cmd.CommandText = "SELECT *FROM test3 where userID = '" + TextBox1.Text.Trim() + "'";
            sdr = cmd.ExecuteReader();//指令传给reader
            if (sdr.HasRows)
                Response.Write("<script>window.alert('密码错误');</script>");
            else
                Response.Write("<script>window.alert('用户名不存在');</script>");
            sdr.Close();
        }

        conn.Close();

    }
    protected void Button2_Click(object sender, EventArgs e)//注册按钮事件
    {

        if (TextBox1.Text == "")
        {
            Response.Write("<script>window.alert('没有输入用户名');</script>");
            return;
        }

        else if (TextBox2.Text == "")
        {
            Response.Write("<script>window.alert('没有输入密码');</script>");
            return;
        }
        conn = new SqlConnection();
        conn.ConnectionString = "Integrated Security=SSPI;Data Source=(local);initial catalog=test;User ID =sa;password=123456";
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        SqlCommand cmd = new SqlCommand("SELECT *FROM test3 where userID = '" + TextBox1.Text.Trim() + "'", conn);
        SqlDataReader sdr = cmd.ExecuteReader();
        Label1.Text = cmd.CommandText.ToString();
        sdr.Read();
        if (sdr.HasRows)
            Response.Write("<script>window.alert('用户名已经存在，不可以重复注册');</script>");
        else
        {
        sql = "insert into test3(userID,userPWD) values('" + TextBox1.Text.ToString().Trim() + "','" + TextBox2.Text.ToString().Trim() + "')";
        execute(sql);
        Response.Write("<script>window.alert('注册成功，可以登录了');</script>");
        }

    }
    protected void Button3_Click(object sender, EventArgs e)//退出登录按钮事件
    {
        Session.Abandon();
        Response.Write("<script>window.alert('成功退出登录！');</script>");
    }


}