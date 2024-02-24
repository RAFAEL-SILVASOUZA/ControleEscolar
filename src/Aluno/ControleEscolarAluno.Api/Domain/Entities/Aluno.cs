using ControleEscolarAluno.Api.Domain.Entities.Commun;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleEscolarAluno.Api.Domain.Entities;

public class Aluno : BaseEntity
{
    protected Aluno() { }
    public Aluno(string name,
        string lasName,
        string email,
        int anoNascimento,
        int mesNascimento)
    {
        AnoNascimento = anoNascimento;
        MesNascimento = mesNascimento;
        Name = name;
        LasName = lasName;
        Email = new EmailValueObject(email);
    }

    public string Name { get; init; }
    public string LasName { get; init; }
    public EmailValueObject Email { get; init; }
    public int AnoNascimento { get; init; }
    public int MesNascimento { get; init; }

    public int GetAge()
    {
        return DateTime.UtcNow.Year - AnoNascimento;
    }

    public bool ValidatesName()
    { 
        if (string.IsNullOrEmpty(LasName) || string.IsNullOrEmpty(Name))
            return false;

        return true;
    }

    public bool CharactersQtd()
    {
        const int MinTamanhoNome = 20;
        const int MaxTamanhoNome = 100;

        //var nomeCompleto = Name+""+LasName;
        string nomeCompleto = $"{Name} {LasName}";

        if (nomeCompleto.Length < MinTamanhoNome || nomeCompleto.Length > MaxTamanhoNome)
            return false;

        return true;
    }
}
