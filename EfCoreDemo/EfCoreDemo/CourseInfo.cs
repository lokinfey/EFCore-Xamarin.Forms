using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCoreDemo
{
    public class CourseInfo
    {
        [Key]
        public int courseID { get; set; }
        public string courseName { get; set; }

        public List<CourseSession> sessionList { get; set; }
    }
}
