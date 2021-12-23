using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using WebAppGyanAPI.Models;
using Nancy.Json;

namespace WebAppGyanAPI.Controllers
{
    public class TestStudentController : Controller
    {
        //Get All Students
        public IActionResult Index()
        {
            IEnumerable<TestStudent> students = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44344/Api/Student");
                var responseTask = client.GetAsync("");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<TestStudent>>();
                    students = readTask.Result;
                }
                else
                {
                    students = Enumerable.Empty<TestStudent>();
                    ModelState.AddModelError(string.Empty, "Internal Server error!");
                }
            }
            return View(students);
        }

        //Get Student details By Id
        public async Task<ActionResult> Details(int id)
        {
            Root testStudent = null;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:44344");
                    var responseTask = httpClient.GetAsync("/Api/Student/" + id.ToString());
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        testStudent = new Root();
                        var readTask = await result.Content.ReadAsStringAsync();
                        var detail = JsonConvert.DeserializeObject<Root>(readTask);
                        if (detail.data != null)
                        {
                            var studentDetail = JsonConvert.DeserializeObject<TestStudent>(detail.data.ToString());
                            return View(studentDetail);
                        }
                    }
                    else
                    {
                        return Ok("Student Record Not Found!");
                    }
                }
            }
            catch
            {
                return Ok("Internal Server error!");
            }
            return View(testStudent.data);
        }
        public ActionResult Create()
        {
            return View();
        }
        //Add New Student
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(TestStudent teststudent)
        {
            try
            {
                //Subjects Add

                string[] textboxValues = Request.Form["DynamicTextBox"];
                string subject = string.Empty;
                foreach (string textboxValue in textboxValues)
                {
                    subject += textboxValue + ",";
                }
                subject = subject.TrimEnd(',');
                teststudent.Subject = subject;

                //record add.

                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(teststudent);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var uri = httpClient.BaseAddress = new Uri("https://localhost:44344");
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.PostAsync("/Api/Student", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var finalvalue = JsonConvert.DeserializeObject<Root>(apiResponse);
                    }
                    else
                    {
                        return Ok("Could Not register Successfully!...........Pls try Again");
                    }
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Root testStudent = null;
            TestStudent Student = new TestStudent();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://localhost:44344");
                    var responseTask = httpClient.GetAsync("/Api/Student/" + id.ToString());
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        testStudent = new Root();
                        var readTask = await result.Content.ReadAsStringAsync();
                        var d = JsonConvert.DeserializeObject<Root>(readTask);
                        if (d.data != null)
                        {
                            var editStudent = JsonConvert.DeserializeObject<TestStudent>(d.data.ToString());
                            return View(editStudent);
                        }
                    }
                    //else
                    //{
                    //    return Ok("Student Record Not Found!");
                    //}
                }
            }
            catch(Exception)
            {
                return Ok("Internal Server error!");
            }
            return View(testStudent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TestStudent student)
        {
            try
            {
                //Add More Subjects in Subject String

                string[] textboxValues = Request.Form["DynamicTextBox"];
                string subject = string.Empty;
                foreach (string textboxValue in textboxValues)
                {
                    subject += textboxValue + ",";
                }
                subject = subject.TrimEnd(',');
                student.Subject = subject;

                //Get record

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44344");

                    //HTTP POST record
                    var putTask = client.PutAsJsonAsync<TestStudent>("/Api/Student/", student);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
                return View();
            }
            return View(student);
        }


        public ActionResult Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44344");
                    var deleteTask = client.DeleteAsync("/Api/Student/" + id.ToString());
                    deleteTask.Wait();
                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        
    }
}
