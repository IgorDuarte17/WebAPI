using Newtonsoft.Json;

namespace WebAPI.Models
{
    public class OAuthModel
    {
        [JsonProperty("Username")]
        public string userName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}