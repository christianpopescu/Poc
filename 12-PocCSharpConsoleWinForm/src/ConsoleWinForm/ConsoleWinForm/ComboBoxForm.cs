using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWinForm
{
    internal class ComboBoxForm : System.Windows.Forms.Form
    {
       private ComboBox SelectItems = new ComboBox();
       private System.Windows.Forms.Button okButton = new Button();
        private StringBuilder returnValue;

        private void InitializeComponents()
        {
            this.SelectItems.Items.AddRange(new object[] { "Select File", "Create Dialog" });
            this.SelectItems.Location = new System.Drawing.Point(8, 248);
            this.SelectItems.Size = new System.Drawing.Size(280, 21);


            this.okButton.Location = new System.Drawing.Point(248, 32);
            this.okButton.Size = new System.Drawing.Size(40, 24);
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);

            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.SelectItems,
                        this.okButton});
            this.Text = "ComboBox Selection";
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            returnValue.Append(SelectItems.SelectedItem.ToString());
            this.Dispose();
        }

        public ComboBoxForm(StringBuilder returnValue)
        {
            this.returnValue = returnValue;
            InitializeComponents();
        }
    }
}
