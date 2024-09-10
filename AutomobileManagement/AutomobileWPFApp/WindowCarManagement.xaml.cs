using AutomobileLibrary.DataAccess;
using AutomobileLibrary.Repository;
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

namespace AutomobileWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WindowCarManagement : Window
    {
        private ICarRepository carRepository;

        // Constructor accepting DI for ICarRepository
        public WindowCarManagement(ICarRepository repository)
        {
            InitializeComponent();
            carRepository = repository;
            LoadCarList();
        }

        // Method to get Car object from form inputs
        private Car GetCarObject()
        {
            Car car = null;
            try
            {
                car = new Car
                {
                    CarID = int.Parse(txtCarId.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleasedYear = int.Parse(txtReleasedYear.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get car");
            }
            return car;
        }

        // Method to load car list into the UI
        public void LoadCarList()
        {
            try
            {
                lvCars.ItemsSource = carRepository.GetCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load car list");
            }
        }


        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadCarList();
        }

        // Insert button click event
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                carRepository.InsertCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} inserted successfully.", "Insert car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert car");
            }
        }

        // Update button click event
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                carRepository.UpdateCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} updated successfully.", "Update car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update car");
            }
        }

        // Delete button click event
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                carRepository.DeleteCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} deleted successfully.", "Delete car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete car");
            }
        }

        // Close button click event
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}