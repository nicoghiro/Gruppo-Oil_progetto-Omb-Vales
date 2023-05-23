using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GruppoOilPrototipo.view
{
    public class SettingsMenager
    {
        static private string _portaAttuale;
        static private int _maxMisurazioni;
        static private string _nome;
        static private string _id;
        private string _filePathPorta;
        private string _filePathMax;
        private string _filePathNome;
        private string _filePathId;
        static private Form1 _form;
        public static Form1 Form
        {
            get { return _form; }
            set
            {
                if (value != null)
                {
                    _form = value;
                }
            }
        }
        public string FilePathNome
        {
            get { return _filePathNome; }
            private set { _filePathNome = value; }
        }
        public string FilePathId
        {
            get { return _filePathId; }
            private set { _filePathId = value; }
        }
        public string FilePathPorta
        {
            get { return _filePathPorta; }
            private set { _filePathPorta = value; }
        }
        public string FilePathMax
        {
            get { return _filePathMax; }
            private set { _filePathMax = value; }
        }
        public SettingsMenager()
        {
            FilePathMax= Path.Combine(Application.StartupPath, "Impostazioni", "MaxMisurazioni.config");
            FilePathPorta= Path.Combine(Application.StartupPath, "Impostazioni", "Porta.config");
            FilePathId = Path.Combine(Application.StartupPath, "impostazioni", "Id.config");
            FilePathNome = Path.Combine(Application.StartupPath, "impostazioni", "Nome.config");
        }
        public static string Nome
        {
            get
            {
                if (_nome == null)
                {
                    return "defaul name";
                }
                else
                    return _nome;
            }
            private set { _nome = value; }
        }
        public static string Id
        {
            get
            {
                if (_id == null)
                {
                    return "defaul id";
                }
                else
                    return _id;
            }
            private set { _id = value; }
        }

        public static string Porta
        {
            get { if (_portaAttuale == null)
                {
                    return "COM5";
                } else 
                return _portaAttuale; }
            private set { _portaAttuale = value; }
        }
        public static int MaxMisurazioni
        {
            get { if(_maxMisurazioni==null)
                    return 100;
                    else return _maxMisurazioni; }
            private set {_maxMisurazioni = value; }
        }
        private void Scrivi(string port, string filePath)
        {

            File.Delete(filePath);
            StreamWriter sw = new StreamWriter(filePath);
            sw.Write(port);
            sw.Close();
        }
        public void SetNome(string nome)
        {
            nome = nome.Trim();
            if (nome=="")
            {
                throw new Exception("Nome non valido");
            }
            Scrivi(nome, FilePathNome);
            Nome = nome;
            if (Form != null)
            {
                Form.VisualizzaImpostazioni();
            }
        }
        public void SetId(string id)
        {
            id = id.Trim();
            if (id == "")
            {
                throw new Exception("Id non valido");
            }
            Scrivi(id, FilePathId);
            Id = id;
            if (Form != null)
            {
                Form.VisualizzaImpostazioni();
            }
        }

        public void SetPorta(decimal nPorta)
        {
            if (nPorta < 0)
            {
                throw new Exception("Porta non valida");
            } 
            Scrivi("COM" + nPorta, FilePathPorta);
            Porta = "COM" + nPorta;
            if (Form != null)
            {
                Form.VisualizzaImpostazioni();
            }
        }
        public void SetMax(int Max)
        {
            if (Max <= 0) throw new Exception("Numero non valido");
            Scrivi(Max.ToString(), FilePathMax);
            MaxMisurazioni = Max;
            if (Form != null)
            {
                Form.VisualizzaImpostazioni();
            }
        }
    }
}
