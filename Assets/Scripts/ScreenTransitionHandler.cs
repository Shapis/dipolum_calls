using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTransitionHandler : MonoBehaviour
{
    public enum ScreenName
    {
        LoginScreen,
        EmployeeScreen,
        CallScreen,
        SupervisorScreen,
    }
    [Header("Dependencies")]
    [SerializeField] private GameObject m_LoginScreen;
    [SerializeField] private GameObject m_SupervisorScreen;
    [SerializeField] private GameObject m_EmployeeScreen;
    [SerializeField] private GameObject m_Callscreen;
    [SerializeField] private InputHandler m_InputHandler;

    [SerializeField] private PopupMenuController m_CallScreenPopUpMenu;

    [SerializeField] private Button m_BackButton1;
    [SerializeField] private Button m_BackButton2;


    private bool busyTransitioning = false;

    private ScreenName? currentActiveScreen = null;

    // Start is called before the first frame update
    void Start()
    {
        m_SupervisorScreen.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, (Screen.height / 2f) - Screen.height);
        m_EmployeeScreen.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, (Screen.height / 2f) - Screen.height);
        //m_Callscreen.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, (Screen.height / 2f) - Screen.height);
        m_InputHandler.OnCancelPressedEvent += OnCancelPressed;

        m_BackButton1.onClick.AddListener(() => OnCancelPressed(this, EventArgs.Empty));
        m_BackButton2.onClick.AddListener(() => OnCancelPressed(this, EventArgs.Empty));
    }

    private void OnCancelPressed(object sender, EventArgs e)
    {
        Debug.Log(!busyTransitioning && currentActiveScreen != null && currentActiveScreen != ScreenName.LoginScreen);
        if (!busyTransitioning && currentActiveScreen != null && currentActiveScreen != ScreenName.LoginScreen)
        {

            if (m_Callscreen.activeSelf)
            {
                m_Callscreen.GetComponent<PopupMenuController>().CloseMenu();
            }

            TransitionToScreen((ScreenName)currentActiveScreen, ScreenName.LoginScreen, false);
        }

    }

    public void TransitionToScreen(ScreenTransitionHandler.ScreenName previousScreen, ScreenTransitionHandler.ScreenName targetScreen, bool previousGoesUp)
    {
        if (previousScreen == ScreenName.LoginScreen && targetScreen == ScreenName.EmployeeScreen)
        {
            StartCoroutine(MoveScreen(m_LoginScreen, m_EmployeeScreen, 0.8f, true, targetScreen));
        }
        else if (previousScreen == ScreenName.EmployeeScreen && targetScreen == ScreenName.LoginScreen)
        {
            StartCoroutine(MoveScreen(m_EmployeeScreen, m_LoginScreen, 0.8f, false, targetScreen));
        }
        else if (previousScreen == ScreenName.LoginScreen && targetScreen == ScreenName.SupervisorScreen)
        {
            StartCoroutine(MoveScreen(m_LoginScreen, m_SupervisorScreen, 0.8f, true, targetScreen));
        }
        else if (previousScreen == ScreenName.SupervisorScreen && targetScreen == ScreenName.LoginScreen)
        {
            StartCoroutine(MoveScreen(m_SupervisorScreen, m_LoginScreen, 0.8f, false, targetScreen));
        }



    }

    private IEnumerator MoveScreen(GameObject previous, GameObject target, float seconds, bool previousGoesUp, ScreenName targetScreen)
    {
        float timer = 0f;

        busyTransitioning = true;

        Vector2 originalTargetPosition = target.transform.position;
        Vector2 originalPreviousPosition = previous.transform.position;

        target.SetActive(true);

        while ((Vector2)target.transform.position != new Vector2(Screen.width / 2f, (Screen.height / 2f)))
        {
            target.transform.position = Vector2.Lerp(originalTargetPosition, new Vector2(Screen.width / 2f, (Screen.height / 2f)), timer);


            if (previousGoesUp)
            {
                previous.transform.position = Vector2.Lerp(originalPreviousPosition, new Vector2(Screen.width / 2f, (Screen.height / 2f) + Screen.height), timer);
            }
            else
            {
                previous.transform.position = Vector2.Lerp(originalPreviousPosition, new Vector2(Screen.width / 2f, (Screen.height / 2f) - Screen.height), timer);
            }
            timer += Time.deltaTime / seconds;

            yield return null;
        }

        currentActiveScreen = targetScreen;
        busyTransitioning = false;


        GameObject.FindObjectOfType<LoginSolver>().ResetToDefault();

        previous.SetActive(false);

    }
}
