using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CallScreen : MonoBehaviour
{
    [SerializeField] private Button m_DropCallButton;
    [SerializeField] private TextMeshProUGUI m_DurationText;

    public float CallStartingTime { get; set; } = 0f;
    // Start is called before the first frame update
    void Start()
    {
        m_DropCallButton.onClick.AddListener(() => m_DropCallButton.gameObject.transform.parent.GetComponent<PopupMenuController>().CloseMenu());
    }

    // Update is called once per frame
    void Update()
    {
        m_DurationText.text = new TimeFormatHandler().FormatTime((Time.time - CallStartingTime));
    }
}
