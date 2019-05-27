using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanceSportDatabase
{
    partial class MainForm
    {
        //---------------------------DANCER------------------------------//

        private void DeleteButtonD_Click(object sender, EventArgs e)
        {
            EnableFiltersD(false);
            try
            {
                TryDeleteCurrentDancer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неможливо видалити танцора");
            }

        }
        private void ResetFilterButtonD_Click(object sender, EventArgs e)
        {
            InitFiltersD();
        }
        private void SaveButtonD_Click(object sender, EventArgs e)
        {
            dANCERTableAdapter.Update(this.danceSportDataSet.DANCER);
            FillTableAdapter(DancerAdapterId);
        }
        private void ResetButtonD_Click(object sender, EventArgs e)
        {
            FillTableAdapter(DancerAdapterId);
        }




        private void textBoxNameD_TextChanged(object sender, EventArgs e)
        {
            configD.name = textBoxNameD.Text;
            FillTableAdapter(DancerAdapterId);
        }


        private void comboBoxMinClassLatD_TextChanged(object sender, EventArgs e)
        {
            configD.minClassLat = comboBoxMinClassLatD.Text;
            FillTableAdapter(DancerAdapterId);
        }
        private void comboBoxMaxClassLatD_TextChanged(object sender, EventArgs e)
        {
            configD.maxClassLat = comboBoxMaxClassLatD.Text;
            FillTableAdapter(DancerAdapterId);
        }
        private void comboBoxMinClassStD_TextChanged(object sender, EventArgs e)
        {
            configD.minClassSt = comboBoxMinClassStD.Text;
            FillTableAdapter(DancerAdapterId);
        }
        private void comboBoxMaxClassStD_TextChanged(object sender, EventArgs e)
        {
            configD.maxClassSt = comboBoxMaxClassStD.Text;
            FillTableAdapter(DancerAdapterId);
        }

        private void comboBoxMinHeightD_TextChanged(object sender, EventArgs e)
        {
            configD.minHeight = Int32.Parse(comboBoxMinHeightD.Text);
            InitMaxHeightFilter();
            FillTableAdapter(DancerAdapterId);
        }
        private void comboBoxMaxHeightD_TextChanged(object sender, EventArgs e)
        {
            configD.maxHeight = Int32.Parse(comboBoxMaxHeightD.Text);
            InitMinHeightFilter();
            FillTableAdapter(DancerAdapterId);
        }
        private void comboBoxMinYearD_TextChanged(object sender, EventArgs e)
        {
            configD.minYear = Int32.Parse(comboBoxMinYearD.Text);
            InitMaxYearFilter();
            FillTableAdapter(DancerAdapterId);
        }
        private void comboBoxMaxYearD_TextChanged(object sender, EventArgs e)
        {
            configD.maxYear = Int32.Parse(comboBoxMaxYearD.Text);
            InitMinYearFilter();
            FillTableAdapter(DancerAdapterId);
        }

        
        private void checkBoxMaleD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaleD.Checked == true)
                configD.sexM = "1";
            else
            {
                if (checkBoxFemaleD.Checked == false)
                {
                    checkBoxMaleD.Checked = true;
                    return;
                }
                else
                    configD.sexM = "0";
            }
            FillTableAdapter(DancerAdapterId);
        }
        private void checkBoxFemaleD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFemaleD.Checked == true)
                configD.sexF = "1";
            else
            {
                if (checkBoxMaleD.Checked == false)
                {
                    checkBoxFemaleD.Checked = true;
                    return;
                }
                else
                    configD.sexF = "0";
            }
            FillTableAdapter(DancerAdapterId);
        }

        


        private void DataGridViewD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("YAAAAY!!!");
   
            EnableFiltersD(false);
        }

        

        private void DataGridViewD_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string error;
            if (IsValidDataD(e.ColumnIndex, e.FormattedValue.ToString(), out error) == false)
            {
                ShowErrorD(error);
                e.Cancel = true;
            }
            else
            {
                HideErrorD();
                e.Cancel = false;
            }
        }



        //---------------------------COUPLE------------------------------//

        private void DeleteButtonC_Click(object sender, EventArgs e)
        {
            EnableFiltersD(false);
            try
            {
                TryDeleteCurrentDancer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неможливо видалити танцора");
            }

        }
        private void textBoxNameC_TextChanged(object sender, EventArgs e)
        {
            configD.name = textBoxNameD.Text;
            FillTableAdapter(DancerAdapterId);
        }

        private void comboBoxMinClassLatC_TextChanged(object sender, EventArgs e)
        {
            configD.minClassLat = comboBoxMinClassLatD.Text;
            FillTableAdapter(DancerAdapterId);
        }

        private void comboBoxMaxClassLatC_SelectedIndexChanged(object sender, EventArgs e)
        {
            configD.maxClassLat = comboBoxMaxClassLatD.Text;
            FillTableAdapter(DancerAdapterId);
        }

        private void SaveButtonC_Click(object sender, EventArgs e)
        {
            dANCERTableAdapter.Update(this.danceSportDataSet.DANCER);
            FillTableAdapter(DancerAdapterId);
        }

        private void ResetButtonC_Click(object sender, EventArgs e)
        {
            FillTableAdapter(DancerAdapterId);
        }

        private void ResetFilterButtonC_Click(object sender, EventArgs e)
        {
            InitFiltersD();
        }

        private void DataGridViewC_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string error;
            if (IsValidDataD(e.ColumnIndex, e.FormattedValue.ToString(), out error) == false)
            {
                ShowErrorD(error);
                e.Cancel = true;
            }
            else
            {
                HideErrorD();
                e.Cancel = false;
            }
        }
        private void checkBoxMaleC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaleD.Checked == true)
                configD.sexM = "1";
            else
            {
                if (checkBoxFemaleD.Checked == false)
                {
                    checkBoxMaleD.Checked = true;
                    return;
                }
                else
                    configD.sexM = "0";
            }
            FillTableAdapter(DancerAdapterId);
        }

        private void checkBoxFemaleC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFemaleD.Checked == true)
                configD.sexF = "1";
            else
            {
                if (checkBoxMaleD.Checked == false)
                {
                    checkBoxFemaleD.Checked = true;
                    return;
                }
                else
                    configD.sexF = "0";
            }
            FillTableAdapter(DancerAdapterId);
        }

        private void comboBoxMinHeightС_TextChanged(object sender, EventArgs e)
        {
            configD.minHeight = Int32.Parse(comboBoxMinHeightD.Text);
            InitMaxHeightFilter();
            FillTableAdapter(DancerAdapterId);
        }

        private void comboBoxMaxHeightС_TextChanged(object sender, EventArgs e)
        {
            configD.maxHeight = Int32.Parse(comboBoxMaxHeightD.Text);
            InitMinHeightFilter();
            FillTableAdapter(DancerAdapterId);
        }

        private void comboBoxMinYearС_TextChanged(object sender, EventArgs e)
        {
            configD.minYear = Int32.Parse(comboBoxMinYearD.Text);
            InitMaxYearFilter();
            FillTableAdapter(DancerAdapterId);
        }


        private void comboBoxMaxYearС_TextChanged(object sender, EventArgs e)
        {
            configD.maxYear = Int32.Parse(comboBoxMaxYearD.Text);
            InitMinYearFilter();
            FillTableAdapter(DancerAdapterId);
        }

        private void DataGridViewС_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            EnableFiltersD(false);
        }

    }
}
