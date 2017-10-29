using UnityEngine;
using System.Collections;

public class CoRoutines : MonoBehaviour 
{
    string url = "http://forum.unity3d.com/attachments/logo-titled-png.16698/";

    public GUITexture downloadedTexture;

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Move());
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(MoveEndOfFrame());
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(DownloadStuff());
        }
	}

    IEnumerator Move()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.Translate(0.5f, 0f, 0f);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator MoveEndOfFrame()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.Translate(0.5f, 0f, 0f);
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator DownloadStuff()
    {
        float timeStart = Time.time;
        Debug.Log("Start downloading : " + url);
        WWW www = new WWW(url);
        yield return www;

        Debug.Log("Finish downloading for : " + (Time.time - timeStart));
        downloadedTexture.texture = www.texture;
    }


    /* 
    PHP part
    $testVariable = $_POST["testVariable"];
    print "You entered $testVariable, or backwards: " . strrev($testVariable);
     */

    IEnumerator GetStuffFromSite()
    {
        WWWForm form = new WWWForm();
        form.AddField("testVariable", "string over network");

        WWW www = new WWW(url, form);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Result recieved : " + www.text); // result will be "You entered string over network, or backwards:..."
        }
        else
        {
            Debug.Log("Site returned error : " + www.error); 
        }
    }
}
