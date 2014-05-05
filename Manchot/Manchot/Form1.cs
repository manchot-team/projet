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
            String[] input = new String[10];
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
            double[] measuredData;
            TdmsFile[] files = new TdmsFile[10];
            TdmsChannelGroupCollection channelGroups;
            TdmsChannelCollection channels;

            //Open TDMS file
            for(int i = 0; i < input.Length; i++) {
                files[i] = new TdmsFile(input[i], TdmsFileAccess.Read);
                Console.WriteLine("FILE["+i+"] = "+files[i].Path+"\n");
            }

            //Read group data
            channelGroups = files[0].GetChannelGroups();
            channels = channelGroups[0].GetChannels();
            numChanValues = channels[0].DataCount;

            Console.WriteLine(numChanValues);
            measuredData = channels[0].GetData<double>();

            //Close file
            files[0].Close();

            //Console.WriteLine(numChanValues.ToString());
            double max = 0;
            double data_a_regarder = 0;
            bool trouve = false;
            for (int i = 0; i < measuredData.Length; i++)
            {
                if (measuredData[i] > max)
                {
                    max = measuredData[i];
                }

                if (measuredData[i] >= 2 && !trouve)
                {
                    data_a_regarder = i;
                    trouve = true;
                }
                
            }

            waveformGraph1.YAxes[0].Mode = AxisMode.Fixed;
            waveformGraph1.YAxes[0].Range = new NationalInstruments.UI.Range(0.0, 12.0);
            waveformGraph1.XAxes[0].Mode = AxisMode.Fixed;
            waveformGraph1.XAxes[0].Range = new NationalInstruments.UI.Range(data_a_regarder-200, data_a_regarder+200);
            waveformGraph1.PlotY(measuredData);

        }
    }
}
