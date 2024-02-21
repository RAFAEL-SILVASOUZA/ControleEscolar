using ControleEscolarAluno.Api.Domain.Entities.Commun;

namespace ControleEscolarAluno.Api.Domain.Entities;

public class Aluno : BaseEntity
{
    protected Aluno() { }
    public Aluno(string name,
        string email,
        int anoNascimento,
        int mesNascimento)
    {
        AnoNascimento = anoNascimento;
        MesNascimento = mesNascimento;
        Name = name;
        Email = new EmailValueObject(email);
    }

    public string Name { get; init; }
    public EmailValueObject Email { get; init; }
    public int AnoNascimento { get; init; }
    public int MesNascimento { get; init; }

    public int GetAge()
    {
        return DateTime.UtcNow.Year - AnoNascimento;
    }
}
