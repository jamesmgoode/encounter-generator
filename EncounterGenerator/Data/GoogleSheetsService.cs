using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;

namespace EncounterGenerator.Data
{
    public class GoogleSheetsService : IGoogleSheetsService
    {
        private readonly string _apiKey;
        private readonly string _spreadsheetId;

        private readonly BaseClientService.Initializer _initializer;

        public GoogleSheetsService(IConfiguration configuration)
        {
            _apiKey = configuration.GetValue<string>("EncounterGeneratorData:ApiKey");
            _spreadsheetId = configuration.GetValue<string>("EncounterGeneratorData:SpreadsheetId");

            _initializer = new BaseClientService.Initializer { ApiKey = _apiKey };
        }

        public async Task GetSomeDataAsync(string range)
        {
            using var sheetsService = new SheetsService(_initializer);

            GetRequest sheetsRequest = sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);

            ValueRange response = await sheetsRequest.ExecuteAsync();
            var values = response.Values;
        }
    }
}
