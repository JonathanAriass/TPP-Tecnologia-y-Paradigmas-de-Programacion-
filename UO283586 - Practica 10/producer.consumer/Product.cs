using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPP.Laboratory.Concurrency.Lab10
{

    class Product {

        public int ProductID { get; private set; }

        public Product(int productID) {
            this.ProductID = productID;
        }

        public override string ToString() {
            return String.Format("Product {0}", this.ProductID);
        }
    }
}
