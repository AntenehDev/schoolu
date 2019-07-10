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
    public partial class BatchNumberPage : CarouselPage
    {
        FirebaseSerivce firebaseSerivce = new FirebaseSerivce();
        public BatchNumberPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allBatchNumbers = await firebaseSerivce.GetAllBatchNumbers();
            collectionViewBatch.ItemsSource = allBatchNumbers;
        }

        private async void ButtonAddBatch_Clicked(object sender, EventArgs e)
        {
            await buttonAddBatch.TranslateTo(100, 0, 500, Easing.BounceOut);
            await buttonAddBatch.TranslateTo(0, 0);

            await firebaseSerivce.AddBatchNumber(entryBatch.Text);
            entryBatch.Text = string.Empty;
            var allBatchNumbers = await firebaseSerivce.GetAllBatchNumbers();
            collectionViewBatch.ItemsSource = allBatchNumbers;

        }
    }
}