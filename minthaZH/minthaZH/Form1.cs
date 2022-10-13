using minthaZH.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace minthaZH
{
    //Year,Host_country,Host_city,Country_Name,Country_Code,Gold,Silver,Bronze
    //0   ,1          ,2         ,3            ,4          ,5             ,6
    public partial class Form1 : Form
    {
        List<OlympicResults> results = new List<OlympicResults>();
        Excel.Application xlApp;
        Excel.Workbook xlWb;
        Excel.Worksheet xlSheet;

        public Form1()
        {
            InitializeComponent();

            LoadData("Summer_olympic_Medals.csv");
            LoadYear();
            Position();
        }

        private void LoadData(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                var fejléc = sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine().Split(',');
                    var olympicResults = new OlympicResults()
                    {
                        Country = sor[3],
                        Medals = new int[]
                        {
                           int.Parse(sor[5]),
                           int.Parse( sor[6]),
                           int.Parse( sor[7])
                        },
                        Year = int.Parse(sor[0])
                    };
                    results.Add(olympicResults);
                }
            }
        }
        private void LoadYear()
        {
            var year = (from y in results
                        orderby y.Year
                        select y.Year).Distinct();
            cmbYear.DataSource = year.ToList();
        }

        private int Sorrend(OlympicResults olympicResults)
        {
            int counter = 0;
            var első = from e in results
                       where e.Year == olympicResults.Year && e.Country != olympicResults.Country
                       select e;


            foreach (var adottsor in első)
            {
                if (adottsor.Medals[0] > olympicResults.Medals[0])
                    counter++;
                else if ((adottsor.Medals[0] == olympicResults.Medals[0]) && (adottsor.Medals[1] > olympicResults.Medals[1]))
                    counter++;
                else if ((adottsor.Medals[0] == olympicResults.Medals[0]) && (adottsor.Medals[1] == olympicResults.Medals[1]) && (adottsor.Medals[2] > olympicResults.Medals[2]))
                    counter++;
            }
            return counter + 1;
        }

        private void Position()
        {
            foreach (var item in results)
            {
                item.Position = Sorrend(item);
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelExport();
        }
        private void ExcelExport()
        {
            try
            {
                xlApp = new Excel.Application();
                xlWb = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWb.ActiveSheet;

                LoadExcel();

                xlApp.Visible = true;
                xlApp.UserControl = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error:");
                xlWb.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWb = null;
                xlApp = null;
            }
        }

        private void LoadExcel()
        {
            var fejléc = new string[]
            {
                "Helyezés",
                "Ország",
                "Arany",
                "Ezüst",
                "Bronz"
            };
            for (int i = 0; i < fejléc.Length; i++)
                xlSheet.Cells[1, 1 + i] = fejléc[i];

            var választottYear = from v in results
                                 where v.Year == (int)cmbYear.SelectedItem
                                 orderby v.Position
                                 select v;

            var counter = 2;
            foreach (var item in választottYear)
            {
                xlSheet.Cells[counter, 1] = item.Position;
                xlSheet.Cells[counter, 2] = item.Country;
                xlSheet.Cells[counter, 3] = item.Medals;
                xlSheet.Cells[counter, 4] = item.Medals[1];
                xlSheet.Cells[counter, 5] = item.Medals[2];
                counter++;
            }
        }

    }
}

