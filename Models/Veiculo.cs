using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_projeto.Models;
using teste2_projeto.Models;

namespace teste2_projeto.Models
{
    public class Veiculo
    {
        // MÉTODO PARA IDENTIFICAR O TIPO DE VEICULO
        public static TipoVeiculo IdentificarTipoVeiculo()
        {
            Console.WriteLine("Qual tipo de veículo será estacionado (carro/moto)?");
            string identificaVeiculo = Console.ReadLine();

            if (identificaVeiculo == "carro")
                return TipoVeiculo.carro;
            else if (identificaVeiculo == "moto")
                return TipoVeiculo.moto;
            else
                return TipoVeiculo.invalido;
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