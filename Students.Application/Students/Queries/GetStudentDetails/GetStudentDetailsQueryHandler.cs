using AutoMapper;
using MediatR;
using Students.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Application.Students.Queries.GetStudentDetails
{

    public class GetStudentDetailsQueryHandler
        : IRequestHandler<GetStudentDetailsQuery, StudentDetailsVm>
    {

        private readonly IStudentsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStudentDetailsQueryHandler(IStudentsDbContext dbContext, IMapper mapper) 
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<StudentDetailsVm> Handle(GetStudentDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Students
                .FirstOrDefaultAsync(student => student.Id == request.Id, cancellationToken);
        
        }
    }
}
