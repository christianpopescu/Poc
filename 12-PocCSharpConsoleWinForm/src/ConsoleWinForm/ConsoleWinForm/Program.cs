using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        // Display the number of command line arguments.
        Console.WriteLine("The console has been started");
        var fileContent = string.Empty;
        var filePath = string.Empty;
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.InitialDirectory = "e:\\";
            openFileDialog.Filter = "txt files (*.pdf)|*.pdf|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;



            }
        }
        MessageBox.Show("WinForm in Console Application + selected file : " + filePath);
        Console.WriteLine("Press any key to exit!");
        Console.ReadKey();
    }
}