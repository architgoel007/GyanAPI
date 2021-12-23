using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyanAPI.Models
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetStudents();
        Student GetStudent(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        void DeleteStudent(Student id);
        Task<IEnumerable<Country>> GetCountry();

    }
}
