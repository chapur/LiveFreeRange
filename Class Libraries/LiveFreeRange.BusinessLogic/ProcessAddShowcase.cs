using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Insert;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessAddShowcase : IBusinessLogic
    {
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

        public ProcessAddShowcase()
        { 
        
        }

        public void Invoke()
        {
            ShowcaseInsertData showcaseData = new ShowcaseInsertData();
            showcaseData.ProductId = this.ProductId;
            showcaseData.PageId = this.PageId;
            showcaseData.Add();
        }
    }
}
