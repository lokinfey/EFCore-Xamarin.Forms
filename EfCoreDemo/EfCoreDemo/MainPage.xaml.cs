using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace EfCoreDemo
{
    public class SessionView
    {
        public string SessionName { get; set; }
    }

	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            LoadData();



        }

        async void LoadData()
        {
#if __IOS__
            string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine (documentsPath, "..", "Library");
#else
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
#endif
            var path = Path.Combine(libraryPath, "course.db");

                try
                {
                    using (var db = new CourseDbContext(path))
                    {
                        //db.Database.OpenConnection();
                        await db.Database.MigrateAsync();
                        CourseInfo info1 = new CourseInfo() { courseID = 1000, courseName = "Xamarin in action" };
                        CourseInfo info2 = new CourseInfo() { courseID = 1001, courseName = "Azure" };

                        List<CourseInfo> courseList = new List<CourseInfo>() { info1, info2 };

                        if (await db.Courses.CountAsync() < 2)
                        {
                            await db.Courses.AddRangeAsync(courseList);
                            await db.SaveChangesAsync();
                        }

                        CourseSession session1 = new CourseSession() { sessionID = 1, sessionName = "1. What's Xamarin", courseID = 1000 };
                        CourseSession session2 = new CourseSession() { sessionID = 2, sessionName = "1. What's azure", courseID = 1001 };
                        CourseSession session3 = new CourseSession() { sessionID = 3, sessionName = "2. Xamarin Installation", courseID = 1000 };


                        List<CourseSession> sessionList = new List<CourseSession>() { session1, session2,session3 };


                        if (await db.Sessions.CountAsync() < 3)
                        {
                            await db.Sessions.AddRangeAsync(sessionList);
                            await db.SaveChangesAsync();
                        }

                        var list = await db.Sessions.ToListAsync();

                    var session = list.Where(item => item.courseID == 1000);
                    ObservableCollection<SessionView> viewList = new ObservableCollection<SessionView>();

                    foreach (var item in session)
                    {
                        viewList.Add(new SessionView { SessionName = item.sessionName });
                    }
                    SessionListView.ItemsSource = viewList;



                    }


                }
                catch (Exception ex)
                {
                    var temp = ex.ToString();
                }

        }
    }
}
