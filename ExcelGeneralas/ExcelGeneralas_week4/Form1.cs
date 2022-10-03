using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;   //()alias       fájlba behivatkozás 
using System.Reflection;                 //(technikai könyvtár) de az Objektumot is há kell adni, Add/References.../Excel

namespace ExcelGeneralas_week4
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();      //példányosítás!
        List<Flat> flats;                                           //mi az hogy nem kell inicializálni? 

        Excel.Application xlApp;             // A Microsoft Excel alkalmazás
        Excel.Workbook xlWB;                 // A létrehozott munkafüzet
        Excel.Worksheet xlSheet;             // Munkalap a munkafüzeten belül
        public Form1()
        {
            InitializeComponent();

            LoadData();
            CreatExcel();
        }

        private void CreatExcel()
        {
            try
            {
                // Excel elindítása, applikáció objektum betöltése
                xlApp = new Excel.Application();

                // Új munkafüzet
                xlWB = xlApp.Workbooks.Add(Missing.Value);      //Missing:Value?

                // Új munkalap
                xlSheet = xlWB.ActiveSheet;

                // Control átadása a felhasználónak
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex) // Hibakezelés a beépített hibaüzenettel
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                // Hiba esetén az Excel applikáció bezárása automatikusan
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        private void LoadData()     //adatok átmásolása memóriába adattárból
        {
            flats = context.Flats.ToList();
        }
    }
}
