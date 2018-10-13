﻿using System;
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
        Dictionary<char, int> dictionaryLettersNumbersForVisualization;
        Dictionary<int, char> dictionaryNumbersLettersForVisualization;
        int numberOfCharsForVisualization;

        public Form1()
        {
            InitializeComponent();
            initializeDictionariesForVisualization();
        }

        // --------------------------------- Odtad skopiowac -------------------------
        // Sprawdzic, czy po wpisaniu tekstu moge zmienic textbox na read only
        // Dodac wczytywanie tekstu z pliku
        // Dodac info

        Label[,] tab = new Label[26, 26];
        Label[] tabForLettersVertical = new Label[26];
        Label[] tabForLettersHorizontal = new Label[26];

        private Label createMyNewLabel(int letterNumber)
        {
            Label labelToReturn = new Label();
            labelToReturn.Text = dictionaryNumbersLettersForVisualization[letterNumber].ToString();
            labelToReturn.Size = new Size(17, 17);
            labelToReturn.Font = new Font("Microsoft Sans Serif", 10);
            labelToReturn.Visible = true;
            labelToReturn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return labelToReturn;
        }

        // To wywolac przy guziku
        private void setVisibilityForAllLabels(bool isVisible)
        {
            foreach(Label l in tab)
            {
                l.Visible = isVisible;
            }

            foreach (Label l in tabForLettersHorizontal)
            {
                l.Visible = isVisible;
            }

            foreach (Label l in tabForLettersVertical)
            {
                l.Visible = isVisible;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int k = 0; k < 26; k++)
            {
                int tempNumberOfLetter = k % 26;
                tabForLettersHorizontal[k] = createMyNewLabel(tempNumberOfLetter);
                tabForLettersHorizontal[k].Location = new Point(20 + 20 * k, 0);
                tabForLettersHorizontal[k].BackColor = System.Drawing.Color.CadetBlue;

                this.Controls.Add(tabForLettersHorizontal[k]);

                tabForLettersVertical[k] = createMyNewLabel(tempNumberOfLetter);
                tabForLettersVertical[k].Location = new Point(0, 20 + 20 * k);
                tabForLettersVertical[k].BackColor = System.Drawing.Color.OrangeRed;

                this.Controls.Add(tabForLettersVertical[k]);
            }

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    int tempNumberOfLetter = (i + j) % 26;
                    tab[i, j] = createMyNewLabel(tempNumberOfLetter);
                    tab[i, j].Location = new Point(20 + 20 * j, 20 + 20 * i);
                    if (i == j)
                        tab[i, j].BackColor = System.Drawing.Color.DarkKhaki;

                    this.Controls.Add(tab[i, j]);
                }
            }
        }

        private void initializeDictionariesForVisualization()
        {
            dictionaryLettersNumbersForVisualization = new Dictionary<char, int>();
            dictionaryNumbersLettersForVisualization = new Dictionary<int, char>();

            char[] allowedCharactersForVisualization = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                                                         'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                                                         'U', 'V', 'W', 'X', 'Y', 'Z' };

            numberOfCharsForVisualization = allowedCharactersForVisualization.Length;

            for (int i = 0; i < numberOfCharsForVisualization; i++)
            {
                dictionaryLettersNumbersForVisualization.Add(allowedCharactersForVisualization[i], i);
                dictionaryNumbersLettersForVisualization.Add(i, allowedCharactersForVisualization[i]);
            }
        }

        private void markRow(int rowNumber, char keyLetter)
        {
            // Oznacz litere tekstu w tabeli vertical
            tabForLettersVertical[rowNumber].BackColor = System.Drawing.Color.Silver;

            // Oznacz caly rzadek liter az do litery klucza
            for (int i = 0; i < 26; i++)
            {
                if(tab[rowNumber, i].Text[0] != keyLetter)
                    tab[rowNumber, i].BackColor = System.Drawing.Color.Green;
                else
                {
                    tab[rowNumber, i].BackColor = System.Drawing.Color.DarkViolet;
                    break;
                }
            }
        }

        private void markColumn(int columnNumber, char keyLetter)
        {
            // Oznacz litere tekstu w tabeli horizontal
            tabForLettersHorizontal[columnNumber].BackColor = System.Drawing.Color.Yellow;

            // Oznacz cala kolumne liter az do litery klucza
            for (int j = 0; j < 26; j++)
            {
                if (tab[j, columnNumber].Text[0] != keyLetter)
                    tab[j, columnNumber].BackColor = System.Drawing.Color.Violet;
                else
                {
                    tab[j, columnNumber].BackColor = System.Drawing.Color.Bisque;
                    break;
                }
            }
        }

        private void markLetters(char textLetter, char keyLetter, char resultLetter)
        {
            int textLetterNumber = dictionaryLettersNumbersForVisualization[textLetter];
            int keyLetterNumber = dictionaryLettersNumbersForVisualization[keyLetter];
            int resultLetterNumber = dictionaryLettersNumbersForVisualization[resultLetter];
            System.Console.WriteLine(textLetterNumber);
            System.Console.WriteLine(keyLetterNumber);
            System.Console.WriteLine(resultLetterNumber);
            markColumn(textLetterNumber, keyLetter);
            markRow(resultLetterNumber, keyLetter);
        }

        // ------------------------ Dotad skopiowac -----------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            markLetters('K', 'R', 'H');                        
        }
    }
}
