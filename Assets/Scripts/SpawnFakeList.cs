using UnityEngine;

public class SpawnFakeList : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Transform m_CallInfoEntry;

    [Header("Settings")]
    [SerializeField] private int m_FakeEntryCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_FakeEntryCount; i++)
        {
            Transform temp = Instantiate(m_CallInfoEntry, new Vector3(m_CallInfoEntry.position.x, (m_CallInfoEntry.position.y) - (i * (Screen.height / 6f))), Quaternion.identity, m_CallInfoEntry.transform.parent);
            temp.gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }


}
