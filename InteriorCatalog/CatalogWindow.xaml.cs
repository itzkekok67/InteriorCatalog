using Model.Core;
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

namespace InteriorCatalog
{
    /// <summary>
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        private FurnitureCatalog _catalog;
        private Furniture[] _allItems;
        public CatalogWindow(FurnitureCatalog catalog)
        {
            InitializeComponent();
            _catalog = catalog;
            _allItems = _catalog.Items;
            FurnitureGrid.ItemsSource = _allItems;
          
            TypeFilterComboBox.SelectedIndex = 0;
        }
        private void AddButton_Click( object sender, RoutedEventArgs e )
        {
            Furniture f = _allItems[0];

            Sofa sofa = (Sofa)f;

            Chair chair = f as Chair;

            if (f is Model.Core.Table t)
            {
                t._basePrice += 100;
            }
            Furniture item = (Furniture)FurnitureGrid.SelectedItem;
            Armchair arm = item as Armchair;
        }

        private void TypeFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem? item = TypeFilterComboBox.SelectedItem as ComboBoxItem;
            if (item == null)
                return;
            string selectedType = item.Content.ToString();

            if (selectedType == "All")
            {
                FurnitureGrid.ItemsSource = _allItems;
                return;
            }
            Furniture[] temp = new Furniture[_allItems.Length];
            int count = 0;
            for (int i = 0; i < _allItems.Length; i++)
            {
                if (_allItems[i] == null)
                    continue;
                if (_allItems[i].GetType().Name == selectedType)
                {
                    temp[count] = _allItems[i];
                    count++;
                }
            }
            Furniture[] result = new Furniture[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = temp[i];
            }
            FurnitureGrid.ItemsSource = result;
        }
        public CatalogWindow()
        {
            InitializeComponent();
        }
        private void SortArticleAsc_Click( object sender, RoutedEventArgs e ) //по артикулу (возр)
        {
            _catalog.Sort(true);

            FurnitureGrid.ItemsSource = null;
            FurnitureGrid.ItemsSource = _catalog.Items;
        }
        private void SortArticleDesc_Click(object sender, RoutedEventArgs e) //по артикулу (убыв)
        {
            _catalog.Sort(false);

            FurnitureGrid.ItemsSource = null;
            FurnitureGrid.ItemsSource = _catalog.Items;
        }
        private void SortNameAsc_Click(object sender, RoutedEventArgs e)
        {
            _catalog.SortByName(true);

            FurnitureGrid.ItemsSource = null;
            FurnitureGrid.ItemsSource = _catalog.Items;
        }
        private void SortNameDesc_Click(object sender, RoutedEventArgs e)
        {
            _catalog.SortByName(false);

            FurnitureGrid.ItemsSource = null;
            FurnitureGrid.ItemsSource = _catalog.Items;
        }
        private void SortPriceAsc_Click(object sender, RoutedEventArgs e)
        {
            _catalog.SortByPrice(true);

            FurnitureGrid.ItemsSource = null;
            FurnitureGrid.ItemsSource = _catalog.Items;
        }
        private void SortPriceDesc_Click(object sender, RoutedEventArgs e)
        {
            _catalog.SortByPrice(false);

            FurnitureGrid.ItemsSource = null;
            FurnitureGrid.ItemsSource = _catalog.Items;
        }
        private void PrioritySort_Click(object sender, RoutedEventArgs e)
        {
            _catalog.PrioritySort();

            FurnitureGrid.ItemsSource = null;
            FurnitureGrid.ItemsSource = _catalog.Items;
        }
        private void OpenImage_Click(object sender, RoutedEventArgs e)
        {
            Furniture selectedFurniture = FurnitureGrid.SelectedItem as Furniture;
            if (selectedFurniture == null)
            {
                MessageBox.Show("Выберите предмет мебели");
                return;
            }
            FurnitureImageWindow window = new FurnitureImageWindow(selectedFurniture);
            window.Show();
        }
    }
}
