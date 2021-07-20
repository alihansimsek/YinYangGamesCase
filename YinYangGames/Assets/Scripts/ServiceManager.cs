using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using System;

public class ServiceManager : MonoBehaviour
{
	private GameManagerScript gms;
	// Use this for initialization
	void Start()
	{
		gms = gameObject.GetComponent<GameManagerScript>();
		StartCoroutine(getUnityWebRequest(gms.playerID));
	}

	public void increaseScore(string playerID, string score) {
		StartCoroutine(postUnityWebRequest(playerID, score));
	}

	IEnumerator getUnityWebRequest(string playerID)
	{
		UnityWebRequest www = UnityWebRequest.Get("https://localhost:44382/api/values/" + playerID);
		yield return www.Send();
		string[] split = www.downloadHandler.text.Split(':');
		string trimmed = split[split.Length - 1].Trim('}', '\"');
		int webScore = int.Parse(trimmed);
		if (webScore > 0)
			gms.Score = webScore;
        else
			gms.Score = 0;

		if (www.isNetworkError || www.isHttpError)
		{
			Debug.Log(www.error);
		}
		else
		{
			Debug.Log(www.downloadHandler.text);
		}
	}

	IEnumerator postUnityWebRequest(string playerID, string score)
	{
		///<summary>
		/// Post using UnityWebRequest class
		/// </summary>
		var jsonString = "{\"id\":\""+playerID+"\",\"score\":\""+score+"\"}";
		byte[] byteData = System.Text.Encoding.ASCII.GetBytes(jsonString.ToCharArray());

		UnityWebRequest unityWebRequest = new UnityWebRequest("https://localhost:44382/api/values", "POST");
		unityWebRequest.uploadHandler = new UploadHandlerRaw(byteData);
		unityWebRequest.SetRequestHeader("Content-Type", "application/json");
		yield return unityWebRequest.Send();

		if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
		{
			Debug.Log(unityWebRequest.error);
		}
		else
		{
			Debug.Log("Form upload complete! Status Code: " + unityWebRequest.responseCode);
		}
	}
}