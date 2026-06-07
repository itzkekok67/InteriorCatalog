using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using Model.Core;
using Model.Data;
using System.IO;
using System.Xml.Serialization;

namespace InteriorCatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FurnitureCatalog[] _catalogs;
        private AbstractSerializer _serializer;
        private string _extension = "json"; //по умолчанию
        private void FormatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FormatComboBox.SelectedItem == null)
            {  return; }
            string format =((ComboBoxItem)FormatComboBox.SelectedItem).Content.ToString();
            SetFormat(format);
        }
        public MainWindow()
        {
            InitializeComponent();
            _serializer = new JsonSerialize();
            _extension = "json";
            LoadCatalogs();
            //по умолчанию
            CatalogComboBox.ItemsSource = _catalogs;
            CatalogComboBox.DisplayMemberPath = "Name";
        }
        private void UpdateSaveBtnState()
        {
            if (_catalogs != null && _serializer != null)
            {
                SaveBtn.IsEnabled = true;
            }
            else
            {
                SaveBtn.IsEnabled=false;
            }
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveCatalogs();
            MessageBox.Show("Файлы обновлены");
        }
        private void ReloadBtn_Click(Object sender, RoutedEventArgs e)
        {
            LoadCatalogs();

            CatalogComboBox.ItemsSource = null;
            CatalogComboBox.ItemsSource = _catalogs;
        }
        private void SetFormat(string format)
        {
            if (format == "XML")
            {
                _serializer = new XmlSerialize();
                _extension = "xml";
            }
            else
            {
                _serializer = new JsonSerialize();
                _extension = "json";
            }
            LoadCatalogs();
            UpdateSaveBtnState();
        }
        private void LoadCatalogs()
        {
            _catalogs = new FurnitureCatalog[4];
            for (int i = 0; i < _catalogs.Length; i++)
            {
                _catalogs[i] = new FurnitureCatalog
                {
                    Name = "Каталог" + (i + 1)
                };
            }
            bool allExists = File.Exists("catalog0"+_extension) && File.Exists("catalog1"+_extension) && File.Exists("catalog2" + _extension) && File.Exists("catalog3" + _extension);
            if (allExists)
            {
                for (int i =0; i < _catalogs.Length; i++)
                {
                    string path = "catalog" + i + "." + _extension;
                    _catalogs[i].Items = _serializer.Load(path);
                }
            }
            else
            {
                CreateCatalogs();
                UpdateSaveBtnState();
            }
            UpdateSaveBtnState();
        }
        private void SaveCatalogs()
        {
            for (int i = 0; i < _catalogs.Length; i++)
            {
                string path = "catalog" + i + "." + _extension;
                Furniture[] items = _catalogs[i].Items;
                string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                _serializer.Save(path, items);
            }
        }

        private void CatalogComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OpenCatalogBtn.IsEnabled = CatalogComboBox.SelectedItem != null;
        }
        private void OpenCatalogBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedCatalog = CatalogComboBox.SelectedItem as FurnitureCatalog;
            if (selectedCatalog == null)
            {
                MessageBox.Show("Выбери каталог");
                return;
            }
            var window = new CatalogWindow(selectedCatalog);
            window.Show();
        }
        private void CreateCatalogs()
        {
            _catalogs = new FurnitureCatalog[4];

            _catalogs[0] = new FurnitureCatalog { Name = "Каталог 1" };
            _catalogs[1] = new FurnitureCatalog { Name = "Каталог 2" };
            _catalogs[2] = new FurnitureCatalog { Name = "Каталог 3" };
            _catalogs[3] = new FurnitureCatalog { Name = "Каталог 4" };
            //МЕБЕЛЬ
            Chair chair1 = new Chair
            {
                Id = 1,
                Article = "A1",
                Brand = "IKEA",
                Model = "Markus",
                Name = "Office Chair",
                _basePrice = 10000,
                ImagePath = "Images/chair1.jpg",
                HasArmrests = true,
                LegsCount = 4
            };

            Chair chair2 = new Chair
            {
                Id = 2,
                Article = "A2",
                Brand = "Herman Miller",
                Model = "Aeron",
                Name = "Premium Chair",
                _basePrice = 50000,
                ImagePath = "Images/chair2.jpg",
                HasArmrests = true,
                LegsCount = 5
            };

            Stool stool1 = new Stool
            {
                Id = 3,
                Article = "A3",
                Brand = "IKEA",
                Model = "FROSTA",
                Name = "Wood Stool",
                _basePrice = 2000,
                ImagePath = "Images/stool1.jpg",
                HasArmrests = false,
                LegsCount = 4,
                HasWheels = false
            };

            Armchair armchair1 = new Armchair
            {
                Id = 4,
                Article = "A4",
                Brand = "BoConcept",
                Model = "Royal",
                Name = "Luxury Armchair",
                _basePrice = 70000,
                ImagePath = "Images/armchair1.jpg",
                HasArmrests = true,
                LegsCount = 4,
                HasGenuineLeather = true
            };

            Sofa sofa1 = new Sofa
            {
                Id = 5,
                Article = "B1",
                Brand = "Lazurit",
                Model = "SoftLine",
                Name = "Corner Sofa",
                _basePrice = 65000,
                ImagePath = "Images/sofa1.jpg",
                IsCorner = true,
                SeatsCounts = 3
            };

            Sofa sofa2 = new Sofa
            {
                Id = 6,
                Article = "B2",
                Brand = "Hoff",
                Model = "Comfort",
                Name = "Classic Sofa",
                _basePrice = 35000,
                ImagePath = "Images/sofa2.jpg",
                IsCorner = false,
                SeatsCounts = 2
            };
            Sofa sofa3 = new Sofa
            {
                Id = 11,
                Article = "B3",
                Brand = "Askona",
                Model = "Grand De Luxe",
                Name = "Sofa Domo Pro",
                _basePrice = 100000,
                ImagePath = "Images/sofa2.jpg",
                IsCorner = true,
                SeatsCounts = 6
            };

            Model.Core.Table table1 = new Model.Core.Table
            {
                Id = 7,
                Article = "C1",
                Brand = "IKEA",
                Model = "Lack",
                Name = "Dining Table",
                _basePrice = 8000,
                ImagePath = "Images/table1.jpg",
                HasDrawers = false,
                SeatsCounts = 4
            };

            Model.Core.Table table2 = new Model.Core.Table
            {
                Id = 8,
                Article = "C2",
                Brand = "IKEA",
                Model = "Bekant",
                Name = "Office Table",
                _basePrice = 12000,
                ImagePath = "Images/table2.jpg",
                HasDrawers = true,
                SeatsCounts = 1
            };

            Bed bed1 = new Bed
            {
                Id = 9,
                Article = "D1",
                Brand = "Hoff",
                Model = "Sleepy",
                Name = "Single Bed",
                _basePrice = 20000,
                ImagePath = "Images/bed1.jpg",
                HasStorageBox = true,
                Size = "Single"
            };

            Bed bed2 = new Bed
            {
                Id = 10,
                Article = "D2",
                Brand = "Lazurit",
                Model = "Dream",
                Name = "Double Bed",
                _basePrice = 35000,
                ImagePath = "Images/bed2.jpg",
                HasStorageBox = false,
                Size = "Double"
            };
            Bed bed3 = new Bed
            {
                Id = 12,
                Article = "D3",
                Brand = "IKEA",
                Model = "Horizon",
                Name = "OneAndHalf Bed",
                _basePrice = 40000,
                ImagePath = "Images/bed2.jpg",
                HasStorageBox = true,
                Size = "OneAndHalf"
            };
            Bed bed4 = new Bed
            {
                Id = 13,
                Article


        = "D4",
                Brand = "The Era",
                Model = "Florence",
                Name = "White gloss King Bed",
                _basePrice = 40000,
                ImagePath = "Images/bed2.jpg",
                HasStorageBox = false,
                Size = "King"
            };

            // Каталог 1
            _catalogs[0].Add(chair1);
            _catalogs[0].Add(sofa1);
            _catalogs[0].Add(table1);
            _catalogs[0].Add(bed1);
            _catalogs[0].Add(stool1);

            // Каталог 2
            _catalogs[1].Add(chair1);
            _catalogs[1].Add(chair2);
            _catalogs[1].Add(sofa2);
            _catalogs[1].Add(table2);
            _catalogs[1].Add(armchair1);

            // Каталог 3
            _catalogs[2].Add(stool1);
            _catalogs[2].Add(armchair1);
            _catalogs[2].Add(sofa1);
            _catalogs[2].Add(bed2);
            _catalogs[2].Add(chair2);

            //Каталог 4
            _catalogs[3].Add(chair2);
            _catalogs[3].Add(armchair1);
            _catalogs[3].Add(sofa3);
            _catalogs[3].Add(bed4);
            _catalogs[3].Add(table1);
        }
    }
}