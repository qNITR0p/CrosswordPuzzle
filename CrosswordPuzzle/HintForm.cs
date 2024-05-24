using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrosswordPuzzle;

namespace CrosswordPuzzle
{
    public partial class HintForm : Form
    {
        private CrosswordForm crosswordForm;

        public HintForm(CrosswordForm crosswordForm)
        {
            InitializeComponent();
            this.crosswordForm = crosswordForm;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }



        private void HintForm_LocationChanged(object sender, EventArgs e)
        {
            crosswordForm.SetDesktopLocation(this.Location.X - crosswordForm.Width, this.Location.Y);
        }




    }

}
