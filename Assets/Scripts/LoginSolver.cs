using UnityEngine;
using TMPro;

public class LoginSolver : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TMP_InputField m_Login;
    [SerializeField] private TMP_InputField m_Password;
    [SerializeField] private ScreenTransitionHandler m_ScreenTransitionHandler;
    private bool isLoggedIn = false;


    // Start is called before the first frame update
    void Start()
    {
        m_Login.contentType = TMP_InputField.ContentType.EmailAddress;
        m_Password.contentType = TMP_InputField.ContentType.Password;

        m_Password.onTextSelection.AddListener((i, o, a) => ClearText());
    }

    // Update is called once per frame
    void Update()
    {
        LoginToRightPage();
    }

    private void ClearText()
    {
        //m_Password.text = " ";
    }

    private void LoginToRightPage()
    {
        if (m_Password.text == "admin" && isLoggedIn == false && m_Login.text == "funcionario@dipolum.com")
        {
            isLoggedIn = true;
            m_ScreenTransitionHandler.TransitionToScreen(ScreenTransitionHandler.ScreenName.LoginScreen, ScreenTransitionHandler.ScreenName.EmployeeScreen, true);
        }
        else if (m_Password.text == "admin" && isLoggedIn == false && m_Login.text == "supervisor@dipolum.com")
        {
            isLoggedIn = true;
            //m_ScreenTransitionHandler.TransitionToScreen(ScreenTransitionHandler.ScreenName.LoginScreen, ScreenTransitionHandler.ScreenName.EmployeeScreen, true);
            m_ScreenTransitionHandler.TransitionToScreen(ScreenTransitionHandler.ScreenName.LoginScreen, ScreenTransitionHandler.ScreenName.SupervisorScreen, true);
        }
    }

    internal void ResetToDefault()
    {
        isLoggedIn = false;
        m_Password.text = "********";
    }
}
