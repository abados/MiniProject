using MiniProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace MiniProject.Entity
{
    public class MessageManager
    {

        public void SendNewInputToDataLayer(UserMessage data)
        {
            Data.Sql.Message message = new Data.Sql.Message();

            message.SendSqlQueryToInsertToDB(data);
            
        }
    }

}
