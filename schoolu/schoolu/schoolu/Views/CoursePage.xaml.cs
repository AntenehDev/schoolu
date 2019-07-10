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
    public partial class CoursePage : CarouselPage
    {
        FirebaseSerivce firebaseSerivce = new FirebaseSerivce();
        public CoursePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allCourses = await firebaseSerivce.GetAllCourses();
            CollectionViewCourse.ItemsSource = allCourses;
        }

        private async void ButtonAddCourse_Clicked(object sender, EventArgs e)
        {
            await buttonAddCourse.TranslateTo(100, 0, 500, Easing.BounceOut);
            await buttonAddCourse.TranslateTo(0, 0);

            await firebaseSerivce.AddCourse(entryCourseCode.Text, entryCourseTitle.Text, Convert.ToInt32(stepperCreditHours.Value));
            entryCourseCode.Text = string.Empty;
            entryCourseTitle.Text = string.Empty;
            var allCourses = await firebaseSerivce.GetAllCourses();
            CollectionViewCourse.ItemsSource = allCourses;
        }

        private async void ButtonRetrieveCourse_Clicked(object sender, EventArgs e)
        {
            var course = await firebaseSerivce.GetCourse(entryCourseCode.Text);
            if (course != null)
            {
                entryCourseCode.Text = course.CoruseCode;
                entryCourseTitle.Text = course.CourseTitle;
                stepperCreditHours.Value = course.CreditHours;
                await DisplayAlert("Success", "Course Retrive Successfully", "OK");
            }
            else
            {
                await DisplayAlert("Success", "Course was not available", "OK");
            }
        }

        private async void ButtonUpdateCourse_Clicked(object sender, EventArgs e)
        {
            await firebaseSerivce.UpdateCourse(entryCourseCode.Text, entryCourseTitle.Text, Convert.ToInt32(stepperCreditHours.Value));
            entryCourseCode.Text = string.Empty;
            entryCourseTitle.Text = string.Empty;
            await DisplayAlert("Success", "Course Updated Successfully", "OK");
            var allCourses = await firebaseSerivce.GetAllCourses();
            CollectionViewCourse.ItemsSource = allCourses;
        }

        private async void ButtonDeleteCourse_Clicked(object sender, EventArgs e)
        {
            await firebaseSerivce.DeleteCourse(entryCourseCode.Text);
            entryCourseCode.Text = string.Empty;
            entryCourseTitle.Text = string.Empty;
            await DisplayAlert("Success", "Course Deleted Successfully", "OK");
            var allCourses = await firebaseSerivce.GetAllCourses();
            CollectionViewCourse.ItemsSource = allCourses;
        }
    }
}