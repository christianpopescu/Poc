using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocWindowsFormCSharp
{
    public  class FormOkCancel : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button okButton = new Button();
        private System.Windows.Forms.Button cancelButton = new Button();

        private void InitializeComponents()
        {
            this.okButton.Location = new System.Drawing.Point(148, 32);
            this.okButton.Size = new System.Drawing.Size(80, 24);
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);

            this.cancelButton.Location = new System.Drawing.Point(148, 102);
            this.cancelButton.Size = new System.Drawing.Size(80, 24);
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.okButton,
                        this.cancelButton});
            this.Text = "Form with OK Cancel buttons";
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("OK Button has been pressed!");
            this.Dispose();
        }

        private void cancelButton_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Cancel Button has been pressed!");
            this.Dispose();
        }

        public FormOkCancel ()
        {
            InitializeComponents();
        }
    }
}
