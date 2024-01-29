namespace ActivityPortal.API.Resources
{
    public class EventResource
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Destination { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? Cost { get; set; }

        public string? Status { get; set; }

        public int? UserId { get; set; }

        public int? CategoryId { get; set; }
    }
}
