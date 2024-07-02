using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebForm.Arkes.Dtos;

namespace WebForm.Arkes.DataAccess
{
    public class StoredProcedureCommand
    {

        public Result RunStoredProsedure(string spName)
        {
            Result result = new Result();

            try
            {
                using (SqlConnection baglanti = new SqlConnection(DataBaseConnectionString.GetConnectionString()))
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand(spName, baglanti);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int val = cmd.ExecuteNonQuery();
                    baglanti.Close();
                    baglanti.Dispose();
                    result.IsSuccess = true;
                    result.Data = val;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public Result RunStoredProsedureWithParameter(string spName, List<StoredProcedureParameterDto> parameters)
        {
            Result result = new Result();

            try
            {
                using (SqlConnection baglanti = new SqlConnection(DataBaseConnectionString.GetConnectionString()))
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand(spName, baglanti);
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.ParameterName, item.Value);
                    }

                    int val = cmd.ExecuteNonQuery();
                    baglanti.Close();
                    baglanti.Dispose();
                    result.IsSuccess = true;
                    result.Data = val;
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