using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Office.Interop.OneNote;

namespace PocCSharOneNote
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new ProcedureSelectorForm());
        }

        // Procedures to select from
        public static void ListAllPages()
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
                Console.WriteLine($"Page Title {title}");
            }
        }

        public static void ListAllNoteBooks()
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
                Console.WriteLine($"Notebook Title: {title}");
            }
        }

        public static void ListAllNotebooks_v2()
        {
            var app = new Microsoft.Office.Interop.OneNote.Application();
            app.GetHierarchy(null, HierarchyScope.hsNotebooks, out string xml);
            var doc = XDocument.Parse(xml);
            var ns = doc.Root?.Name.Namespace;
            var notebooks = doc.Descendants(ns + "Notebook")
                               .Select(nb => new
                               {
                                   Name = nb.Attribute("name")?.Value,
                                   ID = nb.Attribute("ID")?.Value
                               })
                               .ToList();
            foreach (var notebook in notebooks)
            {
                Console.WriteLine($" Notebook Info -> Notebook: {notebook.Name}, ID: {notebook.ID}");
            }
        }
    }

    public class ProcedureSelectorForm : Form
    {
        private ListBox listBox;
        private Button runButton;

        public ProcedureSelectorForm()
        {
            Text = "Select Procedure";
            Width = 300;
            Height = 200;

            listBox = new ListBox
            {
                Dock = DockStyle.Top,
                Height = 100
            };
            listBox.Items.AddRange(new string[]
            {
                "ListAllPages",
                "ListAllNoteBooks",
                "ListAllNotebooks_v2",
                "ListHierachycalNotebooksContent"
            });

            runButton = new Button
            {
                Text = "Run",
                Dock = DockStyle.Bottom
            };
            runButton.Click += RunButton_Click;

            Controls.Add(listBox);
            Controls.Add(runButton);
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            var selected = listBox.SelectedItem as string;
            if (selected == null)
            {
                MessageBox.Show("Please select a procedure.");
                return;
            }

            switch (selected)
            {
                case "ListAllPages":
                    Program.ListAllPages();
                    break;
                case "ListAllNoteBooks":
                    Program.ListAllNoteBooks();
                    break;
                case "ListAllNotebooks_v2":
                    Program.ListAllNotebooks_v2();
                    break;
                case "ListHierachycalNotebooksContent":
                    OneNoteHelper.PrintHierarchycalNotebooksContent();
                    break;
            }

        }
    }
}
