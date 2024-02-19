namespace WSH_HomeAssignment.Domain.Entities
{
    public class User : IEntity
    {
        public User(string id, string userName, string email)
        {
            InvalidArgumentException.CheckNullOrWhiteSpace(id);
            InvalidArgumentException.CheckNullOrWhiteSpace(userName);
            InvalidArgumentException.CheckNullOrWhiteSpace(email);
            Id = id;
            UserName = userName;
            Email = email;
        }

        public string Id { get; }
        public string UserName { get; }
        public string Email { get; }

        public object[] GetKey()
        {
            return new object[] { Id };
        }
    }
}