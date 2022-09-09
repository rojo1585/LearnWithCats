using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{
    private PlayerController playerController;
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, Action> wordToAction;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        //Creamos el diccionario
        wordToAction = new Dictionary<string, Action>();
        wordToAction.Add("salta", Jump);
        wordToAction.Add("arriba", Jump);
        wordToAction.Add("brinca", Jump);
        
        
        //Creamos el recocnocimiento de voz y comvertimos las keys en array para us revicion y encendemos el reconocimiento de vox
        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += WordRecognized;
        keywordRecognizer.Start();
    }
    //funcion para invocar la funcion dependiendo de la palabra utilizada
    private void WordRecognized(PhraseRecognizedEventArgs word)
    {
        Debug.Log(word.text);
        wordToAction[word.text].Invoke();
    }
    //metodo para llamar al metodo jump que se encuentra en playercontroller 
    private void Jump(){
        playerController.jump = true;
        playerController.Jump();
        //transform.Translate(0,10,0);
    }


}