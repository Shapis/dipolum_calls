using UnityEngine;
using UnityEngine.UI;

public class SpawnFakeList : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Transform m_CallInfoEntry;
    [SerializeField] private Transform m_employeeInfoEntry;
    [SerializeField] private PopupMenuController m_CallScreenPopUpMenu;

    [Header("Settings")]
    [SerializeField] private int m_FakeEntryCount = 10;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < m_FakeEntryCount; i++)
        {
            Transform temp = Instantiate(m_CallInfoEntry, new Vector3(m_CallInfoEntry.position.x, (m_CallInfoEntry.position.y) - (i * (Screen.height / 6f))), Quaternion.identity, m_CallInfoEntry.transform.parent);


            if (Random.Range(0, 2) > 0)
            {
                temp.gameObject.GetComponentInChildren<Button>().gameObject.GetComponent<Image>().color = Color.red;
            }
            else
            {
                temp.gameObject.GetComponentInChildren<Button>().gameObject.GetComponent<Image>().color = Color.green;
                temp.gameObject.GetComponentInChildren<Button>().onClick.AddListener(() =>
                {
                    m_CallScreenPopUpMenu.OpenMenu();
                    GameObject.FindObjectOfType<CallScreen>().CallStartingTime = Time.time;
                });
            }


            temp.gameObject.SetActive(true);
        }


        for (int i = 0; i < m_FakeEntryCount; i++)
        {
            Transform temp = Instantiate(m_employeeInfoEntry, new Vector3(m_employeeInfoEntry.position.x, (m_employeeInfoEntry.position.y) - (i * (Screen.height / 6f))), Quaternion.identity, m_employeeInfoEntry.transform.parent);
            temp.gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }


}
