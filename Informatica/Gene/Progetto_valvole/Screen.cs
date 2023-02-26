using prototipo;

namespace Progetto_valvole
{
    public partial class Screen : Form
    {
        ArduinoReader arduinoReader = new ArduinoReader();
        SerialPortReader serialPortReader = new SerialPortReader();
        FileMenager file = new FileMenager();
        List<String> righe = new List<string>();

        public Screen()
        {
            InitializeComponent();
        }

        private void timerCiclo_Tick(object sender, EventArgs e)
        {
            //arduinoReader.inzio();
            //listView1.Items.Clear();
            righe = file.LeggiFile();
            for (int i = 0; i < righe.Count; i++)
            {
                string str = righe[i];
                ListViewItem riga = new ListViewItem(str.Split(';'));
                listView1.Items.Add(riga);
            }
            //arduinoReader.fine();
            timerCiclo.Enabled = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSTART_Click(object sender, EventArgs e)
        {
            arduinoReader.inzio();
            timerCiclo.Enabled = true;
            //listView1.Items.Clear();
        }

        private void buttonSTOP_Click(object sender, EventArgs e)
        {
            timerCiclo.Enabled = false;
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            string[] intestazione = new string[] { "MISURAZIONE 1", "MISURAZIONE 2", "DATA" };
            for (int i = 0; i < intestazione.Length; i++)
            {
                listView1.Columns.Add(intestazione[i]);
            }

        }
    }
}