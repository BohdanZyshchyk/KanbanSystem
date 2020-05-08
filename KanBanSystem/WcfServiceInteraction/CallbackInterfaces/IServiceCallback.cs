using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceInteraction.DTO;

namespace WcfServiceInteraction.CallbackInterfaces
{
    public interface IServiceCallback
    {
        void RefreshBoards(IEnumerable<BoardDTO> boards);
    }
}
