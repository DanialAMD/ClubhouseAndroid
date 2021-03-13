using Clubhouse.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Clubhouse.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}