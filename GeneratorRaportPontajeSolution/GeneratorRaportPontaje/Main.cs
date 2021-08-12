using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using Microsoft.Office.Interop;
using CsvHelper;
using GeneratorRaportPontaje.Utils;

namespace GeneratorRaportPontaje
{
    public partial class Main : Form
    {
        string raportTimesheetsPath;
        string raportEmployersPath;

        string currentName = "";
        CurrentEmployee currentEmployeeData;
        DefaultRaportValues raportCurrentValues;
        Dictionary<string, DefaultRaportValues> raportData;
        Dictionary<string, Employee> allEmployeesData;
        Dictionary<int, int> dailyHoursMinimClocking;
        Dictionary<string, string> perimetru;

        

        public Main()
        {
            raportTimesheetsPath = "";
            raportEmployersPath = "";

            InitializeVariables();

            InitializeComponent();
        }

            
        private void InitializeVariables()
        {
            currentName = "";

            dailyHoursMinimClocking = new Dictionary<int, int>
            {
                {4,2},
                {5,2},
                {6,4},
                {7,4},
                {8,4},
            }; 

            raportData = new Dictionary<string, DefaultRaportValues>
            {
                {"Bauturi + Tabac", new DefaultRaportValues()},
                {"Detergenti", new DefaultRaportValues()},
                {"Parfumerie", new DefaultRaportValues()},
                {"Textile", new DefaultRaportValues()},
                {"Menaj", new DefaultRaportValues()},
                {"Cultura,jocuri,jucarii", new DefaultRaportValues()},
                {"Auto", new DefaultRaportValues()},
                {"Activitati exterioare", new DefaultRaportValues()},
                {"Electronice / Electrocasnice", new DefaultRaportValues()},
                {"Securitate", new DefaultRaportValues()},
                {"Intretinere", new DefaultRaportValues()},
                {"Receptie Food si Non Food", new DefaultRaportValues()},
                {"CDG + Deco", new DefaultRaportValues()},
                {"E-commerce", new DefaultRaportValues()},
                {"Casa principala", new DefaultRaportValues()},
                {"Case in linie", new DefaultRaportValues()},
                {"RH", new DefaultRaportValues()},
                { "Magazin", new DefaultRaportValues()},
            };

            perimetru = new Dictionary<string, string>
            {
                {"Carmangerie", ""},
                {"Carne congelata", ""},
                {"Casa Principala", ""},
                {"Case In Linie", ""},
                {"Cdg Magazin", ""},
                {"Cofetarie prod proprie", ""},
                {"Comun Activitati exterioare", ""},
                {"Comun Alimentatie Speciala", ""},
                {"Comun Animalier", ""},
                {"Comun Auto Brico", ""},
                {"Comun Bauturi cu alcool", ""},
                {"Comun Bauturi fara alcool", ""},
                {"Comun Bebe", ""},
                {"Comun Branzeturi", ""},
                {"Comun Congelate", ""},
                {"Comun Cultura jocuri jucarii", ""},
                {"Comun Deterg Igienizarea Casei", ""},
                {"Comun Dulciuri", ""},
                {"Comun Electrocasnice", ""},
                {"Comun Electronice, Multimedia", ""},
                {"Comun Fructe si Legume", ""},
                {"Comun Frumusete", ""},
                {"Comun Lactate", ""},
                {"Comun Menaj", ""},
                {"Comun Mezeluri", ""},
                {"Comun Sarate", ""},
                {"Comun Tabac", ""},
                {"Comun Textile", ""},
                {"Decorare", ""},
                {"E-commerce", ""},
                {"Gastro productie proprie", ""},
                {"Gastro semipreparate", ""},
                {"Intretinere", ""},
                {"Panificatie prod proprie", ""},
                {"Pasare", ""},
                {"Patiserie prod proprie", ""},
                {"Peste Proaspat", ""},
                {"Peste procesat", ""},
                {"Receptie marfa", ""},
                {"Resurse Umane", ""},
                {"Securitate", ""},
                {"SSM SU", ""},
            };

            allEmployeesData = new Dictionary<string, Employee>();

            raportCurrentValues = new DefaultRaportValues();
            currentEmployeeData = new CurrentEmployee();

        }

        private void about_MenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made By Alin Gogoase in 2021", "Despre Generator!");
        }

        private void exit_MenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void upload_raport_access_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                raportTimesheetsPath = openFileDialog1.FileName;

