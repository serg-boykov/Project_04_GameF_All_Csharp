using BoardF;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    /// <summary>
    /// The size of the board for the Unity Game F.
    /// </summary>
    const int size = 4;

    /// <summary>
    /// The Unity Game F.
    /// </summary>
    Game game;

    /// <summary>
    /// Info about the number of game moves.
    /// </summary>
    public Text textMoves;

    /// <summary>
    /// Sounds of game events.
    /// </summary>
    Sound sound;

    // Start is called before the first frame update
    void Start()
    {
        game = new Game(size);
        sound = GetComponent<Sound>();
        HideButtons();
    }

    /// <summary>
    /// Start the Unity Game F.
    /// </summary>
    public void OnStart()
    {
        // Mix the cells.
        game.Start(1000 + System.DateTime.Now.DayOfYear);
        
        ShowButton();

        // Play tht start melogy.
        sound.PlayStart();
    }

    /// <summary>
    /// Event to press the mouse on the cell of the game board.
    /// </summary>
    public void OnClick()
    {
        // if the game has been over.
        if (game.Solved())
        {
            return;
        }

        // Getting the name of the clicked game cell like the game object "00", "01" ...
        string name = EventSystem.current.currentSelectedGameObject.name;

        // Getting the cell coordinates x and y.
        int x = int.Parse(name[..1]);
        int y = int.Parse(name.Substring(1, 1));

        // Play the move melody.
        if (game.PressAt(x, y) > 0)
        {
            sound.PlayMove();
        }

        ShowButton();

        // if the game has been over.
        if (game.Solved())
        {
            textMoves.text = "Game finished in " + game.Moves.ToString() + " moves";
            sound.PlaySolved();
        }
    }

    /// <summary>
    /// Show the digit at the cell with the coordinates x and y.
    /// </summary>
    /// <param name="digit">The digit at the cell.</param>
    /// <param name="x">The coordinate X.</param>
    /// <param name="y">The coordinate Y.</param>
    void ShowDigitAt(int digit, int x, int y)
    {
        string name = "" + x + y;
        var button = GameObject.Find(name);
        var text = button.GetComponentInChildren<Text>();
        text.text = DecToHex(digit);

        // If digit == 0, then the button will not be visible, because Color.clear.
        // (We work with the button Image).
        // This is like a Set Visible in Windows Forms.
        button.GetComponent<Image>().color = (digit > 0) ? Color.white : Color.clear;
    }

    /// <summary>
    /// Hide the cells.
    /// </summary>
    void HideButtons()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                ShowDigitAt(0, x, y);
            }
        }

        textMoves.text = "Welcome to Game F";
    }

    /// <summary>
    /// Show the cells.
    /// </summary>
    void ShowButton()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                ShowDigitAt(game.GetDigitAt(x, y), x, y);
            }
        }

        textMoves.text = game.Moves.ToString() + " moves";
    }

    /// <summary>
    /// Convert the Dec digit to the Hex digit.
    /// </summary>
    /// <param name="digit">The Dec digit.</param>
    /// <returns>The Hex digit.</returns>
    private string DecToHex(int digit)
    {
        if (digit == 0)
        {
            return "";
        }
        else if (digit < 10)
        {
            return digit.ToString();
        }

        return ((char)('A' + digit - 10)).ToString();
    }
}
