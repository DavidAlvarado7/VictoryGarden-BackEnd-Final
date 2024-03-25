using VictoryGarden_BackEnd.Models;

namespace VictoryGarden_BackEnd.Services
{
    public class TrefleService
    {
        private readonly HttpClient _client;

        public TrefleService(HttpClient client)
        {
            _client = client;
        }

        public async Task<TrefleUI> GetTrefleData(int id)
        {

            var httpResponseMessage = await _client.GetAsync($"{id}/?token=-mwv_gdmHkcI3oEhRqEqrXqFAmPdwBmuQf3TqddpT3Y");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string results = await httpResponseMessage.Content.ReadAsStringAsync();
                try
                {
                    Trefle trefle = await httpResponseMessage.Content.ReadFromJsonAsync<Trefle>();

                    int trefleId = trefle.data.main_species_id;
                    string imageURL = trefle.data.image_url;
                    string commonName = trefle.data.common_name;
                    string scientificName = trefle.data.scientific_name;
                    bool? vegetable = trefle.data.vegetable;

                    TrefleUI trefleUI = new TrefleUI();

                    trefleUI.id = trefleId;
                    trefleUI.image_url = imageURL;
                    trefleUI.common_name = commonName;
                    trefleUI.scientific_name = scientificName;
                    trefleUI.vegetable = vegetable;


                    return trefleUI;
                }
                catch(Exception e)
                {
                    Console.WriteLine(results + " " + e.Message);
                    return null;
                }
                
            }
            else
            {
                Console.Error.WriteLine($"Invalid ID: {id}");
                return null;
            }
        }
    }
}