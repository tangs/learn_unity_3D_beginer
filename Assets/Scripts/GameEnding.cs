using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitPanel;

    private bool m_IsPlyerAtExit;
    private float m_ExitPanelTimer;

    void Start()
    {
        m_IsPlyerAtExit = false;
        m_ExitPanelTimer = 0;
    }

    void Update()
    {
        if (m_IsPlyerAtExit)
        {
            EndLevel();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlyerAtExit = true;
            m_ExitPanelTimer = 0;
            Debug.Log("trigger.");
        }
    }

    void EndLevel()
    {
        m_ExitPanelTimer += Time.deltaTime;
        exitPanel.alpha = m_ExitPanelTimer / fadeDuration;
        if (m_ExitPanelTimer > fadeDuration + displayImageDuration) {
            Application.Quit();
        }
    }
}
