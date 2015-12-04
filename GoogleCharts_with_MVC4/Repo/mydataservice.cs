using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using GoogleCharts_with_MVC4.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using MySql.Data.MySqlClient;

namespace GoogleCharts_with_MVC4.Repo
{
    public class mydataservice
    {
        [WebMethod]
        public  List<sales> GetChartData()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection("server = 127.0.0.1; database= econectividad; uid=root"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from sales", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            List<sales> dataList = new List<sales>();


            foreach (DataRow dtrow in dt.Rows)
            {
                sales details = new sales();
                details.years = dtrow[0].ToString();
                details.sale = Convert.ToInt32(dtrow[1]);
                dataList.Add(details);
            }
            return dataList;
        }

        public class sales
        {
            public string years { get; set; }
            public int sale { get; set; }
        }
    }
}