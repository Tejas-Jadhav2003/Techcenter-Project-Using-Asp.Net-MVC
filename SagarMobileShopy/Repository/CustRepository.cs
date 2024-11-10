using SagarMobileShopy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SagarMobileShopy.Repository
{
    public class CustRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
        {
            DataSource = @"(localdb)\MSSQLLocalDB",
            InitialCatalog = "MobileShopy"
        };

        private void connection()
        {
            con = new SqlConnection(sConnB.ConnectionString);
        }

        public bool AddCustDetails(Registration obj)
        {
            connection();
            SqlCommand com = new SqlCommand("[dbo].[AddCustDetails]", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Contact", obj.Contact);
            com.Parameters.AddWithValue("@EmailId", obj.EmailId);
            com.Parameters.AddWithValue("@Password", obj.Password);            
            com.Parameters.AddWithValue("@Registered_Date", obj.Cust_RegisteredDate = DateTime.Now);            

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool CheckEmailIDIsExist(Registration obj)
        {
            connection();
            SqlCommand com = new SqlCommand(@"


SELECT 1
FROM [Registrations]
WHERE EmailID = @EmailID


 ", con);
            com.CommandType = CommandType.Text;
         
            com.Parameters.AddWithValue("@EmailID", obj.EmailId);
          
            con.Open();
            bool i = Convert.ToBoolean(com.ExecuteScalar());
            con.Close();
     
            return i;
        
        }


        public bool CustLogin(AdminLogin obj)
        {
            connection();
            SqlCommand com = new SqlCommand("select [dbo].[Login_Fun](@EmailId,@Password)", con);
            com.Parameters.AddWithValue("@EmailId", obj.A_UserName);
            com.Parameters.AddWithValue("@Password", obj.A_Password);

            con.Open();
            int i = (int)com.ExecuteScalar();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}