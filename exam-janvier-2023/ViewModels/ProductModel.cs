using exam_janvier_2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_janvier_2023.ViewModels
{
    public class ProductModel
    {
        private readonly Product _product;

        public ProductModel(Product product)
        { 
            this._product = product;
        }

        public int ProductId
        {
            get { return _product.ProductId; }
        }

        public string ProductName 
        {
            get { return _product.ProductName; }
        }

        public string Category
        {
            get { return _product.Category.CategoryName; }
        }

        public string ContactName
        {
            get { return _product.Supplier.ContactName; }
        }
    }
}
