using System;
using System.Collections.Generic;

namespace radiostation_db.Models
{
    public partial class Сотрудники
    {
        public string Фио { get; set; }
        public byte[] КодСотрудника { get; set; }
        public long Возраст { get; set; }
        public string Пол { get; set; }
        public long Телефон { get; set; }
        public string Адрес { get; set; }
        public string ПаспортныеДанны { get; set; }
        public byte[] КодДолжности { get; set; }

        public virtual Должности КодДолжностиNavigation { get; set; }
    }
}
