using System.Windows.Forms;

class Program
{
    static void Main(string[] args)
    {
        // Display the number of command line arguments.
        Console.WriteLine("The console has been started");
        MessageBox.Show("WinForm in Console Application");
        Console.WriteLine("Press any key to exit!");
        Console.ReadKey();
    }
}