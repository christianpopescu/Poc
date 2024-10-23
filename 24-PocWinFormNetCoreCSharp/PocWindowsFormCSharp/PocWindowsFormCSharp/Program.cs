using System.Windows.Forms;

namespace PocWindowsFormCSharp
{
    internal class Program
    {
        [STAThread()]
        static void Main(string[] args)
        {
            SimpleActionModel model = new SimpleActionModel() { Input = "ABCD" };
            Form form = new SimpleActionView(model);
            form.ShowDialog();
            MessageBox.Show(model.Output);

        }
    }
}
