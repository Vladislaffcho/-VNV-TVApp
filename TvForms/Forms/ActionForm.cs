using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvForms
{
    public partial class ActionForm : Form
    {
        public ActionForm(int id)
        {
            InitializeComponent();
            panUserActions.Controls.Add(new UcUserProfile(id));
        }


    }
}
