using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Students.Application.Interfaces;
using Students.Application.Common.Exceptions;
using Students.Domain;

namespace Students.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler
        : IRequestHandler<UpdateStudentCommand>
    {

        private readonly IStudentsDbContext _dbContext;
        public UpdateStudentCommandHandler(IStudentsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateStudentCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Students.FirstOrDefaultAsync(student =>
            student.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            } // Not Found

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.BirthDay = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
