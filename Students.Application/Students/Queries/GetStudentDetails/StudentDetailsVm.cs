using Students.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Domain;
using AutoMapper;

namespace Students.Application.Students.Queries.GetStudentDetails
{
    public class StudentDetailsVm : IMapWith<Student> // View Model
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDetailsVm>()
                .ForMember(studentVm => studentVm.FirstName,
                opt => opt.MapFrom(student => student.FirstName))
                .ForMember(studentVm => studentVm.LastName,
                opt => opt.MapFrom(student => student.LastName))
                .ForMember(studentVm => studentVm.BirthDay,
                opt => opt.MapFrom(student => student.BirthDay))
                .ForMember(studentVm => studentVm.Id,
                opt => opt.MapFrom(student => student.Id));
        }
    }
}
