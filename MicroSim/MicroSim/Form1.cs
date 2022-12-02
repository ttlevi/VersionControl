using MicroSim.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MicroSim
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        public Form1()
        {
            InitializeComponent();
            Population = ReadPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = ReadBirth(@"C:\Temp\születés.csv");
            DeathProbabilities = ReadDeath(@"C:\Temp\halál.csv");
        }

        private List<Person> ReadPopulation(string path)
        {
            List<Person> pop = new List<Person>();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    pop.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return pop;
        }

        private List<DeathProbability> ReadDeath(string path)
        {
            List<DeathProbability> death= new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    death.Add(new DeathProbability()
                    {
                        Age = int.Parse(line[1]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return death;
        }

        private List<BirthProbability> ReadBirth(string path)
        {
            List<BirthProbability> birth = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birth.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        P = double.Parse(line[2])
                    });
                }
            }

            return birth;
        }
    }
}
