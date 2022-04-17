using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TEste");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Teste R");
            ServerCommunication.Instance.GetDeckRespostas(trataRespostaComSucesso, trataRespostaComFalha);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Teste R");
            ServerCommunication.Instance.GetDeckPerguntas(trataRespostaComSucesso, trataRespostaComFalha);
        }
    }

    public void trataRespostaComSucesso(string sucesso)
    {
        //Debug.Log("segue o sucesso:" + sucesso);
        Debug.Log($"segue o sucesso: {sucesso}");


    }

    public void trataRespostaComFalha(string sucesso)
    {
        Debug.Log(sucesso);

    }
}
