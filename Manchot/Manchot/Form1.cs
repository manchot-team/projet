using NationalInstruments.Analysis;
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


        private void btn_open_file_Click(object sender, EventArgs e)
        {
            String input = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter ="tdms files (*.tdms)|*.tdms|All files (*.*)|*.*";
            dialog.InitialDirectory = "C:";
            dialog.Title = "Select a tdms file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                input = dialog.FileName;
            }
            if (input == String.Empty)
            {
                return;
            }
            Console.WriteLine("Chemin fichier : " + input);
            long numChanValues;
            double[] measuredData;
            TdmsFile file;
            TdmsChannelGroupCollection channelGroups;
            TdmsChannelCollection channels;

            //Open TDMS file
            file = new TdmsFile(input, TdmsFileAccess.Read);

            //Read group data
            channelGroups = file.GetChannelGroups();
            channels = channelGroups[0].GetChannels();
            numChanValues = channels[0].DataCount;

            Console.WriteLine(numChanValues);
            measuredData = channels[0].GetData<double>();

            //Close file
            file.Close();

            //Console.WriteLine(numChanValues.ToString());
            //for (int i = 0; i < 90; i++)
            //{
            //    Console.WriteLine(measuredData[i] + "\n");
            //}

            waveformGraph1.PlotYAppend(measuredData);
 
        }
    }
}
