using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] private int max;
    [SerializeField] private int min;
    [SerializeField] private TextMeshProUGUI guessText;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private WizardsDialog[] dialogs;
    int guess;
    bool wellcomeDialog = true;
    int selectedDialog = 0;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        NextGuess();
        max = max + 1;
    }

    public void onPressHigh()
    {
        min = guess;
        NextGuess();
    }

    public void onPressLow()
    {
        max = guess;
        NextGuess();
    }

    private void NextGuess()
    {
        guess = (max + min) / 2;
        guessText.text = guess.ToString();
        if (dialogs.Length > 0)
        {
            if (wellcomeDialog)
            {
                dialogText.text = dialogs[0].getDialog();
                wellcomeDialog = false;
            }
            else
            {
                int candidateDialog = Random.Range(1, dialogs.Length + 1);
                if (dialogs.Length > 2)
                {
                    while (candidateDialog != selectedDialog)
                        candidateDialog = Random.Range(1, dialogs.Length + 1);
                }
                selectedDialog = candidateDialog;
                dialogText.text = dialogs[selectedDialog].getDialog();
            }
        }
    }
}