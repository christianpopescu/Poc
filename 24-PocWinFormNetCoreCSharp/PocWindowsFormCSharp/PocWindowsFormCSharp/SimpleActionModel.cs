using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocWindowsFormCSharp
{
    public class SimpleActionModel
    {
        public string Input { get; set; }
        public string Output { get; set; }

        public SimpleActionView theView { get; set; }

        public void ActionDone (object sender, EventArgs e)
        {
            theView.ViewToModel();
            Output = Input + " : ";
            theView.ModelToView();
            theView.Refresh();
        }
    }
}
