using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_projeto.Models
{
    public class VagaMoto : Vaga
    {
        private List<string> motos = new List<string>();
        public override bool VagasDisponiveis(List<string> veiculosMoto)
        {
            if (veiculosMoto.Count >= 4) return false;
            return true;
        }
    }
}