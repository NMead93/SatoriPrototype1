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
	public partial class ToDoHomePage : ContentPage
	{

        public ToDoHomePage ()
		{
			InitializeComponent ();
		}

        public async void OnAddItemClicked(object sender, EventArgs e)
        {
            StatusMessage.Text = string.Empty;
            await ItemRepository.Instance.AddNewItem(newItem.Text);
            StatusMessage.Text = ItemRepository.Instance.StatusMessage;
        }

        public async void OnGetItemsClicked(object sender, EventArgs e)
        {
            StatusMessage.Text = string.Empty;
            var items = await ItemRepository.Instance.GetAllItems();
            itemList.ItemsSource = items;
        }
	}
}