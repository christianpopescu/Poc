using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocWindowsFormCSharp
{
    
    /// <summary>
    ///  This is a simple form that contains :
    ///  - Input line
    ///  - Action Button
    ///  - Output text (with vertical and horizontal scrolling
    ///  - Ok + Cancel buttons
    /// </summary>
    
    public class SimpleActionView : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button okButton = new Button();
        private System.Windows.Forms.Button cancelButton = new Button();
        private System.Windows.Forms.Button actionButton = new Button();
        private System.Windows.Forms.TextBox inputTextBox = new TextBox();
        private System.Windows.Forms.TextBox outputTextBox = new TextBox();

        private SimpleActionModel theModel;

        private void InitializeComponents()
        {
            this.okButton.Location = new System.Drawing.Point(48, 500);
            this.okButton.Size = new System.Drawing.Size(80, 24);
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);

            this.cancelButton.Location = new System.Drawing.Point(148, 500);
            this.cancelButton.Size = new System.Drawing.Size(80, 24);
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            this.actionButton.Location = new System.Drawing.Point(40, 80);
            this.actionButton.Size = new System.Drawing.Size(80, 24);
            this.actionButton.Text = "Action";
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);

            this.inputTextBox.Location = new System.Drawing.Point(40, 40);
            this.inputTextBox.Size = new System.Drawing.Size(400, 24);
            this.inputTextBox.Multiline = false;

            this.outputTextBox.Location = new System.Drawing.Point(40,120);
            this.outputTextBox.Size = new System.Drawing.Size(400, 200);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.ScrollBars = ScrollBars.Vertical;

            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.okButton,
                this.cancelButton,
                this.actionButton,
                this.inputTextBox,
            this.outputTextBox});
            this.Text = "Form with OK Cancel buttons";
        }

        private void ModelToView()
        {
            this.inputTextBox.Text = theModel.Input;
            this.outputTextBox.Text = theModel.Output;
        }

        private void ViewToModel()
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
            InitializeComponents();
            this.theModel = theModel;
            ModelToView();
        }
    }
}
