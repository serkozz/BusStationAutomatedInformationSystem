﻿using System;
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
    public partial class RouteForm : Form
    {
        public MainForm MainForm { get; }
        public Profile Profile { get; }

        public RouteForm(MainForm mainForm, Profile profile)
        {
            MainForm = mainForm;
            Profile = profile;
            InitializeComponent();
        }


    }
}
