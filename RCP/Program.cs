using System;
using System.Collections.Generic;
using System.IO;



namespace RCP
{
    
    public class DzienPracy
    {
        public string KodPracownika { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan GodzinaWejscia { get; set; }
        public TimeSpan GodzinaWyjscia { get; set; }
    }
    
    
    
    internal class Program
    {
        
        static List<DzienPracy> GetWorkingDays(string path, string delimiter)
        {
            var columns = File.ReadAllLines(path)[0].Split(delimiter);
            var result = new List<DzienPracy>();
            switch (columns.Length)
            {
                case 4:
                    Convertion.InitialRead<Type2>(path, new InitialMapType2(), out var initialInput, delimiter: delimiter);
                    Convertion.ConvertToResult(out result, initialInput);
                    break;

                case 5:
                    Convertion.InitialRead<Type1>(path, new InitialMapType1(), out var input, delimiter: delimiter);
                    Convertion.CreateResult(out result, input);
                    break;
                default:
                    Console.WriteLine("Nie standardowy format pliku!!!");
                    break;

            }
           
            return result;
        }
        
        static void Main(string[] args)
        {
            
            var result = GetWorkingDays(path, delimiter);
            foreach (var item in result)
            {
                Console.WriteLine("KodPracownika: {0},\t Data: {1},\t GodzinaWejscia: {2},\t GodzinaWyjscia: {3}.",
                    item.KodPracownika,
                    item.Data.ToShortDateString(),
                    item.GodzinaWejscia,
                    item.GodzinaWyjscia);
            }
            
        }
    }
}
