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
            this.Visibility = Visibility.Hidden;
            InitializeComponent();
            Register Login = new Register();

            Officiallogin form = new Officiallogin();
            form.ShowDialog();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

        }
        public Mainwindow(bool doNotMakeInvisibile)
        {

            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Normal;
            InitializeComponent();






        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void chxAlleKoekjes_Checked(object sender, RoutedEventArgs e)
        {
            if (cbxAlleKoekjes.IsChecked.HasValue)
            {
                if (cbxAlleKoekjes.IsChecked.HasValue == true)
                {
                    cbxLeeftijd.IsChecked = true;
                    cbxMateriaal.IsChecked = true;
                    cbxSoort.IsChecked = true;
                    cbxTerein.IsChecked = true;
                    cbxThema.IsChecked = true;
                    cbxDuur.IsChecked = true;
                    cbxVakanties.IsChecked = true;
                }
                if (cbxAlleKoekjes.IsChecked.HasValue == false)
                {

                    cbxLeeftijd.IsChecked = false;
                    cbxMateriaal.IsChecked = false;
                    cbxSoort.IsChecked = false;
                    cbxTerein.IsChecked = false;
                    cbxThema.IsChecked = false;
                    cbxDuur.IsChecked = false;
                    cbxVakanties.IsChecked = false;


                }
            }
        }









        //window bar
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

        private void GrdCentrum_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void cbxMateriaal_Checked(object sender, RoutedEventArgs e)
        {
            if (cbxAlleKoekjes.IsChecked.HasValue == false)
            {
                cbxMateriaal.IsChecked = false;
            }

        }
    }
}


