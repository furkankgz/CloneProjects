using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberController : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private NumberColorData _colorData;

    public int Number { 
        get => _number; 

        set
        {
            int valuePrint = (int)Mathf.Pow(2, value); // 2'nin kuvvetlerini yaz
            _text.SetText(valuePrint.ToString());

            _spriteRenderer.color = _colorData._numberColors[value - 1]; // index'ler 0'dan baþladýðý için value - 1 olarak tanýmladýk
            _number = value;
        }
    } // number her deðiþtiðinde text ve sprite deðiþmesi için
    private int _number = 1;

    private void Start()
    {
        Number = _number;
    }
}
