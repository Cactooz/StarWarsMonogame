﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StarWars
{
    class HighscoreManager
    {
        //Date format day/month/year (04/05/2020 - May the 4th be with you :D)
        private string dateFormat = "dd/MM/yyyy";
        private string filePath;

        //Make a new list of Highscore
        private List<Highscore> highscores = new List<Highscore>();

        /// <summary>
        /// List containing all <c>Highscores</c>
        /// </summary>
        public List<Highscore> Highscores { get => highscores; }

        /// <summary>
        /// Constructor for <c>HighscoreManager</c>
        /// </summary>
        /// <param name="fileName">The fileName that the file has</param>
        public HighscoreManager(string fileName)
        {
            //The path to the file, combine the directory and the fileName
            filePath = Path.Combine(Environment.CurrentDirectory, fileName);
        }

        /// <summary>
        /// Check if the file already exists otherwise create the file
        /// </summary>
        public void SearchForFile()
        {
            //Check if the doesn't file exists
            if (!File.Exists(filePath))
                //Create a new file and close it
                File.Create(filePath).Dispose();
        }

        /// <summary>
        /// Read data from the file from the <c>filePath</c>
        /// and seperate the elements by commas
        /// </summary>
        public void ReadData()
        {
            //Get all lines from the file
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (string line in lines)
            {
                //Split the line into multiple items
                string[] items = line.Split(',');

                Highscore newHighscore = new Highscore();

                //Make sure that there are 3 items
                if (items.Length == 3)
                {
                    //Set the first item as name
                    //Convert the second item into a int and set the score as it
                    //Set the date to the third item
                    newHighscore = new Highscore(items[0], Convert.ToInt32(items[1]), items[2]);
                }
                //Otherwise add in error data
                else
                {
                    //Set the name to "Error", score to 0 and the data to May 4th 1977
                    newHighscore = new Highscore("Error", 0, "04-05-1977");
                }

                //Add the highscore to the list highscores
                highscores.Add(newHighscore);
            }
        }

        /// <summary>
        /// Save all the data seperated by commas
        /// </summary>
        public void SaveData()
        {
            //List for all lines that should be written to the file
            List<string> saveData = new List<string>();

            //Add all the lines that should be written
            foreach (Highscore highscore in highscores)
            {
                saveData.Add($"{highscore.Name},{highscore.Score},{highscore.Date}");
            }

            //Write all the saveData to the file
            File.WriteAllLines(filePath, saveData);
        }

        /// <summary>
        /// Check a new highscore with the rest of the <c>highscores</c>,
        /// check if it is larger that the last value
        /// </summary>
        /// <param name="newScore">The new score that should be checked with the rest of the <c>highscores</c></param>
        /// <returns>Returns true or false</returns>
        public bool CheckNewHighscore(int newScore)
        {
            //Check if there are less than 10 highscores added, then return true
            //Or check if the new score lager than the last element in the highscores list
            if (highscores.Count < 10 || newScore > highscores[highscores.Count - 1].Score)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Add the new highscore to the <c>higscores</c> in the right place
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public void AddNewHighscore(string name, int score)
        {
            //A temporary list of higscores
            List<Highscore> tempHighscores = new List<Highscore>();
            //The position where the new highscore got added
            int addPosition = 0;
            //If the new score has been to the list
            bool newScoreAdded = false;

            //Check if the higscores list have any highscores
            if (highscores.Count != 0)
            {
                //Loop through all highscores
                foreach (Highscore highscore in highscores)
                {
                    //Check if the score is higher the the highscore, add the score and stop the loop
                    if (score > highscore.Score)
                    {
                        tempHighscores.Add(new Highscore(name, score, DateTime.Now.ToString(dateFormat)));
                        newScoreAdded = true;
                        break;
                    }
                    //Otherwise add the current highscore
                    else
                    {
                        tempHighscores.Add(highscore);
                        addPosition++;
                    }
                }
            }
            //If the list doesn't have any highscores just add the new highscore
            else
            {
                tempHighscores.Add(new Highscore(name, score, DateTime.Now.ToString(dateFormat)));
                newScoreAdded = true;
            }

            //Add in the rest of the highscores that may be after the new score
            for (int i = addPosition; i < highscores.Count; i++)
            {
                tempHighscores.Add(highscores[i]);
            }

            //If the new score hasn't been added yet add it at the end of the list
            if (!newScoreAdded)
                tempHighscores.Add(new Highscore(name, score, DateTime.Now.ToString(dateFormat)));

            //Overwrite highscores with tempHighscores
            highscores = tempHighscores;
        }
    }
}
