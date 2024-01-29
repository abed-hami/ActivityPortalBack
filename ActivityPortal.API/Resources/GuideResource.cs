namespace ActivityPortal.API.Resources
{
    public class GuideResource
    {

        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? MobileNumber { get; set; }

        public string? Photo { get; set; }

        public string? Profession { get; set; }

        public string? Nationality { get; set; }

        public string? EmergencyNumber { get; set; }

        public int? MemberId { get; set; }
    }
}
