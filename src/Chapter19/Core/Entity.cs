namespace Core
{
	public class Entity
	{
		public int Id { get; set; }

		public bool Equals(Entity other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Id == Id;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Entity)) return false;
			return Equals((Entity) obj);
		}

		public override int GetHashCode()
		{
			return Id;
		}
	}
}