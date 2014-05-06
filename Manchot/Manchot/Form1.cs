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

namespace Manchot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[][] measuredData = new double[3][];

        private void btn_open_file_Click(object sender, EventArgs e)
        {
            String[] input = new String[3];
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter ="tdms files (*.tdms)|*.tdms|All files (*.*)|*.*";
            dialog.Multiselect = true;
            dialog.InitialDirectory = "C:";
            dialog.Title = "Select a tdms file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                input = dialog.FileNames;
            }
            /*if (input.Length == 0)
            {
                return;
            }*/
            //Console.WriteLine("Chemin fichier : " + input);
            long numChanValues;
            
            TdmsFile[] files = new TdmsFile[3];
            TdmsChannelGroupCollection channelGroups;
            TdmsChannelCollection channels;

            //Open TDMS file
            for(int i = 0; i < input.Length; i++) {
                files[i] = new TdmsFile(input[i], TdmsFileAccess.Read);
                Console.WriteLine("FILE["+i+"] = "+files[i].Path+"\n");
            }
            Console.WriteLine(files.Length);
            for (int i = 0; i < files.Length; i++)
            {
                channelGroups = files[i].GetChannelGroups();
                channels = channelGroups[0].GetChannels();
                numChanValues = channels[0].DataCount;
                Console.WriteLine(numChanValues);
                measuredData[i] = channels[0].GetData<double>();
                files[i].Close();
            }
            //Read group data



            //Console.WriteLine(numChanValues.ToString());
            double max = 0;
            double data_a_regarder = 0;
            bool trouve = false;
            for (int i = 0; i < measuredData[1].Length; i++)
            {
                if (measuredData[1][i] > max)
                {
                    max = measuredData[1][i];
                }

                if (measuredData[1][i] >= 2 && !trouve)
                {
                    data_a_regarder = i;
                    trouve = true;
                }
                
            }

            Console.WriteLine(data_a_regarder);
            waveformGraph1.YAxes[0].Mode = AxisMode.Fixed;
            waveformGraph1.YAxes[0].Range = new NationalInstruments.UI.Range(0.0, 12.0);
            waveformGraph1.XAxes[0].Mode = AxisMode.Fixed;
            waveformGraph1.XAxes[0].Range = new NationalInstruments.UI.Range(data_a_regarder - 200, data_a_regarder + 300);
            waveformPlot1.PlotY(measuredData[0]);
            waveformPlot2.PlotY(measuredData[1]);
            waveformPlot3.PlotY(measuredData[2]);

        }

        private void button1_Click(object sender, EventArgs e)
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

            Console.Write(data_a_regarder);

            foreach ( double index in data_a_regarder ){
                listBox1.Items.Add(index);
                Console.WriteLine(index);
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Element selectionné: " + listBox1.SelectedItem.ToString());
            double data_a_regarder = Convert.ToDouble(listBox1.SelectedItem.ToString());
            waveformGraph1.YAxes[0].Mode = AxisMode.Fixed;
            waveformGraph1.YAxes[0].Range = new NationalInstruments.UI.Range(0.0, 12.0);
            waveformGraph1.XAxes[0].Mode = AxisMode.Fixed;
            waveformGraph1.XAxes[0].Range = new NationalInstruments.UI.Range(data_a_regarder - 200, data_a_regarder + 300);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] measuredDataFusionned = new double[measuredData[1].Length];

            for (int i = 0; i < measuredData[1].Length; i++)
            {
                measuredDataFusionned[i] = measuredData[0][i] + measuredData[1][i] + measuredData[2][i];
            }
            waveformPlot4.PlotY(measuredDataFusionned);

        }
    }
}
