using System.ComponentModel.DataAnnotations;

namespace VictoryGarden_BackEnd.Models
{
    public class Plot
    {
        [Key]
        public int Id { get; set; }
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public int PlotSpace { get; set; }
        public int PlotId { get; set; }
    }
}
