using martesbiblio.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace martesbiblio.Views
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