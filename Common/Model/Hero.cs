﻿using Common.Base;
using Common.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF_Prism_MarvelCards.Model
{

    [Table("Hero", Schema = "dbo")]
    public class Hero : ModelBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string HeroName { get; set; }
        public string HeroNameLine1 { get; set; }
        public string HeroNameLine2 { get; set; }
        public string RealName { get; set; }
        public string Image { get; set; }
        [Required]
        public string HeroColor { get; set; }
    }
}
