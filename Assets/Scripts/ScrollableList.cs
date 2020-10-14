using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private GameObject m_ContentContainer;

    [SerializeField] private GameObject m_CallInfoEntry;

    private RectTransform m_RectTransform;
    private void Awake()
    {
        m_RectTransform = m_ContentContainer.GetComponent<RectTransform>();
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
        m_RectTransform.sizeDelta =
        new Vector2(m_RectTransform.sizeDelta.x,
        (
            10f + (m_ContentContainer.transform.childCount - 1) * (m_CallInfoEntry.gameObject.GetComponent<RectTransform>().sizeDelta.y + 10f)
        ));
    }
}
