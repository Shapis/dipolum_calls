using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject m_ContentContainer;
    [SerializeField] private GameObject m_EmployeeInfoContainer;

    [SerializeField] private GameObject m_CallInfoEntry;
    [SerializeField] private GameObject m_EmployeeInfoEntry;

    private RectTransform m_CallInfoContainerRectTransform;
    private RectTransform m_EmployeeInfoContainerRectTransform;
    private void Awake()
    {
        m_CallInfoContainerRectTransform = m_ContentContainer.GetComponent<RectTransform>();
        m_EmployeeInfoContainerRectTransform = m_EmployeeInfoContainer.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ResizeRect();
    }

    private void ResizeRect()
    {
        m_CallInfoContainerRectTransform.sizeDelta =
        new Vector2(m_CallInfoContainerRectTransform.sizeDelta.x,
        (
            10f + (m_ContentContainer.transform.childCount - 1) * (m_CallInfoEntry.gameObject.GetComponent<RectTransform>().sizeDelta.y + 10f)
        ));

        m_EmployeeInfoContainerRectTransform.sizeDelta = new Vector2(m_EmployeeInfoContainerRectTransform.sizeDelta.x,
        (
            10f + (m_EmployeeInfoContainer.transform.childCount - 1) * (m_EmployeeInfoEntry.gameObject.GetComponent<RectTransform>().sizeDelta.y + 10f)
        ));
    }
}
