namespace VictoryGarden_BackEnd.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Gardener { get; set; }
        public string Notes { get; set; }
    }
}
