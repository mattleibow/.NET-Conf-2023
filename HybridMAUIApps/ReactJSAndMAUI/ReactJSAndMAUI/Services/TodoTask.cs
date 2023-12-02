using System.Text.Json.Serialization;

namespace ReactJSAndMAUI
{
    public class TodoTask
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
    }
}
