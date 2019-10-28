using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Wizard Dialog")]
public class WizardsDialog : ScriptableObject
{
    [TextArea(5,10)][SerializeField] private string dialog;

    public string getDialog() { return dialog; }
}
