using teste_projeto.Models;
using teste2_projeto.Models;
namespace EstacionamentoTestes;

public class EstacionamentoTeste
{
    private Estacionamento _testes = new Estacionamento();

    [Fact]
    public void VerificarEstacionamentoAbertoHoraDentroDoHorarioRetornarTrue()
    {
        Estacionamento estacionamento = new Estacionamento();
        DateTime horaDentroDoHorario = new DateTime(2024, 1, 1, 10, 0, 0);

        bool resultado = estacionamento.VerificarEstacionamentoAberto(horaDentroDoHorario);

        Assert.True(resultado);
    }

    [Fact]
    public void VerificarEstacionamentoAbertoHoraForaDoHorarioRetornarFalse(){

        Estacionamento estacionamento = new Estacionamento();
        DateTime horaForadoHorario = new DateTime(2024, 1, 1, 6, 0, 0);

        bool resultado = estacionamento.VerificarEstacionamentoAberto(horaForadoHorario);

        Assert.False(resultado);
    }
}