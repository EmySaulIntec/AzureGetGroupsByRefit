using Azure.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Azure.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupPage : ContentPage
    {
        public GroupPage()
        {
            InitializeComponent();
            this.BindingContext = new GroupViewModelPage();
        }
    }
}