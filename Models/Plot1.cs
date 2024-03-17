using System.ComponentModel.DataAnnotations;

namespace VictoryGarden_BackEnd.Models
{
    public class Plot1
    {
        [Key]
        public int ID { get; set; }
        public int PlantID { get; set; }
        public string PlantName { get; set; }
        public int PlotSpace { get; set; }
    }
}
