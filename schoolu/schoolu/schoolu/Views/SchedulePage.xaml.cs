using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using schoolu.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace schoolu.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulePage : CarouselPage
    {
        FirebaseSerivce firebaseSerivce = new FirebaseSerivce();
        public SchedulePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allWeekSchedules = await firebaseSerivce.GetAllWeekSchedules();
            CollectionViewSchedule.ItemsSource = allWeekSchedules;
        }

        private async void ButtonUpdateSchedule_Clicked(object sender, EventArgs e)
        {
            await buttonAddSchedule.TranslateTo(100, 0, 500, Easing.BounceOut);
            await buttonAddSchedule.TranslateTo(0, 0);

            await firebaseSerivce.AddWeekSchedule(BatchNo.Text, Monday.Text, Tuseday.Text, Wednesday.Text, Thursday.Text, Friday.Text, Saturday.Text);
            BatchNo.Text = string.Empty;
            Monday.Text = string.Empty;
            Tuseday.Text = string.Empty;
            Wednesday.Text = string.Empty;
            Thursday.Text = string.Empty;
            Friday.Text = string.Empty;
            Saturday.Text = string.Empty;
            var allWeekSchedules = await firebaseSerivce.GetAllWeekSchedules();
            CollectionViewSchedule.ItemsSource = allWeekSchedules;
        }

        private async void ButtonDeleteSchedule_Clicked(object sender, EventArgs e)
        {

        }

        private async void ButtonAddSchedule_Clicked(object sender, EventArgs e)
        {

        }

        private async void ButtonRetrieveSchedule_Clicked(object sender, EventArgs e)
        {

        }
    }
}