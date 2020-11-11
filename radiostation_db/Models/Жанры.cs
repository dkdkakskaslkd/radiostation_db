using System;
using System.Collections.Generic;

namespace radiostation_db.Models
{
    public partial class Жанры
    {
        public Жанры()
        {
            Записи = new HashSet<Записи>();
        }

        public string Наименование { get; set; }
        public string Описание { get; set; }
        public byte[] КодЖанра { get; set; }

        public virtual ICollection<Записи> Записи { get; set; }
    }
}
