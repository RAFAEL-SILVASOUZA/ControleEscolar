using ControleEscolarAluno.Api.Domain.Entities;
using FluentAssertions;

namespace ControleEscolarAluno.Api.Tests.Unit;

public class EmailValueObjectTest
{

    [Fact(DisplayName = "Should have not IsValidEmail")]
    public void Should_Have_Not_IsValidEmail()
    {
        //Arrange
        var aluno = GetAluno("", "jose@.email", 0, 0);

        //Act
        var validEmail = aluno.Email.IsValidEmail();

        //Assert
        validEmail
            .Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Should be IsValidEmail")]
    public void Should_Be_IsValidEmail()
    {
        //Arrange
        var aluno = GetAluno("", "jose@email.com", 0, 0);

        //Act
        var validEmail = aluno.Email.IsValidEmail();

        //Assert
        validEmail
            .Should()
            .BeTrue();
    }

    private Aluno GetAluno(string name, string email, int year, int month)
       => new Aluno(name, email, year, month);
}
