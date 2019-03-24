using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using FlowerLauage2018_8_17.Entity;
using System.Configuration;
using FlowerLauage2018_8_17.Service;

namespace FlowerLauage2018_8_17.Service.SQLService
{
    public class SqlChat
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SQLConnectStr"]);    //数据库连接配置

        #region 客服聊天
        /// <summary>
        /// 保存聊天记录
        /// </summary>
        /// <param name="ChatData">聊天记录</param>
        public void SaveChat(ChatData ChatData)
        {
            string sql = "insert into ChatData values('" + ChatData.ID + "','" + ChatData.DialogID + "','" + ChatData.RoleID + "','" + ChatData.Role + "','" + ChatData.RoleName + "','" + ChatData.ChatRoleID + "','" + ChatData.ChatRoleName + "','" + ChatData.Notes + "','" + ChatData.Date + "')";     //传输数据到数据库
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
        /// <summary>
        /// 最新聊天记录
        /// </summary>
        /// <returns></returns>
        public ChatData NewChatData(string RoleID)
        {
            var Data = new ChatData();
            string sql = "select * from ChatData where ChatRoleID='" + RoleID + "'"+ "order by SortID desc";    //获取最后一条数据
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                Data.ID = dr["ID"].ToString();
                Data.DialogID = dr["DialogID"].ToString();
                Data.RoleID = dr["RoleID"].ToString();
                Data.Role = dr["Role"].ToString();
                Data.RoleName = dr["RoleName"].ToString();
                Data.ChatRoleID = dr["ChatRoleID"].ToString();
                Data.ChatRoleName = dr["ChatRoleName"].ToString();
                Data.Notes = dr["Notes"].ToString();
                Data.Date = Convert.ToDateTime(dr["Date"].ToString());
                Data.SortID = Convert.ToInt32(dr["SortID"].ToString());
            }
            conn.Close();
            return Data;
        }
        
