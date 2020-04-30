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

        public DataStorageHandler(string fileName)
        {
            filePath = Path.Combine(Environment.CurrentDirectory, fileName);
        }

        public void Update()
        {

        }

        private void LoadData()
        {

        }

        private void SaveData()
        {

        }

        private void RemoveData()
        {

        }

        private void WriteData()
        {

        }

    }
}
