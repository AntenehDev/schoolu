using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using schoolu.Models;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;

namespace schoolu.Services
{
    class FirebaseSerivce
    {
        FirebaseClient firebase = new FirebaseClient("https://antenehdevschoolu.firebaseio.com/");

        public async Task<List<BatchNumber>> GetAllBatchNumbers()
        {
            return (await firebase
            .Child("BatchNumbers")
            .OnceAsync<BatchNumber>()).Select(item => new BatchNumber
            {
                BatchNo = item.Object.BatchNo
            }).ToList();
        }

        public async Task AddBatchNumber(string batchNo)
        {
            await firebase
            .Child("BatchNumbers")
            .PostAsync(new BatchNumber() { BatchNo = batchNo });
        }

        public async Task<List<LectureRoom>> GetAllLectureRooms()
        {
            return (await firebase
            .Child("LectureRooms")
            .OnceAsync<LectureRoom>()).Select(item => new LectureRoom
            {
                LR = item.Object.LR
            }).ToList();
        }

        public async Task AddLectureRoom(string lR)
        {
            await firebase
            .Child("LectureRooms")
            .PostAsync(new LectureRoom() { LR = lR });
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return (await firebase
            .Child("Courses")
            .OnceAsync<Course>()).Select(item => new Course
            {
                CoruseCode = item.Object.CoruseCode,
                CourseTitle = item.Object.CourseTitle,
                CreditHours = item.Object.CreditHours

            }).ToList();
        }

        public async Task AddCourse(string coruseCode, string courseTitle, int creditHours)
        {
            await firebase
            .Child("Courses")
            .PostAsync(new Course() { CoruseCode = coruseCode, CourseTitle = courseTitle, CreditHours = creditHours });
        }

        public async Task<Course> GetCourse(string coruseCode)
        {
            var allCourses = await GetAllCourses();
            await firebase
            .Child("Courses")
            .OnceAsync<Course>();
            return allCourses.Where(a => a.CoruseCode == coruseCode).FirstOrDefault();
        }

        public async Task UpdateCourse(string coruseCode, string courseTitle, int creditHours)
        {
            var toUpdateCourse = (await firebase
            .Child("Courses")
            .OnceAsync<Course>()).Where(a => a.Object.CoruseCode == coruseCode).FirstOrDefault();
            await firebase
            .Child("Courses")
            .Child(toUpdateCourse.Key)
            .PutAsync(new Course() { CoruseCode = coruseCode, CourseTitle = courseTitle, CreditHours = creditHours });
        }

        public async Task DeleteCourse(string coruseCode)
        {
            var toDeleteCourse = (await firebase
            .Child("Courses")
            .OnceAsync<Course>()).Where(a => a.Object.CoruseCode == coruseCode).FirstOrDefault();
            await firebase.Child("Courses").Child(toDeleteCourse.Key).DeleteAsync();
        }

        public async Task<List<WeekSchedule>> GetAllWeekSchedules()
        {
            return (await firebase
            .Child("WeekSchedules")
            .OnceAsync<WeekSchedule>()).Select(item => new WeekSchedule
            {
                BatchNo = item.Object.BatchNo,
                Mon = item.Object.Mon,
                Tue = item.Object.Tue,
                Wed = item.Object.Wed,
                Thu = item.Object.Thu,
                Fri = item.Object.Fri,
                Sat = item.Object.Sat,
            }).ToList();
        }

        public async Task AddWeekSchedule(string batchNo, string mon, string tue, string wed, string thu, string fri, string sat)
        {
            await firebase
            .Child("WeekSchedules")
            .PostAsync(new WeekSchedule() { BatchNo = batchNo, Mon = mon, Tue = tue, Wed = wed, Thu = thu, Fri = fri, Sat = sat });
        }

    }
}
