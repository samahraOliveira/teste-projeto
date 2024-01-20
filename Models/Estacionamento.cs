using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using teste2_projeto.Models;

namespace teste_projeto.Models
{
    public class Estacionamento
    {
        public decimal PrecoInicial = 10;
        public decimal PrecoPorHora = 5;
        public TimeSpan TempoTotal { get; set; }
        private List<string> veiculosCarro = new List<string>();
        private List<string> veiculosMoto = new List<string>();

        public Estacionamento() { }
        public Estacionamento(decimal precoInicial, decimal precoPorHora, TimeSpan tempoTotal)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
            TempoTotal = tempoTotal;
        }

        // MÉTODO PARA CADASTRAR VEÍCULO
        public void CadastrarVeiculo()
        {
            DateTime horaEntrada = DateTime.Now;
            string placa = "";

            //IDENTIFICA SE O ESTACIONAMENTO ESTÁ EM HORÁRIO DE FUNCIONAMENTO
            if (!VerificarEstacionamentoAberto(horaEntrada))
            {
                Console.WriteLine("O Estacionamento está fora do horário de funcionamento.");
                return;
            }

            // IDENTIFICAÇÃO DO VEÍCULO (CARRO OU MOTO) E SE AINDA HÁ VAGAS
            TipoVeiculo tipoVeiculo = Veiculo.IdentificarTipoVeiculo();
            if (tipoVeiculo == TipoVeiculo.invalido)
            {
                Console.WriteLine("Digite uma opção válida");
                return;
            }

            if (tipoVeiculo == TipoVeiculo.carro)
            {
                VagaCarro vagaCarro = new VagaCarro();
                if (!vagaCarro.VagasDisponiveis(veiculosCarro))
                {
                    Console.WriteLine("O estacionamento atingiu a sua capacidade máxima de carros!");
                    return;
                }
                Console.WriteLine("Digite a placa do veículo para estacionar: ");
                placa = Console.ReadLine();
                
                // Validar placa
                if (!ValidarPlaca(placa)){
                    Console.WriteLine("Esta placa não é válida!");
                    return;
                }
            }

            if (tipoVeiculo == TipoVeiculo.moto)
            {
                VagaMoto vagaMoto = new VagaMoto();
                if (!vagaMoto.VagasDisponiveis(veiculosMoto))
                {
                    Console.WriteLine("O estacionamento atingiu a sua capacidade máxima de motos!");
                    return;
                }
                Console.WriteLine("Digite a placa do veículo para estacionar: ");
                placa = Console.ReadLine();

                 // Validar placa
                if (!ValidarPlaca(placa)){
                    Console.WriteLine("Esta placa não é válida!");
                    return;
                }
            }

        // ADICIONAR O VEÍCULO NA LIST
             if (tipoVeiculo == TipoVeiculo.carro)
                 veiculosCarro.Add(placa);
             else
                 veiculosMoto.Add(placa);

             Console.WriteLine("Veículo inserido no estacionamento!");
         }


        // MÉTODO PARA REMOVER VEÍCULO
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = "";
            placa = Console.ReadLine();


            // VALIDAÇÃO PLACA
           if (!ValidarPlaca(placa)){
                    Console.WriteLine("Esta placa não é válida!");
                    return;
                }

            Console.Clear();

            // Verifica se o veículo existe em alguma das listas
            if (veiculosCarro.Any(x => x.ToUpper() == placa.ToUpper()) || veiculosMoto.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                // Faz o cálculo do tempo em que o veículo ficou estacionado
                Console.WriteLine("Em que horário o veículo foi estacionado?(HH:mm)");
                string horaEntradaString = "HH:mm";
                horaEntradaString = Console.ReadLine();
                Console.Clear();
                DateTime horaEntrada = DateTime.Parse(horaEntradaString);

                TempoTotal = DateTime.Now.Subtract(horaEntrada);
                int horasTotais = TempoTotal.Hours;
                int minutosTotais = TempoTotal.Minutes;

                // Faz o cálculo do preço a ser pago baseado nas horas
                decimal valorTotal = 0;
                if (horasTotais <= 1)
                {
                    valorTotal = PrecoInicial;
                }
                else
                {
                    valorTotal = PrecoInicial + ((horasTotais - 1) * PrecoPorHora);
                }

                // REMOVENDO DAS LISTAS
                veiculosCarro.Remove(placa);
                veiculosMoto.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido. O tempo total foi de {horasTotais} horas e {minutosTotais} minutos, e o valor total a ser pago é de R${valorTotal}.");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }

        }

        // MÉTODO PARA LISTAR OS VEÍCULOS
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculosCarro.Any() || veiculosMoto.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // Laço de repetição, exibindo os veículos estacionados

                Console.WriteLine("Carros: ");

                foreach (string carros in veiculosCarro)
                {
                    Console.WriteLine(carros);
                }

                Console.WriteLine("Motos: ");
                foreach (string motos in veiculosMoto)
                {
                    Console.WriteLine(motos);
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        // MÉTODO PARA VERIFICAR SE O ESTACIONAMENTO ESTÁ ABERTO
        public bool VerificarEstacionamentoAberto(DateTime hora)
        {
            if (hora.Hour > 7 && hora.Hour < 20)
                return true;
            return false;
        }

        
        // MÉTODO PARA VALIDAR PLACA
        public static bool ValidarPlaca(string placa)
        {
            try
            {
                return ValidacaoPlaca.ValidarPlaca(placa);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

        }

    }
}



// passar p projeto original
// refazer o UML
// refazer o read me do projeto
// ajeitar github
// estudar projeto e aulas bootcamp




