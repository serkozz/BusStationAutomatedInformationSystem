﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusStationAutomatedInformationSystem
{
    public partial class MainForm : Form
    {
        private string _connectionString;
        public MainForm(string connectionString)
        {
            _connectionString = connectionString;
            InitializeComponent();
        }
    }
}
