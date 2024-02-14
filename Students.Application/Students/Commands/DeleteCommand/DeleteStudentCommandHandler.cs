using MediatR;
using Students.Application.Interfaces; // database
using Students.Application.Common.Exceptions; // exception
using Students.Domain; // Model
using System;
using System.Threading.Tasks;

namespace Students.Application.Students.Commands.DeleteCommand
{
    public class DeleteStudentCommandHandler 
        :IRequestHandler<DeleteStudentCommand>
    {
        private readonly IStudentsDbContext _dbContext;
        public DeleteStudentCommandHandler(IStudentsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteStudentCommand request,
            CancellationToken cancellationToken) // Unit <-- empty answer??
        {
            var entity = await _dbContext.Students
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null && entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            // if found then remove student
            _dbContext.Students.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
