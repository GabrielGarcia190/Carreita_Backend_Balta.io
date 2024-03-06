namespace JwtStore.Core.SharedContext.Entities
{
    public abstract class Entity : IEquatable<Guid>
    {
        protected Entity() => Guid.NewGuid();
    }
}
