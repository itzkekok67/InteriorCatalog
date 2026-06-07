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
    /// Логика взаимодействия для FurnitureImageWindow.xaml
    /// </summary>
    public partial class FurnitureImageWindow : Window
    {
        public FurnitureImageWindow(Furniture furniture)
        {
            InitializeComponent();

            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,furniture.ImagePath);
            FurnitureImage.Source = new BitmapImage(new Uri(fullPath));
            FurnitureNameText.Text = furniture.Name;
        }
    }
}
