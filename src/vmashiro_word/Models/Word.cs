using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vmashiro_word.Models
{
    public class Word
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Translation { get; set; }
        [Display(Name ="添加日期")]
        public DateTime AddDate { get; set; }
    }
}
