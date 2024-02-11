using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using GruppoOilPrototipo.view;
using DocumentFormat.OpenXml.Spreadsheet;

namespace GruppoOilPrototipo
{
    public class FileMenager
    {
        private string _nomeFile;
        private int _numeroMisurazioni;
        private string _nomeFoglio;
        XLWorkbook wb;
        private bool misurazioneAttiva;
        private Form1 form;
        private string _dataFile;
        private int misurazioniErrate;
        public int NumeroMisurazioni
        {
            get { return _numeroMisurazioni; }
            private set { _numeroMisurazioni = value; }

        }
        public string DataFile
        {
            get { return _dataFile; }
            private set { _dataFile = value; }
        }
        public FileMenager(Form1 form)
        {
            
            this.form = form;
            

        }
        /*private void nuovoFile()
        {
            DataFile = "";
            string[] tmp = DateTime.Now.ToString().Split(' ')[0].Split('/');
            DataFile = $"{tmp[0]}_{tmp[1]}_{tmp[2]}_";
            tmp = DateTime.Now.ToString().Split(' ')[1].Split(':');
            DataFile += $"{tmp[0]}.{tmp[1]}.{tmp[2]}";
            _nomeFile = "misurazioni" + DataFile + ".xlsx";
            _nomeFoglio = "Misurazioni";

        }*/
        public void AvviaMisurazione()
        {
           if (!misurazioneAttiva)
           {
                wb = new XLWorkbook($"./Misurazioni/template.xlsx");
                misurazioniErrate = 0;
                    //nuovoFile();
                    NumeroMisurazioni = 2;
                    misurazioneAttiva = true;
            }
            else throw new Exception("Misurazione già in corso");
        }
        public void Input(string line)
        {
            if (line != null)
            {
                if (line == "f") form.Stop();
                scriviAppend(_nomeFile, line);
                NumeroMisurazioni++;
                if (NumeroMisurazioni == SettingsMenager.MaxMisurazioni + 3 && SettingsMenager.MaxMisurazioni!=0) form.Stop();
            }
            else { throw new Exception("Valore nullo"); }
        }
        private void scriviAppend(string filename, string content)
        {
            
            var ws = wb.Worksheet("Misurazioni");
            try
                {
                    string orarioMisurazione = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "," + DateTime.Now.Millisecond.ToString();
                    ws.Cell("A" + NumeroMisurazioni).Value = content.Split(';')[0];
                    ws.Cell("B" + NumeroMisurazioni).Value = content.Split(';')[1];
                    ws.Cell("C" + NumeroMisurazioni).Value = orarioMisurazione;
                    content+= ";" + orarioMisurazione + ";";
                    form.OttieniMisurazione(content);
                }
                catch (Exception ex)
                {
                    NumeroMisurazioni--;
                    misurazioniErrate++;
                }
        }
        public void FineMisurazione()
        {
            // if (misurazioneAttiva== true)
            //{
            var wsInfo = wb.Worksheet("Info");
            wsInfo.Cell("A2").Value = SettingsMenager.NomeValvola;
            wsInfo.Cell("B2").Value = SettingsMenager.IDValvola;
            wsInfo.Cell("C2").Value = NumeroMisurazioni - 3;
            wsInfo.Cell("D2").Value = misurazioniErrate;
            wb.SaveAs($@"{AppDomain.CurrentDomain.BaseDirectory}Misurazioni\{SettingsMenager.IDValvola}-{SettingsMenager.NomeValvola}-{DataFile}.xlsx");
            StopMisurazione();
            //} else
            //{
                //throw new Exception("Misurazione non avviata");
          //  }
            
        }
        public void StopMisurazione()
        {
            misurazioneAttiva = false;
        }
    }
}
