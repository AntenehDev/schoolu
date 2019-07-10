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
    }
}
