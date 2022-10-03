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

namespace ExcelGeneralas_week4
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();      //példányosítás!
        List<Flat> flats;                                           //mi az hogy nem kell inicializálni? 
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()     //adatok átmásolása memóriába adattárból
        {
            flats = context.Flats.ToList();
        }
    }
}
