using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace StarWars
{
    class TextBoxInputManager
    {
        //New and old state of the keyboard
        private KeyboardState kNewState, kOldState;
        //The old keys that were pressed
        private Keys[] oldKeysPressed = new Keys[5];
        //The highscore name, that the letters will get added to
        private string highscoreName = string.Empty;

        /// <summary>
        /// The <c>highscoreName</c> chosen by the player
        /// </summary>
        public string HighscoreName { get => highscoreName; }

        /// <summary>
        /// Check wich keys are being pressed on the keyboard
        /// </summary>
        public void GetKeyInput()
        {
            //Get the current state of the keys on the keyboard
            kNewState = Keyboard.GetState();

            //An array storing all keys pressed
            Keys[] newKeysPressed = kNewState.GetPressedKeys();

            //Loop through all keys in array
            foreach (Keys key in newKeysPressed)
            {
                //Check if the button was not pressed last frame
                if (!oldKeysPressed.Contains(key))
                    KeyPress(key);
            }

            //Save the current keyboard state as the old
            kOldState = kNewState;
            //Save the current pressed keys as the old
            oldKeysPressed = newKeysPressed;
        }

        /// <summary>
        /// Checks if the key is an allowed key, if so change the <c>highscoreName</c>
        /// </summary>
        /// <param name="key">The key that got pressed</param>
        private void KeyPress(Keys key)
        {
            //If back button is clicked remove the last character from the string
            //if there is at least one character in the string
            if (key == Keys.Back && highscoreName.Length > 0)
                highscoreName = highscoreName.Remove(highscoreName.Length - 1);
            //Add a space if spacebar is clicked if the string is not longer than 10
            else if (key == Keys.Space && highscoreName.Length < 10)
                highscoreName += " ";
            //Add the letter if the string is not longer than 10
            else if (highscoreName.Length < 10)
                KeyToChar();
        }

        /// <summary>
        /// Checks for all english letters and adds the right letter
        /// to the <c>highscoreName</c>
        /// </summary>
        private void KeyToChar()
        {
            if (kNewState.IsKeyDown(Keys.A) && kOldState.IsKeyUp(Keys.A))
                highscoreName += "A";
            else if (kNewState.IsKeyDown(Keys.B) && kOldState.IsKeyUp(Keys.B))
                highscoreName += "B";
            else if (kNewState.IsKeyDown(Keys.C) && kOldState.IsKeyUp(Keys.C))
                highscoreName += "C";
            else if (kNewState.IsKeyDown(Keys.D) && kOldState.IsKeyUp(Keys.D))
                highscoreName += "D";
            else if (kNewState.IsKeyDown(Keys.E) && kOldState.IsKeyUp(Keys.E))
                highscoreName += "E";
            else if (kNewState.IsKeyDown(Keys.F) && kOldState.IsKeyUp(Keys.F))
                highscoreName += "F";
            else if (kNewState.IsKeyDown(Keys.G) && kOldState.IsKeyUp(Keys.G))
                highscoreName += "G";
            else if (kNewState.IsKeyDown(Keys.H) && kOldState.IsKeyUp(Keys.H))
                highscoreName += "H";
            else if (kNewState.IsKeyDown(Keys.I) && kOldState.IsKeyUp(Keys.I))
                highscoreName += "I";
            else if (kNewState.IsKeyDown(Keys.J) && kOldState.IsKeyUp(Keys.J))
                highscoreName += "J";
            else if (kNewState.IsKeyDown(Keys.K) && kOldState.IsKeyUp(Keys.K))
                highscoreName += "K";
            else if (kNewState.IsKeyDown(Keys.L) && kOldState.IsKeyUp(Keys.L))
                highscoreName += "L";
            else if (kNewState.IsKeyDown(Keys.M) && kOldState.IsKeyUp(Keys.M))
                highscoreName += "M";
            else if (kNewState.IsKeyDown(Keys.N) && kOldState.IsKeyUp(Keys.N))
                highscoreName += "N";
            else if (kNewState.IsKeyDown(Keys.O) && kOldState.IsKeyUp(Keys.O))
                highscoreName += "O";
            else if (kNewState.IsKeyDown(Keys.P) && kOldState.IsKeyUp(Keys.P))
                highscoreName += "P";
            else if (kNewState.IsKeyDown(Keys.Q) && kOldState.IsKeyUp(Keys.Q))
                highscoreName += "Q";
            else if (kNewState.IsKeyDown(Keys.R) && kOldState.IsKeyUp(Keys.R))
                highscoreName += "R";
            else if (kNewState.IsKeyDown(Keys.S) && kOldState.IsKeyUp(Keys.S))
                highscoreName += "S";
            else if (kNewState.IsKeyDown(Keys.T) && kOldState.IsKeyUp(Keys.T))
                highscoreName += "T";
            else if (kNewState.IsKeyDown(Keys.U) && kOldState.IsKeyUp(Keys.U))
                highscoreName += "U";
            else if (kNewState.IsKeyDown(Keys.V) && kOldState.IsKeyUp(Keys.V))
                highscoreName += "V";
            else if (kNewState.IsKeyDown(Keys.W) && kOldState.IsKeyUp(Keys.W))
                highscoreName += "W";
            else if (kNewState.IsKeyDown(Keys.X) && kOldState.IsKeyUp(Keys.X))
                highscoreName += "X";
            else if (kNewState.IsKeyDown(Keys.Y) && kOldState.IsKeyUp(Keys.Y))
                highscoreName += "Y";
            else if (kNewState.IsKeyDown(Keys.Z) && kOldState.IsKeyUp(Keys.Z))
                highscoreName += "Z";
        }
    }
}
