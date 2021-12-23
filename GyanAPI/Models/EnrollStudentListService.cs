using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyanAPI.Models
{
    public class EnrollStudentListService : IEnrollStudentList
    {
        public ApplicationContext _Context { get; }
        public EnrollStudentListService(ApplicationContext context)
        {
            _Context = context;
        }

        public async Task<EnrollStudentList> AddEnrollStudentList(EnrollStudentList enrollStudentList)
        {
            try
            {
                var result= await _Context.EnrollStudentList.AddAsync(enrollStudentList);
                await _Context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<EnrollStudentList>> GetEnrollStudents()
        {
            try
            {
                return await _Context.EnrollStudentList.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
