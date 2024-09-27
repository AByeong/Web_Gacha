using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class GoogleData
{

    public string order, result, msg, value;
}


public class GoogleSheetManager : MonoBehaviour
{

    private static GoogleSheetManager instance;
    public static GoogleSheetManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }//싱글톤을 위한 부분



    public string URL;//구글 스프레드 시트 배포 URL.
    public InputField IDInput, PasswordInput;
    public GoogleData GD;

    string id, pass;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);

        }
        else
        {

            Destroy(this.gameObject);
        }//싱글톤으로 세팅하기 위한 부분
    }

   

    bool SetIDPass()
    {

        id = IDInput.text.Trim();
        pass = PasswordInput.text.Trim();

        if (id == "" || pass == "") return false;
        else return true;
    }

    public void Register()
    {
        if (!SetIDPass())
        {
            print("아이디 또는 비밀번호가 비었습니다.");return;
        }

        WWWForm form = new WWWForm();
        form.AddField("order", "register");
        form.AddField("id", id);
        form.AddField("pass", pass);

        StartCoroutine(Post(form));
    }


    public void Login()
    {

        if (!SetIDPass())
        {
            print("아이디 또는 비밀번호가 비었습니다."); return;
        }

        WWWForm form = new WWWForm();
        form.AddField("order", "login");
        form.AddField("id", id);
        form.AddField("pass", pass);

        StartCoroutine(Post(form));
    }

    private void OnApplicationQuit()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "logout");

        StartCoroutine(Post(form));
    }

    public void SetValue(string valuetoset)
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "setvalue");
        form.AddField("value", valuetoset);

        StartCoroutine(Post(form));

    }

    public void GetValue()
    {
        WWWForm form = new WWWForm();
        form.AddField("order", "getvalue");

        StartCoroutine(Post(form));


    }


    void Response(string json)
    {
        if (string.IsNullOrEmpty(json)) return;

        GD = JsonUtility.FromJson<GoogleData>(json);

        if (GD.result == "ERROR")
        {
            print(GD.order + "을 실행할 수 없습니다. 에러 메시지 : " + GD.msg);
            return;
        }

        print(GD.order + "을 실행했습니다. 메시지 : " + GD.msg);

        /*if (GD.order == "getValue")
        {
            TextGet.text = GD.value;
        }*/
    }

    IEnumerator Post(WWWForm form)
    {
        using(UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {

            yield return www.SendWebRequest();

            if (www.isDone) Response(www.downloadHandler.text);
            else print("웹의 응답이 없습니다.");

        }
    }
}
