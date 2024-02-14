using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Students.Domain;
using Students.Application.Interfaces;
namespace Students.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler
        :IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly IStudentsDbContext _dbContext;
        public CreateStudentCommandHandler(IStudentsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Id = Guid.NewGuid(),
                BirthDay = DateTime.Now
            };

            await _dbContext.Students.AddAsync(student, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return student.Id;
        }
    }
}
