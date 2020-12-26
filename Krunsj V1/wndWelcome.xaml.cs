using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;


namespace Krunsj_V1
{
    /// <summary>
    /// Interaction logic for wndWelcome.xaml
    /// </summary>
    public partial class wndWelcome : ThemedWindow
    {
        public wndWelcome()
        {
            InitializeComponent();
        }

        #region Declarations
        private string startUpmessge;
        private string userName;
        Officiallogin login;
        #endregion

        #region Methodes


        #endregion

        #region Eventhandelers
        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            bool messageIsVisible = false;
            //if (!String.IsNullOrEmpty(login.UserName))
            //{
            while (messageIsVisible == false)
            {
                if (messageIsVisible == false)
                {
                    StringBuilder sb = new StringBuilder();
                    /*Organisatie kan hier staan voor in de toekomst*/
                    string organisation = "Krunsj";
                    userName = "Unkown";
                    sb.Append($"Welcome {/*login.UserName*/ userName } to de {organisation} catagorizer!");
                    sb.Append("\n");
                    sb.Append("Deze applicatie zoekt alle spelletjes die je kan spelen in een jeugdwerking op je computer.");
                    sb.Append("\n");
                    sb.Append("De applicatie kan deze spelletjes ook filteren op basis van een bepaalde category");
                    sb.Append("\n");
                    sb.Append("Zoeken, Editen en Filteren gemakkelijk gemaakt door de Categorizer");
                    sb.Append("\n");
                    startUpmessge = sb.ToString();

                    txtBlockInformation.Text = startUpmessge;
                    txtBlockInformation.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
                    txtBlockInformation.Width = System.Windows.SystemParameters.PrimaryScreenWidth;

                    messageIsVisible = true;
                }
                else
                {
                    break;
                }
                //}

            }

        }

        private void rdoFirstScreen_Loaded(object sender, RoutedEventArgs e)
        {
            
            foreach (RadioButton radioButton in FindVisualChildren<RadioButton>(wndUserSettings))
            {
                
            }
        }
        #endregion


        /// <summary>
        /// I'm looking for a way to find all controls on Window by their type,
        /// 
        /// for example: find all TextBoxes, find all controls implementing specific interface etc.
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        #region IEnumerable (WIP)
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        #endregion

        private void wndUserSettings_Loaded_1(object sender, RoutedEventArgs e)
        {


            bool messageIsVisible = false;
            //if (!String.IsNullOrEmpty(login.UserName))
            //{
                while (messageIsVisible == false)
                {
                    if (messageIsVisible == false)
                    {
                        StringBuilder sb = new StringBuilder();
                        /*Organisatie kan hier staan voor in de toekomst*/
                        string organisation = "Krunsj";
                        userName = "Unkown";
                        sb.Append($"Welcome {/*login.UserName*/ userName } to de {organisation} catagorizer!");
                        sb.Append("Deze applicatie zoekt alle spelletjes die je kan spelen in een jeugdwerking op je computer.");
                        sb.Append("De applicatie kan deze spelletjes ook filteren op basis van een bepaalde category");
                        sb.Append("\n");
                        sb.Append("Zoeken, Editen en Filteren gemakkelijk gemaakt door de Categorizer");
                        sb.Append("\n");
                        startUpmessge = sb.ToString();

                        txtBlockInformation.Text = startUpmessge;
                   
                        messageIsVisible = true;
                    }
                    else
                    {
                        break;
                    }
                //}
               
            }
           
           
            
                
            
            


        }

        private void FillTextboxes(int wndState)
        {
            switch (wndState)
            {
                case 0:
                    
                    break;

                case 1:
                    break;
                case 2:
                    break; 
                default:
                    break;
            }
        }

        
    }



}

