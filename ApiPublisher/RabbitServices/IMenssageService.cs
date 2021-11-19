using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPublisher.RabbitServices
{
    public interface IMenssageService
    {
        void ConnectMensage(Produtos produto);
    }
}
