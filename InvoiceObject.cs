using System;
using System.Data;

namespace SampleBO
{
    public class InvoiceObject
    {
        //blank constructor
        public InvoiceObject(){}
        
        //parameterized constructor
        public InvoiceObject(string invoiceNumber, DateOnly issueDate, DateOnly dueDate,
                                    Double totalAmount, Double tax, DataTable lineItems)
        {
            InvoiceNumber = invoiceNumber;
            IssueDate = issueDate;
            DueDate = dueDate;
            IssueDate = issueDate;
            TotalAmount = totalAmount;
            Tax = tax;
            LineItems = lineItems;
        }
        
        //Invoice number is now read only
        public string InvoiceNumber { get; }
        
        public DateOnly IssueDate { get; set; }
        
        public DateOnly DueDate { get; set; }
        
        public Double TotalAmount { get; set; }
        
        public Double Tax { get; set; }
        
        public DataTable LineItems{ get; set; }
        
        //Dynamic tax calculator based on the other props
        public Double TaxAmount
        { 
            get{
             return TotalAmount*Tax/100;   
            }
        }
        
        //Function to check invoice amount below threshold
        public bool checkInvoice(double thresholdAmount)
        {
            return TotalAmount < thresholdAmount;
        }
    }
}