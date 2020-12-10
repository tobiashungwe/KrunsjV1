using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krunsj_V1.Lib.Framework
{
    public class Subcatagory
    {

        private string subcatagoryName;

        public string SubcatagoryName
        {
            get { return subcatagoryName; }
            set { subcatagoryName = value; }
        }

        private int subcatagoryID;

        public int SubcatagoryID
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


        public Subcatagory(int subcatagoryID, string subcatagoryName/*, bool isChecked */)
        {
            this.subcatagoryID = subcatagoryID;
            this.subcatagoryName = subcatagoryName;
            //this.isChecked = isChecked;
        }

    }
}
