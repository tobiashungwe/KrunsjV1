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
        
        private string[] categoryNames = { "Materiaal", "Leeftijd", "Thema", "Terein", "Duur", "Soort Spel", "Vakanties" };
        private List<bool> categoryIsChecked = new List<bool>();
        private const int minBottom = 10;
        private const int maxBottom = 240;
        private const int minRight = 10;
        private const int maxRight = 130;
        private List<StackPanel> Cookies = new List<StackPanel>();
        private List<Category> categories = new List<Category>();
        private Dictionary<int, int> rndPositions = new Dictionary<int, int>();
        private int itemsChecked = 0;




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
            #region Visibility settings
            stackMateriaal.Visibility = Visibility.Collapsed;
            stackLeeftijd.Visibility = Visibility.Collapsed;
            stackThema.Visibility = Visibility.Collapsed;
            stackTerein.Visibility = Visibility.Collapsed;
            stackDuur.Visibility = Visibility.Collapsed;
            stackSoortSpel.Visibility = Visibility.Collapsed;
            stackVakanties.Visibility = Visibility.Collapsed;
            stackCustom.Visibility = Visibility.Collapsed;
            #endregion


        }

        private void IsAllChecked()
        {
           

            foreach (CheckBox checkbox in lstCheckboxItems.Items)
            {
                foreach (Category category in categories)
                {
                    if (category.BinaryCheckState == 1)
                    {


                        if (itemsChecked == categoryNames.Length)
                        {
                            chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                            
                        }

                    }

                    else
                    {
                        if (itemsChecked < categoryNames.Length)
                        {
                            chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                        }

                    }
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
            /*
            Random rnd = new Random();
            int minTop = 10;
            int maxTop = 635;
            int minLeft = 10;
            int maxLeft = 1023;
            top = rnd.Next(minTop, maxTop);
            left = rnd.Next(minLeft, maxLeft);
            int bottom = maxTop - top;
            int right = maxLeft - left;
            */
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
            /*
            myStackPanel.Width = pictureSize;
            myStackPanel.Height = pictureSize;
            myStackPanel.Margin = new Thickness(left, top, right, bottom);
            */
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
            EmptyAllUsedLists();
            GiveCategoryRandomPosition();
            AddingCategoriesToList();
            
            OnCheckedGiveProperties();


        }

        private void EmptyAllUsedLists()
        {
            categoryIsChecked.Clear();
            Cookies.Clear();
            categories.Clear();
            rndPositions.Clear();
            
        }

        private void AddingCategoriesToList()
        {
            CheckCheckboxen();


            Cookies.Add(stackMateriaal);
            Cookies.Add(stackLeeftijd);
            Cookies.Add(stackThema);
            Cookies.Add(stackTerein);
            Cookies.Add(stackDuur);
            Cookies.Add(stackSoortSpel);
            Cookies.Add(stackVakanties);



            for (int i = 0; i < lstCheckboxItems.Items.Count; i++)
            {
                List<int> binaryCheckState = new List<int>();
                
                // Oude ingave: CatagoryId = i, CategoryName = categoryNames[i], CheckState = categoryIsChecked[i], BinaryCheckState = Convert.ToInt32(categoryIsChecked[i]), CookieName = Cookies[i]

                Category categoryReference = new Category(i, categoryIsChecked[i], Convert.ToInt32(categoryIsChecked[i]), Cookies[i]);
                categories.Add(categoryReference);
                

               

                
            }


        }




        private void OnCheckedGiveProperties()
        {
            foreach (Category category in categories)
            {
                

                //positioning
                if (category.BinaryCheckState == 1)
                {

                    //MessageBox.Show(category.ToString());
                    AddRandomMargin(minBottom, maxBottom, minRight, maxRight);

                    ShowObjects(category.CheckState, category.CatagoryId);
                    //

                   

                    //category hier is een instance van de class category en zal niet werken door de naam category te geven
                    //category.Margin = new Thickness();


                }

                else
                {
                    ShowObjects(category.CheckState, category.CatagoryId);
                }

            }
        }
        private void ShowObjects(bool isVisible, int id)
        {
            for (int i = 0; i < categoryIsChecked.Count; i++)
            {



                if (categoryIsChecked[i] == false && itemsChecked == 0)
                {
                    stackCustom.Visibility = Visibility.Collapsed;
                }

            }

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
                        stackMateriaal.Visibility = Visibility.Collapsed;

                        

                        break;
                    case 1:
                        stackLeeftijd.Visibility = Visibility.Collapsed;

                        

                        break;
                    case 2:
                        stackThema.Visibility = Visibility.Collapsed;

                        

                        break;
                    case 3:
                        stackTerein.Visibility = Visibility.Collapsed;

                        

                        break;
                    case 4:
                        stackDuur.Visibility = Visibility.Collapsed;

                        

                        break;
                    case 5:
                        stackSoortSpel.Visibility = Visibility.Collapsed;

                        

                        break;
                    case 6:
                        stackVakanties.Visibility = Visibility.Collapsed;

                        

                        break;

                    default:
                        break;
                        
                }

                

               


               


            }




        }
        private (int, int) CreateCombination(int xMAxValue = 1, int yMAxValue = 1)
        {   //Creating random position 
            Random rnd = new Random();
            int x = rnd.Next(0, 4);
            int y = rnd.Next(1, 3);
            

            if (xMAxValue > 1 && yMAxValue > 1)
            {
                x = rnd.Next(0, xMAxValue);
                y = rnd.Next(0, yMAxValue);
            }
            return (x, y);
        }

        private void GiveCategoryRandomPosition()
        {
            if (itemsChecked == 0)
            {
                var rndPositions = new List<(int x, int y)>();
                            
                                int index = 0;
                                while (index < lstCheckboxItems.Items.Count + 1)
                                {
                                    
                                    foreach (UIElement uIElement in GrdCentrum.Children)
                                    {
                                        
                  
                                        string elementName = uIElement.ToString();

                                        if (elementName != "System.Windows.Controls.Canvas")
                                        {

                                            
                                                
                                                var randomPosition = CreateCombination();
                                        
                                                string controle = randomPosition.ToString();
                                                //Creating new positions
                                                if (!rndPositions.Contains(randomPosition))
                                                {
                                                        rndPositions.Add(randomPosition);
                                        
                                                        if (rndPositions.Count == lstCheckboxItems.Items.Count + 1)
                                                        {

                                                            index = lstCheckboxItems.Items.Count + 1;
                                                        }
                                                        else
                                                        {
                                                            continue;
                                                        }
                                                    
                                                }
                                                else
                                                {
                                                    continue;
                                                }
                                             
                                        }
                                        else
                                        {
                                            continue;
                                        }

                                    }
                                }

                                 foreach (UIElement uIElement in GrdCentrum.Children)
                                 {
                                    string elementName = uIElement.ToString();
                                    if (elementName != "System.Windows.Controls.Canvas")
                                     {
                                         int id = Convert.ToInt32(uIElement.Uid);
                                         Grid.SetRow(uIElement, rndPositions[id].y);
                                         Grid.SetColumn(uIElement, rndPositions[id].x);
                                     }

                                 }

            }
                        
                   
        }

        private void AddRandomMargin(int minBottom, int maxBottom, int minRight, int maxRight)
        {

            foreach (Category c in categories)
            {
                Random rnd = new Random();

                if (true)
                {
                    
                    FrameworkElement framework = new FrameworkElement();
                    framework = (FrameworkElement)c.CookieName;
                    
                    

                    
                    int bottom = rnd.Next(minBottom, maxBottom);
                    int right = rnd.Next(minRight, maxRight);
                    
                    int top = maxBottom - bottom;
                    int left = maxRight - right;
                    framework.Margin = new Thickness(left, top, right, bottom);

                }
                
            }
        }

        #endregion

        #region EventHandelers


        #region Startup and update

        private void Left_DockPanel_MouseMove(object sender, MouseEventArgs e)
        {
            IsAllChecked();
            

        }
        private void lstCheckboxItems_UpdateGui(object sender, MouseEventArgs e)
        {
            //AddRandomMargin();
            //GiveCategoryRandomPosition();
            IsAllChecked();
            
            for (int i = 0; i < categoryIsChecked.Count; i++)
            {



                if (categoryIsChecked[i] == false && itemsChecked == 0)
                {
                    stackCustom.Visibility = Visibility.Collapsed;
                }

                if (categoryIsChecked[i] == true)
                {
                    
                    //GiveCategoryRandomPosition(i);
                }

            }
        }
        private void GrdCentrum_Loaded(object sender, RoutedEventArgs e)
        {
                    Boot();
                    AddingCategoriesToList();
                    IsAllChecked();
                    
        }
        #endregion
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

        private void cvsToolbar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            cvsToolbar.Width = e.NewSize.Width;
            cvsToolbar.Height = e.NewSize.Height;


            double xChange = 1, yChange = 1;

            if (e.PreviousSize.Width != 0)
                xChange = (e.NewSize.Width / e.PreviousSize.Width);

            if (e.PreviousSize.Height != 0)
                yChange = (e.NewSize.Height / e.PreviousSize.Height);

            ScaleTransform scale = new ScaleTransform(cvsToolbar.LayoutTransform.Value.M11 * xChange, cvsToolbar.LayoutTransform.Value.M22 * yChange);
            cvsToolbar.LayoutTransform = scale;
            cvsToolbar.UpdateLayout();
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
                    itemsChecked = lstCheckboxItems.Items.Count;


                }
                else
                {
                    checkbox.IsChecked = false;
                    itemsChecked = 0;


                }
            }
        }

        private void chkCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            Execute();
            itemsChecked++;
            stackCustom.Visibility = Visibility.Visible;
            
            
           
            
            
            
        }

        private void chkCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            Execute();
            itemsChecked--;
            

        }






        #endregion

        #endregion

    

      

      
        
    }

}



