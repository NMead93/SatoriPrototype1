using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SatoriWeek1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnimationPage : ContentPage
	{
		public AnimationPage ()
		{
			InitializeComponent ();
		}

        private async void OnAnimationClicked(object sender, EventArgs e)
        {
            await AnimationGrid.TranslateTo(200, 300, 1000, Easing.Linear);
            await AnimationGrid.RotateTo(90, 1000, Easing.SinOut);
            await AnimationGrid.FadeTo(0.4, 800, Easing.CubicOut);
            await AnimationGrid.LayoutTo(new Rectangle(-200, -300, 300, 100));
            await AnimationGrid.ScaleTo(0.5, 500, Easing.CubicIn);
        }
	}
}