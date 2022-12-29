using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProject.Model;

namespace MiniProject.Data.Sql
{
    public class Message
    {
        UserMessage data = new UserMessage();
        public void SendSqlQueryToInsertToDB(UserMessage data)
        {
            string uploadMessageQuery = "insert into ContactUs values('" + data.name + "','" + data.message + "','" + data.cellPhone + "','" + data.email + "',getdate())";
            DAL.SqlQuery.Insert_Update_Delete_DataInDB(uploadMessageQuery);
            
        }
       

    }
}
