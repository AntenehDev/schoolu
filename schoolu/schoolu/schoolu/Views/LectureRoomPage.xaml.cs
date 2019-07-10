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
    public partial class LectureRoomPage : CarouselPage
    {
        FirebaseSerivce firebaseSerivce = new FirebaseSerivce();
        public LectureRoomPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allLectureRoom = await firebaseSerivce.GetAllLectureRooms();
            collectionLectureRoom.ItemsSource = allLectureRoom;
        }

        private async void ButtonAddLectureRoom_Clicked(object sender, EventArgs e)
        {
            await buttonAddLectureRoom.TranslateTo(100, 0, 500, Easing.BounceOut);
            await buttonAddLectureRoom.TranslateTo(0, 0);

            await firebaseSerivce.AddLectureRoom(entryLectureRoom.Text);
            entryLectureRoom.Text = string.Empty;
            var allLectureRoom = await firebaseSerivce.GetAllLectureRooms();
            collectionLectureRoom.ItemsSource = allLectureRoom;

        }
    }
}