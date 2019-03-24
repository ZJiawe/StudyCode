using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;


namespace FlowerLauage2018_8_17.Fuctions
{
    public class SensorService
    {
        static SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SQLConnectStr"]);    //数据库连接配置
        /// <summary>
        /// 服务器端
        /// </summary>
        /// <param name="port"></param>
        public void Server(string ip, int port)
        {
            try
            {
                //string ip = "192.168.43.5";
                //1.监听端口
                TcpListener server = new TcpListener(IPAddress.Parse(ip), port);
                server.Start();
                Console.WriteLine("{0:HH:mm:ss}->监听端口{1}...", DateTime.Now, port);

                //2.等待请求
                while (true)
                {
                    try
                    {
                        //2.1 收到请求
                        TcpClient client = server.AcceptTcpClient(); //停在这等待连接请求
                        IPEndPoint ipendpoint = client.Client.RemoteEndPoint as IPEndPoint;
                        NetworkStream stream = client.GetStream();
                        //2.2 解析数据,长度<1024字节
                        string data = string.Empty;
                        byte[] bytes = new byte[1024];
                        int length = stream.Read(bytes, 0, bytes.Length);
                        if (length > 0)
                        {
                            data = Encoding.Default.GetString(bytes, 0, length);
                            Console.WriteLine("{0:HH:mm:ss}->接收数据(from {1}:{2})：{3}", DateTime.Now, ipendpoint.Address, ipendpoint.Port, data);
                            InsertData(data, ConfigurationManager.AppSettings["UserID"]);
                            //分析插入数据
                            string[] datas = data.Split(new char[] { '!', '，' });
                            int count = Convert.ToInt32(ConfigurationManager.AppSettings["waterCount"]);
                            if (datas.Length == 3) {
                                string ID = CreatKey();
                                decimal Humidity = GetNumber(datas[1]);
                                decimal Temperature = GetNumber(datas[2]);
                                if (Humidity > 20)
                                {
                                    //string datapacket = "15";
                                    //byte[] array = HexStringToByteArray(datapacket);
                                    //string stoppacket = "10";
                                    //byte[] stoparray = HexStringToByteArray(stoppacket);
                                    //stream.Write(array, 0, array.Length);
                                    //stream.Write(stoparray, 0, stoparray.Length);
                                    //count++;
                                    //ConfigurationManager.AppSettings["waterCount"] = count.ToString();
                                    //if (count > 1)
                                    //{
                                    //    stream.Write(stoparray, 0, stoparray.Length);
                                    //}
                                    //else if (count > 3) {
                                    //    stream.Write(array, 0, array.Length);
                                    //}
                                }
                                //else
                                //{
                                //    string datapacket = "10";
                                //    byte[] array = HexStringToByteArray(datapacket);
                                //    string startdatapacket = "15";
                                //    byte[] startarray = HexStringToByteArray(datapacket);
                                //    stream.Write(startarray, 0, startarray.Length);
                                //    stream.Write(array, 0, array.Length);
                                //}                                                          
                            }
                        }
                        //2.3 返回状态
                        //byte[] messages = Encoding.Default.GetBytes("ok.");
                        //stream.Write(messages, 0, messages.Length);

                        //2.4 关闭客户端
                        stream.Close();
                        client.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0:HH:mm:ss}->{1}", DateTime.Now, ex.Message);
                    }
                }
            }
            catch (SocketException socketEx)
            {
                //10013 The requested address is a broadcast address, but flag is not set.
                if (socketEx.ErrorCode == 10013)
                    Console.WriteLine("{0:HH:mm:ss}->启动失败,请检查{1}端口有无其他程序占用.", DateTime.Now, port);
                else
                    Console.WriteLine("{0:HH:mm:ss}->{1}", DateTime.Now, socketEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0:HH:mm:ss}->{1}", DateTime.Now, ex.Message);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 生成主键
        /// </summary>
        /// <returns></returns>
        static public string CreatKey()
        {
            Random R = new Random();
            string strDateTimeNumber = DateTime.Now.ToString("yyyyMMddHHmmssms");
            string strRandomResult = R.Next(1, 1000).ToString();
            return strDateTimeNumber + strRandomResult;
        }

        static public void InsertData(string data,string UserID)
        {
            string Humidity = "";
            string Temperature = "";
            string Light = Convert.ToString(rnd());
            string FlowerName = "";
            string[] datas = data.Split(new char[] { '!','，' });
            if (datas.Length == 3)
            {
                string ID = CreatKey();
                FlowerName = datas[0];
                Humidity = Convert.ToString(GetNumber(datas[1]));
                Temperature = Convert.ToString(GetNumber(datas[2]));
                Console.WriteLine("FlowerName:" + FlowerName);
                Console.WriteLine("Humidity:" + Humidity);
                Console.WriteLine("Temperature:" + Temperature);
                DateTime Date = DateTime.Now;
                string sql = "insert into FlowerDataDetail values('" + ID + "','" + FlowerName + "','" + Temperature + "','" + Humidity + "','" + Light + "','" + Date + "','" + UserID + "')";     //传输数据到数据库
                SqlCommand comm = new SqlCommand(sql, conn);
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        /// <summary>
        /// 提取字符串中得数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal GetNumber(string str)
        {
            decimal result = 0;
            if (str != null && str != string.Empty)
            {
                // 正则表达式剔除非数字字符（不包含小数点.）
                str = Regex.Replace(str, @"[^\d.\d]", "");
                // 如果是数字，则转换为decimal类型
                if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                {
                    result = decimal.Parse(str);
                }
            }
            return result;
        }

        /// <summary>
        /// 转换十六进制发送
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        static int rnd()
        {
            Random rad = new Random();
            int cnt = rad.Next(100, 110);
            return cnt;
        }
    }
}