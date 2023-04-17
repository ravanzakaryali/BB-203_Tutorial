
using Newtonsoft.Json;
using System.Text.Json;
using System.Threading.Tasks.Dataflow;
using System.Xml.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Directory,File
        //string path = @"C:\Data\BB-203";
        //Directory.CreateDirectory(path + @"\BDU-BB203\Chingiz\Elvin");
        //Directory.CreateDirectory(path + @"\BDU-BB203");
        //Directory.CreateDirectory(path + @"\BDU\BB-203\Chingiz");
        //Directory.CreateDirectory(path + @"\BDU\BB-203\Mammad");
        //Directory.CreateDirectory(path + @"\BDU\BB-203\Elvin");
        //Directory.CreateDirectory(path + @"\BDU\BB-203\Sahbaz");

        //string[] directories = Directory.GetFiles(path);

        //foreach (string directory in directories)
        //{
        //    Console.WriteLine(directory);
        //}
        //Directory.Delete(path + @"\BDU -BB203", true);
        //File.Create(path + @"\BDU-BB203\Aynur\word.txt");
        //File.Delete(@"C:\Data\word.txt");
        //if(Directory.Exists(path + @"\BDU"))
        //{
        //    File.Create(path + @"\BDU" + @"\word.txt");
        //    //Directory.Delete(path + @"\BDU");
        //}
        #endregion

        #region Json, XML
        string path = @"C:\Data\BB-203";
        //File.Create(path + @"\word.txt");

        //StreamReader
        //StreamWriter

        //StreamWriter streamWriter = new StreamWriter(path + @"\word.txt");
        //streamWriter.WriteLine("BB203");
        //streamWriter.WriteLine("BB203  - 1");
        //streamWriter.WriteLine("BB203 - 2");
        //streamWriter.WriteLine("BB203 - 3");
        //streamWriter.Close();
        //StreamReader streamReader = new StreamReader(path + @"\word.txt");
        //Console.WriteLine(streamReader.ReadToEnd());
        //streamReader.Close();

        #endregion
        #region SerializeObject
        //City city = new City()
        //{
        //    Name = "Gence"
        //};
        //City city2 = new City()
        //{
        //    Name = "Sheki"
        //};
        //Country country = new Country()
        //{
        //    Name = "Azerbaycan"
        //};
        //country.Cities = new List<City>()
        //{
        //    city,city2
        //};
        //string json = JsonConvert.SerializeObject(country);
        //using (StreamWriter sw = new StreamWriter(@"C:\Data\BB-203\FileDirectoryJsonXML\FileDirectoryJsonXML\Files\country.json"))
        //{
        //    sw.Write(json);
        //}
        #endregion
        #region DeserializeObject

        //using (StreamReader streamReader = new StreamReader(@"C:\Data\BB-203\FileDirectoryJsonXML\FileDirectoryJsonXML\Files\country.json"))
        //{
        //    string jsonText = streamReader.ReadToEnd();
        //    Country country =  JsonConvert.DeserializeObject<Country>(jsonText);
        //    Console.WriteLine(country.Name);
        //    foreach (City item in country.Cities)
        //    {
        //        Console.WriteLine(item.Name);
        //    }
        #endregion
        #region XML 
        //City city = new City()
        //{
        //    Name = "Gence"
        //};
        //City city2 = new City()
        //{
        //    Name = "Sheki"
        //};
        //Country country = new Country()
        //{
        //    Name = "Azerbaycan"
        //};
        //country.Cities = new List<City>()
        //{
        //    city,city2
        //};

        //using (StreamWriter streamWriter = new StreamWriter(@"C:\Data\BB-203\FileDirectoryJsonXML\FileDirectoryJsonXML\Files\country.xml"))
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(Country));
        //    serializer.Serialize(streamWriter, country);
        //}
        //using (StreamReader streamReader = new StreamReader(@"C:\Data\BB-203\FileDirectoryJsonXML\FileDirectoryJsonXML\Files\country.xml"))
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(Country));
        //    Country country = (Country)serializer.Deserialize(streamReader);
        //    Console.WriteLine(country.Name);
        //}

        #endregion

        string name = Console.ReadLine();
        string cityName = Console.ReadLine();


        Country country = new Country()
        {
            Name = name,
            //Cities = new List<City>()
            //{
            //    new City()
            //    {
            //        Name = cityName
            //    }
            //}
        };
        country.Cities.Add(new City()
        {
            Name = cityName
        });

        //1. Add

        // Olke adini daxil edin: Azerbaycan
        //List<City>
        //1. Add city -- Json ser
        //2. Get All City ;;



    }


}

public class City
{
    public string Name { get; set; }
}
public class Country
{
    public Country()
    {
        Cities = new List<City>();
    }
    public string Name { get; set; }
    public List<City> Cities { get; set; }
}