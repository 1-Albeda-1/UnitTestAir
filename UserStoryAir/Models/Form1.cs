using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserStoryAir.Models;

namespace UserStoryAir
{
    public partial class Аэропорт : Form
    {
        private readonly List<Reys> reys;
        private readonly BindingSource bindingSource;
        private decimal sum = 0;
        public Аэропорт()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            reys = new List<Reys>();
            bindingSource = new BindingSource();
            bindingSource.DataSource = reys;
            dataGridView1.DataSource = bindingSource;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Смирнова К.А ИП-20-3.", "Аэропорт 5 вариант.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void addtool_Click(object sender, EventArgs e)
        {
            var infoForm = new ReysInfoForm();
            infoForm.Text = "Добавить рейс";
            if (infoForm.ShowDialog(this) == DialogResult.OK)
            {
                reys.Add(infoForm.Reys);
                bindingSource.ResetBindings(false);
                CalculateStats();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column9")
            {
                var data = (Reys)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                sum += (data.NumberPassengers * data.SborP + data.NumberCrew * data.SborC) * ((100.00m + data.allowance) / 100.0m);
                e.Value = sum;
                sum = 0;
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column2")
            {
                var val = (plane)e.Value;
                switch (val)
                {
                    case plane.Boing:
                        e.Value = "Бойнг";
                        break;
                    case plane.Airbus:
                        e.Value = "Эйрбас";
                        break;
                    case plane.OAK:
                        e.Value = "ОАК";
                        break;
                    default:
                        e.Value = "не известен";
                        break;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            изменитьToolStripMenuItem.Enabled =
            удалитьToolStripMenuItem.Enabled =
            ChangeTool.Enabled =
            DeleteTool.Enabled =
            dataGridView1.SelectedRows.Count > 0;
        }

        private void DeleteTool_Click(object sender, EventArgs e)
        {
            var data = (Reys)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            if (MessageBox.Show($"Вы действительно желаете удалить рейс номер'{data.NumberReys}'?",
                "Удадение записи",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                reys.Remove(data);
                bindingSource.ResetBindings(false);
                CalculateStats();
            }
        }
        private void ChangeTool_Click(object sender, EventArgs e)
        {
            var data = (Reys)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            var infoform = new ReysInfoForm(data);
            infoform.Text = "Реадактировать студента";
            if (infoform.ShowDialog(this) == DialogResult.OK)
            {
                data.NumberReys = infoform.Reys.NumberReys;
                data.Plane = infoform.Reys.Plane;
                data.NumberPassengers = infoform.Reys.NumberPassengers;
                data.NumberCrew = infoform.Reys.NumberCrew;
                data.SborP = infoform.Reys.SborP;
                data.SborC = infoform.Reys.SborC;
                data.allowance = infoform.Reys.allowance;
                data.arrivalTime = infoform.Reys.arrivalTime;
                bindingSource.ResetBindings(false);
                CalculateStats();
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addtool_Click(sender, e);
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeTool_Click(sender, e);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteTool_Click(sender, e);
        }

        public void CalculateStats()
        {
            var count = reys.Count;
            var Summa = 0.0m;
            var pas = 0.0m;
            var Ekip = 0.0m;
            РейсыStripStatusLabel1.Text = $"Кол-во рейсов: " + count;
            foreach (var rey in reys)
            {
                pas += rey.NumberPassengers;
                Ekip += rey.NumberCrew;
                Summa += (rey.NumberPassengers * rey.SborP + rey.NumberCrew * rey.SborC) * ((100.00m + rey.allowance) / 100.0m);
            }
            ВыручкаStripStatusLabel2.Text = $"Сумма всей выручки: " + Summa;
            ПассажирыStripStatusLabel2.Text = $"Кол-во пассажиров: " + pas;
            ЭкипажStripStatusLabel2.Text = $"Кол-во экипажа:" + Ekip;
        }


    }

}