namespace ContactHub
{
    public class Contact : EntityDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
    public class EntityDto
    {
        public Guid Id { get; set; }
    };
    public class PersonalContact : Contact
    {
        public string Nickname { get; set; }
    }
}
