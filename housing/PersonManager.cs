﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;


namespace housing
{
    public class PersonManager
    {
        private List<Person> _persons;

        public bool IsTheInputAcceptable(string input)
        {
            return !String.IsNullOrEmpty(input);
        }

        public void LoadUpList()
        {
            this._persons = new List<Person>();
            FileStream fs = null;
            StreamReader sr = null;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "Tenants.txt";
            bool fileFound = false;
            while (!fileFound)
            {
                string[] files = Directory.GetFiles(desktopPath, fileName, SearchOption.AllDirectories);
                if (files.Length > 0)
                {
                    string filePath = files[0];
                    try
                    {
                        fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        sr = new StreamReader(fs);
                        string s = sr.ReadLine();
                        while (s != null && !string.IsNullOrEmpty(s))
                        {
                            char delimiter = ',';
                            string[] words = s.Split(delimiter);
                            Person p = new Person();
                            p.FirstName = words[0];
                            p.LastName = words[1];
                            p.Code = Convert.ToInt32(words[2]);
                            p.Phone = words[3];
                            p.Email = words[4];
                            p.IsAdmin = words[5];
                            p.RoomNumber = Convert.ToInt32(words[6]);
                            p.IsPresent = words[7];
                            this._persons.Add(p);
                            s = sr.ReadLine();
                        }
                    }
                    finally
                    {
                        if (sr != null)
                        {
                            sr.Close();
                        }
                    }
                    fileFound = true;
                }
                else
                {
                    MessageBox.Show("the Tenant.txt file was not found make sure that you run the program in a folder that is located on the desktop.");
                }
            }
        }

        public List<Person> GetList()
        {
            return this._persons;
        }

        public bool IsThePersonInTheCSV(int code)
        {
            foreach (Person p in this._persons)
            {
                if (p.DoesTheCodeMatch(code))
                {
                    p.CreateUser();
                    MessageBox.Show("success");
                    return true;
                }
            }
            return false;
        }

        public bool IsThePersonAdmin()
        {
            User User = new User();
            return User.IsItAdmin();
        }
    }
}
