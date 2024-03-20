namespace AutoGlass.ProductManagement.Domain.Entities
{
    public class EntityBase<TSource> : IEquatable<EntityBase<TSource>>
    {
        public virtual TSource Id { get; set; }
        public bool Equals(EntityBase<TSource> other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            EntityBase<TSource> entidade = obj as EntityBase<TSource>;

            if (entidade != null)
                return Equals(entidade);

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
