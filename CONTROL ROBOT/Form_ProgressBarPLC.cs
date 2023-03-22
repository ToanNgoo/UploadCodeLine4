using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONTROL_ROBOT
{
    public partial class Form_ProgressBarPLC : Form
    {

        fMain fmain;

        public Form_ProgressBarPLC(fMain _fmain)
        {
            InitializeComponent();
            fmain = _fmain;
            //Control.CheckForIllegalCrossThreadCalls = false;        // Cho phep cross du lieu    
        }

       

       public void CloseForm()
        {
            
            this.Close();
            //this.Dispose();
        }

       private void Form_ProgressBarPLC_Load(object sender, EventArgs e)
       {

       }

       private void timer_ProgressBar_Tick(object sender, EventArgs e)
       {

       }

      



        

       













    }
}
