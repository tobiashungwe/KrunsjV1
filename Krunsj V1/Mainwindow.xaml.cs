﻿using Krunsj_V1.Lib.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;



namespace Krunsj_V1
{
    /// <summary>
    /// Interaction logic for Mainwindow.xaml
    /// Everything of functionality, you can find here!
    /// </summary>
    public partial class Mainwindow : Window
    {
        #region declartions
        //default settings


        private List<bool> categoryIsChecked = new List<bool>();
        private List<bool> subcategoryIsChecked = new List<bool>();
        private const int minBottom = 10;
        private const int maxBottom = 45;
        private const int minRight = 10;
        private const int maxRight = 27;
        private List<StackPanel> Cookies = new List<StackPanel>();
        private List<Category> categories = new List<Category>();
        private Dictionary<int, int> rndPositions = new Dictionary<int, int>();
        private int categoriesChecked = 0;
        private int subcategoriesChecked = 0;
        private bool stackpanelIsClicked = false;
        private bool stackpanelIsSelected = false;
        private bool isValid = false;
        private bool isNotVisable = false;
        private string stackpanelName_Clicked;
        
        




        #endregion

        public Mainwindow()
        {
            InitializeComponent();
            this.Visibility = Visibility.Hidden;

            Register Login = new Register();
            Officiallogin form = new Officiallogin();

            form.ShowDialog();
            
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            

        }
        public Mainwindow(bool doNotMakeInvisibile)
        {

            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Normal;
            this.IsEnabled = true;
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
            stackIntensiteit.Visibility = Visibility.Collapsed;
            btnHome.Visibility = Visibility.Collapsed;

            chkItem0.Content = Category.category.Materiaal.ToString();
            chkItem1.Content = Category.category.Leeftijd.ToString();
            chkItem2.Content = Category.category.Thema.ToString();
            chkItem3.Content = Category.category.Terein.ToString();
            chkItem4.Content = Category.category.Duur.ToString();
            chkItem5.Content = "Soort spel";
            chkItem6.Content = Category.category.Vakanties.ToString();
            chkItem7.Content = Category.category.Intensiteit.ToString();
            #endregion

           


        }


