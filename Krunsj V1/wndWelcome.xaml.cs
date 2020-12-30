using DevExpress.Xpf.Core;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using wpf = System.Windows.Forms;
using System;


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

        public wndWelcome(Mainwindow main)
        {
            this.main = main;
            
        }

        #region Declarations
        
        private string startUpmessage;
        private string instructions;
        private string settingUpPathMessage;
        private string userName;
        private string organisation;
        Officiallogin login;
        private (bool, int) firstBtnChecked = (false , 1);
        private (bool, int) secondBtnChecked = (false, 2);
        private (bool, int) thirdBtnChecked = (false, 3);
        private int counter;
        private bool IsValidPathFilled;
        private string folderName;
        private Mainwindow main;

        #endregion

        #region Methodes
        private void FillTextboxes(bool isChecked, int rdoID)
        {
            if (isChecked == true)
            {
                switch (rdoID)
                {
                    case 1:

                        //Settings visibility on
                        imgHeader.Visibility = Visibility.Visible;


                        //settings visibility off
                        imgExample.Visibility = Visibility.Collapsed;
                        imgOrganisation.Visibility = Visibility.Collapsed;
                        txtUserPathInput.Visibility = Visibility.Collapsed;
                        btnBrowse.Visibility = Visibility.Collapsed;

                        txtBlockInformation.Text = startUpmessage;
                        break;


                    case 2:

                        //Settings visibility on
                        imgExample.Visibility = Visibility.Visible;

                        //settings visibility off
                        imgHeader.Visibility = Visibility.Collapsed;
                        imgOrganisation.Visibility = Visibility.Collapsed;
                        txtUserPathInput.Visibility = Visibility.Collapsed;
                        btnBrowse.Visibility = Visibility.Collapsed;

                        instructions = $"Hoe werkt het:" +
                                              $"\n 1) Bij het maken van je spelletjes is het handig om een sjabloon van de categorizer \n te maken op het einde van je document." +
                                              $"\n 2) Daarna schrijf je de subcategoriën als een hashtag in de sjabloon." +
                                              $"\n 3) Als je alle spelletjes hebt staan op je computer zonder sjabloon zal de applicatie niet werken." +
                                              $"\n" +
                                              $"\n Tip: Bij het maken van je nieuwe spelen is het slim om het sjabloon er direct in te voegen \n dan hoeft dit later niet te gebeuren.";

                        txtBlockInformation.Text = instructions;
                        break;

                    case 3:

                        //Settings visibility on
                        imgOrganisation.Visibility = Visibility.Visible;
                        txtUserPathInput.Visibility = Visibility.Visible;
                        btnBrowse.Visibility = Visibility.Visible;

                        //settings visibility off
                        imgHeader.Visibility = Visibility.Collapsed;
                        imgExample.Visibility = Visibility.Collapsed;

                        settingUpPathMessage = $"We kunnen bijna naar de app, voor dat we verder kunnen heb ik een locatie nodig waar " +
                                               $"\n vermodelijk alle spelletjes in zullen zitten dit kan bv: documenten zijn " +
                                               $"\n" +
                                               $"\n Alle documenten die in subfolders zitten uit de gesecteerde folder worden allemaal gezocht";
                        txtBlockInformation.Text = settingUpPathMessage;
                        break;


                    default:
                        break;


                }
            }


        }

        #endregion

        #region Eventhandelers

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {

            using (wpf.FolderBrowserDialog fbd = new wpf.FolderBrowserDialog() { Description = "Selecteer de hoofdfolder van je spelletjes" })
            {
                if (fbd.ShowDialog() == wpf.DialogResult.OK)
                {

                    folderName = fbd.SelectedPath;
                    txtUserPathInput.Text = folderName;
                }
            }
        }

        private void rdoFirstScreen_Loaded(object sender, RoutedEventArgs e)
        {
            
            foreach (RadioButton radioButton in FindVisualChildren<RadioButton>(wndUserSettings))
            {
                
            }
        }

        private void wndUserSettings_MouseMove(object sender, MouseEventArgs e)
        {

            //Configuration for first radiobutton
            if (firstBtnChecked.Item1 == true)
            {

                rdoFirstScreen.IsChecked = true;
                FillTextboxes(firstBtnChecked.Item1, firstBtnChecked.Item2);
            }
            else
            {
                rdoFirstScreen.IsChecked = false;
                FillTextboxes(firstBtnChecked.Item1, firstBtnChecked.Item2);
            }

            //Configuration for second radiobutton
            if (secondBtnChecked.Item1 == true)
            {
                rdoSecondScreen.IsChecked = true;
                FillTextboxes(secondBtnChecked.Item1, secondBtnChecked.Item2);

            }
            else
            {
                rdoSecondScreen.IsChecked = false;
                FillTextboxes(secondBtnChecked.Item1, secondBtnChecked.Item2);
            }

            //Configuration for third radiobutton
            if (thirdBtnChecked.Item1 == true)
            {
                rdoThirdScreen.IsChecked = true;
                FillTextboxes(thirdBtnChecked.Item1, thirdBtnChecked.Item2);

            }
            else
            {
                rdoThirdScreen.IsChecked = false;
                FillTextboxes(thirdBtnChecked.Item1, thirdBtnChecked.Item2);
            }

            if (txtUserPathInput.Text != "Selecteer map met alle spelletjes bv: documenten\r\n\r\n")
            {
                IsValidPathFilled = true;
            }
            else
            {
                IsValidPathFilled = false;
            }

            if (rdoThirdScreen.IsChecked == true && IsValidPathFilled == true)
            {
                btnContinue.IsEnabled = true;
            }
            else
            {
                btnContinue.IsEnabled = false;
            }
           

        }

        private void rdoFirstScreen_Checked(object sender, RoutedEventArgs e)
        {
            firstBtnChecked.Item1 = true;
            //setting up counter
            counter++;
        }

        private void rdoSecondScreen_Checked(object sender, RoutedEventArgs e)
        {
            secondBtnChecked.Item1 = true;
            //setting up counter
            counter++;
        }

        private void rdoThirdScreen_Checked(object sender, RoutedEventArgs e)
        {
            thirdBtnChecked.Item1 = true;
            //setting up counter
            counter++;

        }

        private void rdoFirstScreen_Unchecked(object sender, RoutedEventArgs e)
        {
            firstBtnChecked.Item1 = false;
        }

        private void rdoSecondScreen_Unchecked(object sender, RoutedEventArgs e)
        {
            secondBtnChecked.Item1 = false;
        }
        private void rdoThirdScreen_Unchecked(object sender, RoutedEventArgs e)
        {
            thirdBtnChecked.Item1 = false;
        }
        private void wndUserSettings_Loaded_1(object sender, RoutedEventArgs e)
        {
            //startup settings 
            btnContinue.IsEnabled = false;
            //Settings visibility on
            imgHeader.Visibility = Visibility.Visible;


            //settings visibility off
            imgExample.Visibility = Visibility.Collapsed;
            imgOrganisation.Visibility = Visibility.Collapsed;
            txtUserPathInput.Visibility = Visibility.Collapsed;
            btnBrowse.Visibility = Visibility.Collapsed;

            bool messageIsVisible = false;

            //if (!String.IsNullOrEmpty(login.UserName))
            //{
            while (messageIsVisible == false)
            {
                if (messageIsVisible == false)
                {
                    /*Organisatie kan hier staan voor in de toekomst*/
                    organisation = "Krunsj";
                    userName = "Unkown";

                    startUpmessage = $"Welcome {/*login.UserName*/ userName } to de {organisation} catagorizer! " +
                                 $"\n Deze applicatie zoekt alle spelletjes die je kan spelen in een jeugdwerking op je computer." +
                                 $"\n De applicatie kan deze spelletjes ook filteren op basis van een bepaalde category. " +
                                 $"\n Zoeken, Editen en Filteren gemakkelijk gemaakt door de Categorizer";

                    txtBlockInformation.Text = startUpmessage;
                    txtBlockInformation.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
                    txtBlockInformation.Width = System.Windows.SystemParameters.PrimaryScreenWidth;



                    firstBtnChecked.Item1 = true;
                    //After this line end unreadable code
                    messageIsVisible = true; //this is the return kind of

                }
                else
                {
                    break;
                }
                //}

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

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            
           wndUserSettings.Visibility = Visibility.Collapsed;
           // System.Windows.Application.Current.MainWindow.Visibility = Visibility.Visible;
            //System.Windows.Application.Current.MainWindow.IsEnabled = true;
            Mainwindow mainwindow = new Mainwindow(true);
            mainwindow.IsEnabled = true;
            mainwindow.ShowDialog();







        }
    }
      

      
      
      
      

      
      
      
      

      
      
      

      

      
      
      
      

      
      
      
      
      
      
      
      

      
    


}





