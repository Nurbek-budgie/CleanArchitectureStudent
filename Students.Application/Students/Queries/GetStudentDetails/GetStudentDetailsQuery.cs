using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Students.Application.Students.Queries.GetStudentDetails
{
    public class GetStudentDetailsQuery : IRequest<StudentDetailsVm> // <- View Model
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
