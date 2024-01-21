using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_projeto.Models
{
    public class VagaMoto : Vaga
    {
        
        public override bool VagasDisponiveis(List<string> veiculosMoto)
        {
            if (veiculosMoto.Count >= 4) {
                return false;
            } else {
                return true;
            }
        }
    }
}