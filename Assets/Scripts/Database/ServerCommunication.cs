using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using System;

/// <summary>
/// Classe responsável por comunicação com o back-end via requests http
/// </summary>
public class ServerCommunication : PersistentLazySingleton<ServerCommunication>
{
    #region [Server Communication]

    /// <summary>
    /// This method is used to begin sending request process.
    /// </summary>
    /// <param name="url">API url.</param>
    /// <param name="callbackOnSuccess">Callback on success.</param>
    /// <param name="callbackOnFail">Callback on fail.</param>
    /// <typeparam name="T">Data Model Type.</typeparam>
    private void SendRequest<T>(string url, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        StartCoroutine(RequestCoroutine(url, callbackOnSuccess, callbackOnFail));

    }

    /// <summary>
    /// Coroutine that handles communication with REST server.
    /// </summary>
    /// <returns>The coroutine.</returns>
    /// <param name="url">API url.</param>
    /// <param name="callbackOnSuccess">Callback on success.</param>
    /// <param name="callbackOnFail">Callback on fail.</param>
    /// <typeparam name="T">Data Model Type.</typeparam>
    private IEnumerator RequestCoroutine<T>(string url, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        var www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
            callbackOnFail?.Invoke(www.error);
        }
        else
        {
            Debug.Log("Deu sucesso na chamada");
            Debug.Log(www.downloadHandler.text);
            //ParseResponse(www.downloadHandler.text, callbackOnSuccess, callbackOnFail);
        }
    }

    /// <summary>
    /// This method finishes request process as we have received answer from server.
    /// </summary>
    /// <param name="data">Data received from server in JSON format.</param>
    /// <param name="callbackOnSuccess">Callback on success.</param>
    /// <param name="callbackOnFail">Callback on fail.</param>
    /// <typeparam name="T">Data Model Type.</typeparam>
    private void ParseResponse<T>(string data, UnityAction<T> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        var parsedData = JsonUtility.FromJson<T>(data);
        callbackOnSuccess?.Invoke(parsedData);
    }

    /*public void getGatinhos(UnityAction<string> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        SendRequest(ServerConfig.SERVER_API_URL_FORMAT, callbackOnSuccess, callbackOnFail);
    }*/


    public void GetDeckPerguntas(UnityAction<string> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        SendRequest(ServerConfig.URL_DECK_PERGUNTAS, callbackOnSuccess, callbackOnFail);
    }

    public void GetDeckRespostas(UnityAction<string> callbackOnSuccess, UnityAction<string> callbackOnFail)
    {
        SendRequest(ServerConfig.URL_DECK_RESPOSTAS, callbackOnSuccess, callbackOnFail);
    }

    #endregion
}