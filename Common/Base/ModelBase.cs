using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Base
{
    public class ModelBase
    {
        [Required]
        public string DB_CRUSR { get; set; }
        [Required]
        public DateTime DB_CRDAT { get; set; }
        public string DB_TRUSR { get; set; }
        public DateTime? DB_TRDAT { get; set; }
    }
}
