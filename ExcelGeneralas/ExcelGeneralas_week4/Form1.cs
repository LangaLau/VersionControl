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

        private int millionValtozo = (int)Math.Pow(10, 6);
        public Form1()
        {
            InitializeComponent();

            LoadData();
            CreatExcel();
        }
        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
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

                CreatTable();

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

        private void CreatTable()
        {
            string[] headers = new string[]     //Flat fejlécei
            {
                 "Kód",
                "Eladó",
                "Oldal",
                "Kerület",
                "Lift",
                "Szobák száma",
                "Alapterület (m2)",
                "Ár (mFt)",
                "Négyzetméter ár (Ft/m2)"
            };
            object[,] storeValues = new object[flats.Count(), headers.Length];   //object 2 dimenziós változó

            int counter = 0;
            int floorArea = 6;

            foreach (Flat f in flats)
            {
                storeValues[counter, 0] = f.Code;
                storeValues[counter, 1] = f.Vendor;
                storeValues[counter, 2] = f.Side;
                storeValues[counter, 3] = f.District;
                storeValues[counter, 4] = f.Elevator ?
                    "Van" : "Nincs";
                storeValues[counter, 5] = f.NumberOfRooms;
                storeValues[counter, 6] = f.FloorArea;
                storeValues[counter, 7] = f.Price;
                storeValues[counter, 8] = string.Format("={0}/{1}*{2}",
                    "H" + (counter + 2).ToString(),
                    GetCell(counter + 2, floorArea + 1),
                    millionValtozo.ToString());
                counter++;
            }

            var range = xlSheet.get_Range(
                GetCell(2, 1),
                GetCell(1 + storeValues.GetLength(0), storeValues.GetLength(1)));

            range.Value2 = storeValues;
        }
    }
}

