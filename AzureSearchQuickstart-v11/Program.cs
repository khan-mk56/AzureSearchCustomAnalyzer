using System;
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;

namespace AzureSearch.Quickstart

{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceName = "qnamakerasdas-asa4ofy66xky2sa";
            string indexName = "testkb2";   //idx-drm-arisg-search-screen
            string apiKey = "EAAA6BB77CE83D66F6EFF73809BA6286";

            Uri serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);
            Azure.Search.Documents.Indexes.SearchIndexClient adminClient = new SearchIndexClient(serviceEndpoint, credential);

            // Create a SearchClient to load and query documents
            SearchClient srchclient = new SearchClient(serviceEndpoint, indexName, credential);

            //Delete index if it exists
            Console.WriteLine("{0}", "Deleting index...\n");
            DeleteIndexIfExists(indexName, adminClient);

            //Create index
            Console.WriteLine("{0}", "Creating index...\n");
            CreateIndex(indexName, adminClient);

            SearchClient ingesterClient = adminClient.GetSearchClient(indexName);

            // Load documents
            Console.WriteLine("{0}", "Uploading documents...\n");
            UploadDocuments(ingesterClient);

            // Wait 2 secondsfor indexing to complete before starting queries (for demo and console-app purposes only)
            Console.WriteLine("Waiting for indexing...\n");
            System.Threading.Thread.Sleep(2000);

            // Call the RunQueries method to invoke a series of queries
            Console.WriteLine("Starting queries...\n");
            RunQueries(srchclient);

            // End the program
            Console.WriteLine("{0}", "Complete. Press any key to end this program...\n");
            Console.ReadKey();
        }

        // delete the hotels-quickstart index to reuse its name
        private static void DeleteIndexIfExists(string indexname, SearchIndexClient adminclient)
        {
            adminclient.GetIndexNames();
            {
                adminclient.DeleteIndex(indexname);
            }
        }
        //Create hotels-quickstart index
        private static void CreateIndex(string indexName, SearchIndexClient adminClient)
        {
            FieldBuilder fieldBuilder = new FieldBuilder();
            var searchFields = fieldBuilder.Build(typeof(Arisg));

            var analyzer = new CustomAnalyzer("aer_number_analyze", "keyword_v2")
            {
                TokenFilters = { TokenFilterName.Lowercase }
            };

            var definition = new SearchIndex(indexName, searchFields);
            definition.Analyzers.Add(analyzer);

            //var suggester = new SearchSuggester("sg", new[] { "Aer_Number" });
            //definition.Suggesters.Add(suggester);

            adminClient.CreateOrUpdateIndex(definition);
        }

        // Upload documents in a single Upload request.
        private static void UploadDocuments(SearchClient searchClient)
        {
            IndexDocumentsBatch<Arisg> batch = IndexDocumentsBatch.Create(
                IndexDocumentsAction.Upload(
                    new Arisg()
                    {
                        Id = "9999999901",
                        Aer_Id = "112321321321",
                        Aer_Number = "Currency currection.docx",
                        Latest_Received_Date = "xxx",
                        Uid = "xxxxx",
                        Max_Version_Flag = "xxxx",
                        Version_No = "xxxx",
                        Product = "xxxx",
                        Country_Code = "xx",
                        Patient_Id = "xxx",
                        Investigator_Last_Name = "xxx",
                        Study = "xxx",
                        Protocol = "xxx",
                        Primary_Event = "xxx",
                        Customer = "xx",
                        Patient_Study_Id = "xxx",
                        Country = "xx",
                        Source_Table = "xxx"

                    }
                    ),
                IndexDocumentsAction.Upload(
                    new Arisg()
                    {
                        Id = "9999999920",
                        Aer_Id = "112321321321",
                        Aer_Number = "Test currection.docx",
                        Latest_Received_Date = "xxx",
                        Uid = "xxxxx",
                        Max_Version_Flag = "xxxx",
                        Version_No = "xxxx",
                        Product = "xxxx",
                        Country_Code = "xx",
                        Patient_Id = "xxx",
                        Investigator_Last_Name = "xxx",
                        Study = "xxx",
                        Protocol = "xxx",
                        Primary_Event = "xxx",
                        Customer = "xx",
                        Patient_Study_Id = "xxx",
                        Country = "xx",
                        Source_Table = "xxx"

                    }
                    ),
                IndexDocumentsAction.Upload(
                    new Arisg()
                    {
                        Id = "9999999950",
                        Aer_Id = "112321321321",
                        Aer_Number = "Currency test.docx",
                        Latest_Received_Date = "xxx",
                        Uid = "xxxxx",
                        Max_Version_Flag = "xxxx",
                        Version_No = "xxxx",
                        Product = "xxxx",
                        Country_Code = "xx",
                        Patient_Id = "xxx",
                        Investigator_Last_Name = "xxx",
                        Study = "xxx",
                        Protocol = "xxx",
                        Primary_Event = "xxx",
                        Customer = "xx",
                        Patient_Study_Id = "xxx",
                        Country = "xx",
                        Source_Table = "xxx"

                    }
                    ),                
                    IndexDocumentsAction.Upload(
                    new Arisg()
                    {
                        Id = "999999987",
                        Aer_Id = "112321321321",
                        Aer_Number = "currection.docx",
                        Latest_Received_Date = "xxx",
                        Uid = "xxxxx",
                        Max_Version_Flag = "xxxx",
                        Version_No = "xxxx",
                        Product = "xxxx",
                        Country_Code = "xx",
                        Patient_Id = "xxx",
                        Investigator_Last_Name = "xxx",
                        Study = "xxx",
                        Protocol = "xxx",
                        Primary_Event = "xxx",
                        Customer = "xx",
                        Patient_Study_Id = "xxx",
                        Country = "xx",
                        Source_Table = "xxx"

                    }),
                    IndexDocumentsAction.Upload(
                    new Arisg()
                    {
                        Id = "99999990",
                        Aer_Id = "112321321321",
                        Aer_Number = "Currency currection",
                        Latest_Received_Date = "xxx",
                        Uid = "xxxxx",
                        Max_Version_Flag = "xxxx",
                        Version_No = "xxxx",
                        Product = "xxxx",
                        Country_Code = "xx",
                        Patient_Id = "xxx",
                        Investigator_Last_Name = "xxx",
                        Study = "xxx",
                        Protocol = "xxx",
                        Primary_Event = "xxx",
                        Customer = "xx",
                        Patient_Study_Id = "xxx",
                        Country = "xx",
                        Source_Table = "xxx"

                    })

                );

            try
            {
                IndexDocumentsResult result = searchClient.IndexDocuments(batch);
            }
            catch (Exception ex)
            {
                // If for some reason any documents are dropped during indexing, you can compensate by delaying and
                // retrying. This simple demo just logs the failed document keys and continues.
                Console.WriteLine("Failed to index some of the documents: {0}");
            }
        }

        // Run queries, use WriteDocuments to print output
        private static void RunQueries(SearchClient srchclient)
        {
            SearchOptions options;
            SearchResults<Arisg> response;
            options = new SearchOptions()    //Manoj
            {
          
                SearchMode = SearchMode.Any,
                IncludeTotalCount = true,
                QueryType = SearchQueryType.Full
            };

            options.SearchFields.Add("Aer_Number");
            //options.SearchFields = new[] { "aer_no" };
            //response = srchclient.Search<Arisg>("Currency currection", options);
            response = srchclient.Search<Arisg>("/.*Currency currection.*/", options);
            Console.WriteLine("Found Match!");
            WriteDocuments(response);

            //response = srchclient.Search<Arisg>("*", options); 
            //Console.WriteLine("Total Documents");
            //WriteDocuments(response);

        }

        private static void WriteDocuments(SearchResults<Arisg> searchResults)
        {
            foreach (SearchResult<Arisg> result in searchResults.GetResults())
            {
                Console.WriteLine(result.Document.Aer_Number);
            }

            Console.WriteLine();
        }

        private static void WriteDocuments(AutocompleteResults autoResults)
        {
            foreach (AutocompleteItem result in autoResults.Results)
            {
                Console.WriteLine(result.Text);
            }

            Console.WriteLine();
        }
    }
}
