using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DatabaseApp
{
    public partial class MainForm : Form
    {
        private readonly IDatabase _database;
        public MainForm()
        {
            InitializeComponent();

            _database = new SqlDatabase(
                server: "mssql",
                database: "ispp3102",
                userName: "ispp3102",
                password: "3102");

            Debug.WriteLine(_database.ToString());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
