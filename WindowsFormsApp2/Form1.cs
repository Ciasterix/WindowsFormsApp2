using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        // Skopiowac ponizsza linijke 1/4
        Visualizator mainVisualizator;

        public Form1()
        {
            InitializeComponent();
            // Skopiowac ponizsza linijke 2/4
            mainVisualizator = new Visualizator();
        }

        // --------------------------------- TODO -------------------------
        // Sprawdzic, czy po wpisaniu tekstu moge zmienic textbox na read only
        // Dodac wczytywanie tekstu z pliku
        // Dodac info
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // Skopiowac ponizsza linijke 3/4
            mainVisualizator.LoadLabelIntoForm(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Skopiowac ponizsza linijke 4/4
            mainVisualizator.markLetters('K', 'R', 'H');                        
        }
    }
}
