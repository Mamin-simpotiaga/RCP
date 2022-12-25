using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace RCP
{
    public static class Convertion
    {
        public static void InitialRead<T>(string filePath, ClassMap<T> map, out List<T> output, bool headerRecord = false, string delimiter = ";")
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = headerRecord,
                Delimiter = delimiter
            };
            output = new List<T>();
            try
            {
                using var streamReader = File.OpenText(filePath);
                using var csvReader = new CsvReader(streamReader, csvConfig);
                csvReader.Context.RegisterClassMap(map);
                do
                {
                    output.AddRange(csvReader.GetRecords<T>());
                } while (csvReader.Read());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void CreateResult(out List<DzienPracy> result, List<Type1> initInput)
        {
            result = new List<DzienPracy>();
            foreach (var input in initInput)
            {

                if (!result.Exists(x => x.KodPracownika == input.KodPracownika && x.Data == input.Data))

                    result.Add(new DzienPracy
                    {
                        KodPracownika = input.KodPracownika,
                        Data = input.Data,
                        GodzinaWejscia = input.GodzinaWejscia,
                        GodzinaWyjscia = input.GodzinaWyjscia
                    });
            }
        }
        public static void ConvertToResult(out List<DzienPracy> result, List<Type2> initInput)
        {
            result = new List<DzienPracy>();
            for (int i = 0; i < initInput.Count - 1; i+=2)
            {
                if (!result.Exists(x => x.KodPracownika == initInput[i].KodPracownika && x.Data == initInput[i].Data))
                {
                    if (initInput[i].KodPracownika == initInput[i + 1].KodPracownika
                        && TimeSpan.TryParse(initInput[i].Godzina, out TimeSpan _GodzinaWejscia)
                        && TimeSpan.TryParse(initInput[i + 1].Godzina, out TimeSpan _GodzinaWyjscia))
                        result.Add(new DzienPracy
                        {
                            KodPracownika = initInput[i].KodPracownika,
                            Data = initInput[i].Data,
                            GodzinaWejscia = _GodzinaWejscia,
                            GodzinaWyjscia = _GodzinaWyjscia
                        });
                }
            }
        }
    }
}
