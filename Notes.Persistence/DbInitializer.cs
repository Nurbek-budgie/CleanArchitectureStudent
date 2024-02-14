namespace Students.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(StudentDbContext context) { 
            context.Database.EnsureCreated();
        }
    }
}
