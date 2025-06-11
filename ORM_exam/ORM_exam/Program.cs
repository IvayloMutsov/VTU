using CsvHelper;
using CsvHelper.Configuration;
using DatabaseContext;
using DatabaseContext.Querry;
using Infrastructure;
using Infrastructure.Models;
using System.Globalization;
using System.IO;

namespace ORM_exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //collections for keeping records
            //Dictionary<string, Country> countries = new Dictionary<string, Country>();
            //Dictionary<string, Website> websites = new Dictionary<string, Website>();
            //Dictionary<string, Industry> industries = new Dictionary<string, Industry>();
            ////db context
            //ApplicationDbContext context = new ApplicationDbContext();
            ////read file
            //StreamReader reader = new StreamReader("organizations-100000.csv");
            //CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            //{
            //    HasHeaderRecord = true,
            //    Delimiter = ","
            //});
            //using (context)
            //{
            //    context.Database.EnsureCreated();
            //    using (reader)
            //    {
            //        using (csv)
            //        {
            //            csv.Context.RegisterClassMap<OrganizationModelClassMap>();// registering class map
            //            var records = csv.GetRecords<OrganizationModel>().ToList();
            //            //loop the records
            //            foreach (var item in records)
            //            {
            //                Website? website = null;
            //                Country? country = null;
            //                Industry? industry = null;
            //                //check websites
            //                if (!websites.ContainsKey(item.Website))
            //                {
            //                    website = new Website { WebsiteName = item.Website };
            //                    websites.Add(website.WebsiteName,website);
            //                }
            //                else
            //                {
            //                    website = websites[item.Website];
            //                }
            //                //check countries
            //                if (!countries.ContainsKey(item.Country))
            //                {
            //                    country = new Country { CountryName = item.Country };
            //                    countries.Add(country.CountryName, country);
            //                }
            //                else
            //                {
            //                    country = countries[item.Country];
            //                }
            //                //check industries
            //                var splittedIndustries = item.Industry.Split(" / ",StringSplitOptions.TrimEntries);
            //                List<Industry> list = new List<Industry>();
            //                foreach (var split in splittedIndustries)
            //                {
            //                    if (!industries.ContainsKey(item.Industry))
            //                    {
            //                        industry = new Industry { IndustryName = item.Industry };
            //                        industries.Add(industry.IndustryName, industry);
            //                        list.Add(industry);
            //                    }
            //                    else
            //                    {
            //                        industry = industries[item.Industry];
            //                        list.Add(industry);
            //                    }
            //                }
            //                //create organization entity and add it to db
            //                var organization = new Organization
            //                {
            //                    Index = int.Parse(item.Index),
            //                    OrganizationId = item.OrganizationId,
            //                    Name = item.Name,
            //                    Website = website,
            //                    Country = country,
            //                    Description = item.Description,
            //                    Founded = int.Parse(item.Founded),
            //                    Industry = industry,
            //                    Numberofemployees =int.Parse(item.Numberofemployees)
            //                };
            //                context.organizations.Add(organization);
            //            }
            //            //add countries in db
            //            foreach (var item in countries)
            //            {
            //                context.counties.Add(item.Value);
            //            }
            //            //add websites to db
            //            foreach (var item in websites)
            //            {
            //                context.websites.Add(item.Value);
            //            }
            //            //add industries to db
            //            foreach (var item in industries)
            //            {
            //                context.industries.Add(item.Value);
            //            }
            //        }
            //    }
            //    context.SaveChanges();
            //}
            QuerryCountries q = new QuerryCountries();
            q.CountriesByIndustriesAndNumOfCompanies();
        }
    }
}