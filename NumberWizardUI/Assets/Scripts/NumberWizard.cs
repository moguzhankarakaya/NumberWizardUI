using TMPro;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] private int max;
    [SerializeField] private int min;
    [SerializeField] private TextMeshProUGUI guessText;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private WizardsDialog[] dialogs;
    [SerializeField] private WizardsDialog[] endGameDialogs;

    bool wellcomeDialog = true;
    int selectedDialog  = 0;
    int prevGuess       = 0;
    int guess           = 0;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        NextGuess();
    }

    public void onPressHigh()
    {
        min = guess + 1;
        if (min > max)
            min = max;
        NextGuess();
    }

    public void onPressLow()
    {
        max = guess - 1;
        if (max < min)
            max = min;
        NextGuess();
    }

    private void NextGuess()
    {
        prevGuess      = guess;
        guess          = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
        loadWizardDialog();
    }

    private void loadWizardDialog()
    {
        if (prevGuess == guess)
        {
            if (endGameDialogs.Length > 0)
            {
                int candidateDialog = selectedDialog;
                do
                {
                    candidateDialog = Random.Range(0, endGameDialogs.Length);
                }
                while (selectedDialog == candidateDialog);

                selectedDialog = candidateDialog;
                dialogText.text = endGameDialogs[selectedDialog].getDialog();
            }
            return;
        }

        if (dialogs.Length > 0)
        {
            if (wellcomeDialog || dialogs.Length == 1)
            {
                dialogText.text = dialogs[0].getDialog();
                wellcomeDialog = false;
            }
            else if (dialogs.Length == 2)
            {
                dialogText.text = dialogs[1].getDialog();
            }
            else
            {
                int candidateDialog = selectedDialog;

                do
                {
                    candidateDialog = Random.Range(1, dialogs.Length);
                }
                while (selectedDialog == candidateDialog);

                selectedDialog = candidateDialog;
                dialogText.text = dialogs[selectedDialog].getDialog();
            }
            return;
        }
    }
}