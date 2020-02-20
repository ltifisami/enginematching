using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enginematching
{
    public class ExcelOperation
    {
        private Excel.Workbook MyBook { get; set; }
        private Excel.Application MyApp { get; set; }
        private Excel.Worksheet MySheet { get; set; }
        private int lastRow { get; set; }
        public ExcelOperation()
        {
            MyApp = new Excel.Application();
            MyApp.Visible = true;
            MyBook = MyApp.Workbooks.Add();
            MySheet = (Microsoft.Office.Interop.Excel.Worksheet)MyBook.Worksheets.Add();
            MySheet.Name = "Liste des devises";
            lastRow = MySheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
        }
       /* public void wirteToExcel(CurrencyRates cur, string name)
        {
            lastRow += 1;
            MySheet.Cells[lastRow, 1] = cur.Base;
            MySheet.Cells[lastRow, 2] = cur.Disclaimer;
            MySheet.Cells[lastRow, 3] = cur.FomatTimeStamp();
            lastRow += 2;
            foreach (var dic in cur.Rates)
            {
                MySheet.Cells[lastRow, 1] = dic.Key;
                MySheet.Cells[lastRow, 2] = dic.Value;
                lastRow += 1;
            }
            MyBook.SaveAs(name);
        }*/
    }


}