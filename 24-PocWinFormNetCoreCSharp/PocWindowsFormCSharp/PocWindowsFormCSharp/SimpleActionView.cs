
namespace PocWindowsFormCSharp
{
    
    /// <summary>
    ///  This is a simple form that contains :
    ///  - Input line
    ///  - Action Button
    ///  - Output text (with vertical and horizontal scrolling
    ///  - Ok + Cancel buttons
    /// </summary>
    
    public class SimpleActionView : Form
    {
        private Button okButton = new Button();
        private Button cancelButton = new Button();
        private Button actionButton = new Button();
        private TextBox inputTextBox = new TextBox();
        private TextBox outputTextBox = new TextBox();

        private SimpleActionModel theModel;

        private void InitButton (Button btn, Point point, Size size, string text, EventHandler eh)
        {
            btn.Location = point;
            btn.Size = size;
            btn.Text = text;
            btn.Click += eh;

        }
        private void InitializeComponents()
        {
            InitButton(this.okButton, new Point(48, 500), new Size(80, 24), "OK", new System.EventHandler(this.okButton_Click));
            InitButton(this.cancelButton, new Point(148, 500), new Size(80, 24), "Cancerl", new System.EventHandler(this.cancelButton_Click));
            InitButton(this.actionButton, new Point(40, 80), new Size(80, 24), "Action", new System.EventHandler(this.theModel.ActionDone));

            this.inputTextBox.Location = new Point(40, 40);
            this.inputTextBox.Size = new Size(400, 24);
            this.inputTextBox.Multiline = false;

            this.outputTextBox.Location = new Point(40,120);
            this.outputTextBox.Size = new Size(400, 200);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.ScrollBars = ScrollBars.Vertical;

            this.ClientSize = new Size(700, 600);
            this.Controls.AddRange(new Control[] {this.okButton,
                this.cancelButton,
                this.actionButton,
                this.inputTextBox,
            this.outputTextBox});
            this.Text = "Form with OK Cancel buttons";
        }

        public void ModelToView()
        {
            this.inputTextBox.Text = theModel.Input;
            this.outputTextBox.Text = theModel.Output;
        }

        public void ViewToModel()
        {
            theModel.Input = this.inputTextBox.Text;
            theModel.Output = this.outputTextBox.Text;
        }
        private void okButton_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("OK Button has been pressed!");
            ViewToModel();
            this.Dispose();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Cancel Button has been pressed!");
            this.Dispose();
        }

        // no more used
        private void actionButton_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Action - Button has been pressed!");
            Form form = new FormOkCancel();
            form.ShowDialog();
            this.outputTextBox.Text = this.inputTextBox.Text + " : ";
            this.Refresh();

                
        }

        protected SimpleActionView()
        {
            InitializeComponents();
        }
        public SimpleActionView(SimpleActionModel theModel)
        {
            this.theModel = theModel;
            InitializeComponents();
            theModel.theView = this;
            ModelToView();
        }
    }
}
