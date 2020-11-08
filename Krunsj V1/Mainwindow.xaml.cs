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
        private List<object> objectDictionary = new List<object>();
        private List<Category> categories = new List<Category>();
        private int counter = 0;




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
            #endregion


        }

        private void IsAllChecked()
        {
            /*
            Category category = new Category();

            for (int i = 0; i < categories.Count; i++)
            {
                if (categories.Contains(new Category { CatagoryId = i, CategoryName = categoryNames[i], CheckState = true , BinaryCheckState = 1, ObjectName = objectDictionary[i]}))
                {
                    int y = 0;
                    
                    y++;
                    
                    if (y == categories.Count)
                    {
                        chkAlleKoekjes.IsChecked = true;
                    }
                    else
                    {
                        chkAlleKoekjes.IsChecked = false;
                    }

                    

                }
                
                
                    
                
            }
            
            if (chkMateriaal.IsChecked == true && chkLeeftijd.IsChecked == true && chkSoortSpel.IsChecked == true && chkterein.IsChecked == true && chkThema.IsChecked == true && chkVakanties.IsChecked == true)
            {
                chkAlleKoekjes.IsChecked = true;
            }
            else
            {
                chkAlleKoekjes.IsChecked = false;
            }
            
*/
            
            foreach (CheckBox checkbox in lstCheckboxItems.Items)
            {
                foreach (Category category in categories)
                {
                    if (category.BinaryCheckState == 1)
                    {
                         

                        if (counter == categoryNames.Length)
                        {
                            chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                        }
                        
                    }

                    else
                    {
                        if (counter < categoryNames.Length)
                        {
                            chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                        }

                    }
                }

            }



        }

        private int ContainsLoop(List<bool> list, bool value)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == value)
                {
                    int y = 0;
                    y++;
                    return y;
                }
            }
            return 0;
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
            EmptyAllUsedLists();
            AddingCategoriesToList();
            OnCheckedGiveProperties();


        }

        private void EmptyAllUsedLists()
        {
            categoryIsChecked.Clear();
            objectDictionary.Clear();
            categories.Clear();
        }

        private void AddingCategoriesToList()
        {
            CheckCheckboxen();
            

            objectDictionary.Add(stackMateriaal);
            objectDictionary.Add(stackLeeftijd);
            objectDictionary.Add(stackThema);
            objectDictionary.Add(stackTerein);
            objectDictionary.Add(stackDuur);
            objectDictionary.Add(stackSoortSpel);
            objectDictionary.Add(stackVakanties);



            for (int i = 0; i < lstCheckboxItems.Items.Count ; i++)
            {

                categories.Add(new Category() { CatagoryId = i, CategoryName = categoryNames[i], CheckState = categoryIsChecked[i], BinaryCheckState = Convert.ToInt32(categoryIsChecked[i]), ObjectName = objectDictionary[i] });
                categories.ToString();
            }

            
        }

        private void CheckAllCheckboxen()
        {
            
            if (chkAlleKoekjes.IsChecked == true)
            {
                foreach (CheckBox checkBox in lstCheckboxItems.Items)
                {
                    checkBox.IsChecked = true;
                }
            }
            else
            {
                foreach (CheckBox checkBox in lstCheckboxItems.Items)
                {
                    checkBox.IsChecked = false;
                }
            }
            
                for (int i = 0; i < categories.Count(); i++)
                {
                    if (categories.Contains(new Category { BinaryCheckState = 0, CheckState = false }))
                    {
                        categories[i] = new Category { CatagoryId = i, CategoryName = categoryNames[i], CheckState = categoryIsChecked[i], BinaryCheckState = Convert.ToInt32(categoryIsChecked[i]), ObjectName = objectDictionary[i] };

                        foreach (CheckBox checkBox in lstCheckboxItems.Items)
                        {
                        checkBox.IsChecked = true;
                        }

                        foreach (Category category in categories)
                        {
                        ShowObjects(category.CheckState, category.CatagoryId);
                        category.ToString();
                        }

                        chkAlleKoekjes.IsChecked = true;
                        categories.ToString();
                    }

                    else
                    {
                        categories[i] = new Category { CatagoryId = i, CategoryName = categoryNames[i], CheckState = categoryIsChecked[i], BinaryCheckState = Convert.ToInt32(categoryIsChecked[i]), ObjectName = objectDictionary[i] };

                        foreach (CheckBox checkBox in lstCheckboxItems.Items)
                        {
                        checkBox.IsChecked = false;
                        }
                        foreach (Category category in categories)
                        {
                          ShowObjects(category.CheckState, category.CatagoryId);
                          category.ToString();
                        }
                        chkAlleKoekjes.IsChecked = false;
                     }
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

                    ShowObjects(category.CheckState, category.CatagoryId);

                    Random rnd = new Random();
                    int minTop = 10;
                    int maxTop = 635;
                    int minLeft = 10;
                    int maxLeft = 1023;
                    top = rnd.Next(minTop, maxTop);
                    left = rnd.Next(minLeft, maxLeft);
                    int bottom = maxTop - top;
                    int right = maxLeft - left;

                    //category hier is een instance van de class category en zal niet werken door de naam category te geven
                    category.Margin = new Thickness(left, top, right, bottom);


                }

                else
                {
                    ShowObjects(category.CheckState, category.CatagoryId);
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
        
        private void chkAlleKoekjes_Checked(object sender, RoutedEventArgs e)
        {
            /*
            EmptyAllUsedLists();
            AddingCategoriesToList();
            CheckAllCheckboxen();
            OnCheckedGiveProperties();
            /*
                for (int i = 0; i < categories.Count(); i++)
                {
                    if (categories.Contains(new Category { BinaryCheckState = 0, CheckState = false}))
                    {
                        categories[i] = new Category { BinaryCheckState = 1, CheckState = true };

                        foreach (CheckBox checkBox in lstCheckboxItems.Items)
                        {

                            checkBox.IsChecked = true;

                        }
                        categories.ToString();
                    }

                }


                EmptyAllUsedLists();
                AddingCategoriesToList();

                foreach (Category cookie in categories)
                {
                    if (cookie.CheckState == false)
                    {
                        cookie.CheckState = true;

                        chkMateriaal.IsChecked = cookie.CheckState;

                        cookie.CheckState = false;
                        foreach (CheckBox check in lstCheckboxItems.Items)
                        {
                            if (categoryNames[cookie.CatagoryId] == cookie.CategoryName)
                            {
                                check.IsChecked = cookie.CheckState;
                            }

                        }
                    }
                    else
                    {
                        cookie.CheckState = false;
                        chkMateriaal.IsChecked = cookie.CheckState;

                        cookie.CheckState = false;
                        foreach (CheckBox check in lstCheckboxItems.Items)
                        {
                            if (categoryNames[cookie.CatagoryId] == cookie.CategoryName)
                            {
                                check.IsChecked = cookie.CheckState;
                            }

                        }
                    }

                }

                chkMateriaal.IsChecked = true;

                chkLeeftijd.IsChecked = true;
                chkThema.IsChecked = true;
                chkterein.IsChecked = true;
                chkDuur.IsChecked = true;
                chkSoortSpel.IsChecked = true;
                chkVakanties.IsChecked = true;
                */
        }

        private void chkAlleKoekjes_Unchecked(object sender, RoutedEventArgs e)
        {
            /*
            EmptyAllUsedLists();
            AddingCategoriesToList();
            CheckAllCheckboxen();
            OnCheckedGiveProperties();
            /*
            for (int i = 0; i < categories.Count(); i++)
            {
                if (categories.Contains(new Category { BinaryCheckState = 1, CheckState = true }))
                {
                    categories[i] = new Category { BinaryCheckState = 0, CheckState = false };

                    foreach (CheckBox checkBox in lstCheckboxItems.Items)
                    {

                        checkBox.IsChecked = false;

                    }
                }

            }
            */
        }

        private void chkMateriaal_Checked(object sender, RoutedEventArgs e)
        {   
            Execute();
            counter++;
            

        }

        private void chkMateriaal_Unchecked(object sender, RoutedEventArgs e)
        {
            Execute();
            counter--;

        }
        private void chkLeeftijd_Checked(object sender, RoutedEventArgs e)
        {
            Execute();
            counter++;
        }

        private void chkLeeftijd_Unchecked(object sender, RoutedEventArgs e)
        {
           Execute();
            counter--;
        }

        private void chkThema_Checked(object sender, RoutedEventArgs e)
        {
            Execute();
            counter++;
        }

        private void chkThema_Unchecked(object sender, RoutedEventArgs e)
        {
            Execute();
            counter--;
        }

        private void chkterein_Checked(object sender, RoutedEventArgs e)
        {
            Execute();
            counter++;
        }

        private void chkterein_Unchecked(object sender, RoutedEventArgs e)
        {
            Execute();
            counter--;
        }

        private void chkDuur_Checked(object sender, RoutedEventArgs e)
        {
            Execute();
            counter++;

        }

        private void chkDuur_Unchecked(object sender, RoutedEventArgs e)
        {
           Execute();
            counter--;

        }

        private void chkSoortSpel_Checked(object sender, RoutedEventArgs e)
        {
            Execute();
            counter++;

        }

        private void chkSoortSpel_Unchecked(object sender, RoutedEventArgs e)
        {
            Execute();
            counter--;

        }
        private void chkVakanties_Checked(object sender, RoutedEventArgs e)
        {
            Execute();
            counter++;

        }

        private void chkVakanties_Unchecked(object sender, RoutedEventArgs e)
        {
            Execute();
            counter--;

        }
        #endregion

        #endregion

        private void GrdCentrum_Loaded(object sender, RoutedEventArgs e)
        {
            Boot();
            AddingCategoriesToList();
            IsAllChecked();


        }

        private void lblMateriaal_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void lstCheckboxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

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

        private void Left_DockPanel_MouseMove(object sender, MouseEventArgs e)
        {
            IsAllChecked();
        }
    }
        
}



