
using C01.BasicSaveWithTracking.Data;
using C01.BasicSaveWithTracking.Entities;
using C01.BasicSaveWithTracking.Helpers;

namespace BasicSaveWithTracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RunBasicSave();
            //RunBasicUpdate();
            //RunBasicDelete();
            //RunMultipleOPWithSingleSave();
            //RunRelatedData();

        }

        private static void RunBasicUpdate()
        {
          using(var context = new AppDbContext())
            {
                var author = context.Authors
                    .FirstOrDefault(x => x.Id == 1);
                author.FName = "Eric";
                context.SaveChanges();
            }
        }
        private static void RunBasicDelete()
        {
            using (var context = new AppDbContext())
            {
                var author = context.Authors
                    .FirstOrDefault(x => x.Id == 1);

               context.Authors.Remove(author);

                context.SaveChanges();
            }
        }
        private static void RunBasicSave()
        {
            DatabaseHelper.RecreateCleanDatabase();
          
            using (var context = new AppDbContext())
            {
                var author = new Author { Id = 1, FName = "eric", LName = "Evan" };
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }
        private static void RunMultipleOPWithSingleSave()
        {
            DatabaseHelper.RecreateCleanDatabase();

            using (var context = new AppDbContext())
            {
                var author01 = new Author { Id = 1, FName = "eric", LName = "Evan" };
                context.Authors.Add(author01);

                var author02 = new Author { Id = 2, FName = "Yousef", LName = "ALi" };
                context.Authors.Add(author02);

                var author03 = new Author { Id = 3, FName = "Sra", LName = "ALi" };
                context.Authors.Add(author03);

                author03.FName = "Sara";
                context.SaveChanges();
            }
        }
        private static void RunRelatedData()
        {

            using (var context = new AppDbContext())
            {
                var author01 = context.Authors.FirstOrDefault(x => x.Id == 1);

                author01.Books.Add(new Book
                {
                    Id = 1,
                    Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software"
                });

                context.SaveChanges();
            }
        }

    }
}
