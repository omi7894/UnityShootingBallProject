using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] InputField IDInputField;
    [SerializeField] InputField PassInputField;
    [SerializeField] InputField New_IDInputField;
    [SerializeField] InputField New_PassInputField;
    [SerializeField] GameObject TitlePanel;
    [SerializeField] GameObject LoginPanel;
    [SerializeField] GameObject CreateAccountPanel;
    [SerializeField] GameObject FailedPanel;
    [SerializeField] GameObject SuccessPanel;

    public string GetID() { return IDInputField.text; }


    public string LoginUrl;
    public string CreateUrl;

    void Start()
    {
        LoginUrl = "omi7894.cafe24.com/Login.php";
        CreateUrl = "omi7894.cafe24.com/Register.php";

        

    }

    public void LoginBtn()
    {
        StartCoroutine(LoginCo());
    }

    IEnumerator LoginCo()
    {
        Debug.Log(IDInputField.text);
        Debug.Log(PassInputField.text);

        WWWForm form = new WWWForm();
        form.AddField("Input_user", IDInputField.text);
        form.AddField("Input_pass", PassInputField.text);

        WWW webRequest = new WWW(LoginUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        if (webRequest.text.Contains("info"))
        {
            LoginPanel.SetActive(false);
            TitlePanel.SetActive(true);
        }
        else {
            StartCoroutine(Failed());
        }
        DontDestroyOnLoad(IDInputField);
    }
  


    public void OpenLoginBtn() {
        CreateAccountPanel.SetActive(false);
        LoginPanel.SetActive(true);

    }
    public void OpenCreateAccountBtn()
    {

        CreateAccountPanel.SetActive(true);
        LoginPanel.SetActive(false);


    }
    public void CreateAccountBtn()
    {

        StartCoroutine(CreateCo());

    }
    IEnumerator CreateCo()
    {


        WWWForm form = new WWWForm();
        form.AddField("Input_user", New_IDInputField.text);
        form.AddField("Input_pass", New_PassInputField.text);
        form.AddField("Input_info", "hi");

        WWW webRequest = new WWW(CreateUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        if (webRequest.text.Contains("Success"))
        {
            StartCoroutine(Success());
        }
        else {
            StartCoroutine(Failed());
        }



    }
    IEnumerator Success()
    {
        SuccessPanel.SetActive(true);
        yield return new WaitForSeconds(0.9f); 
        SuccessPanel.SetActive(false);
    }
    IEnumerator Failed()
    {
        FailedPanel.SetActive(true);
        yield return new WaitForSeconds(0.9f); 
        FailedPanel.SetActive(false);
    }



    
}

