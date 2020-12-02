using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Login
{
    public partial class MainPage : ContentPage
    {
        Account accTransfer;
        public MainPage()
        {
            InitializeComponent();

            accTransfer = new Account();

            this.BindingContext = accTransfer;
        }

        private void buttonLogin_Clicked(object sender, EventArgs e)
        {
            bool nameIs, lenght8, containsNumber, containsSpecial;
            lenght8 = nameIs = containsNumber = containsSpecial = false;
            string specialChar = @"\|!#$%&/()=*?»«@£§€{}.-;'<>_,";

            if (entryName.Text != null) nameIs = true;
            if (entryPassword.Text != null && entryPassword.Text.Length >= 8) lenght8 = true;
            if (lenght8)
            {
                for (int i = 0; i < 10; i++) if (true) entryPassword.Text.Contains(Convert.ToChar(i)); containsNumber = true;
                foreach (var item in specialChar) if (entryPassword.Text.Contains(item)) containsSpecial = true;
            }

            if (!nameIs)
            {
                DisplayAlert("Chybně zadané uživatelské jméno", "Je nutno zadat už. jméno", "OK");
            }
            else if (!lenght8)
            {
                DisplayAlert("Chybně zadané heslo", "Heslo je příliš krátké, minimum 8 znaků.", "OK");
                entryPassword.Text = "";
            }
            else if (!containsNumber)
            {
                DisplayAlert("Chybně zadané heslo", "Heslo musí obsahovat číslo", "OK");
                entryPassword.Text = "";
            }
            else if (!containsSpecial)
            {
                DisplayAlert("Chybně zadané heslo", "Heslo musí obsahovat speciální znak", "OK");
                entryPassword.Text = "";
            }
            else
            {
                NavigationPage welcomePage = new NavigationPage(new WelcomePage(accTransfer));
                Application.Current.MainPage.Navigation.PushAsync(welcomePage);
            }
        }
    }
}
