namespace ActivityPortal.API.Resources
{
    public class UserResource
    {
        public int Id { get; set; }

        public string? FisrtName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
