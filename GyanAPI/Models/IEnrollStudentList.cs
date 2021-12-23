using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyanAPI.Models
{
    public interface IEnrollStudentList
    {
        Task<IEnumerable<EnrollStudentList>> GetEnrollStudents();
        Task<EnrollStudentList> AddEnrollStudentList(EnrollStudentList enrollStudentList);
    }
}
