using sagar.mobile.shopy.business.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sagar.mobile.shopy.business.Repository
{
    public class PurchaseRepository
    {
        SqlConnection _conn = null;
        SqlCommand _cmd = null;

        void Connection()
        {
            string _conStr = ConfigurationManager.ConnectionStrings["MobileShopy"].ToString();

            _conn = new SqlConnection(_conStr);
        }

        void Command(string sqlQuery)
        {
             _cmd = new SqlCommand(sqlQuery, _conn);
        }



        public List<Purchase> PurchaseGetList()
        {

            try
            {
                List<Purchase> purchaseList = null;
                Connection();

                string sqlQuery = @"
                                     select * from smobileshopy_purchase order by id desc
                                    ";

                Command(sqlQuery);


                _conn.Open();
                SqlDataReader dr = _cmd.ExecuteReader();

                purchaseList = new List<Purchase>();

                while (dr.Read())
                {
                    Purchase purchaseObj = new Purchase();

                    purchaseObj.id =  Convert.ToInt32(dr["id"]);
                    purchaseObj.company_name =  Convert.ToString(dr["company_name"]);
                    purchaseObj.model_no =  Convert.ToString(dr["model_no"]);
                    purchaseObj.imei_no =  Convert.ToString(dr["imei_no"]);
                    purchaseObj.features =  Convert.ToString(dr["features"]);
                    purchaseObj.warranty =  Convert.ToInt32(dr["warranty"]);
                    purchaseObj.qty =  Convert.ToInt32(dr["qty"]);
                    purchaseObj.purchase_price =  Convert.ToSingle(dr["purchase_price"]);
                    purchaseObj.sale_price =  Convert.ToSingle(dr["sale_price"]);
                    purchaseObj.total =  Convert.ToInt32(dr["total"]);
            
                    purchaseList.Add(purchaseObj);
                }

                return purchaseList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }


        public bool PurchaseAdd(Purchase purchase)
        {
   
            try
            {
                Connection();

                string sqlQuery = @"
                                     insert into smobileshopy_purchase 
                                     values(
                                            @company_name,
                                            @model_no,
                                            @imei_no,
                                            @features,
                                            @warranty,
                                            @qty,
                                            @purchase_price,
                                            @sale_price,
                                            @total
                                           )
                                    ";

                Command(sqlQuery);

                _cmd.Parameters.AddWithValue("@company_name",purchase.company_name);
                _cmd.Parameters.AddWithValue("@model_no", purchase.model_no);
                _cmd.Parameters.AddWithValue("@imei_no", purchase.imei_no);
                _cmd.Parameters.AddWithValue("@features", purchase.features);
                _cmd.Parameters.AddWithValue("@warranty", purchase.warranty);
                _cmd.Parameters.AddWithValue("@qty", purchase.qty);
                _cmd.Parameters.AddWithValue("@purchase_price", purchase.purchase_price);
                _cmd.Parameters.AddWithValue("@sale_price", purchase.sale_price);                
                _cmd.Parameters.AddWithValue("@total", purchase.total);

                _conn.Open();
                int result = _cmd.ExecuteNonQuery();

                return result >= 1 ? true : false; 
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
         }

        public bool PurchaseUpdate(Purchase purchase)
        {

            try
            {
                Connection();

                string sqlQuery = @"
                                     update  smobileshopy_purchase set
                                     
                                       company_name    =   @company_name,
                                       model_no        =   @model_no,
                                       imei_no         =   @imei_no,
                                       features        =   @features,
                                       warranty        =   @warranty,
                                       qty             =   @qty,
                                       purchase_price  =   @purchase_price,
                                       sale_price      =   @sale_price,
                                       total           =   @total
                                       
                                      where id = @id
                                    ";

                Command(sqlQuery);

                _cmd.Parameters.AddWithValue("@id", purchase.id);
                _cmd.Parameters.AddWithValue("@company_name", purchase.company_name);
                _cmd.Parameters.AddWithValue("@model_no", purchase.model_no);
                _cmd.Parameters.AddWithValue("@imei_no", purchase.imei_no);
                _cmd.Parameters.AddWithValue("@features", purchase.features);
                _cmd.Parameters.AddWithValue("@warranty", purchase.warranty);
                _cmd.Parameters.AddWithValue("@qty", purchase.qty);
                _cmd.Parameters.AddWithValue("@purchase_price", purchase.purchase_price);
                _cmd.Parameters.AddWithValue("@sale_price", purchase.sale_price);                
                _cmd.Parameters.AddWithValue("@total", purchase.total);

                _conn.Open();
                int result = _cmd.ExecuteNonQuery();

                return result >= 1 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public bool PurchaseDelete(int purchaseId)
        {

            try
            {
                Connection();

                string sqlQuery = @"
                                     delete from smobileshopy_purchase where id = @id
                                    ";

                Command(sqlQuery);

                _cmd.Parameters.AddWithValue("@id", purchaseId);

                _conn.Open();
                int result = _cmd.ExecuteNonQuery();

                return result >= 1 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }


            


    }
}
