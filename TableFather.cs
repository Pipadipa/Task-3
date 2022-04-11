using System;
using System.Collections.Generic;

using System.Text;

namespace Task3
{
    class TableFather
    {
        private static List<string> table = new List<string>();

        public static void generateTable(string[] mov) 
        {
           
            createTable(mov);
            foreach (string s in table) Console.WriteLine(s);
        }
        private static void createTable(string[] mov) 
        {
            table.Add(to10(" "));
            for(int i = 0; i < mov.Length; i++) 
            {
                table[0] += to10(mov[i]);
                table.Add(to10(mov[i]));
                for (int j = 0; j < mov.Length; j++) 
                {
                    table[i + 1] += to10(GameLogicClass.getWinCodition(j, i, mov));
                }
            }
        } 
        private static string to10(string s) 
        {
            return s.Length <= 10 ? (s + getSpace(10 - s.Length)) : (s.Substring(0, 9) + ".");
        }
        private static string getSpace(int n)
        {
            string s = null;
            for (int i = 0; i < n; i++) s += " ";
            return s;
        }
    }
}
