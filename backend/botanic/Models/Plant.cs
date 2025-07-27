namespace botanic.Models
{
    public class Plant
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public string? ScientificName { get; set; }

        public string? Family { get; set; }

        public string? Genus { get; set; }

        public string? Species { get; set; }

        public string? CommonName { get; set; }

        public string? CareInstructions { get; set; }

        public bool IsIndoor { get; set; }

        public bool IsOutdoor { get; set; }

        public bool IsPerennial { get; set; }

        public bool IsAnnual { get; set; }
    }
}
