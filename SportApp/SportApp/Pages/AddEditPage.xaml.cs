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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        public string FlagAddOrEdit = "default";
        public Data.Users CurrentUser = new Data.Users();
        public AddEditPage(Data.Users _user)
        {
            
            InitializeComponent();
            if(_user != null)
            {
                CurrentUser = _user;
                FlagAddOrEdit = "edit";
            }
            else
            {
                FlagAddOrEdit = "add";
            }
            DataContext = CurrentUser;
            Init();
        }

        public void Init()
        {
            try
            {
                RoleComboBox.ItemsSource = Data.User1Entities.GetContext().RoleName.ToList();
                GenderComboBox.ItemsSource = Data.User1Entities.GetContext().GenderName.ToList();
                if(FlagAddOrEdit == "add")
                {
                    UserNameTextBox.Text = string.Empty;
                    RoleComboBox.SelectedItem = null;
                    NumberPhoneTextBox.Text = string.Empty;
                    GenderComboBox.SelectedItem = null;
                    EmailTextBox.Text = string.Empty;
                    LoginTextBox.Text = string.Empty;
                    PasswordTextBox.Text = string.Empty;
                } else if (FlagAddOrEdit == "edit")
                {
                    UserNameTextBox.Text = CurrentUser.NameUser;
                    RoleComboBox.SelectedItem = Data.User1Entities.GetContext().RoleName
                        .Where(d => d.Id == CurrentUser.IdRole).FirstOrDefault();
                    NumberPhoneTextBox.Text = CurrentUser.NumberPhone;
                    GenderComboBox.SelectedItem = Data.User1Entities.GetContext().GenderName
                        .Where(d => d.Id == CurrentUser.IdGender).FirstOrDefault();
                    EmailTextBox.Text = CurrentUser.Email;
                    LoginTextBox.Text = CurrentUser.Login;
                    PasswordTextBox.Text = CurrentUser.Password;
                    ConfirmPasswordTextBox.Text = PasswordTextBox.Text;
                }
            }
            catch
            {

            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrEmpty(UserNameTextBox.Text))
                {
                    errors.AppendLine("Заполните ФИО!");
                }
                if (string.IsNullOrEmpty(NumberPhoneTextBox.Text))
                {
                    errors.AppendLine("Заполните номер телефона!");
                }
                if (string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    errors.AppendLine("Заполните почту!");
                }
                if (string.IsNullOrEmpty(LoginTextBox.Text))
                {
                    errors.AppendLine("Заполните логин!");
                }
                if (string.IsNullOrEmpty(PasswordTextBox.Text))
                {
                    errors.AppendLine("Заполните пароль!");
                }
                if (string.IsNullOrEmpty(ConfirmPasswordTextBox.Text))
                {
                    errors.AppendLine("Заполните повторно пароль!");
                }
                if(errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBox.Show("Успех, но логики нет!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                Classes.Manager.MainFrame.Navigate(new Pages.ListViewUsers());
            }
            catch
            {

            }
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.ListViewUsers());
        }
    }
}
