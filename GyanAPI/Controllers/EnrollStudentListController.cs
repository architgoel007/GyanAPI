using GyanAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollStudentListController : ControllerBase
    {
        public IEnrollStudentList _EnrollStudentList { get; }
        public EnrollStudentListController(IEnrollStudentList enrollStudentList)
        {
            _EnrollStudentList = enrollStudentList;
        }

        [HttpPost]
        public async Task<EnrollStudentList> AddEnrollStudentList(EnrollStudentList enrollStudentList)
        {
            try
            {
                var result = await _EnrollStudentList.AddEnrollStudentList(enrollStudentList);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<EnrollStudentList>> GetEnrollStudentLists()
        {
            try
            {
                return await _EnrollStudentList.GetEnrollStudents();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
