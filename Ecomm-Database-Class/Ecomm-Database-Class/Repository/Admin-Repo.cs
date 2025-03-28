﻿using System.Collections.Generic;
using System.Data;
using Ecomm_Database_Class.Data;

namespace Ecomm_Database_Class.Repository
{
    public class AdminRepo
    {
        public int InsertAdmin(AdminTable1 admin)
        {

            string query = "INSERT INTO AdminTable1 (Name, Role) VALUES (@Name, @Role)";
            nameValuePairList parameters = new nameValuePairList
                {
                    new nameValuePair("Name", admin.Name),
                    new nameValuePair("Role", admin.Role)
                };

            DB1 db = new DB1();
            return db.InsertUpdateOrDelete(query, parameters);
        }

        public AdminTable1 GetAdminById(int adminId)
        {
            string query = "SELECT * FROM AdminTable1 WHERE AdminID = @AdminID";
            nameValuePairList parameters = new nameValuePairList
                {
                    new nameValuePair("AdminID", adminId)
                };

            DB1 db = new DB1();
            DataTable dataTable = db.FillAndReturnDataSet(query, parameters);

            return ConvertDataTableToAdmin(dataTable);
        }

        public int UpdateAdmin(AdminTable1 admin)
        {
            string query = "UPDATE AdminTable1 SET Name = @Name, Role =@Role WHERE AdminID =@id";
            nameValuePairList parameters = new nameValuePairList
                {
                    new nameValuePair("@Name", admin.Name),
                    new nameValuePair("@Role", admin.Role),
                    new nameValuePair("@id", admin.AdminID)

                };

            DB1 db = new DB1();
            return db.InsertUpdateOrDelete(query, parameters);
        }

        public int DeleteAdmin(int adminId)
        {
            string query = "DELETE FROM AdminTable1 WHERE AdminID = @AdminID";
            nameValuePairList parameters = new nameValuePairList
                {
                    new nameValuePair("AdminID", adminId)
                };

            DB1 db = new DB1();
            return db.InsertUpdateOrDelete(query, parameters);
        }

        private AdminTable1 ConvertDataTableToAdmin(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
                return null;

            DataRow row = dataTable.Rows[0];
            AdminTable1 admin = new AdminTable1
            {
                AdminID = Convert.ToInt32(row["AdminID"]),
                Name = row["Name"].ToString(),
                Role = row["Role"].ToString()
            };

            return admin;
        }
    }
}