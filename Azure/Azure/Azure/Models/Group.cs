using Newtonsoft.Json;

namespace Azure.Models
{
    public class Group
    {
        [JsonProperty("personGroupId")]
        public string PersonGroupId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Nombre: {this.Name}, PersonGroupId: {this.PersonGroupId}";
        }
    }
}
