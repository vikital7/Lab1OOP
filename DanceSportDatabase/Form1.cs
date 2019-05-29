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
    public partial class MainForm : Form
    {
        DancerConfiguration configD = new DancerConfiguration();
        CoupleConfiguration configС = new CoupleConfiguration();
        const int AdaptersCount = 5;
        const int DancerAdapterId = 1, CoupleAdapterId = 2, ClubAdapterId = 3, TrainerAdapterId = 4, DirectorAdapterId = 5;

        public MainForm()
        {
            InitializeComponent();
            InitFiltersD();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillAllTableAdapters();
            EnableFiltersD(true);
        }
        

        public void FillAllTableAdapters()
        {
            for (int id=1; id <= AdaptersCount; id++)
                FillTableAdapter(id);
        }

        public void FillTableAdapter(int id)
        {
            switch (id)
            {
                case 1: //Fill Dancer TableAdapter
                    string minName = configD.name, maxName = configD.name + "ЯЯ";
                    this.dANCERTableAdapter.Fill(this.danceSportDataSet.DANCER, minName, maxName, configD.sexM, configD.sexF,
                        configD.minHeight, configD.maxHeight, configD.minYear, configD.maxYear,
                        configD.minClassLat, configD.maxClassLat, configD.minClassSt, configD.maxClassSt);
                    for (int i = 1; i < DataGridViewD.RowCount; i++)
                        DataGridViewD.Rows[i-1].HeaderCell.Value = i.ToString();
                    EnableFiltersD(true);
                    break;
                case 2: //Fill Couple TableAdapter
                    string minNameM = configС.nameM, maxNameM = configС.nameM + "ЯЯ";
                    string minNameF = configС.nameF, maxNameF = configС.nameF + "ЯЯ";

                    //this.cOUPLETableAdapter.Fill(this.danceSportDataSet.COUPLE);
                    this.cOUPLETableAdapter.Fill(this.danceSportDataSet.COUPLE, minNameM, maxNameM, minNameF, maxNameF);
                    //this.cOUPLETableAdapter.Fill(this.danceSportDataSet.COUPLE, minNameM, maxNameM, minNameF, maxNameF,
                    //    configС.minYear, configС.maxYear, configС.minClassLat, configС.maxClassLat, configС.minClassSt, configС.maxClassSt,
                    //    configС.minRating, configС.maxRating);
                    //FillCoupleExtraData();
                    break;
                case 3: //Fill Club TableAdapter
                    this.cLUBTableAdapter.Fill(this.danceSportDataSet.CLUB);
                    break;
                case 4: //Fill Trainer TableAdapter
                    this.tRAINERTableAdapter.Fill(this.danceSportDataSet.TRAINER);
                    break;
                case 5: //Fill Director TableAdapter
                    this.dIRECTORTableAdapter.Fill(this.danceSportDataSet.DIRECTOR);
                    break;
                default:
                    throw new Exception("FillTableAdapter with id=" + id + " does not exist.");
            }
        }
        

        public void FillCoupleExtraData()
        {
            for (int i=0; i<DataGridViewC.Rows.Count-1; i++)
            {
                int year1 = Int32.Parse(DataGridViewC[9, i].FormattedValue.ToString());
                int year2 = Int32.Parse(DataGridViewC[10, i].FormattedValue.ToString());
                string year = Math.Min(year1, year2).ToString();
                DataGridViewC[2, i].Value = year;
                DataGridViewC.NotifyCurrentCellDirty(true);

                string lat1 = DataGridViewC[11, i].FormattedValue.ToString();
                string lat2 = DataGridViewC[12, i].FormattedValue.ToString();
                string lat;
                if (lat1 == "S" || lat2 == "S") lat = "S";
                else if (string.Compare(lat1, lat2) == -1) lat = lat1;
                else lat = lat2;
                DataGridViewC[3, i].Value = lat;
                DataGridViewC.NotifyCurrentCellDirty(true);

                string st1 = DataGridViewC[13, i].FormattedValue.ToString();
                string st2 = DataGridViewC[14, i].FormattedValue.ToString();
                string st;
                if (st1 == "S" || st2 == "S") st = "S";
                else if (string.Compare(st1, st2) == -1) st = st1;
                else st = st2;
                DataGridViewC[4, i].Value = st;
                DataGridViewC.NotifyCurrentCellDirty(true);
                                       
            }
        }

        private void textBoxNameMaleC_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNameFemaleC_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMinYearC_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void MaxYearComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void MinRatingComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void MaxRatingComboBox5_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void MinLatComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void MaxLatComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void MinStComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void MaxStComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void DataGridViewD_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        //private void ResetFilterButtonD_Click(object sender, EventArgs e)
        //{

        //}

        private void TryDeleteCurrentDancer()
        {
            int id = (int)DataGridViewD.CurrentRow.Cells["iDDataGridViewTextBoxColumn"].Value;
            int c_count = Int32.Parse(cOUPLETableAdapter.CouplesCountByDancerId(id).ToString());
            if (c_count > 0)
                throw new Exception("Цей танцор має танцювальну пару (" + c_count.ToString() + "). Видаліть її спочатку.");
            else
                dANCERBindingSource.RemoveCurrent();
        }
        

        private bool IsValidDataD(int columnIndex, string value, out string error)
        {
            int number;
            bool isNumber = Int32.TryParse(value, out number);
            switch (columnIndex){
                case 2: //Name
                    break;
                case 3: //Surname
                    break;
                case 5: //Height

                    if (isNumber == false)
                    {
                        error = "Це має бути ціле додатнє число!";
                        return false;
                    }
                    else if (number <= 0)
                    {
                        error = "А буває недодатній зріст? o_O";
                        return false;
                    }
                    else if (number >= 272)
                    {
                        error = "Найвища людина у світі мала зріст 272 см, ви шо? )";
                        return false;
                    }
                    else if (number <= 99)
                    {
                        error = "Занадто малий зріст. Ну ріл)";
                        return false;
                    }
                    else break;
                case 8: //Year
                    if (isNumber == false)
                    {
                        error = "Це має бути ціле додатнє число!";
                        return false;
                    }
                    else if (number <= 0)
                    {
                        error = "Додатнє число! o_O";
                        return false;
                    }
                    else if (number >= 2020)
                    {
                        error = "Зараз: " + DateTime.Now.Date.ToShortDateString() + ". Мабуть " + number + " - це забагато як для року народження)";
                        return false;
                    }
                    else if (number <= 1900)
                    {
                        error = "Занадто мало.";
                        return false;
                    }
                    else if (number >= DateTime.Now.Year - 3)
                    {
                        error = "Дітям видають кваліфікаційні книжки з 4 років, тому хай ще підростуть:)";
                        return false;
                    }
                    else break;
                default:
                    break;
            }
            error = "";
            return true;
        }
        

        private void ShowErrorD(string message)
        {
            ErrorLabelD.Text = message;
        }
        private void HideErrorD()
        {
            ErrorLabelD.Text = "";
        }

        
    }
}
