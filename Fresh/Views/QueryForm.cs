using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fresh
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }
        public DataGridView DataGridView
        {
            get { return dataGridView1; }
            set { dataGridView1 = value; }
        }
    }
}
