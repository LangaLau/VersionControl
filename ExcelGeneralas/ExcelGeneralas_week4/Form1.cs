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
        private int millionValtozo = (int)Math.Pow(10, 6);

        RealEstateEntities context = new RealEstateEntities();      //példányosítás!
        List<Flat> flats;                                           //mi az hogy nem kell inicializálni? 

        Excel.Application xlApp;             // A Microsoft Excel alkalmazás
        Excel.Workbook xlWB;                 // A létrehozott munkafüzet
        Excel.Worksheet xlSheet;             // Munkalap a munkafüzeten belül

        string[] headers;

        public Form1()
        {
            InitializeComponent();

            LoadData();
            dataGridView1.DataSource = flats;
            CreatExcel();
        }

        public void LoadData()     //adatok átmásolása memóriába adattárból
        {
            flats = context.Flats.ToList();
        }
        public void CreatExcel()
        {
            try
            {
                xlApp = new Excel.Application();                // Excel elindítása, applikáció objektum betöltése                               
                xlWB = xlApp.Workbooks.Add(Missing.Value);      // Új munkafüzet        //Missing:Value?
                xlSheet = xlWB.ActiveSheet;                     //uj sheet

                CreatTable();
                FormatTable();

                xlApp.Visible = true;                              // Control átadása a felhasználónak
                xlApp.UserControl = true;
            }
            catch (Exception ex)                                 // Hibakezelés a beépített hibaüzenettel
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
        private void CreatTable()
        {
            headers = new string[]     //Flat fejlécei
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

            for (int i = 0; i < headers.Length; i++)
                xlSheet.Cells[1, i + 1] = headers[i];

            object[,] storeValues = new object[flats.Count, headers.Length];   //object 2 dimenziós változó

            int counter = 0;
            int floorArea = 6;

            foreach (Flat f in flats)
            {
                storeValues[counter, 0] = f.Code;
                storeValues[counter, 1] = f.Vendor;
                storeValues[counter, 2] = f.Side;
                storeValues[counter, 3] = f.District;
                storeValues[counter, 4] = f.Elevator ?
                    "Van" :
                    "Nincs";
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

        private void FormatTable()
        {
            int lastRowID = xlSheet.UsedRange.Rows.Count;
            int másodiksor = 2;
            //(1;A)         (1; A-tól szélleség)
            Excel.Range headerRange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, headers.Length));         //fejléc meg határozása
            headerRange.Font.Bold = true;                                                                   //félkövér
            headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;                                  //függöleges igazítása
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;                                //vizszintes igazítása
            headerRange.WrapText = true;
            headerRange.EntireColumn.AutoFit();                                                             //szélleség
            headerRange.RowHeight = 40;
            headerRange.Interior.Color = Color.LightBlue;
            headerRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);        //cella magasság, hátérszín, keret

            //(A;A)         (A; szélleség)
            Excel.Range tableRange = xlSheet.get_Range(GetCell(1, 1), GetCell(lastRowID, headers.Length));
            tableRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium);        //Az egész táblának is legyen olyan körbe szegélye, mint a fejlécnek
                                                                                                            //(2;A)         (150; A)
            Excel.Range firstColRange = xlSheet.get_Range(GetCell(másodiksor, 1), GetCell(lastRowID, 1));            //Az első oszlop adatai legyenek félkövérek és a háttér legyen halvány sárga
            firstColRange.Font.Bold = true;
            firstColRange.Interior.Color = Color.LightYellow;
            //(2;9)      (150; szélleség)
            Excel.Range lastColRange = xlSheet.get_Range(GetCell(másodiksor, headers.Length), GetCell(lastRowID, headers.Length));             //Az utolsó oszlop adatainak háttere legyen halványzöld.          
            lastColRange.Interior.Color = Color.LightGreen;
            lastColRange.ColumnWidth = 15;
            //lastColRange.NumberFormat = true;

            //Az utolsó oszlop adatai két tizedesre kerekített formában jelenjenek meg?

        }

    }
}

