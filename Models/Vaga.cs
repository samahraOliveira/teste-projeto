using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_projeto.Models
{
    public abstract class Vaga
    {
        public virtual bool VagasDisponiveis(List<string>veiculos){
            if (veiculos.Count >= 10){
                return false;
            } else {
                return true;
            }

        }
    }
}