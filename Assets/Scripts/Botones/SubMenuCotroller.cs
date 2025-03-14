using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SubMenuCotroller : MonoBehaviour
{
    public GameObject panelL;
    public GameObject panelR;
    public InputActionProperty acLB;
    public InputActionProperty acRB;

    // Start is called before the first frame update
    void Start()
    {
        acLB.action.Enable();
        acRB.action.Enable();
        acLB.action.performed += acl => ToggleMenuL();
        acRB.action.performed += acr => ToggleMenuR();
    }
    public void ToggleMenuL()
    {
        panelL.SetActive(!panelL.activeSelf);
    }
    public void ToggleMenuR()
    {
        panelR.SetActive(!panelR.activeSelf);
    }
}
