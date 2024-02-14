using MediatR;

namespace Students.Application.Students.Commands.DeleteCommand
{
    public class DeleteStudentCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }

    }
}
