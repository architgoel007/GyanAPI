using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebAppGyanAPI.Models;

namespace WebAppGyanAPI.Controllers
{
    public class TestEnrollStudentListController : Controller
    {
        public IActionResult EnrollListIndex()
        {
            IEnumerable<TestEnrollStudentList> enrollStudentLists = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44344/Api/EnrollStudentList");
                var responseTask = client.GetAsync("");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<TestEnrollStudentList>>();
                    enrollStudentLists = readTask.Result;
                }
                else
                {
                    enrollStudentLists = Enumerable.Empty<TestEnrollStudentList>();
                    ModelState.AddModelError(string.Empty, "Internal Server error!");
                }
            }
            return View(enrollStudentLists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsyc([FromBody] List<TestEnrollStudentList> testEnrollStudentList)
        {
            try
            {
                int index = 0;
                StringBuilder name = new StringBuilder();
                foreach (var item in testEnrollStudentList)
                {
                    name.Append(item.Name+",");
                     index =  index + 1;
                }
                index = index - 1;
                string namelist = name.ToString().TrimEnd(',');
                
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(testEnrollStudentList[index]);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.PostAsync("https://localhost:44344/Api/EnrollStudentList", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var finalvalue = JsonConvert.DeserializeObject<TestEnrollStudentList>(apiResponse);
                    }
                    else
                    {
                        return Ok("Could Not register Successfully!...........Pls try Again");
                    }
                }
            }
            catch (Exception)
            {
                return View();
            }
            return RedirectToAction("EnrollListIndex");
        }
    }
}
