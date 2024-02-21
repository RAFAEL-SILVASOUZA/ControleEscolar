namespace ControleEscolarAluno.Api.Domain.Entities.Commun;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatAt = DateTime.UtcNow;
        Deleted = 0;
    }

    public Guid Id { get; set; }
    public DateTime CreatAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public int Deleted { get; set; }
}
