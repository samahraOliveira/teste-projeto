using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_projeto.Models
{
    public class VagaCarro : Vaga
    {
        private List<string> carros = new List<string>();
        public override bool VagasDisponiveis(List<string> veiculosCarro)
        {
            if (veiculosCarro.Count >= 2) return false;
            return true;
        }

    }
}