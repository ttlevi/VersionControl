﻿using System;
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

namespace ExcelExport
{
    public partial class Form1 : Form
    {
        RealEstateEntities context = new RealEstateEntities();
        List<Flat> flats;
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;

        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }

        void LoadData()
        {
            flats = context.Flats.ToList();
        }

        private void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;
                CreateTable();
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
            
        }

        private void CreateTable()
        {
            string[] headers = new string[]
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
            {
                xlSheet.Cells[1,i+1] = headers[i];
            }

            object[,] values = new object[flats.Count, headers.Length];

            int j = 0; //counter
            foreach (Flat f in flats)
            {
                values[j, 0] = f.Code;
                values[j, 1] = f.Vendor;
                values[j, 2] = f.Side;
                values[j, 3] = f.District;
                if (f.Elevator) { values[j, 4] = "Van"; } else { values[j, 4] = "Nincs"; };
                values[j, 5] = f.NumberOfRooms;
                values[j, 6] = f.FloorArea;
                values[j, 7] = f.Price;
                values[j, 8] = "";
                j++;
            }

            xlSheet.get_Range(  //adott range kitöltése
                GetCell(2, 1),  //innentől
                GetCell(1 + values.GetLength(0), values.GetLength(1))   //idáig
            ).Value = values;   //ezzel (a GetLength(i) egy tömb i. dimenziójának hosszát adja ki - itt 2d-s táblázat van 0. és 1. dimenzióval)

            for (int i = 0; i < values.GetLength(0); i++)
            {
                xlSheet.get_Range(
                    GetCell(2 + i, 9),
                    GetCell(2 + i, 9)
                ).Value = "=" + GetCell(2 + i, 8) + "/" + GetCell(2 + i, 7) + "*1000000";
            }
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
    }
}
