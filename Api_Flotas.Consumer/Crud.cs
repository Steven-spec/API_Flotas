using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net;

namespace Api_Flotas.Consumer
{
    public static class Crud<T> where T : class
    {
        // Asignar la URL base de la API (ejemplo: "https://localhost:7235/api/conductores")
        public static string EndPoint { get; set; }

        // Reusar el mismo HttpClient para no abrir conexiones nuevas constantemente
        private static readonly HttpClient client = new HttpClient();

        public static List<T> GetAll()
        {
            var response = client.GetAsync(EndPoint).Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        public static T GetById(int id)
        {
            var response = client.GetAsync($"{EndPoint}/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(json);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                // Si no encuentra el recurso, retorna null en vez de lanzar excepción
                return null;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        public static List<T> GetBy(string campo, int id)
        {
            var response = client.GetAsync($"{EndPoint}/{campo}/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        public static T Create(T item)
        {
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(item),
                Encoding.UTF8,
                "application/json"
            );

            var response = client.PostAsync(EndPoint, jsonContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        public static bool Update(int id, T item)
        {
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(item),
                Encoding.UTF8,
                "application/json"
            );

            var response = client.PutAsync($"{EndPoint}/{id}", jsonContent).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        public static bool Delete(int id)
        {
            var response = client.DeleteAsync($"{EndPoint}/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
    }
}
