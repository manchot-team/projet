﻿using NationalInstruments.Analysis;
using NationalInstruments.Analysis.Conversion;
using NationalInstruments.Analysis.Dsp;
using NationalInstruments.Analysis.Dsp.Filters;
using NationalInstruments.Analysis.Math;
using NationalInstruments.Analysis.Monitoring;
using NationalInstruments.Analysis.SignalGeneration;
using NationalInstruments.Analysis.SpectralMeasurements;
using NationalInstruments;
using NationalInstruments.UI;
using NationalInstruments.NetworkVariable;
using NationalInstruments.NetworkVariable.WindowsForms;
using NationalInstruments.Tdms;
using NationalInstruments.UI.WindowsForms;
using NationalInstruments.Controls;
using NationalInstruments.Controls.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Threading;
using System.IO;

namespace Manchot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Initialisation variable globale
        double[][] measuredData = new double[3][];
        Double[] measuredDataFusionned;
        List<TdmsFile> files = new List<TdmsFile>();
        DateTime dateFiles = new DateTime();

        /*******
         * Fonctions évènements objets
         *******/
        private void btn_open_file_Click(object sender, EventArgs e)
        {
            openAndReadFiles();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openAndReadFiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double max = 0;
            List<double> data_a_regarder = new List<double>();
            bool trouve = false;
            for (int i = 0, j = 0; i < measuredData[0].Length; i++)
            {
                if (measuredData[0][i] > max)
                {
                    max = measuredData[0][i];
                }

                if (measuredData[0][i] >= 2 && !trouve)
                {
                    data_a_regarder.Add(i);
                    j++;
                    trouve = true;
                }

                if (measuredData[0][i] <= 2 && trouve)
                {
                    trouve = false;
                }

            }

            comboBox1.Items.Clear();
            foreach (double index in data_a_regarder)
            {
                comboBox1.Items.Add(index);
                Console.WriteLine(index);
            }
            comboBox1.Items.Insert(0, "Vue d'ensemble");
            comboBox1.SelectedIndex = 0;

            measuredData = Traitement.supressionBruit(measuredData);

            // Affichage des courbes :
            waveformPlot1.PlotY(measuredData[0]);
            waveformPlot2.PlotY(measuredData[1]);
            waveformPlot3.PlotY(measuredData[2]);

            // Affichage d'un message flash dans la bar de status: 
            Thread affiche = new Thread(new ParameterizedThreadStart(MessageFlash));
            affiche.Start("Fichiers ouverts");

            // Activation des menus Affichage et Analyse
            affichageToolStripMenuItem.Enabled = true;
            analyseToolStripMenuItem.Enabled = true;
        }
        /// <summary>
        /// Fonction permettant de lancer l'analyse sur les fichiers et detecte ainsi les évenements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lancerLanalyseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double max = 0;
            double[] data_a_regarder = new double[30];
            bool trouve = false;
            for (int i = 0, j = 0; i < measuredData[1].Length; i++)
            {
                if (measuredData[1][i] > max)
                {
                    max = measuredData[1][i];
                }

                if (measuredData[1][i] >= 2 && !trouve)
                {
                    data_a_regarder[j] = i;
                    j++;
                    trouve = true;
                }

                if (measuredData[1][i] <= 2 && trouve)
                {
                    trouve = false;
                }

            }

            comboBox1.DataSource = null;
            Dictionary<Evenement, string> valeurs = new Dictionary<Evenement, string>();
            valeurs.Add(new Evenement(), "Vue d'ensemble");
            Console.Write(data_a_regarder);
            Evenement ev_tmp = Traitement.dateEvenement(dateFiles, data_a_regarder[0]);
            int compteur = 0;
            foreach (double index in data_a_regarder)
            {
                if (index != 0)
                {
                    Evenement ev = Traitement.dateEvenement(dateFiles, index);
                    if (ev.dateDebut.Second != ev_tmp.dateDebut.Second || compteur == 0)
                    {
                        ev_tmp.absFin = index - 50;
                        ev.analyser(measuredDataFusionned);
                        valeurs.Add(ev, ev.heure);
                    }
                    //comboBox1.Items.Add(ev.absDebut);
                    ev_tmp = ev;
                    compteur++;
                }
                
            }
            comboBox1.DataSource = new BindingSource(valeurs, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.SelectedIndex = 0;

            if (!comboBox1.Enabled)
            {
                comboBox1.Enabled = true;
            }
        }

        /// <summary>
        /// Fonction dynamique permettant de gérer l'affichage des courbes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void balanceCourbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // On récupere dynamiquement l'objet qui a lancé l'event : 
            ToolStripMenuItem itemSender = sender as ToolStripMenuItem;
            Console.WriteLine(itemSender.AccessibleName);

            // En fonction de l'objet, on affiche un courbe ou l'autre
            switch (Convert.ToInt16(itemSender.AccessibleName))
            {
                case 0:
                    waveformPlot1.Visible = true;
                    waveformPlot2.Visible = true;
                    waveformPlot3.Visible = true;
                    break;

                case 1:
                    Console.WriteLine("Affichage de la courbe 1");
                    waveformPlot1.Visible = true;
                    waveformPlot2.Visible = false;
                    waveformPlot3.Visible = false;
                    break;
                case 2:
                    Console.WriteLine("Affichage de la courbe 2");
                    waveformPlot1.Visible = false;
                    waveformPlot2.Visible = true;
                    waveformPlot3.Visible = false;
                    break;
                case 3:
                    Console.WriteLine("Affichage de la courbe 3");
                    waveformPlot1.Visible = false;
                    waveformPlot2.Visible = false;
                    waveformPlot3.Visible = true;
                    break;
                default:
                    Console.WriteLine("Ne rien faire");
                    break;

            }
        }

        /// <summary>
        /// Permet de faire la somme des trois balances
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sommeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itemSender = sender as ToolStripMenuItem;
            Console.WriteLine("Appuie sur le bouton somme, statut :" + itemSender.Checked);

            if (itemSender.Checked)
            {

                measuredDataFusionned = new double[measuredData[1].Length];

                for (int i = 0; i < measuredData[1].Length; i++)
                {
                    measuredDataFusionned[i] = measuredData[0][i] + measuredData[1][i] + measuredData[2][i];
                }
                waveformPlot4.PlotY(measuredDataFusionned);
                waveformPlot4.Visible = true;
            }
            else
            {
                waveformPlot4.Visible = false;
            }
        }

        /// <summary>
        /// Fonction qui gere un click sur la combobox des evenements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.DataSource != null)
            {
                if (comboBox1.SelectedIndex != 0)
                {
                    Console.WriteLine("Element selectionné: " + comboBox1.SelectedItem.ToString());
                    double data_a_regarder = ((KeyValuePair<Evenement, string>)comboBox1.SelectedItem).Key.absDebut;
                    waveformGraph1.XAxes[0].Mode = AxisMode.Fixed;
                    waveformGraph1.XAxes[0].Range = new NationalInstruments.UI.Range(data_a_regarder - 200, data_a_regarder + 300);
                }
                else
                {
                    Console.WriteLine("Vue globale");
                    waveformGraph1.XAxes[0].Mode = AxisMode.Fixed;
                    waveformGraph1.XAxes[0].Range = new NationalInstruments.UI.Range(0, measuredData[0].Length);
                }
            }
        }

        /// <summary>
        /// Fonction gérant l'ouverture des fichiers et l'affichages des courbes
        /// </summary>
        private void openAndReadFiles()
        {
            // Déclaration des variables
            String[] input;
            OpenFileDialog dialog = new OpenFileDialog();
            TdmsChannelGroupCollection channelGroups;
            TdmsChannelCollection channels;
            long numChanValues;

            //Clear de la liste des fichiers
            files.Clear();
            comboBox1.DataSource = null;
            comboBox1.Enabled = false;

            dialog.Filter = "tdms files (*.tdms)|*.tdms|All files (*.*)|*.*";
            dialog.Multiselect = true;
            dialog.InitialDirectory = "C:";
            dialog.Title = "Select a tdms file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                input = dialog.FileNames;
                Console.WriteLine(input.Length + " fichier(s) ouvert(s)");
                if (input.Length == 3)
                {
                    //Open TDMS file
                    for (int i = 0; i < input.Length; i++)
                    {
                        files.Add(new TdmsFile(input[i], TdmsFileAccess.Read));
                        Console.WriteLine("FILE[" + i + "] = " + files[i].Path);
                        // Recupération des métadata : 
                        DateTime creationTime = File.GetLastWriteTime(files[i].Path);
                        Console.WriteLine("FILE[" + i + "] CREATION = " + creationTime);
                    }



                    // Lecture des données TDMS
                    for (int i = 0; i < files.Count; i++)
                    {
                        channelGroups = files[i].GetChannelGroups();
                        channels = channelGroups[0].GetChannels();
                        numChanValues = channels[0].DataCount;
                        measuredData[i] = channels[0].GetData<double>();
                        files[i].Close();
                    }
                    
                    measuredData = Traitement.supressionBruit(measuredData);
                     measuredData = Traitement.filtreMoyenne(measuredData);
 
                     for (int i = 0; i < measuredData.Length; i++ )
                     {
                         measuredData[i] = Traitement.filtreMedian(measuredData[i], 150);
                         Console.WriteLine("Application du filtre median");
                     }

                    // Affichage des courbes
                    waveformGraph1.XAxes[0].Mode = AxisMode.Fixed;
                    waveformGraph1.XAxes[0].Range = new NationalInstruments.UI.Range(0, measuredData[0].Length);
                    waveformPlot1.PlotY(measuredData[0]);
                    waveformPlot2.PlotY(measuredData[1]);
                    waveformPlot3.PlotY(measuredData[2]);

                    // Affichage d'un message flash dans la bar de status
                    Thread affiche = new Thread(new ParameterizedThreadStart(MessageFlash));
                    affiche.Start("Fichiers ouverts");

                    // Activation des menus Affichage et Analyse ainsi que le bouton d'analyse
                    //button1.Enabled = true;
                    affichageToolStripMenuItem.Enabled = true;
                    analyseToolStripMenuItem.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Vous devez sélectionner les trois fichiers du plateau!", "Erreur de sélection");
                }
            }
        }

        /// <summary>
        /// Permet d'afficher un message d'un durée de deux secondes dans la boite de message 
        /// </summary>
        /// <param name="message">Message à afficher</param>
        public void MessageFlash(Object message)
        {
            toolStripStatusLbl.Visible = true;
            toolStripStatusLbl.Text = (String)message;
            //this.Refresh();
            System.Threading.Thread.Sleep(4000);
            toolStripStatusLbl.Visible = false;
        }

        /// <summary>
        /// Fonctoin gerant l'exportation des résultats dans un fichier .txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void exporterLesRésultatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StringBuilder sb = new StringBuilder();
            double bruit = Traitement.pourcentageBruit(measuredData);
            sb.AppendLine(" Rapport d'Analyse des fichiers :");
            sb.AppendLine(" **************************************************");
            int i = 0;
            for (; i < comboBox1.Items.Count; i++)
            {
                sb.AppendLine("Evenement n°" + (i + 1) + ": " + comboBox1.Items[i]);
                sb.AppendLine("Analyse : " + ((KeyValuePair<Evenement, string>)comboBox1.Items[i]).Key.analyse);
            }
            sb.AppendLine("Votre fichier contient " + bruit + "% de bruit");
            sb.AppendLine("");
            sb.AppendLine("");
            

            using (StreamWriter outfile = new StreamWriter(mydocpath + @"\Rapport_tdms.txt", true))
            {
                await outfile.WriteAsync(sb.ToString());
            }
            

        }

            
    }
}
