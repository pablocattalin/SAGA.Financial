namespace Backend.Domain.Contract.Model
{
  public abstract class Entity<I> where I : new()
    {
        public I Id { get; }
  
        protected Entity()
        {
                Id = new I();
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = obj as Entity<I>;
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