                raport_pontaje_nume_fisier.Text = "Nume Raport: " + Path.GetFileName(raportTimesheetsPath);
            }
        }

        private void upload_raport_angajati_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.raportEmployersPath = openFileDialog1.FileName;

                raport_angajati_nume_fisier.Text = "Nume Raport: " + Path.GetFileName(this.raportEmployersPath);
            }
        }

        private void generator_raport_Click(object sender, EventArgs e)
        {
            if(raportTimesheetsPath == "")
            {
                MessageBox.Show("Raportul cu Pontajele Angajatilor nu a fost incarcat", "Eroare!");
                return;
            }

            if (raportEmployersPath == "")
            {
                MessageBox.Show("Raportul cu Datele Angajatilor nu a fost incarcat", "Eroare!");
                return;
            }

            string raportName = DateTime.Now.ToString();

            getEmployeesData(raportEmployersPath);
            generateRaport(raportTimesheetsPath);

            MessageBox.Show("Raportul a fost generat cu success:" + raportName, "Success!");
        }

        private void getEmployeesData(string raportEmployersPath)
        {
            int headerIndex = 0;

            string[] lines = File.ReadAllLines(raportEmployersPath);
            string[] fields = lines[headerIndex].Split(new char[] { ',' });

            int linesLength = lines.Length;

            for (int i = 1; i < linesLength; i++)
            {
                string[] currentEmployerData = lines[i].Split(new char[] { ',' });

                if (string.IsNullOrEmpty(currentEmployerData[0]))
                {
                    continue;
                }

                processEmployeeData(currentEmployerData);
            }
        }

        private void processEmployeeData(string[] currentEmployerData)
        {
            Employee currentData = new Employee(currentEmployerData);

            allEmployeesData.Add(currentData.nrMarca, currentData);
        }

        private void generateRaport(string raportTimesheetsPath)
        {
            int headerIndex = 0;

            string[] lines = File.ReadAllLines(raportTimesheetsPath);
            string[] fields = lines[headerIndex].Split(new char[] { ',' });

            int linesLength = lines.Length;

            for (int i = 1; i < linesLength; i++)
            {
                string[] currentEmployerData = lines[i].Split(new char[] { ',' });

                if (string.IsNullOrEmpty(currentEmployerData[0]))
                {
                    continue;
                }

                calculateEmployeeData(currentEmployerData);
            }
        }

        private void calculateEmployeeData(string[] currentEmployerData)
        {
            bool mistakeMade = false;

            TimeSheetRecord currentData = new TimeSheetRecord(currentEmployerData);

            if(allEmployeesData.ContainsKey(currentData.nrMarca) == false)
            {
                return;
            }

            if (currentName != currentData.numeAngajat)
            {
                if (currentName != "")
                {
                    updateRaportData();
                }

                currentEmployeeData.employerID = currentData.nrMarca;
            }

            int intrariSize = currentData.intrari.Length;
            for (int index = 0; index < intrariSize; index++)
            {
                if (string.IsNullOrEmpty(currentData.intrari[index]) == true)
                {
                    if (string.IsNullOrEmpty(currentData.iesiri[index]) == false)
                    {
                        mistakeMade = true;
                        currentEmployeeData.mistakesCount++;
                        break;
                    }
                }
                else if (string.IsNullOrEmpty(currentData.intrari[index]) == false)
                {
                    if (string.IsNullOrEmpty(currentData.iesiri[index]) == true)
                    {
                        mistakeMade = true;
                        currentEmployeeData.mistakesCount++;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(currentData.intrari[index]) == true
                    && string.IsNullOrEmpty(currentData.iesiri[index]) == true)
                {
                    break;
                }
            }

            if (mistakeMade == true)
            {
                return;
            }

            int employeeHoursPerDay = allEmployeesData[currentData.nrMarca].oreZiLucru;
            int minHoursPerDay = dailyHoursMinimClocking[employeeHoursPerDay];

            int intrariCount = count_array_values(currentData.intrari);
            int iesirCount = count_array_values(currentData.iesiri);
            int employeeClocking = intrariCount + iesirCount;

            if (employeeClocking < minHoursPerDay)
            {
                currentEmployeeData.mistakesCount++;
                currentEmployeeData.lowerClockingCount++;
            }
        }

        private int count_array_values(string[] array)
        {
            int size = 0;

            foreach(string value in array)
            {
                if(string.IsNullOrEmpty(value) == false)
                {
                    size++;
                }
            }
            return size;
        }

        private void updateRaportData()
        {
            string currentPerimetru = perimetru[currentEmployeeData.perimetru];
            raportData[currentPerimetru].employerCount++;

            if (currentEmployeeData.lowerClockingCount > 3)
            {
                raportData[currentPerimetru].lowerClocking++;
            }

            if (currentEmployeeData.mistakesCount > 3)
            {
                raportData[currentPerimetru].wrongClocking++;
            } else
            {
                raportData[currentPerimetru].correctClocking++;
            }
            
            raportData[currentPerimetru].correctness = raportData[currentPerimetru].correctClocking / raportData[currentPerimetru].employerCount;
        }
    }

    
}
