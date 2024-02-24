using ControleEscolarAluno.Api.Domain.Entities;
using FluentAssertions;

namespace ControleEscolarAluno.Api.Tests.Unit;

public class AlunoTests
{
    [Fact(DisplayName = "Should get age")]
    public void Should_Get_Age()
    {
        //Arrange
        var aluno = GetAluno("", "", "", 1987, 10);

        //Act
        var age = aluno.GetAge();

        //Assert
        age
            .Should()
            .Be(37);
    }

    [Fact(DisplayName = "Should not get age")]
    public void Should_Not_Get_Age()
    {
        //Arrange
        var aluno = GetAluno("", "", "", 0, 0);

        //Act
        var age = aluno.GetAge();

        //Assert
        age
            .Should()
            .Be(DateTime.UtcNow.Year);
    }

    [Fact(DisplayName = "correct name")]
    public void Correct_Name()
    {
        //Arrange
        var aluno = GetAluno("Hiro", "Brilhante", "", 0, 0);

        //Act
        var name = aluno.ValidatesName();

        //Assert
        name
            .Should()
            .BeTrue();
    }

    [Fact(DisplayName = "doesn't have a last name")]
    public void Doesnt_Have_A_Last_Name()
    {
        //Arrange
        var aluno = GetAluno("Hiro", "", "", 0, 0);

        //Act
        var name = aluno.ValidatesName();

        //Assert
        name
            .Should()
            .BeFalse();
    }

    [Fact(DisplayName = "doesn't have a name")]
    public void Doesnt_Have_A_Name()
    {
        //Arrange
        var aluno = GetAluno("", "Brilhante", "", 0, 0);

        //Act
        var name = aluno.ValidatesName();

        //Assert
        name
            .Should()
            .BeFalse();
    }

    [Fact(DisplayName = "doesn't have a name and last name")]
    public void Doesnt_Have_A_Name_And_Last_Name()
    {
        //Arrange
        var aluno = GetAluno("", "", "", 0, 0);

        //Act
        var name = aluno.ValidatesName();

        //Assert
        name
            .Should()
            .BeFalse();
    }

    [Fact(DisplayName = "qtd allowed characters")]
    public void Qtd_Allowed_Characters()
    {
        //Arrange
        var aluno = GetAluno("Hiroylk", "Brilhante da Silva", "", 0, 0);

        //Act
        var name = aluno.CharactersQtd();

        //Assert
        name
            .Should()
            .BeTrue();
    }

    [Fact(DisplayName = "qtd disallowed characters")]
    public void Qtd_disallowed_Characters()
    {
        //Arrange
        var aluno = GetAluno("Hiroylk", "Brilhante", "", 0, 0);

        //Act
        var name = aluno.CharactersQtd();

        //Assert
        name
            .Should()
            .BeFalse();
    }




    private Aluno GetAluno(string name, string lasName, string email, int year, int month)
       => new Aluno(name, lasName, email, year, month);
}
