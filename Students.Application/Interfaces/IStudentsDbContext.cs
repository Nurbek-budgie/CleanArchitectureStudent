using Students.Domain;
using Microsoft.EntityFrameworkCore;


namespace Students.Application.Interfaces
{
    public interface IStudentsDbContext
    {
        DbSet<Student> Students { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
