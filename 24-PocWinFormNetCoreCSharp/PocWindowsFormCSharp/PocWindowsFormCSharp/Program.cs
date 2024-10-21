using System.Windows.Forms;

namespace PocWindowsFormCSharp
{
    internal class Program
    {
        [STAThread()]
        static void Main(string[] args)
        {
            Form form = new FormOkCancel();
            form.ShowDialog();

        }
    }
}
