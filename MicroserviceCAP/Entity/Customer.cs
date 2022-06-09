namespace Entity
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool? IsEmailConfirmed { get; set; }
        public bool? IsPhoneConfirmed { get; set; }
    }
}