using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCoreDemo
{
    public class CourseSession
    {
        [Key]
        public int sessionID { get; set; }

        public string sessionName { get; set; }

        public int courseID { get; set; }

        public CourseInfo course { get; set; }
    }
}
