using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Text.Json;
using System.IO;

namespace TheatricalPlayersRefactoringKata;

public class StatementPrinter
{



    public Invoice GenerateCustomerInvoice(Invoice invoice, Dictionary<string, Play> plays){

        invoice.InvoiceCost(invoice.Performances,plays);
        invoice.InvoiceCredits(invoice.Performances,plays);
        return invoice;
    }

  
   
    public string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        CultureInfo cultureInfo = new CultureInfo("en-US");

        var invoiceCustomer = this.GenerateCustomerInvoice(invoice, plays);
        var invoiceText = string.Format("Statement for {0}\n", invoice.Customer);

        foreach(var perf in invoiceCustomer.Performances){
            var play = plays[perf.PlayId].Name;
            invoiceText += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play, Convert.ToDecimal(perf.PlayCost / 100), perf.Audience);
        }
        invoiceText += String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(invoice.TotalCost/100));
        invoiceText += String.Format("You earned {0} credits",invoice.TotalCretids);
        //invoice.SaveInvoice(invoice);
        return invoiceText;
    }


 public string PrintXml(Invoice invoice, Dictionary<string, Play> plays)
{
    CultureInfo cultureInfo = new CultureInfo("en-US");
    var invoiceCustomer = this.GenerateCustomerInvoice(invoice, plays);
    
    // Definição dos namespaces corretos
    XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
    XNamespace xsd = "http://www.w3.org/2001/XMLSchema";

    XElement itemsElement = new XElement("Items");

    foreach (var perf in invoiceCustomer.Performances)
    {
        itemsElement.Add(new XElement("Item",
            new XElement("AmountOwed", (perf.PlayCost / 100).ToString("0.##", cultureInfo)),
            new XElement("EarnedCredits", perf.PlayCredtis),
            new XElement("Seats", perf.Audience)
        ));
    }

    XDocument xmlInvoice = new XDocument(
        new XDeclaration("1.0", "utf-8", null), // Adiciona a declaração XML correta
        new XElement("Statement",
            new XAttribute(XNamespace.Xmlns + "xsi", xsi.NamespaceName),
            new XAttribute(XNamespace.Xmlns + "xsd", xsd.NamespaceName),
            new XElement("Customer", invoice.Customer),
            itemsElement,
            new XElement("AmountOwed", (invoice.TotalCost / 100).ToString("0.##", cultureInfo)),
            new XElement("EarnedCredits", invoice.TotalCretids)
        )
    );

    using var ms = new MemoryStream();
    using var writer = new StreamWriter(ms, new UTF8Encoding(false, false));
    xmlInvoice.Save(writer);
    writer.Flush();
    return Encoding.UTF8.GetString(ms.ToArray());
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
