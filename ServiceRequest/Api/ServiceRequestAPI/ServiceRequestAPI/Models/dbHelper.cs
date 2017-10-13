using MySql.Data.MySqlClient;
using ServiceRequestAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ServiceRequestAPI.Models
{
    public class dbHelper
    {
        DbConnect db = new DbConnect();
        MySqlConnection con;
        MySqlCommand cmd;


        public Users ValidateUser(string email, string pwd)
        {

            Users obju = new Users();
            try
            {
                con = db.OpenConnection();
                cmd = new MySqlCommand("sp_validate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("emailid", email);
                cmd.Parameters.AddWithValue("pwd", pwd);
                MySqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    obju.role = sdr["role"].ToString();
                    obju.userName = sdr["userName"].ToString();

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                db.CloseConnection();
            }
            return obju;
        }

        public List<ServiceRequestModel> LoadServiceRequest()
        {

            List<ServiceRequestModel> ServiceRequestModelList = new List<ServiceRequestModel>();
            try
            {

                MySqlConnection sqlcon = db.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("sp_ServiceRequest", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                
                MySqlDataReader sdr = cmd.ExecuteReader();


                while (sdr.Read())
                {
                    ServiceRequestModel sr = new ServiceRequestModel();
                    sr.idsr = sdr["idsr"].ToString();
                    sr.userName = sdr["userName"].ToString();
                    sr.emailId = sdr["email"].ToString();
                    sr.title = sdr["title"].ToString();
                    sr.category = sdr["category"].ToString();
                    sr.subCategory = sdr["sub_category"].ToString();
                  
                    sr.priority = sdr["priority"].ToString();
                    sr.status = sdr["status"].ToString();
                    ServiceRequestModelList.Add(sr);

                }
                sdr.Close();



            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                db.CloseConnection();
            }
            return ServiceRequestModelList;
        }

        public string loadDescription(string idsr)
        {

            string description = "";
            try
            {

                MySqlConnection sqlcon = db.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("sp_description", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("spidsr", idsr);
                MySqlDataReader sdr = cmd.ExecuteReader();


                if (sdr.Read())
                {
                    description = sdr["description"].ToString();
                  

                }
                sdr.Close();

                return description;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                db.CloseConnection();
            }
            return description;
        }

        public List<ServiceRequestModel> loadUserServiceRequest(string email)
        {

            List<ServiceRequestModel> ServiceRequestModelList = new List<ServiceRequestModel>();
            try
            {

                MySqlConnection sqlcon = db.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("sp_User_ServiceRequest", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("spemail", email);
                MySqlDataReader sdr = cmd.ExecuteReader();


                while (sdr.Read())
                {
                    ServiceRequestModel sr = new ServiceRequestModel();
                    sr.idsr = sdr["idsr"].ToString();
                   
                    sr.title = sdr["title"].ToString();
                    sr.category = sdr["category"].ToString();
                    sr.subCategory = sdr["sub_category"].ToString();

                    sr.priority = sdr["priority"].ToString();
                    sr.status = sdr["status"].ToString();
                    ServiceRequestModelList.Add(sr);

                }
                sdr.Close();



            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                db.CloseConnection();
            }
            return ServiceRequestModelList;
        }


        //for saving service request in db

        public bool saveServiceRequest(ServiceRequestModel objsr)
        {

            bool Inserted = false;
               try
            {

                MySqlConnection sqlcon = db.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("sp_saveServiceRequest", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                

                cmd.Parameters.AddWithValue("spidsr", objsr.idsr);
                cmd.Parameters.AddWithValue("spemail", objsr.emailId);
                cmd.Parameters.AddWithValue("sptitle", objsr.title);
                cmd.Parameters.AddWithValue("spcategory", objsr.category);
                cmd.Parameters.AddWithValue("spsubcategory", objsr.subCategory);
                cmd.Parameters.AddWithValue("sppriority", objsr.priority);
                cmd.Parameters.AddWithValue("spdescription", objsr.description);
               
                int rowInserted = cmd.ExecuteNonQuery();

                if (rowInserted > 0)
                {
                    Inserted = true;
                }

               



            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                db.CloseConnection();
            }
            return Inserted;
        }

    }
}