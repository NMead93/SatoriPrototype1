using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SatoriWeek1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        async void GoToAnimationPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AnimationPage());
        }

        async void ShowAlert(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Question?", "Is the sky blue?", "Yes", "No");
        }

        async void OnSQLiteButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDoHomePage());
        }
    }
}
