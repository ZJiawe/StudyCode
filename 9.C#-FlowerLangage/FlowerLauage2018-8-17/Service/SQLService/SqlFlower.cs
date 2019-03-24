using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using FlowerLauage2018_8_17.Entity;
using System.Configuration;
using FlowerLauage2018_8_17.Service;

namespace FlowerLauage2018_8_17.Fuctions.SQL
{
    public class SqlFlower
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SQLConnectStr"]);    //数据库连接配置

        #region 花的种类

        /// <summary>
        /// 获取所有花种类信息
        /// </summary>
        /// <returns></returns>
        public List<FlowerData> FindAllDatas()
        {
            var Datas = new List<FlowerData>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("FlowerData");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from FlowerData";
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;
            conn.Open();
            da.Fill(dt);
            conn.Close();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var Data = new FlowerData();
                Data.ID = dt.Rows[i]["ID"].ToString();
                Data.Introduction = dt.Rows[i]["Introduction"].ToString();
                Data.Techniques = dt.Rows[i]["Techniques"].ToString();
                Data.Alias = dt.Rows[i]["Alias"].ToString();
                Datas.Add(Data);
            }
            return Datas;
        }

        /// <summary>
        /// 获取指定花品种信息
        /// </summary>
        /// <returns></returns>
        public List<FlowerData> FindFlowerDatas(string qurystring)
        {
            var Datas = new List<FlowerData>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("FlowerData");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from FlowerData where Alias='" + qurystring+"'";
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;
            conn.Open();
            da.Fill(dt);
            conn.Close();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var Data = new FlowerData();
                Data.ID = dt.Rows[i]["ID"].ToString();
                Data.Introduction = dt.Rows[i]["Introduction"].ToString();
                Data.Techniques = dt.Rows[i]["Techniques"].ToString();
                Data.Alias = dt.Rows[i]["Alias"].ToString();
                Datas.Add(Data);
            }
            return Datas;
        }

        #endregion

        #region 花的详细数据
        /// <summary>
        /// 获取最新数据
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="FlowerName"></param>
        /// <returns></returns>
        public FlowerDataDetail NewDetailData(string UserID,string FlowerName)     
        {
            var flowerName = "红掌";
            var Data = new FlowerDataDetail();
            string sql = "select * from FlowerDataDetail where UserID='"+ UserID+ "' AND FlowerName like '%[" + flowerName + "]%'" + "order by OrderID desc";
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                Data.ID = dr["ID"].ToString();
                Data.Temperature = dr["Temperature"].ToString();
                Data.Humidity = dr["Humidity"].ToString();
                Data.Light = dr["Light"].ToString();
                Data.Date = Convert.ToDateTime(dr["Date"].ToString());
                Data.UserID = dr["UserID"].ToString();
                Data.FlowerName = dr["FlowerName"].ToString();
            }
            conn.Close();
            return Data;
        }

        /// <summary>
        /// 获取最新数据
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="FlowerName"></param>
        /// <returns></returns>
        public FlowerDataDetail NewDetailData()
        {
            var Data = new FlowerDataDetail();
            string sql = "select * from FlowerDataDetail order by OrderID desc";
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                Data.ID = dr["ID"].ToString();
                Data.Temperature = dr["Temperature"].ToString();
                Data.Humidity = dr["Humidity"].ToString();
                Data.Light = dr["Light"].ToString();
                Data.Date = Convert.ToDateTime(dr["Date"].ToString());
                Data.UserID = dr["UserID"].ToString();
                Data.FlowerName = dr["FlowerName"].ToString();
            }
            conn.Close();
            return Data;
        }
        /// <summary>
        /// 历史数据
        /// </summary>
        /// <returns></returns>
        public List<FlowerDataDetail> GetHistoryData(DateTime StartTime, DateTime EndTime ,string UserID , string FlowerName)
        {
            var Datas = new List<FlowerDataDetail>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("FlowerDataDetail");
            DataTableCollection dc = ds.Tables;
            dc.Add(dt);
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "select * from FlowerDataDetail where Date >='" + StartTime + "' AND Date <='" + EndTime + "'AND UserID='"+ UserID + "' AND FlowerName like '%[" + FlowerName+"]%'";
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;

            conn.Open();
            da.Fill(dt);
            conn.Close();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var Data = new FlowerDataDetail();
                Data.ID = dt.Rows[i]["ID"].ToString();
                Data.Temperature = dt.Rows[i]["Temperature"].ToString();
                Data.Humidity = dt.Rows[i]["Humidity"].ToString();
                Data.Light = dt.Rows[i]["Light"].ToString();
                Data.Date = Convert.ToDateTime(dt.Rows[i]["Date"].ToString());
                Data.UserID = dt.Rows[i]["UserID"].ToString();
                Data.FlowerName= dt.Rows[i]["FlowerName"].ToString();
                Datas.Add(Data);
            }
            return Datas;
        }

        #endregion
    }
}