using itTrend.Models;
using System;
using System.Linq;

namespace itTrend.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var Students = new Student[]
            {
            new Student{StudentID=1,FullName="Alexander Trofim",Phone="23232424",Photo="https://catherineasquithgallery.com/uploads/posts/2021-03/1614560341_16-p-ikonki-na-belom-fone-18.png"},
            new Student{StudentID=2,FullName="Alonso Xavi",Phone="351235",Photo="https://catherineasquithgallery.com/uploads/posts/2021-03/1614560341_16-p-ikonki-na-belom-fone-18.png"},
            new Student{StudentID=3,FullName="Anand Ormandji",Phone="21343214",Photo="https://catherineasquithgallery.com/uploads/posts/2021-03/1614560341_16-p-ikonki-na-belom-fone-18.png"},
            new Student{StudentID=4,FullName="Barzdukas Kalyn",Phone="523152135",Photo="https://catherineasquithgallery.com/uploads/posts/2021-03/1614560341_16-p-ikonki-na-belom-fone-18.png"},
            new Student{StudentID=5,FullName="Li Budu",Phone="23141234",Photo="https://catherineasquithgallery.com/uploads/posts/2021-03/1614560341_16-p-ikonki-na-belom-fone-18.png"},
            new Student{StudentID=6,FullName="Justice One",Phone="23152315",Photo="https://catherineasquithgallery.com/uploads/posts/2021-03/1614560341_16-p-ikonki-na-belom-fone-18.png"},
            new Student{StudentID=7,FullName="Norman Holland",Phone="21341234",Photo="https://catherineasquithgallery.com/uploads/posts/2021-03/1614560341_16-p-ikonki-na-belom-fone-18.png"},
            new Student{StudentID=8,FullName="Olivetto Piery",Phone="634623",Photo="https://catherineasquithgallery.com/uploads/posts/2021-03/1614560341_16-p-ikonki-na-belom-fone-18.png"}
            };
            foreach (Student s in Students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var Groups = new Group[]
            {
            new Group{Number=1050,Specialization="Chemistry",CourseID=3,FullNameID="Alexander Trofim"},
            new Group{Number=4022,Specialization="Microeconomics",CourseID=3,FullNameID="sdsd kfs"},
            new Group{Number=4041,Specialization="Macroeconomics",CourseID=3,FullNameID="sd sf"},
            new Group{Number=1045,Specialization="Calculus",CourseID=4,FullNameID="asfsaf sagasg"},
            new Group{Number=3141,Specialization="Trigonometry",CourseID=4,FullNameID="saf safasf"},
            new Group{Number=2021,Specialization="Composition",CourseID=3,FullNameID="asg gwg"},
            new Group{Number=2042,Specialization="Literature",CourseID=4,FullNameID="rey vncknll"}
            };
            foreach (Group c in Groups)
            {
                context.Groups.Add(c);
            }
            context.SaveChanges();
        }
    }
}