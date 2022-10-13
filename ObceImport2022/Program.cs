using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ObceImport2022.Data;
using ObceImport2022.Mappers;
using ObceImport2022.Models;
using System.Text;
using TinyCsvParser;

// https://github.com/TinyCsvParser/TinyCsvParser
// Source: https://www.czso.cz/csu/czso/pocet-obyvatel-v-obcich-k-112019

using IHost host = Host.CreateDefaultBuilder(args).Build();
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
/*
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();*/
string connectionString = config.GetConnectionString("Default");
var db = new ApplicationDbContext();

CsvParserOptions csvParserOptions = new CsvParserOptions(false, ';');
Console.WriteLine("-- Purging all tables --");
db.Populations.RemoveRange(db.Populations.ToArray());
db.Municipalities.RemoveRange(db.Municipalities.ToArray());
db.Districts.RemoveRange(db.Districts.ToArray());
db.Regions.RemoveRange(db.Regions.ToArray());
db.SaveChanges();

Console.WriteLine("-- Setting regions --");
RegionMapper csvRegionMapper = new RegionMapper();
CsvParser<Region> csvRegionParser = new CsvParser<Region>(csvParserOptions, csvRegionMapper);
var regions = csvRegionParser
    .ReadFromFile(@"Files/Regions.csv", Encoding.UTF8)
    .ToList();
foreach (var item in regions)
{
    Console.WriteLine(item.Result.Name);
    db.Regions.Add(item.Result);
}
db.SaveChanges();

Console.WriteLine("-- Setting districts --");
DistrictMapper csvDistrictMapper = new DistrictMapper();
CsvParser<District> csvDistrictParser = new CsvParser<District>(csvParserOptions, csvDistrictMapper);
var districts = csvDistrictParser
    .ReadFromFile(@"Files/Districts.csv", Encoding.UTF8)
    .ToList();
foreach (var item in districts)
{
    Console.WriteLine(item.Result.Name);
    db.Districts.Add(item.Result);
}
db.SaveChanges();

Console.WriteLine("-- Setting municipalities --");
MunicipalityMapper csvMunicipalityMapper = new MunicipalityMapper();
CsvParser<MunicipalityPopulation> csvMunicipalityParser = new CsvParser<MunicipalityPopulation>(csvParserOptions, csvMunicipalityMapper);
var municipalities2020 = csvMunicipalityParser
    .ReadFromFile(@"Files/2020.csv", Encoding.UTF8)
    .ToList();
foreach (var item in municipalities2020)
{
    Console.WriteLine(item.Result.Name);
    db.Municipalities.Add(new Municipality
    {
        LAU1 = item.Result.LAU1,
        LAU2 = item.Result.LAU2,
        Name = item.Result.Name,
    });
}
db.SaveChanges();

var municipalities2019 = csvMunicipalityParser
    .ReadFromFile(@"Files/2019.csv", Encoding.UTF8)
    .ToList();
Console.WriteLine("-- Adding population data 2019 --");
foreach (var item in municipalities2019)
{
    Console.WriteLine(item.Result.Name);
    db.Populations.Add(new Population
    {
        LAU2 = item.Result.LAU2,
        Year = 2019,
        Total = item.Result.Total,
        Men = item.Result.Men,
        Women = item.Result.Women,
        Age = Convert.ToDouble(item.Result.Age)/10,
        MensAge = Convert.ToDouble(item.Result.MensAge)/10,
        WomensAge = Convert.ToDouble(item.Result.WomensAge)/10
    });
}
db.SaveChanges();

Console.WriteLine("-- Adding population data 2020 --");
foreach (var item in municipalities2020)
{
    Console.WriteLine(item.Result.Name);
    db.Populations.Add(new Population
    {
        LAU2 = item.Result.LAU2,
        Year = 2020,
        Total = item.Result.Total,
        Men = item.Result.Men,
        Women = item.Result.Women,
        Age = Convert.ToDouble(item.Result.Age)/10,
        MensAge = Convert.ToDouble(item.Result.MensAge)/10,
        WomensAge = Convert.ToDouble(item.Result.WomensAge)/10
    });
}
db.SaveChanges();

var municipalities2021 = csvMunicipalityParser
    .ReadFromFile(@"Files/2021.csv", Encoding.UTF8)
    .ToList();
Console.WriteLine("-- Adding population data 2021 --");
foreach (var item in municipalities2021)
{
    Console.WriteLine(item.Result.Name);
    db.Populations.Add(new Population
    {
        LAU2 = item.Result.LAU2,
        Year = 2021,
        Total = item.Result.Total,
        Men = item.Result.Men,
        Women = item.Result.Women,
        Age = Convert.ToDouble(item.Result.Age)/10,
        MensAge = Convert.ToDouble(item.Result.MensAge)/10,
        WomensAge = Convert.ToDouble(item.Result.WomensAge)/10
    });
}
db.SaveChanges();
/*
var municipalities2022 = csvMunicipalityParser
    .ReadFromFile(@"Files/2022.csv", Encoding.UTF8)
    .ToList();
Console.WriteLine("-- Adding population data 2022 --");
foreach (var item in municipalities2022)
{
    Console.WriteLine(item.Result.Name);
    db.Populations.Add(new Population
    {
        LAU2 = item.Result.LAU2,
        Year = 2021,
        Total = item.Result.Total,
        Men = item.Result.Men,
        Women = item.Result.Women,
        Age = Convert.ToDouble(item.Result.Age) / 10,
        MensAge = Convert.ToDouble(item.Result.MensAge) / 10,
        WomensAge = Convert.ToDouble(item.Result.WomensAge) / 10
    });
}
db.SaveChanges();
*/
await host.RunAsync();