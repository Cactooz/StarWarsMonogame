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
                highscoreName += "a";
            else if (kNewState.IsKeyDown(Keys.B) && kOldState.IsKeyUp(Keys.B))
                highscoreName += "b";
            else if (kNewState.IsKeyDown(Keys.C) && kOldState.IsKeyUp(Keys.C))
                highscoreName += "c";
            else if (kNewState.IsKeyDown(Keys.D) && kOldState.IsKeyUp(Keys.D))
                highscoreName += "d";
            else if (kNewState.IsKeyDown(Keys.E) && kOldState.IsKeyUp(Keys.E))
                highscoreName += "e";
            else if (kNewState.IsKeyDown(Keys.F) && kOldState.IsKeyUp(Keys.F))
                highscoreName += "f";
            else if (kNewState.IsKeyDown(Keys.G) && kOldState.IsKeyUp(Keys.G))
                highscoreName += "g";
            else if (kNewState.IsKeyDown(Keys.H) && kOldState.IsKeyUp(Keys.H))
                highscoreName += "h";
            else if (kNewState.IsKeyDown(Keys.I) && kOldState.IsKeyUp(Keys.I))
                highscoreName += "i";
            else if (kNewState.IsKeyDown(Keys.J) && kOldState.IsKeyUp(Keys.J))
                highscoreName += "j";
            else if (kNewState.IsKeyDown(Keys.K) && kOldState.IsKeyUp(Keys.K))
                highscoreName += "k";
            else if (kNewState.IsKeyDown(Keys.L) && kOldState.IsKeyUp(Keys.L))
                highscoreName += "l";
            else if (kNewState.IsKeyDown(Keys.M) && kOldState.IsKeyUp(Keys.M))
                highscoreName += "m";
            else if (kNewState.IsKeyDown(Keys.N) && kOldState.IsKeyUp(Keys.N))
                highscoreName += "n";
            else if (kNewState.IsKeyDown(Keys.O) && kOldState.IsKeyUp(Keys.O))
                highscoreName += "o";
            else if (kNewState.IsKeyDown(Keys.P) && kOldState.IsKeyUp(Keys.P))
                highscoreName += "p";
            else if (kNewState.IsKeyDown(Keys.Q) && kOldState.IsKeyUp(Keys.Q))
                highscoreName += "q";
            else if (kNewState.IsKeyDown(Keys.R) && kOldState.IsKeyUp(Keys.R))
                highscoreName += "r";
            else if (kNewState.IsKeyDown(Keys.S) && kOldState.IsKeyUp(Keys.S))
                highscoreName += "s";
            else if (kNewState.IsKeyDown(Keys.T) && kOldState.IsKeyUp(Keys.T))
                highscoreName += "t";
            else if (kNewState.IsKeyDown(Keys.U) && kOldState.IsKeyUp(Keys.U))
                highscoreName += "u";
            else if (kNewState.IsKeyDown(Keys.V) && kOldState.IsKeyUp(Keys.V))
                highscoreName += "v";
            else if (kNewState.IsKeyDown(Keys.W) && kOldState.IsKeyUp(Keys.W))
                highscoreName += "w";
            else if (kNewState.IsKeyDown(Keys.X) && kOldState.IsKeyUp(Keys.X))
                highscoreName += "x";
            else if (kNewState.IsKeyDown(Keys.Y) && kOldState.IsKeyUp(Keys.Y))
                highscoreName += "y";
            else if (kNewState.IsKeyDown(Keys.Z) && kOldState.IsKeyUp(Keys.Z))
                highscoreName += "<";
        }
    }
}