        /// <summary>
        /// 历史聊天天数据
        /// </summary>
        /// <returns></returns>
        public List<ChatData> GetHistoryData(DateTime StartTime, DateTime EndTime)
        {
            var Datas = new List<ChatData>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("ChatData");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from ChatData where Date >='" + StartTime + "' AND Date <='" + EndTime + "'";
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;

            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var Data = new ChatData();
                Data.ID = dt.Rows[i]["ID"].ToString();
                Data.DialogID = dt.Rows[i]["DialogID"].ToString();
                Data.RoleID = dt.Rows[i]["RoleID"].ToString();
                Data.Role = dt.Rows[i]["Role"].ToString();
                Data.RoleName = dt.Rows[i]["RoleName"].ToString();
                Data.ChatRoleID = dt.Rows[i]["ChatRoleID"].ToString();
                Data.ChatRoleName = dt.Rows[i]["ChatRoleName"].ToString();
                Data.Notes = dt.Rows[i]["Notes"].ToString();           
                Data.Date = Convert.ToDateTime(dt.Rows[i]["Date"].ToString());
                Data.SortID = Convert.ToInt32(dt.Rows[i]["SortID"].ToString());
                Datas.Add(Data);
            }
            return Datas;
        }

        /// <summary>
        /// 获取近10条聊天记录
        /// </summary>
        /// <returns></returns>
        public List<ChatData> HistoryData(string DialogID)
        {
            string sql = "select top 10 from ChatData where DialogID='" + DialogID+"'"+ "order by SortID desc";
            var Datas = new List<ChatData>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("ChatData");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;
            conn.Open();
            da.Fill(dt);
            conn.Close();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var Data = new ChatData();
                Data.ID = dt.Rows[i]["ID"].ToString();
                Data.DialogID = dt.Rows[i]["DialogID"].ToString();
                Data.RoleID = dt.Rows[i]["RoleID"].ToString();
                Data.Role = dt.Rows[i]["Role"].ToString();
                Data.RoleName = dt.Rows[i]["RoleName"].ToString();
                Data.ChatRoleID = dt.Rows[i]["ChatRoleID"].ToString();
                Data.ChatRoleName = dt.Rows[i]["ChatRoleName"].ToString();
                Data.Notes = dt.Rows[i]["Notes"].ToString();
                Data.Date = Convert.ToDateTime(dt.Rows[i]["Date"].ToString());
                Data.SortID = Convert.ToInt32(dt.Rows[i]["SortID"].ToString());
                Datas.Add(Data);
            }
            return Datas;
        }
        /// <summary>
        /// 验证聊天框是否存在
        /// </summary>
        /// <param name="DialogID"></param>
        /// <returns></returns>
        public int ConfirmChat(string DialogID)
        {
            string sql = "select * from ChatData where DialogID='" + DialogID + "'"+ "order by SortID desc";
            var Datas = new List<ChatData>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("ChatData");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt.Rows.Count; //返回数据数量
        }
        /// <summary>
        /// 获取指定历史聊天记录
        /// </summary>
        /// <returns></returns>
        public List<ChatData> FindHistoryData(DateTime StartTime,DateTime EndTime)
        {
            var Datas = new List<ChatData>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("ChatData");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from ChatData where Date >='" + StartTime + "' AND Date <='" + EndTime + "'";
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;

            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var Data = new ChatData();
                Data.ID = dt.Rows[i]["ID"].ToString();
                Data.DialogID = dt.Rows[i]["DialogID"].ToString();
                Data.RoleID = dt.Rows[i]["RoleID"].ToString();
                Data.Role = dt.Rows[i]["Role"].ToString();
                Data.RoleName = dt.Rows[i]["RoleName"].ToString();
                Data.ChatRoleID = dt.Rows[i]["ChatRoleID"].ToString();
                Data.ChatRoleName = dt.Rows[i]["ChatRoleName"].ToString();
                Data.Notes = dt.Rows[i]["Notes"].ToString();
                Data.Date = Convert.ToDateTime(dt.Rows[i]["Date"].ToString());
                Data.SortID = Convert.ToInt32(dt.Rows[i]["SortID"].ToString());
                Datas.Add(Data);
            }
            return Datas;
        }
        #endregion


        #region 植物聊天
        /// <summary>
        /// 获取用户添加聊天记录
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<AnswerData> GetAnswerUserList(string UserID)
        {
            var Datas = new List<AnswerData>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("AnswerData");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from AnswerData where UserID ='" + UserID + "'";
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;

            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var Data = new AnswerData();
                Data.ID = dt.Rows[i]["ID"].ToString();
                Data.AnsKey = dt.Rows[i]["AnsKey"].ToString();
                Data.AnsValue = dt.Rows[i]["AnsValue"].ToString();
                Data.Role = dt.Rows[i]["Role"].ToString();
                Data.UserID= dt.Rows[i]["UserID"].ToString();
                Datas.Add(Data);
            }
            return Datas;
        }

        /// <summary>
        /// 获取系统自带对话
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<AnswerData> GetAnswerSysList()
        {
            var Datas = new List<AnswerData>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("AnswerData");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from AnswerData where Role = '系统 '";
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;

            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var Data = new AnswerData();
                Data.ID = dt.Rows[i]["ID"].ToString();
                Data.AnsKey = dt.Rows[i]["AnsKey"].ToString();
                Data.AnsValue = dt.Rows[i]["AnsValue"].ToString();
                Data.Role = dt.Rows[i]["Role"].ToString();
                Data.UserID = dt.Rows[i]["UserID"].ToString();
                Datas.Add(Data);
            }
            return Datas;
        }

        /// <summary>
        /// 插入对话聊天
        /// </summary>
        /// <param name="Data"></param>
        public void InsertAns(AnswerData Data)
        {
            string sql = "insert into AnswerData values('" + Data.ID + "','" + Data.AnsKey + "','" + Data.AnsValue + "','" + Data.Role + "','" + Data.UserID + "')";     //传输数据到数据库
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
        #endregion
    }
}