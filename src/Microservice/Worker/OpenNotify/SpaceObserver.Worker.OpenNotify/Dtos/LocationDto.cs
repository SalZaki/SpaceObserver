namespace SpaceObserver.Worker.ISS.Dtos
{
    using System.Text.Json.Serialization;

    public class LocationDto
    {
        [JsonPropertyName("iss_position")]
        public IssPositionDto IssPosition { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("timestamp")]
        public long TimeStamp { get; set; }
    }

    public class IssPositionDto
    {
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
    }
}