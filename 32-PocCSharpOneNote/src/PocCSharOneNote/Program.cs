using System;
using System.Xml.Linq;
using Microsoft.Office.Interop.OneNote;
namespace PocCSharOneNote
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ListAllPages();
            ListAllNoteBooks();
        }

        private static void ListAllPages()
        {
            var app = new Microsoft.Office.Interop.OneNote.Application();
            app.GetHierarchy(null, HierarchyScope.hsPages, out string xml);
            var doc = XDocument.Parse(xml);

            var ns = doc.Root?.Name.Namespace;
            var pageTitles = doc.Descendants(ns + "Page")
                                .Select(p => p.Attribute("name")?.Value)
                                .ToList();

            foreach (var title in pageTitles)
            {
                Console.WriteLine(title);
            }
        }

        private static void ListAllNoteBooks()
        {
            var app = new Microsoft.Office.Interop.OneNote.Application();
            app.GetHierarchy(null, HierarchyScope.hsNotebooks, out string xml);
            var doc = XDocument.Parse(xml);
            var ns = doc.Root?.Name.Namespace;
            var notebookTitles = doc.Descendants(ns + "Notebook")
                                    .Select(nb => nb.Attribute("name")?.Value)
                                    .ToList();
            foreach (var title in notebookTitles)
            {
                Console.WriteLine(title);
            }
        }
    }
}
