using exam_janvier_2023.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace exam_janvier_2023.ViewModels
{
    public class ProductVM : INotifyPropertyChanged
    {
        private NorthwindContext dc = new NorthwindContext();
        private ObservableCollection<ProductModel> _productList;
        private List<ProductCountByCountry> _productCountByCountry;
        private ProductModel _product;
        private DelegateCommand _markAsDiscontinuedCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<ProductModel> ProductList
        {
            get { return _productList = _productList ?? loadProducts(); }
        }

        public ObservableCollection<ProductModel> loadProducts()
        {
            ObservableCollection<ProductModel> products = new ObservableCollection<ProductModel>();

            foreach (var product in dc.Products.Where(p => p.Discontinued == false))
            {
                products.Add(new ProductModel(product));
            }

            return products;
        }

        public List<ProductCountByCountry> ProductCountByCountry
        {
            get { return _productCountByCountry = _productCountByCountry ?? loadProductCountByCountry(); }
        }

        public List<ProductCountByCountry> loadProductCountByCountry()
        {
            List<ProductCountByCountry> productsCountByCountry = new List<ProductCountByCountry>();

            var productCountsByCountry = from orderDetail in dc.OrderDetails
                                         group orderDetail.ProductId by orderDetail.Product.Supplier.Country into countryGroup
                                         orderby countryGroup.Count() descending
                                         select new
                                         {
                                             Country = countryGroup.Key,
                                             ProductCount = countryGroup.Distinct().Count()
                                         };

            foreach (var country in productCountsByCountry)
            {
                productsCountByCountry.Add(new ProductCountByCountry(country.Country, country.ProductCount));
            }

            return productsCountByCountry;
        }

        public ProductModel SelectedProduct
        {
            get { return _product; }
            set { _product = value; OnPropertyChanged("SelectedProduct"); }
        }

        public DelegateCommand MarkAsDiscontinuedCommand
        {
            get { return _markAsDiscontinuedCommand = _markAsDiscontinuedCommand ?? new DelegateCommand(MarkAsDiscontinued); }
        }

        private void MarkAsDiscontinued()
        {
            if (SelectedProduct == null)
            {
                MessageBox.Show("Aucun produit sélectionné.");
                return;
            }

            Product existingProduct = dc.Products.FirstOrDefault(p => p.ProductId == SelectedProduct.ProductId && !p.Discontinued);

            if (existingProduct != null)
            {
                existingProduct.Discontinued = true;
                dc.SaveChanges();
                ProductList.Remove(SelectedProduct);
                OnPropertyChanged("ProductList");

                MessageBox.Show("Le produit a été abandonné");
            }
            else
            {
                MessageBox.Show("Erreur : Le produit n'existe pas ou est déjà discontinué.");
            }
        }
    }
}
