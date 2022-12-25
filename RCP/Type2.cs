using System;
using CsvHelper.Configuration;

namespace RCP
{
    public class Type2
    {
        public string KodPracownika { get; set; }
        public DateTime Data { get; set; }
        public string Godzina { get; set; }
        public string WeLubWy { get; set; }
    }
    public class InitialMapType2 : ClassMap<Type2>
    {
        public InitialMapType2()
        {
            Map(m => m.KodPracownika);
            Map(m => m.Data);
            Map(m => m.Godzina);
            Map(m => m.WeLubWy);
        }
    }
}
