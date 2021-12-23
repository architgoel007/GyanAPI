using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyanAPI.Models
{
    public class StudentService : IStudent
    {
        private readonly ApplicationContext dbContext;
        public StudentService(ApplicationContext context)
        {
            dbContext = context;
        }
        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                var result = await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception )
            {
                throw ;
            }
        }
        public void DeleteStudent(Student id)
        {
            try
            {
                if (id.Id > 0)
                {
                    dbContext.Students.Remove(id);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw ;
            }
        }
       
       public async Task<IEnumerable<Student>> GetStudents()
        {
            try
            {
                return await dbContext.Students.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Student GetStudent(int id)
        {
            try
            {
                var stu1 = dbContext.Students.FirstOrDefault(e => e.Id == id);
                return stu1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<Student> UpdateStudent(Student student)
        {
            try
            {
                if (student != null)
                {
                    dbContext.Entry(student).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public async Task<IEnumerable<Country>> GetCountry()
        {
            try
            {
                return await dbContext.Countries.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

