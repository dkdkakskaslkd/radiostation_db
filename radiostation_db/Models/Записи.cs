using System;
using System.Collections.Generic;

namespace radiostation_db.Models
{
    public partial class Записи
    {
        public byte[] Год { get; set; }
        public string Альбом { get; set; }
        public byte[] КодЗаписи { get; set; }
        public long Рейтинг { get; set; }
        public byte[] ДатаЗаписи { get; set; }
        public string Длительность { get; set; }
        public string Наименование { get; set; }
        public byte[] КодИсполнителя { get; set; }
        public byte[] КодЖанра { get; set; }

        public virtual Жанры КодЖанраNavigation { get; set; }
        public virtual Исполнители КодИсполнителяNavigation { get; set; }
    }
}
