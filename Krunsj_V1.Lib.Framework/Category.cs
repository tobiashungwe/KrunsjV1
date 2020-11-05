using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Krunsj_V1.Lib.Framework
{
    public class Category 
    {
        //Fields
        private string categoryName;
        private bool checkState;
        private int binaryCheckState;
        private int catagoryID;
        private object objectName;

        //Properties

        public  Thickness Margin { get; set; }

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        public bool CheckState
        {
            get { return checkState; }
            set { checkState = value; }
        }

        public int BinaryCheckState
        {
            get { return binaryCheckState; }
            set { binaryCheckState = value; }
        }

        

        public int CatagoryId
        {
            get { return catagoryID; }
            set { catagoryID = value; }
        }

        

        public object ObjectName
        {
            get { return objectName; }
            set { objectName = value; }
        }


        private object[] cookies = new object[7];

        public override string ToString()
        {
            return $"Category Name: {CategoryName} CheckState: {CheckState} BinaryCheckState: {BinaryCheckState} Object Name: {ObjectName}";
        }



       
        /*
        public void AddCategory()
        {
            foreach (string category in CategoryNames)
            {
                cookieNames.Add(CategoryName = category);
            }

        }
        */
    }
}
