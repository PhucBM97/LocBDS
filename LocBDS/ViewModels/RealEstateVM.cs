namespace HoangLocRealEstate.ViewModels
{
    public class RealEstateVM
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? Area { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDt { get; set; }
        public DateTime? UpdatedDt { get; set; }
    }
}
