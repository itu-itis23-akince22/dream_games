using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class MovesManager : Singleton<MovesManager>
{
    [SerializeField] private TextMeshProUGUI movesText;
    private int moves;
    public int Moves => moves;
    public Action OnMovesFinished;
    public void Init(int moves)
    {
        this.moves = moves;
        movesText.text = moves.ToString();
    }

    public async Task DecreaseMovesAsync()
    {
        moves--;

        if (moves <= 0)
        {
            this.GetComponent<TouchManager>().enabled = false; 
            moves = 0;
            movesText.text = moves.ToString();
            await Task.Delay(TimeSpan.FromSeconds(1));
            OnMovesFinished?.Invoke();
        }

        movesText.text = moves.ToString();
    }
}