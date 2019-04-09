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
        string oldValue = "";
        int changesCount = 0;
        public MainForm()
        {
            InitializeComponent();
            InitFiltersD();
            int a = 0;
        }

        public void FillDancerTableAdapter()
        {
            string minName = configD.name, maxName = configD.name + "ЯЯ";
            this.dANCERTableAdapter.Fill(this.danceSportDataSet.DANCER, minName, maxName, configD.sexM, configD.sexF,
                configD.minHeight, configD.maxHeight, configD.minYear, configD.maxYear, 
                configD.minClassLat, configD.maxClassLat, configD.minClassSt, configD.maxClassSt);
            this.dANCERTableAdapter.Fill(this.danceSportDataSet3.DANCER, minName, maxName, configD.sexM, configD.sexF,
                configD.minHeight, configD.maxHeight, configD.minYear, configD.maxYear,
                configD.minClassLat, configD.maxClassLat, configD.minClassSt, configD.maxClassSt);

        }

        public void FillCoupleTableAdapter()
        {
            this.cOUPLETableAdapter.Fill(this.danceSportDataSet1.COUPLE);
            FillCoupleExtraData();
        }


        public void FillCoupleExtraData()
        {
            for (int i=0; i<DataGridViewC.Rows.Count-1; i++)
            {
                //DataGridViewC.Rows[i].Cells[8].Value = DataGridViewC.Rows[i].Cells[9].Value.ToString() + " " +
                //                                        DataGridViewC.Rows[i].Cells[10].Value.ToString();
                //Console.WriteLine("Set: {0}", DataGridViewC.Rows[i].Cells[9].Value.ToString() + " " +
                //                                        DataGridViewC.Rows[i].Cells[10].Value.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'danceSportDataSet3.COUPLE' table. You can move, or remove it, as needed.
            this.cOUPLETableAdapter.Fill(this.danceSportDataSet3.COUPLE);
            // TODO: This line of code loads data into the 'danceSportDataSet2.COUPLE2' table. You can move, or remove it, as needed.
            //this.cOUPLE2TableAdapter.Fill(this.danceSportDataSet2.COUPLE2);
            // TODO: This line of code loads data into the 'danceSportDataSet.COUPLE2' table. You can move, or remove it, as needed.
            //this.cOUPLE2TableAdapter.Fill(this.danceSportDataSet.COUPLE2);
            // TODO: This line of code loads data into the 'danceSportDataSet1.TRAINER' table. You can move, or remove it, as needed.
            this.tRAINERTableAdapter.Fill(this.danceSportDataSet1.TRAINER);
            // TODO: This line of code loads data into the 'danceSportDataSet1.COUPLE' table. You can move, or remove it, as needed.
            this.cOUPLETableAdapter.Fill(this.danceSportDataSet1.COUPLE);
            // TODO: This line of code loads data into the 'danceSportDataSet1.CLUB' table. You can move, or remove it, as needed.
            this.cLUBTableAdapter.Fill(this.danceSportDataSet1.CLUB);
            // TODO: This line of code loads data into the 'danceSportDataSet1.DIRECTOR' table. You can move, or remove it, as needed.
            this.dIRECTORTableAdapter.Fill(this.danceSportDataSet1.DIRECTOR);
            // TODO: This line of code loads data into the 'danceSportDataSet.DANCER' table. You can move, or remove it, as needed.
            FillDancerTableAdapter();
            FillCoupleTableAdapter();
            EnableFiltersD(true);
            Console.WriteLine(DataGridViewC.Rows[0].Cells[5].Value);

        }

        
        private void InitFiltersD()
        {
            textBoxNameD.Text = "";
            comboBoxMinClassLatD.Text = "H";
            comboBoxMaxClassLatD.Text = "S";
            comboBoxMinClassStD.Text = "H";
            comboBoxMaxClassStD.Text = "S";
            checkBoxMaleD.Checked = true;
            checkBoxFemaleD.Checked = true;

            InitMinHeightFilter();
            InitMaxHeightFilter();
            comboBoxMinHeightD.Text = "100";
            comboBoxMaxHeightD.Text = "270";

            InitMinYearFilter();
            InitMaxYearFilter();
            comboBoxMinYearD.Text = "1900";
            comboBoxMaxYearD.Text = "2019";
        }

        private void InitMinHeightFilter()
        {
            string maxHeightStr = comboBoxMaxHeightD.Text;
            if (maxHeightStr == "") maxHeightStr = "270";
            int maxHeight = Int32.Parse(maxHeightStr);

            int lastItem;
            int count = comboBoxMinHeightD.Items.Count;
            if (count == 0)
                lastItem = 99;
            else
            {
                string lastItemStr = comboBoxMinHeightD.Items[count - 1].ToString();
                lastItem = Int32.Parse(lastItemStr);
            }

           
            if (lastItem < maxHeight)
            {
                for (int i = lastItem + 1; i <= maxHeight; i++)
                    comboBoxMinHeightD.Items.Add(i);
            }
            if (lastItem > maxHeight)
            {
                for (int i = count - 1; i > count - 1 - lastItem + maxHeight; i--)
                    comboBoxMinHeightD.Items.RemoveAt(i);
            }
        }

        private void InitMaxHeightFilter()
        {
            string minHeightStr = comboBoxMinHeightD.Text;
            if (minHeightStr == "") minHeightStr = "100";
            int minHeight = Int32.Parse(minHeightStr);

            int firstItem;
            int count = comboBoxMaxHeightD.Items.Count;
            if (count == 0)
            {
                firstItem = 271;
            }
            else
            {
                string firstItemStr = comboBoxMaxHeightD.Items[0].ToString();
                firstItem = Int32.Parse(firstItemStr);
            }

            if (firstItem > minHeight)
            {
                for (int i = firstItem - 1; i >= minHeight; i--)
                    comboBoxMaxHeightD.Items.Insert(0, i);
            }
            if (firstItem < minHeight)
            {
                for (int i = firstItem; i < minHeight; i++)
                    comboBoxMaxHeightD.Items.RemoveAt(0);
            }
        }

        private void InitMinYearFilter()
        {
            string maxYearStr = comboBoxMaxYearD.Text;
            if (maxYearStr == "") maxYearStr = "2019";
            int maxYear = Int32.Parse(maxYearStr);

            int lastItem;
            int count = comboBoxMinYearD.Items.Count;
            if (count == 0)
                lastItem = 1899;
            else
            {
                string lastItemStr = comboBoxMinYearD.Items[count - 1].ToString();
                lastItem = Int32.Parse(lastItemStr);
            }


            if (lastItem < maxYear)
            {
                for (int i = lastItem + 1; i <= maxYear; i++)
                    comboBoxMinYearD.Items.Add(i);
            }
            if (lastItem > maxYear)
            {
                for (int i = count - 1; i > count - 1 - lastItem + maxYear; i--)
                    comboBoxMinYearD.Items.RemoveAt(i);
            }
        }

        private void InitMaxYearFilter()
        {
            string minYearStr = comboBoxMinYearD.Text;
            if (minYearStr == "") minYearStr = "1900";
            int minYear = Int32.Parse(minYearStr);

            int firstItem;
            int count = comboBoxMaxYearD.Items.Count;
            if (count == 0)
            {
                firstItem = 2020;
            }
            else
            {
                string firstItemStr = comboBoxMaxYearD.Items[0].ToString();
                firstItem = Int32.Parse(firstItemStr);
            }

            if (firstItem > minYear)
            {
                for (int i = firstItem - 1; i >= minYear; i--)
                    comboBoxMaxYearD.Items.Insert(0, i);
            }
            if (firstItem < minYear)
            {
                for (int i = firstItem; i < minYear; i++)
                    comboBoxMaxYearD.Items.RemoveAt(0);
            }
        }

        private void EnableFiltersD(bool mode)
        {

            textBoxNameD.Enabled = mode;
            comboBoxMinHeightD.Enabled = mode;
            comboBoxMaxHeightD.Enabled = mode;
            comboBoxMinYearD.Enabled = mode;
            comboBoxMaxYearD.Enabled = mode;
            checkBoxMaleD.Enabled = mode;
            checkBoxFemaleD.Enabled = mode;
            comboBoxMinClassLatD.Enabled = mode;
            comboBoxMaxClassLatD.Enabled = mode;
            comboBoxMinClassStD.Enabled = mode;
            comboBoxMaxClassStD.Enabled = mode;
            ResetFilterButtonD.Enabled = mode;

            SaveButtonD.Enabled = !mode;
            ResetButtonD.Enabled = !mode;

        }

        private void TryDeleteCurrentDancer()
        {
            int id = (int)DataGridViewD.CurrentRow.Cells["iDDataGridViewTextBoxColumn"].Value;
            //global::System.Nullable<int> c_count = dANCERTableAdapter.ExistingCouplesCount(id);
            int c_count = Int32.Parse(dANCERTableAdapter.ExistingCouplesCount(id).ToString());
            if (c_count > 0)
                throw new Exception("This dancers has " + c_count.ToString() + " couple(s).");
            dANCER2BindingSource.RemoveCurrent();
        }

        private void DeleteButtonD_Click(object sender, EventArgs e)
        {
            EnableFiltersD(false);
            try
            {
                TryDeleteCurrentDancer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dancer delete unsuccessful");
            }

        }
        private void textBoxNameD_TextChanged(object sender, EventArgs e)
        {
            configD.name = textBoxNameD.Text;
            FillDancerTableAdapter();
        }

        private void comboBoxMinClassLatD_TextChanged(object sender, EventArgs e)
        {
            configD.minClassLat = comboBoxMinClassLatD.Text;
            FillDancerTableAdapter();
        }

        private void comboBoxMaxClassLatD_SelectedIndexChanged(object sender, EventArgs e)
        {
            configD.maxClassLat = comboBoxMaxClassLatD.Text;
            FillDancerTableAdapter();
        }

        private void SaveButtonD_Click(object sender, EventArgs e)
        {
            EnableFiltersD(true);
            dANCERTableAdapter.Update(this.danceSportDataSet.DANCER);   FillDancerTableAdapter();
        }

        private void ResetButtonD_Click(object sender, EventArgs e)
        {
            EnableFiltersD(true);
            FillDancerTableAdapter();
        }

        private void ResetFilterButtonD_Click(object sender, EventArgs e)
        {
            InitFiltersD();
        }

        

        private bool HasMistakesD(int c, int r)
        {
            return false;
        }

        private string GetOriginalValueD(int c, int r)
        {
            //DanceSportDataSet.DANCERRow[0].ToString;
            //dANCERTableAdapter.GetData
            return "";
        }
        private void DataGridViewD_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Console.Write("BE ");

            EnableFiltersD(false);
            oldValue = DataGridViewD[e.ColumnIndex, e.RowIndex].Value.ToString();
            Console.WriteLine("OV:{0} ", oldValue);
        }
        private void DataGridViewD_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Console.Write("EE ");
        }
        
        private void DataGridViewD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            EnableFiltersD(false);
            Console.Write("SV ");
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

        private void ShowErrorD(string message)
        {
            ErrorLabelD.Text = message;
        }

        private void HideErrorD()
        {
            ErrorLabelD.Text = "";
        }

        private void checkBoxMaleD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMaleD.Checked == true)
                configD.sexM = "1";
            else{
                if (checkBoxFemaleD.Checked == false)
                {
                    checkBoxMaleD.Checked = true;
                    return;
                }
                else
                    configD.sexM = "0";
            }
            FillDancerTableAdapter();
        }

        private void checkBoxFemaleD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFemaleD.Checked == true)
                configD.sexF = "1";
            else{ 
                if (checkBoxMaleD.Checked == false){
                    checkBoxFemaleD.Checked = true;
                    return;
                }
                else
                    configD.sexF = "0";
            }
            FillDancerTableAdapter();
        }

        private void comboBoxMinHeightD_TextChanged(object sender, EventArgs e)
        {
            configD.minHeight = Int32.Parse(comboBoxMinHeightD.Text);
            InitMaxHeightFilter();
            FillDancerTableAdapter();
        }

        private void comboBoxMaxHeightD_TextChanged(object sender, EventArgs e)
        {
            configD.maxHeight = Int32.Parse(comboBoxMaxHeightD.Text);
            InitMinHeightFilter();
            FillDancerTableAdapter();
        }

        private void comboBoxMinYearD_TextChanged(object sender, EventArgs e)
        {
            configD.minYear = Int32.Parse(comboBoxMinYearD.Text);
            InitMaxYearFilter();
            FillDancerTableAdapter();
        }

        private void comboBoxMaxYearD_TextChanged(object sender, EventArgs e)
        {
            configD.maxYear = Int32.Parse(comboBoxMaxYearD.Text);
            InitMinYearFilter();
            FillDancerTableAdapter();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void DeleteButtonC_Click(object sender, EventArgs e)
        {

        }

        private void SaveButtonC_Click(object sender, EventArgs e)
        {
            //EnableFiltersD(true);
            cOUPLETableAdapter.Update(this.danceSportDataSet1.COUPLE);
            FillCoupleTableAdapter();
        }

        private void ResetButtonC_Click(object sender, EventArgs e)
        {
            //EnableFiltersD(true);
            FillCoupleTableAdapter();
        }

        private void ResetFilterButtonC_Click(object sender, EventArgs e)
        {
            //InitFiltersD();
        }
    }
}
