using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Entity
{
    public class MainManager
    {
        //constructor
        private MainManager() { }

        // Singleton variable
        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance
        {
            get { return instance; }
        }


        // Instance of product
        // Because of it I can access to its function
        public ProductManager product = new ProductManager();

        // Instance of message
        // Because of it I can access to its function
        public MessageManager message = new MessageManager();

    }
}
