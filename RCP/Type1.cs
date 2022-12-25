using System;
using CsvHelper.Configuration;

namespace RCP
{
    public class Type1
    {
        public string KodPracownika { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan GodzinaWejscia { get; set; }
        public TimeSpan GodzinaWyjscia { get; set; }
        public string CzasPracy { get; set; }
    }
    public class InitialMapType1 : ClassMap<Type1>
    {
        public InitialMapType1()
        {
            Map(m => m.KodPracownika);
            Map(m => m.Data);
            Map(m => m.GodzinaWejscia);
            Map(m => m.GodzinaWyjscia);
            Map(m => m.CzasPracy);
        }
    }
}
