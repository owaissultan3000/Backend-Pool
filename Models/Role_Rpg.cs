using System.Text.Json.Serialization;

namespace carpool.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role_Rpg
    {
        User,
        Captain

    }
}
