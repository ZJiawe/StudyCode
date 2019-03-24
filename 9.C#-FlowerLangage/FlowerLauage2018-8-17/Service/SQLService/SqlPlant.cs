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
    public class SqlPlant
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SQLConnectStr"]);    //数据库连接配置
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="Data"></param>
        public void Insert(PlantData Data)
        {
            string sql = "insert into PlantData values('" + Data.PlantID + "','" + Data.UserID + "','" + Data.Name + "','" + Data.Kind + "','" + Data.Date + "')";     //传输数据到数据库
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="Data"></param>
        public void Update(PlantData Data)
        {
            string sql = "update PlantData set Name='" + Data.Name + "',Kind='" + Data.Kind + "',Date='" + Data.Date + "'where PlantID = '" + Data.PlantID+"'";
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// 获取用户所有植物信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<PlantData> GetList(string UserID)
        {
            var Datas = new List<PlantData>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("PlantData");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from PlantData where UserID='"+UserID+"'";
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;
            conn.Open();
            da.Fill(dt);
            conn.Close();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var Data = new PlantData();
                Data.PlantID = dt.Rows[i]["PlantID"].ToString();
                Data.UserID = dt.Rows[i]["UserID"].ToString();
                Data.Name = dt.Rows[i]["Name"].ToString();
                Data.Kind = dt.Rows[i]["Kind"].ToString();
                Data.Date = Convert.ToDateTime(dt.Rows[i]["Date"].ToString());
                Datas.Add(Data);
            }
            return Datas;
        }
    }
}