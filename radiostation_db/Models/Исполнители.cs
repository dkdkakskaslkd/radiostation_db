using System;
using System.Collections.Generic;

namespace radiostation_db.Models
{
    public partial class Исполнители
    {
        public Исполнители()
        {
            Записи = new HashSet<Записи>();
        }

        public string Наименование { get; set; }
        public string Описание { get; set; }
        public byte[] КодИсполнителя { get; set; }

        public virtual ICollection<Записи> Записи { get; set; }
    }
}
