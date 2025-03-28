using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.StatementFormatters;

public class XmlFormatter : IStatementFormatter
{
    public string Format(StatementData data)
    {
        var xmlDeclaration = new XDeclaration("1.0", "utf-8", null);
        
        var statementElement = new XElement("Statement",
            new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
            new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
            new XElement("Customer", data.Customer),
            new XElement("Items",
                data.Performances.Select(p => 
                    new XElement("Item",
                        new XElement("AmountOwed", p.Amount),
                        new XElement("EarnedCredits", p.EarnedCredits),
                        new XElement("Seats", p.Audience)
                    )
                )
            ),
            new XElement("AmountOwed", data.TotalAmount),
            new XElement("EarnedCredits", data.TotalCredits)
        );

        var document = new XDocument(xmlDeclaration, statementElement);
        
        var settings = new XmlWriterSettings 
        { 
            Encoding = new UTF8Encoding(false), // UTF-8 sem BOM
            Indent = true,
            IndentChars = "  ",
            OmitXmlDeclaration = false
        };

        // Usando StringWriter com Encoding UTF-8
        using var stringWriter = new StringWriter();
        using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
        {
            document.Save(xmlWriter);
        }
        
        return stringWriter.ToString();
    }

}
