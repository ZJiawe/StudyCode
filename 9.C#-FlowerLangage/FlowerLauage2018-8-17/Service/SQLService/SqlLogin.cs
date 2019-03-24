using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using FlowerLauage2018_8_17.Entity;
using System.Configuration;
using FlowerLauage2018_8_17.Service;

namespace FlowerLauage2018_8_17.Fuctions
{
    public class SqlLogin
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SQLConnectStr"]);    //数据库连接配置
        /// <summary>
        /// 用户账户密码核实
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Login UserLogin(string Account, string password)
        {
            var Data = new Login();
            DataSet ds1 = new DataSet();
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable("Login");
            DataTable dt = new DataTable("Login");
            DataTableCollection dc1 = ds1.Tables;
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            dc1.Add(dt1);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlDataAdapter da1 = new SqlDataAdapter();
            string sql1 = "select * from Login where Account='" + Account + "'";
            string sql = "select * from Login where Account='" + Account + "'AND Password='" + password + "'";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlCommand comm1 = new SqlCommand(sql1, conn);
            da.SelectCommand = comm;
            da1.SelectCommand = comm1;
            conn.Open();
            da.Fill(dt);
            da1.Fill(dt1);
            conn.Close();
            if (dt1.Rows.Count > 0)
            {
                Data.ID = dt1.Rows[0]["ID"].ToString();
                Data.Account = dt1.Rows[0]["Account"].ToString();
            }
            else
            {
                Data.ID = "";
                Data.Account = "";
            }
            if (dt.Rows.Count>0)
            {
                Data.Password = dt.Rows[0]["Password"].ToString();
                Data.UserName = dt.Rows[0]["UserName"].ToString();
                Data.Role = dt.Rows[0]["Role"].ToString();
            }
            else
            {
                Data.Password = "";
                Data.UserName = "";
            }
            return Data;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="loginData"></param>
        public void InsertLoginData(Login loginData)
        {
            string sql = "insert into Login values('" + loginData.ID + "','" + loginData.UserName + "','" + loginData.Account + "','" + loginData.Password + "','"+loginData.Role+"')";     //传输数据到数据库
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
        /// <summary>
        ///更改用户资料
        /// </summary>
        /// <param name="loginData"></param>
        public void UpdateLoginData(Login loginData)
        {
            string sql = "update Login set UserName='" + loginData.UserName + "',Account='" + loginData.Account + "',Password='" + loginData.Password + "' where ID='" + loginData.ID + "'";
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
        /// <summary>
        /// 注销用户
        /// </summary>
        /// <param name="KeyValue"></param>
        public void DeleteAccount(string KeyValue)
        {
            string sql = "delete from Login where ID='" + KeyValue + "'";
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<Login> FindUsers()
        {
            var Datas = new List<Login>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Login");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from Login";
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;
            conn.Open();
            da.Fill(dt);
            conn.Close();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var Data = new Login();
                Data.ID = dt.Rows[i]["ID"].ToString();
                Data.Account = dt.Rows[i]["Account"].ToString();
                Data.Password = dt.Rows[i]["Password"].ToString();
                Data.UserName = dt.Rows[i]["UserName"].ToString();
                Data.Role = dt.Rows[i]["Role"].ToString();
                Datas.Add(Data);
            }
            return Datas;
        }

        /// <summary>
        /// 搜索指定用户通过账号
        /// </summary>
        /// <param name="KeyValue"></param>
        /// <returns></returns>
        public Login FindUser(string KeyValue)
        {
            var Data = new Login();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Login");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from Login where Account='" + KeyValue + "'";
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;

            conn.Open();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                Data.ID = dt.Rows[0]["ID"].ToString();
                Data.Account = dt.Rows[0]["Account"].ToString();
                Data.Password = dt.Rows[0]["Password"].ToString();
                Data.UserName = dt.Rows[0]["UserName"].ToString();
                Data.Role = dt.Rows[0]["Role"].ToString();
            }
            else
            {
                Data.ID = "";
                Data.Account = "";
                Data.Password = "";
                Data.UserName = "";
            }
            return Data;
        }
    }
}