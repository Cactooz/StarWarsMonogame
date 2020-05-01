using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarWars
{
    class DataStorageHandler
    {
        private string filePath;
        string[,] highscores = new string[,] {
                {"Leader", "1000"},
                {"Test", "100"}
            };

        public DataStorageHandler(string fileName)
        {
            filePath = Path.Combine(Environment.CurrentDirectory, fileName);
        }

        public void GetData()
        {

        }

        public void SaveData()
        {

        }

        public void RemoveData()
        {

        }

        public void WriteData()
        {

        }

    }
}
