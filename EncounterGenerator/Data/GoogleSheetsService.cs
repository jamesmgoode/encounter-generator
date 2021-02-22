using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EncounterGenerator.Data
{
    public class GoogleSheetsService : IGoogleSheetsService
    {
        private readonly string _apiKey;
        private readonly string _spreadsheetId;

        public GoogleSheetsService(IConfiguration configuration)
        {
            _apiKey = configuration.GetValue<string>("EncounterGeneratorData:ApiKey");
            _spreadsheetId = configuration.GetValue<string>("EncounterGeneratorData:SpreadsheetId");
        }

        public async Task GetSomeDataAsync()
        {
            var service = new SheetsService(new BaseClientService.Initializer
            {
                ApiKey = _apiKey
            });

            // Define request parameters.
            var spreadsheetId = _spreadsheetId;
            var range = "SheetName!A2:D";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            var response = await request.ExecuteAsync();
            var values = response.Values;
        }
    }
}
