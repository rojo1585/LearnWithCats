using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerLetters : MonoBehaviour
{
    [SerializeField] private GameObject answerPanel;
    [SerializeField] private GameObject panelPrefab;
    


    void Start()
    {
        //MakePanelsAnswer();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
        }
    }

    private void MakePanelsAnswer(){
        for (int i = 0; i < ImagesController.Instance.selectWord.Length; i++)
        {
            GameObject panel  = Instantiate(panelPrefab);
            panel.transform.SetParent(transform);
        }
        //panel.transform.scale = new Vector3(1,1,0);
    }
}
