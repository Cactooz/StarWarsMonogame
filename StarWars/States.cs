using System;

namespace StarWars
{
    /// <summary>
    /// Current state of the game
    /// Normal, Game, Pause & GameOver
    /// </summary>
    public enum GameState { MainMenu, Game, Pause, GameOver }

    /// <summary>
    /// Current state of button
    /// Normal, Clicked & Hover
    /// </summary>
    public enum ClickableButtonState { Normal, Clicked, Hover }

    /// <summary>
    /// Current state of the cursor
    /// Normal & Click
    /// </summary>
    public enum CursorState { Normal, Click }
}
