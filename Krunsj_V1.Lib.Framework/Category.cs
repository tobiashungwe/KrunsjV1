using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Krunsj_V1.Lib.Framework
{
    public class Category
    {


        #region Fields,Types
        public enum category { Materiaal, Leeftijd, Thema, Terein, Duur, SoortSpel, Vakanties, Varia };


        #endregion






        #region Properties



        private string categoryName;


        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        private int totalCategories;

        public int TotalCategories
        {
            get
            {
                return totalCategories = Enum.GetNames(typeof(category)).Length;
            }

        }

        private bool checkState;

        public bool CheckState
        {
            get { return checkState; }
            set { checkState = value; }
        }

        private int binaryCheckState;

        public int BinaryCheckState
        {
            get { return binaryCheckState; }
            set { binaryCheckState = value; }
        }

        private int catagoryID;

        public int CatagoryId
        {
            get { return catagoryID; }
            set { catagoryID = value; }
        }

        private StackPanel cookieName;

        public StackPanel CookieName
        {
            get { return cookieName; }
            set { cookieName = value; }
        }


        private List<StackPanel> cookies = new List<StackPanel>();

        public List<StackPanel> Cookies
        {
            get { return cookies; }
            set { cookies = value; }
        }


        #region Constructor(s)

        public Category()
        {
        }
        public Category(int catagoryId , bool checkState , int binaryCheckState , StackPanel cookieName)
        {
            this.catagoryID = catagoryId;
            this.categoryName = GetCategory(catagoryId);
            this.checkState = checkState;
            this.binaryCheckState = binaryCheckState;
            this.cookieName = cookieName;
        }




        #endregion


        //public  Thickness Margin { get; set; }

        #endregion

        #region ClassMethods
        public override string ToString()
        {
            return $"CategoryId: {this.catagoryID} Category Name: {this.categoryName} CheckState: {this.checkState} BinaryCheckState: {this.binaryCheckState} ObjectName: {this.cookieName}";
        }

        public string GetCategory(int index)
        {
            string[] categoryNames = Enum.GetNames(typeof(Category.category));
            string categoryName = categoryNames[index];
            return categoryName;
        }
        

        #endregion

    }
}
