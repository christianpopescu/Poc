using Microsoft.Office.Interop.OneNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PocCSharOneNote
{
    class OneNoteHelper
    {
        
        public static void PrintHierarchycalNotebooksContent()
        {
            var app = new Microsoft.Office.Interop.OneNote.Application();
            app.GetHierarchy(null, HierarchyScope.hsPages, out string hierarchyXml);

            var doc = XDocument.Parse(hierarchyXml);
            XNamespace ns = doc.Root.Name.Namespace;

            foreach (var notebook in doc.Descendants(ns + "Notebook"))
            {
                PrintNotebook(notebook, ns, indent: 0);
            }
        }
        
        static void PrintNotebook(XElement notebook, XNamespace ns, int indent)
        {
            string name = notebook.Attribute("name")?.Value;
            Console.WriteLine($"{new string(' ', indent)} Notebook: {name}");

            foreach (var sectionGroup in notebook.Elements(ns + "SectionGroup"))
            {
                PrintSectionGroup(sectionGroup, ns, indent + 2);
            }

            foreach (var section in notebook.Elements(ns + "Section"))
            {
                PrintSection(section, ns, indent + 2);
            }
        }

        static void PrintSectionGroup(XElement sectionGroup, XNamespace ns, int indent)
        {
            string name = sectionGroup.Attribute("name")?.Value;
            Console.WriteLine($"{new string(' ', indent)}Section Group: {name}");

            foreach (var subGroup in sectionGroup.Elements(ns + "SectionGroup"))
            {
                PrintSectionGroup(subGroup, ns, indent + 2);
            }

            foreach (var section in sectionGroup.Elements(ns + "Section"))
            {
                PrintSection(section, ns, indent + 2);
            }
        }

        static void PrintSection(XElement section, XNamespace ns, int indent)
        {
            string name = section.Attribute("name")?.Value;
            Console.WriteLine($"{new string(' ', indent)}Section: {name}");

            foreach (var page in section.Elements(ns + "Page"))
            {
                string pageTitle = page.Attribute("name")?.Value;
                Console.WriteLine($"{new string(' ', indent + 2)}Page: {pageTitle}");
            }
        }

    }
}



