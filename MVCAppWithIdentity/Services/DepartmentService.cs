using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using MVCAppWithIdentity.Models;

namespace MVCAppWithIdentity.Services
{
    public class DepartmentService : IDepartmentServices
    {
        private readonly HttpClient _httpClient;
        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<Department> Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Department> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            List<Department> departments;
            _httpClient.DefaultRequestHeaders.Authorization =
             new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImVyaWNrQGdtYWlsLmNvbSIsIm5iZiI6MTcwMjQ1OTIzNywiZXhwIjoxNzAyNTQ1NjM3LCJpYXQiOjE3MDI0NTkyMzd9.WqpCZ7CEKoAAblB1fLO7Oa1d6iVu1oRRx087cuPfcRQ");
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5000/api/Departments");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error");
            }
            string content = await response.Content.ReadAsStringAsync();
            departments = JsonSerializer.Deserialize<List<Department>>(content);
            if (departments == null)
            {
                throw new Exception("Error");
            }
            return departments;
        }

        public Task<Department> Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}