using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Insert
{
    public class ShowcaseInsertData : DataAccessBase
    {
        private int _productId;
        private int _pageId;
        private ShowcaseInsertDataParameters _showcaseInsertDataParameters;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        
        public int PageId
        {
            get { return _pageId; }
            set { _pageId = value; }
        }

        public ShowcaseInsertDataParameters ShowcaseInsertDataParameters
        {
            get { return _showcaseInsertDataParameters; }
            set { _showcaseInsertDataParameters = value; }
        }

        public ShowcaseInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Showcase_Insert.ToString();
        }

        public void Add()
        {
            _showcaseInsertDataParameters = new ShowcaseInsertDataParameters(PageId, ProductId);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Parameters = _showcaseInsertDataParameters.Parameters;
            dbHelper.Run();
        }
    }

    public class ShowcaseInsertDataParameters
    {
        private SqlParameter[] _parameters;
        private int _productId;
        private int _pageId;
        
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public int PageId
        {
            get { return _pageId; }
            set { _pageId = value; }
        }
        
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ShowcaseInsertDataParameters(int pageId, int productId)
        {
            this.ProductId = productId;
            this.PageId = pageId;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = {new SqlParameter("@PageId", PageId),
                                        new SqlParameter("@ProductId", ProductId)};

            Parameters = parameters;
        }
    }
}
