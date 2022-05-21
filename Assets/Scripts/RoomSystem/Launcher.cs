using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        //Isso faz com que quando LoadLevel for chamado no Master Client, todos os outros clients da room vão atualizar automaticamente
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        PlayerPrefs.DeleteAll(); 
        Connect();
    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    /// <summary>
    /// Start the connection process.
    /// - If already connected, we attempt joining a random room
    /// - if not yet connected, Connect this application instance to Photon Cloud Network
    /// </summary>
    public void Connect()
    {
        //Checa se tá conectado ou não, se tiver dá join, senão faz a conexão do servidor
        if (PhotonNetwork.IsConnected)
        {
            //PhotonNetwork.JoinOrCreateRoom();
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            //Conecta no servidor
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
