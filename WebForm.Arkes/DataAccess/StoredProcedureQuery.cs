using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebForm.Arkes.Dtos;

namespace WebForm.Arkes.DataAccess
{
    public class StoredProcedureQuery
    {

        public Result RunStoredProsedureForListQuery(string spName)
        {
            Result result = new Result();
            DataTable resultOfObject = new DataTable();

            try
            {
                using (SqlConnection baglanti = new SqlConnection(DataBaseConnectionString.GetConnectionString()))
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand(spName, baglanti);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(resultOfObject);
                    baglanti.Close();
                    baglanti.Dispose();
                    result.IsSuccess = true;
                    result.Data = resultOfObject;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }


        public Result RunStoredProsedureForListQueryWithParameter(string spName, List<StoredProcedureParameterDto> parameters)
        {
            Result result = new Result();
            DataTable resultOfObject = new DataTable();

            try
            {
                using (SqlConnection baglanti = new SqlConnection(DataBaseConnectionString.GetConnectionString()))
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand(spName, baglanti);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.ParameterName, item.Value);
                    }
                    da.Fill(resultOfObject);
                    baglanti.Close();
                    baglanti.Dispose();
                    result.IsSuccess = true;
                    result.Data = resultOfObject;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}