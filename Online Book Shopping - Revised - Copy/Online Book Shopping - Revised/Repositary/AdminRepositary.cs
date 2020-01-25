using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Shopping___Revised.Repositary
{
    class AdminRepositary : Admin
    {

        static string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString; // Get Connection String From App.Config

        SqlConnection dbConnection = new SqlConnection(connection);
        
        public void addAdminIntoList()
        {
            string sqlQuery = "Select * From Admin";
            using (SqlCommand selectCommand = new SqlCommand(sqlQuery, dbConnection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = selectCommand;
                DataSet AdminDataset = new DataSet();
                adapter.Fill(AdminDataset, "Admin");
                DataTable AdminDataTable = AdminDataset.Tables["Admin"];
                foreach (DataRow row in AdminDataTable.Rows)
                {
                    Admin admin = new Admin
                    {
                        Name = row[0].ToString(),
                        UserName = row[1].ToString(),
                        MailId = row[2].ToString(),
                        PhoneNumber =double.Parse(row[3].ToString()),
                        Password = row[4].ToString(),
                        Role = row[5].ToString(),
                        AdminID = int.Parse(row[6].ToString())
                    };
                    AdminList.Add(admin.AdminID, admin);
                }
            };

        }

    }
}
