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
    public partial class ReysInfoForm : Form
    {
        private readonly Reys reys;
        public ReysInfoForm()
        {
            InitializeComponent();
            Fillplane();
            reys = new Reys
            {
                Plane = plane.Boing,
                arrivalTime = DateTime.Now,
            };
            comboBox1.SelectedItem = reys.Plane;
        }
        public ReysInfoForm(Reys source)
            : this()
        {
            numericUpDown1.Value = source.NumberReys;
            comboBox1.SelectedItem = source.Plane;
            numericUpDown2.Value = source.NumberPassengers;
            numericUpDown3.Value = source.NumberCrew;
            numericUpDown4.Value = source.SborP;
            numericUpDown5.Value = source.SborC;
            numericUpDown6.Value = source.allowance;
            dateTimePicker1.Value = source.arrivalTime;
        }
        public Reys Reys => reys;
        private void Fillplane()
        {
            foreach (plane item in Enum.GetValues(typeof(plane)))
            {
                comboBox1.Items.Add(item);
            }
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var parent = sender as ComboBox;
            if (parent != null)
            {
                e.DrawBackground();
                Brush brush = new SolidBrush(parent.ForeColor);
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    brush = SystemBrushes.HighlightText;
                }
                if (e.Index >= 0)
                {
                    if (parent.Items[e.Index] is plane gender)
                    {
                        string text = "";
                        switch (gender)
                        {
                            case (plane.Airbus):
                                text = "Эйрбас";
                                break;
                            case (plane.Boing):
                                text = "Боинг";
                                break;
                            case (plane.OAK):
                                text = "ОАК";
                                break;
                        }
                        e.Graphics.DrawString(
                            text,
                            parent.Font,
                            brush,
                            e.Bounds);
                    }
                    else
                    {
                        e.Graphics.DrawString(
                            parent.Items[e.Index].ToString(),
                            parent.Font,
                            brush,
                            e.Bounds);
                    }
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            reys.NumberReys = numericUpDown1.Value;
            Validate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            reys.NumberPassengers = numericUpDown2.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reys.Plane = (plane)comboBox1.SelectedIndex;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            reys.NumberCrew = numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            reys.SborP = numericUpDown4.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            reys.SborC = numericUpDown5.Value;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            reys.allowance = numericUpDown6.Value;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            reys.arrivalTime = dateTimePicker1.Value;
        }
        public void Validate()
        {
            Save.Enabled = !string.IsNullOrWhiteSpace(reys.NumberReys.ToString());
        }

    }
}
