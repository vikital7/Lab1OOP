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

        private void DeleteButtonC_Click(object sender, EventArgs e)
        {
            EnableFiltersD(false);
            cOUPLEBindingSource.RemoveCurrent();

        }
        private void SaveButtonC_Click(object sender, EventArgs e)
        {
            cOUPLETableAdapter.Update(this.danceSportDataSet.COUPLE);
           cOUPLETableAdapter. 
            FillTableAdapter(CoupleAdapterId);
        }


        private void ResetButtonC_Click(object sender, EventArgs e)
        {
            FillTableAdapter(DancerAdapterId);
        }

        private void ResetFilterButtonC_Click(object sender, EventArgs e)
        {
            InitFiltersD();
        }







        private void textBoxNameMaleC_TextChanged(object sender, EventArgs e)
        {
            configС.nameM = textBoxNameMC.Text;
            FillTableAdapter(CoupleAdapterId);
        }

        private void textBoxNameFemaleC_TextChanged(object sender, EventArgs e)
        {
            configС.nameF = textBoxNameFC.Text;
            FillTableAdapter(CoupleAdapterId);
        }

        private void comboBoxMinLatC_SelectedValueChanged(object sender, EventArgs e)
        {
            configС.minClassLat = comboBoxMinClassLatC.Text;
            FillTableAdapter(CoupleAdapterId);
        }

        private void comboBoxMaxLatC_SelectedValueChanged(object sender, EventArgs e)
        {
            configС.maxClassLat = comboBoxMaxClassLatC.Text;
            FillTableAdapter(CoupleAdapterId);
        }

        private void comboBoxMinStC_SelectedValueChanged(object sender, EventArgs e)
        {
            configС.minClassSt = comboBoxMinClassStC.Text;
            FillTableAdapter(CoupleAdapterId);
        }

        private void comboBoxMaxStC_SelectedValueChanged(object sender, EventArgs e)
        {
            configС.maxClassSt = comboBoxMaxClassStC.Text;
            FillTableAdapter(CoupleAdapterId);
        }


        

        
        


        private void comboBoxMinYearC_SelectedValueChanged(object sender, EventArgs e)
        {
            configС.minYear = Int32.Parse(comboBoxMinYearC.Text);
            InitMaxYearFilter();
            FillTableAdapter(CoupleAdapterId);
        }


        private void comboBoxMaxYearC_SelectedValueChanged(object sender, EventArgs e)
        {
            configС.maxYear = Int32.Parse(comboBoxMaxYearC.Text);
            InitMinYearFilter();
            FillTableAdapter(CoupleAdapterId);
        }

        private void DataGridViewC_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            EnableFiltersD(false);
            UpdateDetailsC();
        }


        private void comboBoxMinRatingС_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMaxRatingС_SelectedValueChanged(object sender, EventArgs e)
        {

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

        //-------------






        //-----------------------


        



        

        

        

    }
}
