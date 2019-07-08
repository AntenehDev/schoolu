using System;
using System.Collections.Generic;
using System.Text;

namespace schoolu.Models
{
    class ASchedule
    {
        public string BatchNo { get; set; }
        public string CourseTile { get; set; }
        public string LectureRoom { get; set; }
        public DateTime DateUtc { get; set; }
        public TimeSpan Strating { get; set; }
        public TimeSpan Ending { get; set; }
        public string Message { get; set; }
    }
}
