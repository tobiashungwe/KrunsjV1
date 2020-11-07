using Krunsj_V1.Lib.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using swf = System.Windows.Forms;
using System.Drawing.Text;
using System.Security.Cryptography;


namespace Krunsj_V1
{
    /// <summary>
    /// Interaction logic for Mainwindow.xaml
    /// </summary>
    public partial class Mainwindow : Window
    {
        public Mainwindow()
        {
            InitializeComponent();
            this.Visibility = Visibility.Hidden;

            Register Login = new Register();

            Officiallogin form = new Officiallogin();
            form.ShowDialog();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

        }



        #region declartions
        //default settings
        private int left;
        private int top;
        private string[] categoryNames = { "Materiaal", "Leeftijd", "Thema", "Terein", "Duur", "Soort Spel", "Vakanties" };
        private List<bool> categoryIsChecked = new List<bool>();
       
        private List<Category> cookieNames = new List<Category>();




        #endregion
        public Mainwindow(bool doNotMakeInvisibile)
        {

            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Normal;
            InitializeComponent();






        }

        #region Methodes

        private void Boot()
        {
            //Bootsettings
            stackMateriaal.Visibility = Visibility.Collapsed;
            stackLeeftijd.Visibility = Visibility.Collapsed;
            stackThema.Visibility = Visibility.Collapsed;
            stackTerein.Visibility = Visibility.Collapsed;
            stackDuur.Visibility = Visibility.Collapsed;
            stackSoortSpel.Visibility = Visibility.Collapsed;
            stackVakanties.Visibility = Visibility.Collapsed;

        }

        private void CategoryReset(CheckBox checkBox)
        {
            if (checkBox.IsChecked == false)
            {
                chkAlleKoekjes.IsChecked = false;
                foreach (CheckBox otherCheckboxes in lstCheckboxItems.Items)
                {
                    otherCheckboxes.IsChecked = false;
                }
            }
        }

        private object CreateStackPanel(string nameStackPanel)
        {

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Orientation = Orientation.Horizontal;
            int pictureSize = 200;

            Image myImage = new Image();
            BitmapImage myImageSource = new BitmapImage();
            myImageSource.BeginInit();
            myImageSource.UriSource = new Uri("C:/Users/Tobias Hungwe/Desktop/Projecten/KrunsjV1/Krunsj V1/Images/Fields.png");
            myImageSource.EndInit();
            myImage.Source = myImageSource;

            #region Positioning
            Random rnd = new Random();
            int minTop = 10;
            int maxTop = 635;
            int minLeft = 10;
            int maxLeft = 1023;
            top = rnd.Next(minTop, maxTop);
            left = rnd.Next(minLeft, maxLeft);
            int bottom = maxTop - top;
            int right = maxLeft - left;

            Grid myGrid = new Grid();
            myGrid.Height = 170;
            myGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            myGrid.VerticalAlignment = VerticalAlignment.Stretch;

            Label myLabel = new Label();
            myLabel.Content = nameStackPanel;
            myLabel.HorizontalAlignment = HorizontalAlignment.Left;
            myLabel.VerticalAlignment = VerticalAlignment.Top;
            myLabel.Margin = new Thickness(pictureSize / 2, pictureSize / 2, 0, 0);


            //size object

            myStackPanel.Width = pictureSize;
            myStackPanel.Height = pictureSize;
            myStackPanel.Margin = new Thickness(left, top, right, bottom);

            #endregion
            myStackPanel.Children.Add(myImage);
            myStackPanel.Children.Add(myGrid);
            myGrid.Children.Add(myLabel);
            GrdCentrum.Children.Add(myStackPanel);
            myStackPanel.Name = nameStackPanel;
            return myStackPanel;

        }
        public void CheckCheckboxen()
        {


            foreach (CheckBox checkBox in lstCheckboxItems.Items)
            {

                categoryIsChecked.Add((bool)checkBox.IsChecked);
            }




        }



        private void Execute()
        {
            AddingCategoriesToList();
            


        }

        private void AddingCategoriesToList()
        {
            CheckCheckboxen();
            Category category = new Category();
            
            object[] objectDictionary = { stackMateriaal, stackLeeftijd, stackThema, stackTerein, stackDuur, stackSoortSpel, stackVakanties };


            for (int i = 0; i < categoryNames.Length; i++)
            {

                cookieNames.Add(new Category() { CatagoryId = i, CategoryName = categoryNames[i], CheckState = categoryIsChecked[i], BinaryCheckState = Convert.ToInt32(categoryIsChecked[i]), ObjectName = objectDictionary[i] });

            }

            /*  //Soort van Controle om te kijken welke items er al inzitten
            foreach (Category catogs in cookieNames)
            {
                
            }
            */

            foreach (Category stack in cookieNames)
            {


                //positioning
                if (stack.BinaryCheckState == 1)
                {

                    MessageBox.Show(stack.ToString());
                    
                    ShowObjects(stack.CheckState, stack.CatagoryId);

                    Random rnd = new Random();
                    int minTop = 10;
                    int maxTop = 635;
                    int minLeft = 10;
                    int maxLeft = 1023;
                    top = rnd.Next(minTop, maxTop);
                    left = rnd.Next(minLeft, maxLeft);
                    int bottom = maxTop - top;
                    int right = maxLeft - left;

                    stack.Margin = new Thickness(left, top, right, bottom);


                } 
                

                
                
                else
                {
                    ShowObjects(stack.CheckState, stack.CatagoryId);
                }
                
            }
        }

