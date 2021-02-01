using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interface
{
    public interface IModelBase
    {
        string DB_CRUSR { get; set; }
        DateTime DB_CRDAT { get; set; }
        string DB_TRUSR { get; set; }
        DateTime DB_TRDAT { get; set; }
    }
}
