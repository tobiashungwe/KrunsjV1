using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krunsj_V1;

namespace Krunsj_V1.Lib.Framework
{
    public class Subcategory
    {
        
        private string subcategoryName;

        public string SubcategoryName
        {
            get { return subcategoryName; }
            set { subcategoryName = value; }
        }

        private int subcatagoryID;

        public int SubcategoryID
        {
            get { return subcatagoryID; }
            set { subcatagoryID = value; }
        }

        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }
        
        
        public Subcategory(int subcatagoryID, string subcatagoryName/*, bool isChecked */)
        {
            this.subcatagoryID = subcatagoryID;
            this.subcategoryName = subcatagoryName;

            //this.isChecked = isChecked;
        }

    }
}
