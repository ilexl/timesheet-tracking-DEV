using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Window : MonoBehaviour
{
    [SerializeField] private WindowManager wm; // window manager show in editor
    public bool showOnStart = false;

#if UNITY_EDITOR
    private void OnValidate() // on change get the manager
    {
        wm = GetComponentInParent<WindowManager>();
    }
#endif

    // Start is called before the first frame update
    void Start()
    {
        // ensure wm exists
        if(wm == null)
        {
            wm = GetComponentInParent<WindowManager>();
        }
        gameObject.SetActive(showOnStart); // show or hide on start
    }
    
    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Window))]
public class Window_EDITOR : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Show THIS Window"))
        {
            ((Window)target).Show();
        }
        if (GUILayout.Button("Hide THIS Window"))
        {
            ((Window)target).Hide();
        }
    }
}
#endif