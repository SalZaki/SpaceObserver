namespace SpaceObserver.Worker.ISS.Infrastructure.OpenNotify
{
    using Dtos;
    using Framework.JsonConverters;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Net.Http;
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Text.Unicode;
    using System.Threading.Tasks;

    internal sealed class OpenNotifyService : IOpenNotifyService
    {
        private readonly OpenNotifySettings _settings;
        private readonly ILogger<OpenNotifyService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _serializerOptions;

        public OpenNotifyService(
            OpenNotifySettings settings,
            IHttpClientFactory httpClientFactory,
            ILogger<OpenNotifyService> logger)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            };
            _serializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            _serializerOptions.Converters.Add(new JsonStringDoubleConverter());
        }

        public async Task<LocationDto> GetIssLocationAsync()
        {
            using var httpClient = _httpClientFactory.CreateClient(_settings.Name);
            var response = await httpClient.GetAsync($"{_settings.IssLocationEndpoint}");
            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<LocationDto>(responseStream, _serializerOptions);
        }
    }
}