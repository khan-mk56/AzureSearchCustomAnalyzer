using System;
using System.Text.Json.Serialization;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Lucene.Net.Analysis;

namespace AzureSearch.Quickstart
{
    public class Arisg
    {
        //public string sourcetable { set; get; }

       [SimpleField(IsKey = true, IsFilterable = true)]
        public string Id { get; set; }

        [SearchableField(IsSortable = true)]
        public string Max_Version_Flag { get; set; }

        [SearchableField(IsSortable = true)]
      
        public string Uid { get; set; }

        [SearchableField(IsSortable = true)]
        public string Aer_Id { get; set; }

        [SearchableField(IsSortable = true, AnalyzerName = "aer_number_analyze")]
        public string Aer_Number { get; set; }

        [SearchableField(IsSortable = true)]
        public string Version_No { get; set; }

        [SearchableField(IsSortable = true)]
        public string Product { get; set; }

        [SearchableField(IsSortable = true)]
        public string Latest_Received_Date { get; set; }

        [SearchableField(IsSortable = true)]
        public string Country_Code { get; set; }

        [SearchableField(IsSortable = true)]
        public string Patient_Id { get; set; }

        [SearchableField(IsSortable = true)]
        public string Investigator_Last_Name { get; set; }

        [SearchableField(IsSortable = true)]
        public string Study { get; set; }

        [SearchableField(IsSortable = true)]
        public string Protocol { get; set; }

        [SearchableField(IsSortable = true)]
        public string Primary_Event { get; set; }

        [SearchableField(IsSortable = true)]
        public string Customer { get; set; }

        [SearchableField(IsSortable = true)]
        public string Patient_Study_Id { get; set; }

        [SearchableField(IsSortable = true)]
        public string Country { get; set; }

        [SearchableField(IsSortable = true)]
        public string Source_Table { get; set; }
    }
}