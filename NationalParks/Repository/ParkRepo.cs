using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NationalParks.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NationalParks.Repository
{
    public class ParkRepo
    {
        private SqlConnection con;
        //To Handle Connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        public bool AddPark(Parks p)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNewParkDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", p.id);
            com.Parameters.AddWithValue("@states", p.states);
            com.Parameters.AddWithValue("@latLong", p.latLong);
            com.Parameters.AddWithValue("@description", p.description);
            com.Parameters.AddWithValue("@designation", p.designation);
            com.Parameters.AddWithValue("@parkCode", p.parkCode);
            com.Parameters.AddWithValue("@directionsInfo", p.directionsInfo);
            com.Parameters.AddWithValue("@directionsUrl", p.directionsUrl);
            com.Parameters.AddWithValue("@fullName", p.fullName);
            com.Parameters.AddWithValue("@url", p.url);
            com.Parameters.AddWithValue("@weatherInfo", p.weatherInfo);
            com.Parameters.AddWithValue("@name", p.name);

            con.Open();
            int i = com.ExecuteNonQuery();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Parks> GetAllParks()
        {
            connection();
            List<Parks> ParkList = new List<Parks>();


            SqlCommand com = new SqlCommand("GetParks", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                ParkList.Add(

                    new Parks
                    {
                        states = Convert.ToString(dr["states"]),
                        latLong = Convert.ToString(dr["latLong"]),
                        description = Convert.ToString(dr["description"]),
                        designation = Convert.ToString(dr["designation"]),
                        parkCode = Convert.ToString(dr["parkCode"]),
                        id = Convert.ToString(dr["Id"]),
                        directionsInfo = Convert.ToString(dr["directionsInfo"]),
                        directionsUrl = Convert.ToString(dr["directionsUrl"]),
                        fullName = Convert.ToString(dr["fullName"]),
                        url = Convert.ToString(dr["url"]),
                        weatherInfo = Convert.ToString(dr["weatherInfo"]),
                        name = Convert.ToString(dr["name"]),
                    }
                    );


            }
            return ParkList;
        }
    }
}