        private void ShowObjects(bool isVisible, int id)
        {
            if (isVisible == true)
            {
                switch (id)
                {
                    case 0:
                        stackMateriaal.Visibility = Visibility.Visible;
                        break;
                    case 1:
                        stackLeeftijd.Visibility = Visibility.Visible;
                        break;
                    case 2:
                        stackThema.Visibility = Visibility.Visible;
                        break;
                    case 3:
                        stackTerein.Visibility = Visibility.Visible;
                        break;
                    case 4:
                        stackDuur.Visibility = Visibility.Visible;
                        break;
                    case 5:
                        stackSoortSpel.Visibility = Visibility.Visible;
                        break;
                    case 6:
                        stackVakanties.Visibility = Visibility.Visible;
                        break;

                    default:
                        break;
                }
                 
                
                
                
            }
            else
            {
                switch (id)
                {
                    case 0:
                        stackMateriaal.Visibility = Visibility.Hidden;
                        break;
                    case 1:
                        stackLeeftijd.Visibility = Visibility.Hidden;
                        break;
                    case 2:
                        stackThema.Visibility = Visibility.Hidden;
                        break;
                    case 3:
                        stackTerein.Visibility = Visibility.Hidden;
                        break;
                    case 4:
                        stackDuur.Visibility = Visibility.Hidden;
                        break;
                    case 5:
                        stackSoortSpel.Visibility = Visibility.Hidden;
                        break;
                    case 6:
                        stackVakanties.Visibility = Visibility.Hidden;
                        break;

                    default:
                        break;
                }
            }
            
            
            
           
        }

        #endregion

        #region EventHandelers

        


        

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
         }




        //window bar
        #region Windowbar properties
        //color
        private void BdrMinimize_MouseEnter(object sender, MouseEventArgs e)
            {
                BdrMinimize.Background = Brushes.Orchid;

            }


            private void BdrExit_MouseEnter_1(object sender, MouseEventArgs e)
            {
                BdrExit.Background = Brushes.Orchid;
            }

            private void BdrMinimize_MouseLeave(object sender, MouseEventArgs e)
            {
                BdrMinimize.Background = Brushes.Transparent;
            }



            private void BdrExit_MouseLeave_1(object sender, MouseEventArgs e)
            {
                BdrExit.Background = Brushes.Transparent;
            }
        #endregion
        #region functionality
        //functionality
            private void lblExit_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    System.Windows.Application.Current.Shutdown();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private void BdrExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    System.Windows.Application.Current.Shutdown();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            private void BdrMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    this.WindowState = WindowState.Minimized;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private void Krunsj_MouseDown(object sender, MouseButtonEventArgs e)
            {
                this.DragMove();

            }

            private void Mycanvas_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                myCanvas.Width = e.NewSize.Width;
                myCanvas.Height = e.NewSize.Height;


                double xChange = 1, yChange = 1;

                if (e.PreviousSize.Width != 0)
                    xChange = (e.NewSize.Width / e.PreviousSize.Width);

                if (e.PreviousSize.Height != 0)
                    yChange = (e.NewSize.Height / e.PreviousSize.Height);

                ScaleTransform scale = new ScaleTransform(myCanvas.LayoutTransform.Value.M11 * xChange, myCanvas.LayoutTransform.Value.M22 * yChange);
                myCanvas.LayoutTransform = scale;
                myCanvas.UpdateLayout();
            }
        #endregion

        #region Categories (eventhandler: click)
        private void chkAlleKoekjes_Click(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox checkbox in lstCheckboxItems.Items)
            {

                if (chkAlleKoekjes.IsChecked == true)
                {
                    checkbox.IsChecked = true;
                    

                }
                else
                {
                    checkbox.IsChecked = false;

                }
                
            }

        }

        private void chkMateriaal_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkMateriaal);
            Execute();
            
        }

        private void chkLeeftijd_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkLeeftijd);
            Execute();
            
            
        }

        private void chkThema_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkThema);
            Execute();
        }

        private void chkterein_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkterein);
            Execute();
        }

        private void chkDuur_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkDuur);
            Execute();

        }

        private void chkSoortSpel_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkSoortSpel);
            Execute();
        }

        private void chkVakanties_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkVakanties);
            Execute();
        }
        #endregion

        #endregion

        private void GrdCentrum_Loaded(object sender, RoutedEventArgs e)
        {
            Boot();


        }

        private void lblMateriaal_Loaded(object sender, RoutedEventArgs e)
        {

        }

       
    }
}



