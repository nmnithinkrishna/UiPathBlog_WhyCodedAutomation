using System.Collections.Generic;
using UiPath.CodedWorkflows;
using Newtonsoft.Json;

namespace SampleBO
{
    public class TestCodedWorkflow : CodedWorkflow
    {
        [Workflow]
        public void Execute()
        {
            //Getting asset value
            string assetValue = system.GetAsset("TestAsset").ToString().Trim();
            Log(assetValue, LogLevel.Info);
            
            //Adding a queue item
            var specificContent = new Dictionary<string,object>();
            specificContent.Add("InvoiceNumber", "12345");
            specificContent.Add("IssueDate", "05/08/2023");
            specificContent.Add("DueDate", "24/08/2023");
            
            //Dynamic using BO
            var invoiceObject = new InvoiceObject(); //Assuming this object is constructed and coming from DU workflow or other
            
            //Serialize object to string & then de-serialize it to dictionary
            specificContent = JsonConvert.DeserializeObject<Dictionary<string,object>>(
                                    JsonConvert.SerializeObject(invoiceObject)
                              );
                
            system.AddQueueItem("TestQueue","TestFolder", specificContent);
        }
    }
}