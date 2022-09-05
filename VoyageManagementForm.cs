using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BusStationAutomatedInformationSystem
{
    public partial class VoyageManagementForm : Form
    {
        public VoyageManagementForm()
        {
            InitializeComponent();
            OnFormLoad();
        }

        private void OnFormLoad()
        {
            // Выгрузить в календарь все даты, на которые есть хотя бы один билет
            // При выборе нужной даты должен подсасываться автобус который ходит по этому маршруту, и по нажатию на кнопку назначить,
            // должна содаваться запись в таблице voyage содержащая автобус  маршрут и список билетов (по дбдиаграм ио)
        }
    }
}
