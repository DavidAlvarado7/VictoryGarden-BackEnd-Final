namespace VictoryGarden_BackEnd.Models
{
    public class Trefle
    {
        public Data data { get; set; }
        public Meta meta { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string common_name { get; set; }
        public string slug { get; set; }
        public string scientific_name { get; set; }
        public int main_species_id { get; set; }
        public string image_url { get; set; }
        public int year { get; set; }
        public string bibliography { get; set; }
        public string author { get; set; }
        public string family_common_name { get; set; }
        public int genus_id { get; set; }
        public string observations { get; set; }
        public bool vegetable { get; set; }
        public Links links { get; set; }
        public Main_Species main_species { get; set; }
        public Genus genus { get; set; }
        public Family family { get; set; }
        public Species[] species { get; set; }
        public object[] subspecies { get; set; }
        public object[] varieties { get; set; }
        public object[] hybrids { get; set; }
        public object[] forms { get; set; }
        public object[] subvarieties { get; set; }
        public Source1[] sources { get; set; }
    }

    public class Links
    {
        public string self { get; set; }
        public string species { get; set; }
        public string genus { get; set; }
    }

    public class Main_Species
    {
        public int id { get; set; }
        public object common_name { get; set; }
        public string slug { get; set; }
        public string scientific_name { get; set; }
        public int year { get; set; }
        public string bibliography { get; set; }
        public string author { get; set; }
        public string status { get; set; }
        public string rank { get; set; }
        public string family_common_name { get; set; }
        public int genus_id { get; set; }
        public string observations { get; set; }
        public bool vegetable { get; set; }
        public object image_url { get; set; }
        public string genus { get; set; }
        public string family { get; set; }
        public object duration { get; set; }
        public object edible_part { get; set; }
        public bool edible { get; set; }
        public Images images { get; set; }
        public Common_Names common_names { get; set; }
        public Distribution distribution { get; set; }
        public Distributions distributions { get; set; }
        public Flower flower { get; set; }
        public Foliage foliage { get; set; }
        public Fruit_Or_Seed fruit_or_seed { get; set; }
        public Source[] sources { get; set; }
        public Specifications specifications { get; set; }
        public object[] synonyms { get; set; }
        public Growth growth { get; set; }
        public Links2 links { get; set; }
    }

    public class Images
    {
    }

    public class Common_Names
    {
    }

    public class Distribution
    {
        public string[] native { get; set; }
    }

    public class Distributions
    {
        public Native[] native { get; set; }
    }

    public class Native
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string tdwg_code { get; set; }
        public int tdwg_level { get; set; }
        public int species_count { get; set; }
        public Links1 links { get; set; }
    }

    public class Links1
    {
        public string self { get; set; }
        public string plants { get; set; }
        public string species { get; set; }
    }

    public class Flower
    {
        public object color { get; set; }
        public object conspicuous { get; set; }
    }

    public class Foliage
    {
        public object texture { get; set; }
        public object color { get; set; }
        public object leaf_retention { get; set; }
    }

    public class Fruit_Or_Seed
    {
        public object conspicuous { get; set; }
        public object color { get; set; }
        public object shape { get; set; }
        public object seed_persistence { get; set; }
    }

    public class Specifications
    {
        public object ligneous_type { get; set; }
        public object growth_form { get; set; }
        public object growth_habit { get; set; }
        public object growth_rate { get; set; }
        public Average_Height average_height { get; set; }
        public Maximum_Height maximum_height { get; set; }
        public object nitrogen_fixation { get; set; }
        public object shape_and_orientation { get; set; }
        public object toxicity { get; set; }
    }

    public class Average_Height
    {
        public object cm { get; set; }
    }

    public class Maximum_Height
    {
        public object cm { get; set; }
    }

    public class Growth
    {
        public object description { get; set; }
        public object sowing { get; set; }
        public object days_to_harvest { get; set; }
        public Row_Spacing row_spacing { get; set; }
        public Spread spread { get; set; }
        public object ph_maximum { get; set; }
        public object ph_minimum { get; set; }
        public object light { get; set; }
        public object atmospheric_humidity { get; set; }
        public object growth_months { get; set; }
        public object bloom_months { get; set; }
        public object fruit_months { get; set; }
        public Minimum_Precipitation minimum_precipitation { get; set; }
        public Maximum_Precipitation maximum_precipitation { get; set; }
        public Minimum_Root_Depth minimum_root_depth { get; set; }
        public Minimum_Temperature minimum_temperature { get; set; }
        public Maximum_Temperature maximum_temperature { get; set; }
        public object soil_nutriments { get; set; }
        public object soil_salinity { get; set; }
        public object soil_texture { get; set; }
        public object soil_humidity { get; set; }
    }

    public class Row_Spacing
    {
        public object cm { get; set; }
    }

    public class Spread
    {
        public object cm { get; set; }
    }

    public class Minimum_Precipitation
    {
        public object mm { get; set; }
    }

    public class Maximum_Precipitation
    {
        public object mm { get; set; }
    }

    public class Minimum_Root_Depth
    {
        public object cm { get; set; }
    }

    public class Minimum_Temperature
    {
        public object deg_f { get; set; }
        public object deg_c { get; set; }
    }

    public class Maximum_Temperature
    {
        public object deg_f { get; set; }
        public object deg_c { get; set; }
    }

    public class Links2
    {
        public string self { get; set; }
        public string plant { get; set; }
        public string genus { get; set; }
    }

    public class Source
    {
        public DateTime last_update { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string citation { get; set; }
    }

    public class Genus
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public Links3 links { get; set; }
    }

    public class Links3
    {
        public string self { get; set; }
        public string plants { get; set; }
        public string species { get; set; }
        public string family { get; set; }
    }

    public class Family
    {
        public int id { get; set; }
        public string name { get; set; }
        public string common_name { get; set; }
        public string slug { get; set; }
        public Links4 links { get; set; }
    }

    public class Links4
    {
        public string self { get; set; }
        public string division_order { get; set; }
        public string genus { get; set; }
    }

    public class Species
    {
        public int id { get; set; }
        public object common_name { get; set; }
        public string slug { get; set; }
        public string scientific_name { get; set; }
        public int year { get; set; }
        public string bibliography { get; set; }
        public string author { get; set; }
        public string status { get; set; }
        public string rank { get; set; }
        public string family_common_name { get; set; }
        public int genus_id { get; set; }
        public object image_url { get; set; }
        public object[] synonyms { get; set; }
        public string genus { get; set; }
        public string family { get; set; }
        public Links5 links { get; set; }
    }

    public class Links5
    {
        public string self { get; set; }
        public string plant { get; set; }
        public string genus { get; set; }
    }

    public class Source1
    {
        public DateTime last_update { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string citation { get; set; }
    }

    public class Meta
    {
        public DateTime last_modified { get; set; }
    }

}
