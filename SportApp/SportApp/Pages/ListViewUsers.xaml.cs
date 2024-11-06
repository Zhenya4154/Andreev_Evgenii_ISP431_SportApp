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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListViewUsers.xaml
    /// </summary>
    public partial class ListViewUsers : Page
    {
        public ListViewUsers()
        {
            InitializeComponent();
            UsersListView.ItemsSource = Data.User1Entities.GetContext().Users.ToList();
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddEditPage((sender as Button).DataContext as Data.Users));
        }

        private void AddEditbutton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddEditPage(null));
        }
    }
}
