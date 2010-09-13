using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class Showcase
    {
        public Showcase()
        { }

        private int _showcaseId;
        private Collection<Product> _product;
        private string _showcaseName;

        public int ShowcaseId
        {
            get { return _showcaseId; }
            set { _showcaseId = value; }
        }

        public string ShowcaseName
        {
            get { return _showcaseName; }
            set { _showcaseName = value; }
        }

        public Collection<Product> Product
        {
            get { return _product; }
            set { _product = value; }
        }
    }
}
