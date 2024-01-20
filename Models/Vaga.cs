using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_projeto.Models
{
    public abstract class Vaga
    {
        public Vaga() { }

        public abstract bool VagasDisponiveis(List<string> veiculos);
    }
}