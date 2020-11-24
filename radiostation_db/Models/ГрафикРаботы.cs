using System;
using System.Collections.Generic;

namespace radiostation_db.Models
{
    public partial class ГрафикРаботы
    {
        public DateTime Дата { get; set; }
        public long Время { get; set; }
        public byte[] КодСотрудника { get; set; }
        public byte[] КодЗаписи { get; set; }

        public virtual Записи КодЗаписиNavigation { get; set; }
        public virtual Сотрудники КодСотрудникаNavigation { get; set; }
    }
}
