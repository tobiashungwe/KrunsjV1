using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krunsj_V1
{
    public class User
    {
        #region Properties
        
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Password { get; set; }

        #endregion

        #region Class methodes
      
        #endregion

        #region Constructors 
        public User(string username, string userpassword)
        {
            this.Name = username;
            this.Password = userpassword;

        }
       #endregion








    }
}
