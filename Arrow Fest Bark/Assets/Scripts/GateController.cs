using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using Random = UnityEngine.Random;


public class GateController : MonoBehaviour
{
    private ArrowMultiplier arrow_multiplier;
    private TextMeshProUGUI _text;
    private int rand_;

    private void Awake()
    {
        arrow_multiplier = GameObject.Find("ArrowController").GetComponent<ArrowMultiplier>();
        
        

    }
    
    private void Start()
    {
        string text_dir = gameObject.transform.parent
            ? gameObject.transform.parent.name + "/" + gameObject.name + "/Canvas/No"
            : gameObject.name + "/Canvas/No";
        _text = GameObject.Find(text_dir).GetComponent<TextMeshProUGUI>();
        
        switch (transform.tag)
        {
            case "PlusGate":
                rand_ = Random.Range(10, 40);
                Debug.LogError(rand_);
                _text.text = "+" + rand_.ToString();
                break;
            case "MinusGate":
                rand_ = Random.Range(5, 20);
                Debug.LogError(rand_);
                _text.text = "-" + rand_.ToString();
                break;
            case "MultiplyGate":
                rand_ = Random.Range(1, 6);
                Debug.LogError(rand_);
                _text.text = "" + rand_.ToString();
                break;
            case "DivideGate":
                rand_ = Random.Range(1, 5);
                Debug.LogError(rand_);
                _text.text = "/" + rand_.ToString();
                break;
            default:
                throw new ArgumentException("error verdi");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            
            arrow_multiplier.Calculations(transform.tag, rand_);
            Behaviour.Destroy(this);
        }
        
    }
}
