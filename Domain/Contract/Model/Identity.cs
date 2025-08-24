namespace Backend.Domain.Contract.Model
{

    public class Identity : IEquatable<Identity>, IIdentity
    {
        public static implicit operator string(Identity identity)
        {
            return identity.Id.ToString();
        }

        public static implicit operator Guid(Identity identity)
        {
            return identity.Id;
        }

    public static implicit operator Identity(Guid identity)
    {
      return new Identity(identity.ToString());
    }
        public Guid Id { get; protected set; }

        internal Identity()
        {
            this.Id = Guid.NewGuid();
        }

        public Identity(string id)
        {
            this.Id = Guid.Parse(id);
        }

        public static T ParseFromGuid<T>(Guid id) where T : Identity, new()
        {
            var @new = new T
            {
                Id = id
            };

            return @new;
        }
        // currently for Entity Framework, set must be protected, not private.
        // will be fixed in EF 6.

        public bool Equals(Identity id)
        {
            if (ReferenceEquals(this, id)) return true;
            if (id is null) return false;
            return this.Id.Equals(id.Id);
        }

        public override bool Equals(object anotherObject)
        {
            return Equals(anotherObject as Identity);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
           return Id.ToString();
        }
    }
}
