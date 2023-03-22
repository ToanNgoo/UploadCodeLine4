using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CONTROL_ROBOT
{
    public partial class Form_AlarmPLC : Form
    {

        fMain fmain;

        public Form_AlarmPLC(fMain _fmain)
        {
            InitializeComponent();
            fmain = _fmain;
        }

        public string Name_Alarm = "";

        private void ptb_Close_Form_Alarm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_AlarmPLC_Load(object sender, EventArgs e)
        {
            lblNameAlarm.Text = Name_Alarm;
        }
    }
}
