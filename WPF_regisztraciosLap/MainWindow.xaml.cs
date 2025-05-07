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
using System.IO;
using System.Text.RegularExpressions;

namespace WPF_regisztraciosLap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<adat> Adatok=new List<adat>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_regisztracio_Click(object sender, RoutedEventArgs e)
        {
            string nev=tbx_nev.Text;
            string email=tbx_emailcim.Text;
            string jelszo=tbx_jelszo.Text;
            if (IsValidEmail(email)==false)
            {
                MessageBox.Show("Hibás email cím!");
                
                tbx_emailcim.Clear();
                
            }
        
            else if (IsValidPassword(jelszo) == false)
            {
                MessageBox.Show("Hibás jelszó!");
                
                
                tbx_jelszo.Clear();
            }

            else
            {
                fajlbaIr(nev, email, jelszo);
                var egyadat = new adat(nev, email, jelszo);
                Adatok.Add(egyadat);
                MessageBox.Show("Sikeres regisztráció");
                tbx_nev.Clear();
                tbx_emailcim.Clear();
                tbx_jelszo.Clear();
            }

            

            
        }
        private void fajlbaIr(string nev, string email, string jelszo)
        {
            using (StreamWriter iro = new StreamWriter("adat.txt", append:true))
            {
                iro.WriteLine($"{nev};{email};{jelszo};");
            }

        }
        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            if (!Regex.IsMatch(password, @"^(?=.*\d)(?=.*[^\w\s]).{8,}$"))
            {
                return false;
            }

            return true;
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            int atIndex = email.IndexOf("@");
            if (atIndex <= 0 || atIndex != email.LastIndexOf("@"))
            {
                return false;
            }
            string localPart = email.Substring(0, atIndex);
            string domainPart = email.Substring(atIndex + 1);
            if (string.IsNullOrEmpty(localPart) || string.IsNullOrEmpty(domainPart))
            {
                return false;
            }
            int dotIndex = email.LastIndexOf(".");
            if (dotIndex <= 0 || dotIndex == email.Length - 1)
            {
                return false;
            }
            int dotindexFirst = email.IndexOf(".");
            if (dotindexFirst <= 0)
            {
                return false;
            }

            return true;
        }
    }

}
