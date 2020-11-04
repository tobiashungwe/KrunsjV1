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
        //private string[] cookieNames = {"Materiaal", "Leeftijd", "Thema", "Terein", "Duur", "Soort Spel", "Vakanties"};
        private List<string> cookieNames = new List<string>();
        private bool[] checkState = { false, false, false, false, false, false, false };
        private object[] cookies = new object[7];
        

        #endregion
        public Mainwindow(bool doNotMakeInvisibile)
            {

                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Normal;
                InitializeComponent();






            }

        #region Methodes

        
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
            

            Image myImage = new Image();
            BitmapImage myImageSource = new BitmapImage();
            myImageSource.BeginInit();
            myImageSource.UriSource = new Uri("C:/Users/Tobias Hungwe/Desktop/Projecten/KrunsjV1/Krunsj V1/Images/Fields.png");
            myImageSource.EndInit();
            myImage.Source = myImageSource;
            

            TextBlock myTextBlock = new TextBlock();
            myTextBlock.Text = $"{nameStackPanel}";
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
            
            
            //size object
            myStackPanel.Width = 200;
            myStackPanel.Height = 200;
            myStackPanel.Margin = new Thickness(left, top, right, bottom);

            #endregion
            myStackPanel.Children.Add(myImage);
            myStackPanel.Children.Add(myGrid);
            myStackPanel.Children.Add(myTextBlock);
            GrdCentrum.Children.Add(myStackPanel);
            myStackPanel.Name = nameStackPanel;
            return myStackPanel;
            
        }
        #endregion

        #region EventHandelers

        private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                
            }

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
            CreateStackPanel("Materiaal");
            
        }

        private void chkLeeftijd_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkLeeftijd);
        }

        private void chkThema_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkThema);
        }

        private void chkterein_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkterein);
        }

        private void chkDuur_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkDuur);
        }

        private void chkSoortSpel_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkSoortSpel);
        }

        private void chkVakanties_Click(object sender, RoutedEventArgs e)
        {
            CategoryReset(chkVakanties);
        }
        #endregion

        #endregion

        private void GrdCentrum_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}



