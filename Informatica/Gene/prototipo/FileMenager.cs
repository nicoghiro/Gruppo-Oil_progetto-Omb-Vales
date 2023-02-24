using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace prototipo
{
    public class FileMenager
    {
        private string _nomeFile;
        private int _numeroMisurazioni;
        Excel.Application xApp;
        Excel.Workbook xWb;
        Excel.Worksheet xWs;
        private string _nomeFoglio;
        private bool misurazioneAttiva;
        public int NumeroMisurazioni
        {
            get { return _numeroMisurazioni; }
            private set { _numeroMisurazioni = value; }
        }
        public FileMenager()
        {
            string dataFile = "";
            string[] tmp = DateTime.Now.ToString().Split(' ')[0].Split('/');
            dataFile = $"{tmp[0]}_{tmp[1]}_{tmp[2]}_";
            tmp = DateTime.Now.ToString().Split(' ')[1].Split(':');
            dataFile += $"{tmp[0]}.{tmp[1]}.{tmp[2]}";
            _nomeFile = @"./misurazioni" + dataFile + ".xlsx";
            _nomeFoglio = "Foglio1";
        }
        public void AvviaMisurazione()
        {
            if (_nomeFile != null)
            {
                NumeroMisurazioni = 1;

                object misValue = System.Reflection.Missing.Value;

                // Avvia Excel.
                xApp = new Excel.Application();
                xApp.Visible = true;


                // Crea un Workbook.
                xApp.SheetsInNewWorkbook = 1;
                xWb = (Excel.Workbook)(xApp.Workbooks.Add(misValue));

                // Crea un Worksheet.
                xWs = (Excel.Worksheet)xWb.ActiveSheet;
                xWs.Name = _nomeFoglio;

                // Salva il file.
                xApp.Visible = false;
                xApp.UserControl = false;
                xWb.SaveAs(_nomeFile, Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xWs.Columns[1].ColumnWidth = 10;
                xWs.Columns[2].ColumnWidth = 10;
                xWs.Columns[3].ColumnWidth = 30;
                misurazioneAttiva = true;
            } else { throw new Exception("Classe non istanziata"); }
        }
        public void Input(string line)
        {
            scriviAppend(_nomeFile, line);

            NumeroMisurazioni++;
        }
        private void scriviAppend(string filename, string content)
        {

            xWs.Cells[NumeroMisurazioni, 1] = content.Split(';')[0];
            xWs.Cells[NumeroMisurazioni, 2] = content.Split(';')[1];
            xWs.Cells[NumeroMisurazioni, 3] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() ;
            xWb.Save();
        }
        public void FineMisurazione() 
        {
            xWb.Close();
            xApp.Quit();
            misurazioneAttiva = false;
        }
        public List<string> LeggiFile()
        {
            List<string> file = new List<string>();
            if (!misurazioneAttiva)
            { 
                
                xApp = new Excel.Application();
                xApp.Visible = true;
                xWb = (Excel.Workbook)(xApp.Workbooks.Add(_nomeFile));
                xWs = xWb.ActiveSheet;
                xApp.Visible = false;
                xApp.UserControl = false;
                xWs.Activate();
                
            }
            for (int i = 1; i < NumeroMisurazioni; i++)
            {
                file.Add(xWs.Cells[i, 1].Value + ";" + xWs.Cells[i, 2].Value + ";" + xWs.Cells[i, 3].Value + ";");
            }
            return file;
    }
    }
}
