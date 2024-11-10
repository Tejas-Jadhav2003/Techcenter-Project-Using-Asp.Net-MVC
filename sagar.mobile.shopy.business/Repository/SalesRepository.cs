using sagar.mobile.shopy.business.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sagar.mobile.shopy.business.Repository
{
    public class SalesRepository
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

        public List<Purchase> GetIMEIData(string imei)
        {

            try
            {
                List<Purchase> searchList = null;
                Connection();

                string sqlQuery = @"                                    
                                    select * from smobileshopy_purchase where imei_no = @imei_no
                                    ";

                Command(sqlQuery);

                _cmd.Parameters.AddWithValue("@imei_no", imei);

                _conn.Open();
                SqlDataReader dr = _cmd.ExecuteReader();
                searchList = new List<Purchase>();

                while (dr.Read())
                {
                    Purchase searchObj = new Purchase();

                    searchObj.company_name = Convert.ToString(dr["company_name"]);
                    searchObj.model_no = Convert.ToString(dr["model_no"]);
                    searchObj.imei_no = Convert.ToString(dr["imei_no"]);
                    searchObj.warranty = Convert.ToInt32(dr["warranty"]);
                    searchObj.qty = Convert.ToInt32(dr["qty"]);
                    searchObj.sale_price = Convert.ToSingle(dr["sale_price"]);
                    searchList.Add(searchObj);
                }

                return searchList;

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

        public List<Purchase> GetCompanyData(string company)
        {

            try
            {
                List<Purchase> searchList = null;
                Connection();

                string sqlQuery = @"                                    
                                    SELECT * FROM smobileshopy_purchase WHERE company_name= @company_name;
                                    ";

                Command(sqlQuery);

                _cmd.Parameters.AddWithValue("@company_name", company);

                _conn.Open();
                SqlDataReader dr = _cmd.ExecuteReader();
                searchList = new List<Purchase>();

                while (dr.Read())
                {
                    Purchase searchObj = new Purchase();
                    
                    searchObj.id = Convert.ToInt32(dr["id"]);
                    searchObj.company_name = Convert.ToString(dr["company_name"]);
                    searchObj.company_name = Convert.ToString(dr["company_name"]);
                    searchObj.model_no = Convert.ToString(dr["model_no"]);
                    searchObj.imei_no = Convert.ToString(dr["imei_no"]);
                    searchObj.warranty = Convert.ToInt32(dr["warranty"]);
                    searchObj.qty = Convert.ToInt32(dr["qty"]);
                    searchObj.sale_price = Convert.ToSingle(dr["sale_price"]);
                    searchList.Add(searchObj);
                }

                return searchList;

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

        public List<Purchase> GetModelData(string Model)
        {

            try
            {
                List<Purchase> searchList = null;
                Connection();

                string sqlQuery = @"                                    
                                    SELECT * FROM smobileshopy_purchase WHERE model_no = @model_no;
                                    ";

                Command(sqlQuery);

                _cmd.Parameters.AddWithValue("@model_no", Model);

                _conn.Open();
                SqlDataReader dr = _cmd.ExecuteReader();
                searchList = new List<Purchase>();

                while (dr.Read())
                {
                    Purchase searchObj = new Purchase();

                    searchObj.id = Convert.ToInt32(dr["id"]);
                    searchObj.company_name = Convert.ToString(dr["company_name"]);
                    searchObj.model_no = Convert.ToString(dr["model_no"]);
                    searchObj.imei_no = Convert.ToString(dr["imei_no"]);
                    searchObj.warranty = Convert.ToInt32(dr["warranty"]);
                    searchObj.qty = Convert.ToInt32(dr["qty"]);
                    searchObj.sale_price = Convert.ToSingle(dr["sale_price"]);
                    searchList.Add(searchObj);
                }

                return searchList;

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


        public string GenerateBillNo()
        {
            string billNo = string.Empty;
            try
            {
                List<Purchase> searchList = null;
                Connection();

                string sqlQuery = @"                                    
                                     SELECT 
                                         CASE 
                                             WHEN (SELECT COUNT(*) FROM Bills) > 0 
                                     		THEN  CONCAT('SAGAR000', (SELECT MAX(bill_id) + 1 FROM Bills),'_', FORMAT(GETDATE(),'yyyy'))
                                             ELSE  CONCAT('SAGAR0001_' , FORMAT(GETDATE(),'yyyy'))
                                         END AS GeneratedBillNumber;
                                    ";

                Command(sqlQuery);

                _conn.Open();
                SqlDataReader dr = _cmd.ExecuteReader();

                while (dr.Read())
                {
                    billNo = dr["GeneratedBillNumber"].ToString();
                    break;
                }

                return billNo;
            }
            catch (Exception  ex)
            {
                throw ex;
            }
            finally
            {
                _conn.Close();
            }
        }


        public bool AddBill(Bill bill)
        {
            bill.billNo = GenerateBillNo();
            try
            {
                Connection();

                string sqlQuery = @"
                                     insert into Bills 
                                     values(
                                            @bill_no,
                                            @customer_name,
                                            @address,
                                            @sub_total,
                                            @gst,
                                            @total,
                                            @date
                                          );

                                         SELECT SCOPE_IDENTITY();
                                    ";

                Command(sqlQuery);


                _cmd.Parameters.AddWithValue("@bill_no", bill.billNo);
                _cmd.Parameters.AddWithValue("@customer_name", bill.customerName);
                _cmd.Parameters.AddWithValue("@address", bill.address);
                _cmd.Parameters.AddWithValue("@sub_total", bill.subTotal);
                _cmd.Parameters.AddWithValue("@gst", bill.gst);
                _cmd.Parameters.AddWithValue("@total", bill.total);
                _cmd.Parameters.AddWithValue("@date", bill.date);



                _conn.Open();

                int billId = Convert.ToInt32(_cmd.ExecuteScalar());

                AddProductBill(bill.productBills, billId);

                return true;
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
        public void AddProductBill(List<ProductBill> productBills, int billId)
        {

            try
            {
                Connection();

                string sqlQuery = @"
                                     insert into product_bill 
                                     values(
                                            @price,
                                            @qty,
                                            @warrenty,
                                            @total,
                                            @bill_id,
                                            @purchase_id
                                          );
                                    ";

                Command(sqlQuery);

                _conn.Open();

                foreach (var productBill in productBills)
                {
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@price", productBill.price);
                    _cmd.Parameters.AddWithValue("@qty", productBill.qty);
                    _cmd.Parameters.AddWithValue("@warrenty", productBill.warrenty);
                    _cmd.Parameters.AddWithValue("@total", productBill.total);
                    _cmd.Parameters.AddWithValue("@bill_id", billId);
                    _cmd.Parameters.AddWithValue("@purchase_id", productBill.purchaseId);

                    _cmd.ExecuteNonQuery();

                    UpdateProductQuntity(productBill.purchaseId, productBill.qty);
                }

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

        public bool UpdateProductQuntity(int purchaseId, int qty)
        {
            try
            {
                Connection();

                string sqlQuery = @"
                                    UPDATE smobileshopy_purchase
                                    SET qty = 
                                        CASE 
                                            WHEN qty >= @qty THEN qty - @qty
                                            ELSE qty
                                        END
                                    WHERE id = @id";

                Command(sqlQuery);

                _cmd.Parameters.AddWithValue("@qty", qty);
                _cmd.Parameters.AddWithValue("@id", purchaseId);

                _conn.Open();

                int rowsAffected = _cmd.ExecuteNonQuery();


                return true;
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
