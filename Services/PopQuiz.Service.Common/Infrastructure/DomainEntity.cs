namespace PopQuiz.Service.Common.Domain.Infrastructure
{
    public abstract class DomainEntity
    {        
        public int Id { get; private set; }

        public DomainEntity(int id)
        {
            this.Id = id;
        }

        public override bool Equals(object obj)
        {
            DomainEntity otherEntity = obj as DomainEntity;
            if (otherEntity == null)
            {
                return false;
            }

            return otherEntity.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 17;
        }
    }
}
