using CsvHelper.Configuration;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class OrganizationModelClassMap : ClassMap<OrganizationModel>
    {
        public OrganizationModelClassMap()
        {
            Map(m => m.Index).Name("Index").Default("No data");
            Map(m => m.OrganizationId).Name("Organization Id").Default("No data");
            Map(m => m.Name).Name("Name").Default("No data");
            Map(m => m.Website).Name("Website").Default("No data");
            Map(m => m.Country).Name("Country").Default("No data");
            Map(m => m.Description).Name("Description").Default("No data");
            Map(m => m.Founded).Name("Founded").Default("No data");
            Map(m => m.Industry).Name("Industry").Default("No data");
            Map(m => m.Numberofemployees).Name("Number of employees").Default("No data");
        }
    }
}
