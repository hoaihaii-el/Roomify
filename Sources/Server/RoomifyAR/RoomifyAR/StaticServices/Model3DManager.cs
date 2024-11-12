using Newtonsoft.Json;
using RoomifyAR.Errors;
using System.Text;
using System.Text.Json;

namespace RoomifyAR.StaticServices
{
    public class Model3DManager
    {
        private readonly IConfiguration _config;

        public Model3DManager(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> AddTaskCreate3DModel(string imageUrl)
        {
            string apiKey = _config["Meshy:APIKey"] ?? "";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            var payload = new
            {
                image_url = imageUrl,
                enable_pbr = true
            };

            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var createResponse = "";

            try
            {
                var response = await client.PostAsync("https://api.meshy.ai/v1/image-to-3d", content);
                response.EnsureSuccessStatusCode(); 

                createResponse = await response.Content.ReadAsStringAsync();
                var jsonDoc = JsonDocument.Parse(createResponse);
                string taskId = jsonDoc.RootElement.GetProperty("result").GetString() ?? "";

                return taskId;
            }
            catch (HttpRequestException)
            {
                throw new CustomException("Too many requests. Please wait!");
            }
        }

        public async Task<string> GetTaskResult(string taskId)
        {
            string apiKey = _config["Meshy:APIKey"] ?? "";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://api.meshy.ai/v1/image-to-3d/{taskId}");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                if (responseBody.Contains("IN_PROGRESS"))
                {
                    throw new CustomException("The creation is in progress. Please wait!");
                }

                var jsonDoc = JsonDocument.Parse(responseBody);
                var modelUrls = jsonDoc.RootElement.GetProperty("model_urls");

                string glbUrl = modelUrls.GetProperty("glb").GetString() ?? "";
                string objUrl = modelUrls.GetProperty("obj").GetString() ?? "";

                return objUrl;
            }
            catch (HttpRequestException)
            {
                throw new CustomException("Can not create 3D model.");
            }
        }
    }
}
