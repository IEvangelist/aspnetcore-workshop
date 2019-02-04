namespace AspNet.Essentials.Workshop.Models
{
    public class Beer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameDisplay { get; set; }
        public string Description { get; set; }
        public float Abv { get; set; }
        public string Ibu { get; set; }
        public int StyleId { get; set; }
        public string IsOrganic { get; set; }
        public string IsRetired { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public Style Style { get; set; }
        public int GlasswareId { get; set; }
        public Glass Glass { get; set; }
        public int AvailableId { get; set; }
        public Labels Labels { get; set; }
        public string ServingTemperature { get; set; }
        public string ServingTemperatureDisplay { get; set; }
        public Available Available { get; set; }
        public int SrmId { get; set; }
        public Srm Srm { get; set; }
    }
}