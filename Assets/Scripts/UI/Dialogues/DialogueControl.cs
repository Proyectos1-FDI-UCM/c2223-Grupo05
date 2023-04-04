    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{
    private Queue<string> _colaDialogos;
    Text _text;
    [SerializeField] TextMeshProUGUI _textMeshPro;
    [SerializeField] private float _timeCaracter;
    public void MessageActive(Text ObjectText)
    { 
        //animacion cartel
        _text = ObjectText; 
    }
    public void TextActive()
    {
        _colaDialogos.Clear();
        foreach(string _saveText in _text._arrayText)
        {
            _colaDialogos.Enqueue(_saveText);
        }
    }
    public void NextPhrase()
    {
        if(_colaDialogos.Count == 0)
        {
            CloseMessage();
            return;
        }
        string _targetPhrase = _colaDialogos.Dequeue();
        _textMeshPro.text = _targetPhrase;

    }
    IEnumerator ShowCharacters(string showText)
    {
        _textMeshPro.text = "";
        foreach(char caracter in showText.ToCharArray())
        {
            _textMeshPro.text += caracter;
            yield return new WaitForSeconds(_timeCaracter);
        }
    }

    public void CloseMessage()
    {
        //animacion cerrar cartel
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
