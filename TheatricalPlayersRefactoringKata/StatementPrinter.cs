using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Text.Json;

namespace TheatricalPlayersRefactoringKata;

public class StatementPrinter
{



    public Invoice GenerateCustomerInvoice(Invoice invoice, Dictionary<string, Play> plays){

        CultureInfo cultureInfo = new CultureInfo("en-US");
        var InvoiceText = string.Format("Statement for {0}\n", invoice.Customer);
        InvoiceText += invoice.InvoiceCostText(invoice.Performances,plays);
        InvoiceText += String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(invoice.TotalCost/100));
        InvoiceText += String.Format("You earned {0} credits\n", invoice.InvoiceCredits(invoice.Performances,plays));
        invoice.InvoiceResume = InvoiceText;
        return invoice;
    }

    // public string PrintXML(Invoice invoice, Dictionary<string, Play> plays)
    // {
    //     var result = string.Format("Statement for {0}\n", invoice.Customer);
        
    // }
   
    public string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        var invoiceCustomer = this.GenerateCustomerInvoice(invoice, plays);
        return invoiceCustomer.InvoiceResume;
    }


     public string PrintXml(Invoice invoice, Dictionary<string, Play> plays)
    {
        var invoiceCustomer = this.GenerateCustomerInvoice(invoice, plays);
        var xml = new XElement("Invoice",
            new XElement("Customer", invoiceCustomer.Customer),
            new XElement("TotalAmount", invoiceCustomer.TotalCost),
            new XElement("Credits", invoiceCustomer.TotalCretids),
            new XElement("InvoiceResume",invoice.InvoiceResume)
        );
        return xml.ToString();
    }


    public string PrintCsv(Invoice invoice, Dictionary<string, Play> plays)
{
    var invoiceCustomer = this.GenerateCustomerInvoice(invoice, plays);

    // Cabeçalhos do CSV
    var csv = new StringBuilder();
    csv.AppendLine("Customer,TotalAmount,Credits,InvoiceResume");

    // Adiciona os valores da fatura
    csv.AppendLine($"{invoiceCustomer.Customer},{invoiceCustomer.TotalCost},{invoiceCustomer.TotalCretids},{invoice.InvoiceResume}");

    return csv.ToString();
}


public string PrintJson(Invoice invoice, Dictionary<string, Play> plays)
{
    var invoiceCustomer = this.GenerateCustomerInvoice(invoice, plays);

    var json = new
    {
        Customer = invoiceCustomer.Customer,
        TotalAmount = invoiceCustomer.TotalCost,
        Credits = invoiceCustomer.TotalCretids,
        InvoiceResume = invoice.InvoiceResume
    };

    return JsonSerializer.Serialize(json, new JsonSerializerOptions { WriteIndented = true });
}



}
