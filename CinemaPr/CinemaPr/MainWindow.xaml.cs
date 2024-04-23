using System;
using System.Windows;
using System.Windows.Controls;
using CinemaPr.CinemaPrDataSetTableAdapters;

namespace CinemaPr
{
    public partial class MainWindow : Window
    {
        private readonly UserRolesTableAdapter roleAdapter = new UserRolesTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
            UsersRolesDgr.ItemsSource = roleAdapter.GetData().Rows;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var logins = roleAdapter.GetData().Rows;

            foreach (var login in logins)
            {
                if (login.ToString() == LoginBox.Text)
                {
                    int roleId = Convert.ToInt32(login);

                    switch (roleId)
                    {
                        case 1:
                            var User = new User();
                            User.Show();
                            break;
                        case 2:
                            var Kassir = new Kassir();
                            Kassir.Show();
                            break;
                        default:
                            MessageBox.Show("Invalid role ID");
                            break;
                    }

                    return;
                }
            }

            MessageBox.Show("Invalid username");
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Можно добавить обработку изменения текста в поле логина
        }
    }
}
