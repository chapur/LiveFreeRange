using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetProductByProductId : IBusinessLogic
    {
        private Product _product;
        private DataSet _resultset;
        private Collection<ProductSize> _productSize;

        public Collection<ProductSize> ProductSize
        {
            get { return _productSize; }
            set { _productSize = value; }
        }

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        private DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public ProcessGetProductByProductId()
        {

        }

        public void Invoke()
        {
            ProductSelectByProductIdData selectproduct = new ProductSelectByProductIdData();
            selectproduct.Product = Product;

            ResultSet = selectproduct.Get();

            //returned multiple productsize rows
            _productSize = new Collection<ProductSize>();

            foreach (DataRow dr in ResultSet.Tables[1].Rows)
                _productSize.Add(new ProductSize(dr));

            Product.Name = ResultSet.Tables[0].Rows[0]["ProductName"].ToString();
            Product.Description = ResultSet.Tables[0].Rows[0]["Description"].ToString();
            Product.Price = Convert.ToDecimal(ResultSet.Tables[0].Rows[0]["Price"].ToString());
            Product.ImageUrl = ResultSet.Tables[0].Rows[0]["ProductImageUrl"].ToString();
            Product.ImageId = Convert.ToInt32(ResultSet.Tables[0].Rows[0]["ProductImageId"]);
            Product.ProductCategory.ProductCategoryName = ResultSet.Tables[0].Rows[0]["ProductCategoryName"].ToString();
            Product.ProductCategoryId = Convert.ToInt32(ResultSet.Tables[0].Rows[0]["ProductCategoryId"]);
            Product.SubCategoryId = Convert.ToInt32(ResultSet.Tables[0].Rows[0]["SubCategoryId"]);
            Product.SubCategory.SubCategoryName = ResultSet.Tables[0].Rows[0]["SubCategoryName"].ToString();
            Product.SubCategory.SubCategoryDisplayName = ResultSet.Tables[0].Rows[0]["SubCategoryDisplayName"].ToString();
            Product.SubCategory.SubCategoryId = Convert.ToInt32(ResultSet.Tables[0].Rows[0]["SubCategoryId"]);
            Product.ProductColour.ProductColourName = ResultSet.Tables[0].Rows[0]["ProductColourName"].ToString();
            Product.ProductColour.ProductColourId = Convert.ToInt32(ResultSet.Tables[0].Rows[0]["ProductColourId"]);
            //Product.ProductSize.ProductSizeName = ResultSet.Tables[0].Rows[0]["ProductSizeName"].ToString();
            //Product.ProductSize.ProductSizeId = Convert.ToInt32(ResultSet.Tables[0].Rows[0]["ProductSizeId"]);
            Product.ProductWeight.ProductWeightName = ResultSet.Tables[0].Rows[0]["ProductWeightName"].ToString();
        }
    }
}
