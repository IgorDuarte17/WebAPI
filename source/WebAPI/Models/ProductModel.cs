using Newtonsoft.Json;

namespace WebAPI.Models
{
    public class ProductModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}