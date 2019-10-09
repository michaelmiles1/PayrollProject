using System;
using System.Collections.Generic;
using System.IO;

namespace PayrollProject
{
    public class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        result = line.Split(separator, StringSplitOptions.None);

                        switch (result[1])
                        {
                            case "Manager":
                                Manager newManager = new Manager(result[0]);
                                myStaff.Add(newManager);
                                break;

                            case "Admin":
                                Admin newAdmin = new Admin(result[0]);
                                myStaff.Add(newAdmin);
                                break;

                            default:
                                Console.WriteLine("Error splitting staff.txt file");
                                break;
                        }
                    }
                    reader.Close();
                }
            }
            else
            {
                Console.WriteLine("staff.txt does not exist");
            }
            return myStaff;
        }
    }
}
