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
                Trefle trefle = await httpResponseMessage.Content.ReadFromJsonAsync<Trefle>();

                string imageURL = trefle.data.image_url;
                string commonName = trefle.data.common_name;
                string scientificName = trefle.data.scientific_name;
                bool vegetable = trefle.data.vegetable;

                TrefleUI trefleUI = new TrefleUI();

                trefleUI.image_url = imageURL;
                trefleUI.common_name = commonName;
                trefleUI.scientific_name = scientificName;
                trefleUI.vegetable = vegetable;


                return trefleUI;
            }
            else
            {
                throw new Exception("Oops... tee hee");
            }
        }
    }
}