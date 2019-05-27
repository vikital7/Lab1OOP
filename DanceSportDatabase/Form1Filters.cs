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
    }
}