        private void IsAllChecked(int inputCategoriesChecked)
        {


            foreach (CheckBox checkbox in lstCheckboxItems.Items)
            {
                foreach (Category category in categories)
                {
                    if (category.BinaryCheckState == 1)
                    {


                        if (inputCategoriesChecked == Enum.GetNames(typeof(Category.category)).Length)
                        {
                            chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, true);

                        }

                    }

                    else
                    {
                        if (inputCategoriesChecked < Enum.GetNames(typeof(Category.category)).Length)
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
        public void CheckCheckboxen(List<bool> inputList)
        {


            foreach (CheckBox checkBox in lstCheckboxItems.Items)
            {
                if (checkBox.Visibility == Visibility.Visible)
                {
                    inputList.Add((bool)checkBox.IsChecked);
                }
                else
                {
                    continue;
                }
                

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
            subcategoryIsChecked.Clear();
            foreach (Category category in categories)
            {
                category.Subcatagories.Clear();
            }
            Cookies.Clear();
            categories.Clear();
            rndPositions.Clear();

        }

        private void AddingCategoriesToList()
        {
            CheckCheckboxen(categoryIsChecked);


            Cookies.Add(stackMateriaal);
            Cookies.Add(stackLeeftijd);
            Cookies.Add(stackThema);
            Cookies.Add(stackTerein);
            Cookies.Add(stackDuur);
            Cookies.Add(stackSoortSpel);
            Cookies.Add(stackVakanties);
            Cookies.Add(stackIntensiteit);



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

                    
                    ShowObjects(category.CheckState, category.CatagoryId);
                    



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



                if (categoryIsChecked[i] == false && categoriesChecked == 0)
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
                    case 7:
                        stackIntensiteit.Visibility = Visibility.Visible;
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
                    case 7:
                        stackIntensiteit.Visibility = Visibility.Collapsed;
                        break;

                    default:
                        break;

                }









            }




        }
        private (int, int) CreateCombination(int xMAxValue = 1, int yMAxValue = 1)
        {   //Creating random position 
            Random rnd = new Random();
            int x = rnd.Next(1, 5);
            int y = rnd.Next(1, 5);


            if (xMAxValue > 1 && yMAxValue > 1)
            {
                x = rnd.Next(0, xMAxValue);
                y = rnd.Next(0, yMAxValue);
            }
            return (x, y);
        }
        

        private void GiveCategoryRandomPosition()
        {
            if (categoriesChecked == 0)
            {
                var rndPositions = new List<(int x, int y)>();
                var bannedPositions = new List<(int x, int y)>
                {
                    (1,1),
                    (1,4),
                    (4,1),
                    (4,4),
                    (2,2),
                    (2,3),
                    (3,2),
                    (3,3)

                };



                int index = 0;
                while (index < lstCheckboxItems.Items.Count)
                {

                    foreach (UIElement uIElement in GrdCentrum.Children)
                    {


                        string elementName = uIElement.ToString();
                        //Controls die ik niet wil random positie geven kan ik hier aanpassen

                        if (elementName != "System.Windows.Controls.Canvas" && uIElement.Uid != "8")
                        {




                            (int, int) randomPosition = CreateCombination();
                            
                            string controle = randomPosition.ToString();
                            //Creating new positions
                            if (!rndPositions.Contains(randomPosition))
                            {
                                if (!bannedPositions.Contains(randomPosition))
                                {
                                    rndPositions.Add(randomPosition);

                                    if (rndPositions.Count == lstCheckboxItems.Items.Count)
                                    {

                                        index = lstCheckboxItems.Items.Count;
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
                        else
                        {
                            continue;
                        }

                    }
                }

                foreach (UIElement uIElement in GrdCentrum.Children)
                {
                    string elementName = uIElement.ToString();
                    if (elementName != "System.Windows.Controls.Canvas" && elementName != "System.Windows.Controls.Button" && elementName != "System.Windows.Controls.GroupBox Header:Geselecteerde categorieën Content:" && uIElement.Uid != "8")
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


        private void Reset()
        {
            int i = 0;
            foreach (CheckBox checkbox in lstCheckboxItems.Items)
            {

                checkbox.Checked -= chkCategory_Checked;
                checkbox.Unchecked -= chkCategory_Unchecked;
                checkbox.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                checkbox.Checked += chkSubCatagory_Checked;
                checkbox.Unchecked += chkSubCatagory_Unchecked;
                checkbox.Content = $"Item_{i}";
                i++;

            }
        }

        private void AddSubCategories()
        {
            foreach (Category c in categories.ToList())
            {
                while (stackpanelIsClicked == true)
                {


                    if (c.CheckState == true)
                    {
                        if (c.CategoryName.ToString() == stackpanelName_Clicked)
                        {
                            switch (c.CatagoryId)
                            {

                                case 0:
                                    #region Materiaal

                                    Subcategory subcatagory0 = new Subcategory(0, "Goedkoop");
                                    Subcategory subcatagory1 = new Subcategory(1, "Duur");
                                    Subcategory subcatagory2 = new Subcategory(2, "Veel materiaal");
                                    Subcategory subcatagory3 = new Subcategory(3, "Weinig materiaal");
                                    categories[0].Subcatagories.Clear();
                                    categories[0].Subcatagories.Add(subcatagory0);
                                    categories[0].Subcatagories.Add(subcatagory1);
                                    categories[0].Subcatagories.Add(subcatagory2);
                                    categories[0].Subcatagories.Add(subcatagory3);
                                    Reset();
                                    ChangeLabelsToSubContent(0);


                                    stackpanelIsClicked = false;
                                    //Ik zou hier een lijst kunnen plaatsen die dat bewaart 


                                    #endregion
                                    break;
                                case 1:
                                    #region Leeftijd
                                    Subcategory subcatagory4 = new Subcategory(0, "5-6");
                                    Subcategory subcatagory5 = new Subcategory(1, "7-9");
                                    Subcategory subcatagory6 = new Subcategory(2, "10-12");
                                    Subcategory subcatagory7 = new Subcategory(3, "13-14");
                                    Subcategory subcatagory8 = new Subcategory(4, "14-16");
                                    Subcategory subcatagory9 = new Subcategory(5, "16-18");
                                    Subcategory subcatagory10 = new Subcategory(6, "18+");
                                    categories[1].Subcatagories.Clear();
                                    categories[1].Subcatagories.Add(subcatagory4);
                                    categories[1].Subcatagories.Add(subcatagory5);
                                    categories[1].Subcatagories.Add(subcatagory6);
                                    categories[1].Subcatagories.Add(subcatagory7);
                                    categories[1].Subcatagories.Add(subcatagory8);
                                    categories[1].Subcatagories.Add(subcatagory9);
                                    categories[1].Subcatagories.Add(subcatagory10);
                                    Reset();
                                    ChangeLabelsToSubContent(1);
                                    stackpanelIsClicked = false;
                                    #endregion
                                    break;
                                case 2:
                                    #region Thema
                                    Subcategory subcatagory11 = new Subcategory(0, "Op basis van bordspelen");
                                    Subcategory subcatagory12 = new Subcategory(1, "Natuur");
                                    Subcategory subcatagory13 = new Subcategory(2, "Plant een vlag");
                                    Subcategory subcatagory14 = new Subcategory(3, "Avontuur");
                                    Subcategory subcatagory15 = new Subcategory(4, "Koken");
                                    Subcategory subcatagory16 = new Subcategory(5, "Fantasie");

                                    categories[2].Subcatagories.Clear();
                                    categories[2].Subcatagories.Add(subcatagory11);
                                    categories[2].Subcatagories.Add(subcatagory12);
                                    categories[2].Subcatagories.Add(subcatagory13);
                                    categories[2].Subcatagories.Add(subcatagory14);
                                    categories[2].Subcatagories.Add(subcatagory15);
                                    categories[2].Subcatagories.Add(subcatagory16);
                                    Reset();
                                    ChangeLabelsToSubContent(2);
                                    stackpanelIsClicked = false;
                                    #endregion
                                    break;
                                case 3:
                                    #region Terein
                                    Subcategory subcatagory17 = new Subcategory(0, "Buiten");
                                    Subcategory subcatagory18 = new Subcategory(1, "Binnen");
                                    Subcategory subcatagory19 = new Subcategory(2, "Bos");
                                    Subcategory subcatagory20 = new Subcategory(3, "Park");
                                    Subcategory subcatagory21 = new Subcategory(4, "Duinen");

                                    categories[3].Subcatagories.Clear();
                                    categories[3].Subcatagories.Add(subcatagory17);
                                    categories[3].Subcatagories.Add(subcatagory18);
                                    categories[3].Subcatagories.Add(subcatagory19);
                                    categories[3].Subcatagories.Add(subcatagory20);
                                    categories[3].Subcatagories.Add(subcatagory21);
                                    Reset();
                                    ChangeLabelsToSubContent(3);
                                    stackpanelIsClicked = false;
                                    #endregion
                                    break;
                                case 4:
                                    #region Duur
                                    Subcategory subcatagory22 = new Subcategory(0, "0 tot 15min");
                                    Subcategory subcatagory23 = new Subcategory(1, "15 tot 30min");
                                    Subcategory subcatagory24 = new Subcategory(2, "30 tot 60min");
                                    Subcategory subcatagory25 = new Subcategory(3, "60 tot 90min");
                                    Subcategory subcatagory26 = new Subcategory(4, "Meer dan 90min");
                                    categories[4].Subcatagories.Clear();
                                    categories[4].Subcatagories.Add(subcatagory22);
                                    categories[4].Subcatagories.Add(subcatagory23);
                                    categories[4].Subcatagories.Add(subcatagory24);
                                    categories[4].Subcatagories.Add(subcatagory25);
                                    categories[4].Subcatagories.Add(subcatagory26);
                                    Reset();
                                    ChangeLabelsToSubContent(4);
                                    stackpanelIsClicked = false;
                                    #endregion
                                    break;
                                case 5:
                                    #region Soort Spelen
                                    Subcategory subcatagory27 = new Subcategory(0, "Waterspelen");
                                    Subcategory subcatagory28 = new Subcategory(1, "Osa");
                                    Subcategory subcatagory29 = new Subcategory(2, "Teambuilding");
                                    Subcategory subcatagory30 = new Subcategory(3, "Kennismakingsspelen");
                                    Subcategory subcatagory31 = new Subcategory(4, "Avond en nachtspelen");
                                    Subcategory subcatagory32 = new Subcategory(5, "Hevige spelen");
                                    Subcategory subcatagory33 = new Subcategory(6, "Rustige Spelen");
                                    Subcategory subcatagory34 = new Subcategory(8, "Kring/Broekzak-Spelen");

                                    categories[5].Subcatagories.Clear();
                                    categories[5].Subcatagories.Add(subcatagory27);
                                    categories[5].Subcatagories.Add(subcatagory28);
                                    categories[5].Subcatagories.Add(subcatagory29);
                                    categories[5].Subcatagories.Add(subcatagory30);
                                    categories[5].Subcatagories.Add(subcatagory31);
                                    categories[5].Subcatagories.Add(subcatagory32);
                                    categories[5].Subcatagories.Add(subcatagory33);
                                    categories[5].Subcatagories.Add(subcatagory34);
                                    Reset();
                                    ChangeLabelsToSubContent(5);
                                    stackpanelIsClicked = false;
                                    #endregion
                                    break;
                                case 6:
                                    #region Vakanties
                                    Subcategory subcatagory35 = new Subcategory(0, "Binnenland");
                                    Subcategory subcatagory36 = new Subcategory(1, "Bomal");
                                    Subcategory subcatagory37 = new Subcategory(2, "Buitenland");
                                    Subcategory subcatagory38 = new Subcategory(3, "Tentenkamp");
                                    Subcategory subcatagory39 = new Subcategory(4, "Oostduinkerke");

                                    categories[6].Subcatagories.Clear();
                                    categories[6].Subcatagories.Add(subcatagory35);
                                    categories[6].Subcatagories.Add(subcatagory36);
                                    categories[6].Subcatagories.Add(subcatagory37);
                                    categories[6].Subcatagories.Add(subcatagory38);
                                    categories[6].Subcatagories.Add(subcatagory39);
                                    Reset();
                                    ChangeLabelsToSubContent(6);
                                    stackpanelIsClicked = false;

                                    #endregion
                                    break;
                                case 7:
                                    #region Intensiteit
                                    Subcategory subcatagory40 = new Subcategory(0, "Matig");
                                    Subcategory subcatagory41 = new Subcategory(1, "Rustig");
                                    Subcategory subcatagory42 = new Subcategory(2, "Zwaar");
                                    Subcategory subcatagory43 = new Subcategory(3, "Hevig");
                                    Subcategory subcatagory44 = new Subcategory(4, "Extreem");

                                    categories[7].Subcatagories.Clear();
                                    categories[7].Subcatagories.Add(subcatagory40);
                                    categories[7].Subcatagories.Add(subcatagory41);
                                    categories[7].Subcatagories.Add(subcatagory42);
                                    categories[7].Subcatagories.Add(subcatagory43);
                                    categories[7].Subcatagories.Add(subcatagory44);
                                    Reset();
                                    ChangeLabelsToSubContent(7);
                                    stackpanelIsClicked = false;

                                    #endregion
                                    break;
                                default:
                                    break;


                            }
                        }
                        else
                        {
                            break;
                        }
                            

                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void ChangeLabelsToSubContent(int catagoryID)
        {

            if (stackpanelIsClicked == true)
            {





                for (int i = -1; i < lstCheckboxItems.Items.Count;)
                {
                    foreach (CheckBox checkBox in lstCheckboxItems.Items)
                     {
                        i++;
                        if (checkBox.Uid == Convert.ToString(i))
                        {
                            if (i < categories[catagoryID].Subcatagories.Count)
                            {
                                string subcatagoryName = categories[catagoryID].Subcatagories[i].SubcategoryName;
                                checkBox.Content = subcatagoryName;
                                
                                checkBox.Margin = new Thickness(0, 0, 0, 0);
                                string checkboxContent = checkBox.Content.ToString();
                                bool containsSearchResult = checkboxContent.Contains("Item");
                                if (!containsSearchResult)
                                {
                                    checkBox.Visibility = Visibility.Visible;

                                }
                                else
                                {
                                    throw new System.ArgumentException("Something went wrong!");
                                }
                            }
                            else
                            {

                                string checkboxContent = checkBox.Content.ToString();
                                bool containsSearchResult = checkboxContent.Contains("Item");
                                if (containsSearchResult)
                                {
                                    checkBox.Visibility = Visibility.Collapsed;
                                    
                                }
                                else
                                {
                                    throw new System.ArgumentException("Something went wrong!");
                                }
                            }
                        }
                        else
                        {
                            break;
                        }

                    }

                }
            }
        }

        private void DisplayGrid(bool isOn)
        {
            if (isOn == true)
            {
                foreach (UIElement uIElement in GrdCentrum.Children)
                {
                    string elementName = uIElement.ToString();

                    if (elementName != "System.Windows.Controls.Canvas")
                    {
                        uIElement.Visibility = Visibility.Collapsed;

                    }
                    else
                    {
                        continue;
                    }

                }
            }
            else
            {
              
                foreach (UIElement uIElement in GrdCentrum.Children)
                {
                    string elementName = uIElement.ToString();
                    //kga nog checked counter er weeer moeten insteken en kijken welke checked zijn om terug te displayen
                    if (elementName != "System.Windows.Controls.Canvas")
                    {
                        uIElement.Visibility = Visibility.Visible;

                    }
                    else
                    {
                        continue;
                    }

                }
            }
            
        }

        private static String convert(String str)
        {

            // Create a char array of
            // given String
            char[] ch = str.ToCharArray();

            for (int i = 0; i < str.Length; i++)
            {

                // If first character of a
                // word is found
                if (i == 0 && ch[i] != ' ' ||
                    ch[i] != ' ' && ch[i - 1] == ' ')
                {

                    // If it is in lower-case
                    if (ch[i] >= 'a' && ch[i] <= 'z')
                    {

                        // Convert into Upper-case
                        ch[i] = (char)(ch[i] - 'a' + 'A');
                    }
                }

                // If apart from first character
                // Any one is in Upper-case
                else if (ch[i] >= 'A' && ch[i] <= 'Z')

                    // Convert into Lower-Case
                    ch[i] = (char)(ch[i] + 'a' - 'A');
            }

            // Convert the char array to
            // equivalent String
            String st = new String(ch);

            return st;
        }

        private void ShowBtnHome()
        {
            for (int i = 0; i < categoryIsChecked.Count; i++)
            {



                if (categoryIsChecked[i] == false && categoriesChecked == 0)
                {
                    stackCustom.Visibility = Visibility.Collapsed;
                }
                foreach (Category.category categoryName in (Category.category[])Enum.GetValues(typeof(Category.category)))
                {
                    

                    foreach (CheckBox checkBox in lstCheckboxItems.Items)
                    {
                        string checkBoxName = checkBox.Content.ToString();
                        checkBoxName = convert(checkBoxName);
                        checkBoxName = Regex.Replace(checkBoxName, @"\s+", "");

                        if (lstCheckboxItems.Items.Contains(categoryName.ToString()))
                        {
                            if (checkBoxName == categoryName.ToString())
                            {
                                btnHome.Visibility = Visibility.Collapsed;
                            }
                            else
                            {

                                btnHome.Visibility = Visibility.Visible;
                            }
                        }

                        else
                        {
                            continue;


                        }





                    }



                }

            }
        }
        private void ShowChkAlleKoekjes()
        {
            foreach (Category category in categories)
            {
                //Hier kan ik eventueel werken met een while

                foreach (CheckBox checkbox in lstCheckboxItems.Items)
                {

                    string checkboxName = checkbox.Content.ToString();
                    checkboxName = convert(checkboxName);
                    checkboxName = Regex.Replace(checkboxName, @"\s+", "");

                    if (category.CategoryName == checkboxName)
                    {
                        if (category.CheckState == true)
                        {
                            if (categoriesChecked == lstCheckboxItems.Items.Count)
                            {
                                chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (categoriesChecked == 0)
                            {
                                chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                            }
                            else if (categoriesChecked < lstCheckboxItems.Items.Count)
                            {
                                chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    if (category.CheckState == true)
                    {
                        if (category.Subcatagories.Count != 0)
                        {


                            foreach (var item in category.Subcatagories.Select((value, i) => (value, i)))
                            {
                                int index = item.i;
                                List<int> storedNumbers = new List<int>();
                                storedNumbers.Add(index);
                                string convertedSubcatagoryName = convert(item.value.SubcategoryName);
                                convertedSubcatagoryName = Regex.Replace(convertedSubcatagoryName, @"\s+", "");
                                if (convertedSubcatagoryName == checkboxName)
                                {


                                    if (checkbox.IsChecked == true)
                                    {
                                        if (!subcategoryIsChecked.Contains(false))
                                        {

                                            if (subcategoriesChecked == subcategoryIsChecked.Select((value, y) => value ? y : -1).Where(o => o >= 0).ToList().Count || subcategoriesChecked >= subcategoryIsChecked.Select((value, y) => value ? y : -1).Where(o => o >= 0).ToList().Count - 1)
                                            {
                                                chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, true);

                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                                            break;
                                        }




                                    }
                                    else
                                    {


                                        if (subcategoriesChecked <= lstCheckboxItems.Items.Count)
                                        {
                                            chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }





                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }








                }

            }
        }

        private void GoBackToMenu()
        {
            #region Resset labels
            chkItem0.Content = Category.category.Materiaal.ToString();
            chkItem1.Content = Category.category.Leeftijd.ToString();
            chkItem2.Content = Category.category.Thema.ToString();
            chkItem3.Content = Category.category.Terein.ToString();
            chkItem4.Content = Category.category.Duur.ToString();
            chkItem5.Content = "Soort spel";
            chkItem6.Content = Category.category.Vakanties.ToString();
            chkItem7.Content = Category.category.Intensiteit.ToString();
            #endregion

            #region Reset of events
            // int counter = -1;

            foreach (CheckBox checkbox in lstCheckboxItems.Items)
            {

                checkbox.Checked -= chkSubCatagory_Checked;
                checkbox.Unchecked -= chkSubCatagory_Unchecked;

                foreach (var item in categories.Select((value, i) => (value, i)))
                {
                    Category c = item.value;
                    int index = item.i;

                    if (categories[index].CheckState == true && categories[index].CatagoryId == index && checkbox.Uid == Convert.ToString(index))
                    {
                        checkbox.SetCurrentValue(CheckBox.IsCheckedProperty, true);


                    }

                    else if (categories[index].CheckState == false && categories[index].CatagoryId == index && checkbox.Uid == Convert.ToString(index))
                    {
                        checkbox.SetCurrentValue(CheckBox.IsCheckedProperty, false);


                    }

                }


                if (checkbox.Visibility == Visibility.Collapsed)
                {
                    checkbox.Visibility = Visibility.Visible;


                }
                if (Convert.ToInt32(checkbox.Uid) % 2 == 0)
                {
                    checkbox.Margin = new Thickness(0, 0, 0, 0);
                }
                else
                {
                    checkbox.Margin = new Thickness(180, 45, 180, 45);
                }

                checkbox.Checked += chkCategory_Checked;
                checkbox.Unchecked += chkCategory_Unchecked;
            }


            #endregion
        }
        
        private void CheckUserPathForCategories(string path)
        {

        }

        #endregion

        #region EventHandelers


        #region Startup and update

        private void Left_DockPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //IsAllChecked(categoriesChecked);


        }
       
        private void GrdCentrum_Loaded(object sender, RoutedEventArgs e)
        {
            Boot();
            AddingCategoriesToList();
            IsAllChecked(categoriesChecked);

        }
        private void Krunsj_UpdateGui_MouseMove(object sender, MouseEventArgs e)
        {

            ShowBtnHome();
            ShowChkAlleKoekjes();
            

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
            if (chkAlleKoekjes.IsChecked == true)
            {
                isValid = false;
            }
            else
            {
                isValid = false;
            }

            foreach (Category.category categoryName in (Category.category[])Enum.GetValues(typeof(Category.category)))
            {
                foreach (CheckBox checkBox in lstCheckboxItems.Items)
                {
                    string checkBoxName = checkBox.Content.ToString();
                    checkBoxName = convert(checkBoxName);
                    checkBoxName = Regex.Replace(checkBoxName, @"\s+", "");


                    if (checkBoxName == categoryName.ToString())
                    {
                        CheckAllCheckBoxen(true, false);
                    }
                    else
                    {

                        CheckAllCheckBoxen(false, true);
                    }



                }

            }
        }

        private void CheckAllCheckBoxen(bool isCatagory, bool isSubcatagory)
        {
            //max aantal categorien
            /*
            if (subcategoriesChecked < 0)
            {
                subcategoriesChecked = 0;
            }
            */
            
            
            while (isValid == false)
            {
                int i = 0;
                foreach (CheckBox checkbox in lstCheckboxItems.Items)
                {
                    

                    if (isCatagory == true && isSubcatagory == false)
                    {
                        if (chkAlleKoekjes.IsChecked == true)
                        {
                            checkbox.IsChecked = true;
                           
                            if (categoriesChecked == lstCheckboxItems.Items.Count)
                            {
                                isValid = true;
                                break;
                            }
                           
                            

                        }
                        else
                        {
                            checkbox.IsChecked = false;
                            
                            if (categoriesChecked == 0)
                            {
                                isValid = true;
                                break;
                            }
                          

                        }

                    }
                    else if (isCatagory == false && isSubcatagory == true)
                    {
                        
                        if (chkAlleKoekjes.IsChecked == true)
                        {
                            i++;
                            checkbox.IsChecked = true;

                            if (i == lstCheckboxItems.Items.Count)
                            {
                                i = 0;
                                isValid = true;
                                break;
                            }


                        }
                        else
                        {
                            i++;
                            checkbox.IsChecked = false;
                            /*
                            if (i == 0)
                            {
                            */
                                isValid = true;
                                continue;
                            /*
                            }
                            */

                        }
                    }

                }
            }
            
            
           
           
        }
        private void chkCategory_Checked(object sender, RoutedEventArgs e)
        {
            Execute();
            categoriesChecked++;
            stackCustom.Visibility = Visibility.Visible;






        }

        private void chkCategory_Unchecked(object sender, RoutedEventArgs e)
        {
            Execute();
            categoriesChecked--;


        }

        private void Category_Clicked(object sender, MouseButtonEventArgs e)
        {
            subcategoriesChecked = 0;
            subcategoryIsChecked.Clear();
            btnHome.Visibility = Visibility.Visible;
            stackpanelIsClicked = true;
            IsAllChecked(subcategoriesChecked);
            while (stackpanelIsClicked == true)
            {
                if (stackpanelIsClicked == true)
                {
                    foreach (CheckBox checkBox in lstCheckboxItems.Items)
                    {
                        if (stackpanelIsClicked == true)
                        {
                            foreach (Category category in categories)
                            {
                                if (stackpanelIsClicked == true)
                                {
                                    if (category.CheckState == true)
                                    {
                                        if (category.CategoryName.ToString() == stackpanelName_Clicked)
                                        {
                                            foreach (StackPanel stackPanel in GrdCentrum.Children.OfType<StackPanel>())
                                            {
                                                if (stackpanelIsClicked == true)
                                                {
                                                    foreach (Grid grid in stackPanel.Children.OfType<Grid>())
                                                    {
                                                        if (stackpanelIsClicked == true)
                                                        {
                                                            foreach (Label label in grid.Children.OfType<Label>())
                                                            {


                                                                string lblContent = label.Content.ToString();


                                                                if (category.CategoryName == stackpanelName_Clicked && category.CheckState == true && stackpanelIsSelected == true)
                                                                {


                                                                    AddSubCategories();
                                                                    stackpanelIsClicked = false;
                                                                    stackpanelIsSelected = false;
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    continue;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }



                                                    }
                                                }
                                                else
                                                {
                                                    break;
                                                }

                                            }
                                        }

                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    break;
                                }





                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                }
                else
                {
                    break;
                }

            }




            //
            //Standaard configuratie bij startup
            /* Een lijst aanmaken die is checked controlleert van de items die */

        }

        #endregion

        #region SubCategories (eventhandler: Click)
        private void chkSubCatagory_Checked(object sender, RoutedEventArgs e)
        {
            subcategoryIsChecked.Clear();
            subcategoriesChecked++;
            CheckCheckboxen(subcategoryIsChecked);
            Console.WriteLine(subcategoriesChecked);


            
            






        }
        private void chkSubCatagory_Unchecked(object sender, RoutedEventArgs e)
        {
            subcategoryIsChecked.Clear();
            subcategoriesChecked--;
            CheckCheckboxen(subcategoryIsChecked);
            Console.WriteLine(subcategoriesChecked);
            
            //Display settings

            /*Hier kan ik eventueel zaken zetten voor subcatagiry checked*/

        }


        #endregion

        #region Homebutton
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            GoBackToMenu();
            OnCheckedGiveProperties();
            subcategoriesChecked = 0;
            
            foreach (Category c in categories)
            {
                if (c.CheckState == true)
                {
                    chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                }
                else
                {
                    chkAlleKoekjes.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                }
            }

            IsAllChecked(categoriesChecked);
            btnHome.Visibility = Visibility.Collapsed;


        }
        



        #endregion

        #region Security (eventhandler: Enter )
        private void stackMateriaal_MouseEnter(object sender, MouseEventArgs e)
        {
            stackpanelIsSelected = true;
            stackpanelName_Clicked = Category.category.Materiaal.ToString();

        }

        private void stackVakanties_MouseEnter(object sender, MouseEventArgs e)
        {
            stackpanelIsSelected = true;
            stackpanelName_Clicked = Category.category.Vakanties.ToString();
        }

        private void stackTerein_MouseEnter(object sender, MouseEventArgs e)
        {
            stackpanelIsSelected = true;
            stackpanelName_Clicked = Category.category.Terein.ToString();
        }

        private void stackThema_MouseEnter(object sender, MouseEventArgs e)
        {
            stackpanelIsSelected = true;
            stackpanelName_Clicked = Category.category.Thema.ToString();
        }

        private void stackDuur_MouseEnter(object sender, MouseEventArgs e)
        {
            stackpanelIsSelected = true;
            stackpanelName_Clicked = Category.category.Duur.ToString();
        }

        private void stackSoortSpel_MouseEnter(object sender, MouseEventArgs e)
        {
            stackpanelIsSelected = true;
            stackpanelName_Clicked = Category.category.SoortSpel.ToString();
        }

        private void stackIntensiteit_MouseEnter(object sender, MouseEventArgs e)
        {
            stackpanelIsSelected = true;
            stackpanelName_Clicked = Category.category.Intensiteit.ToString();
        }

        private void stackLeeftijd_MouseEnter(object sender, MouseEventArgs e)
        {
            stackpanelIsSelected = true;
            stackpanelName_Clicked = Category.category.Leeftijd.ToString();
        }

        private void stackCustom_MouseEnter(object sender, MouseEventArgs e)
        {
            stackpanelIsSelected = true;
            //Kan hier later properties aan geven voor specification
        }





        #endregion

        #endregion

        private void Krunsj_Loaded(object sender, RoutedEventArgs e)
        {
            //Visibility settings
            grpCategorySummary.Visibility = Visibility.Collapsed;
            

                            
            
            wndWelcome wndWelcome = new wndWelcome();
            wndWelcome.Visibility = Visibility.Visible;
            System.Windows.Forms.Application.Exit();
            wndWelcome.ShowDialog();
                       
        }




      

        
    }
        

        

}



