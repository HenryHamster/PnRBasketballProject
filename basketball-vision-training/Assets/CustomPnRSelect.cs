using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomPnRSelect : MonoBehaviour
{
    [SerializeField] private bool _isSelecting;
    private GameObject[] _playerList=new GameObject[3];//stores clickColliders
    private int _cindex;
    [SerializeField] private LayerMask _collidingObjectsLayerMask;
    [SerializeField] private GenerateTriangle _customPnRTriangle;
    public GameObject[] buttonBlockers;
    [SerializeField] private TextMeshProUGUI _customPnRButtonText;
    // Start is called before the first frame update
    // Update is called once per frame
    
    void Update()
    {
        if (_isSelecting)
        {
            if (_playerList[2] != null) { _isSelecting = false; ConfirmPnRSelection(); return; }
            else
            {
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit rh, 100,_collidingObjectsLayerMask);
                if (rh.collider == null) return;
                Debug.Log(rh.collider.transform.parent.name);
                if (Input.GetMouseButtonDown(0))
                {
                    for(int i = 0; i < _cindex; i++) { if (_playerList[i] == rh.collider.gameObject) { return; } }
                    rh.collider.GetComponent<MeshRenderer>().material.color = Color.red; //Debug
                    _playerList[_cindex] = rh.collider.gameObject;
                    _cindex++;
                }
            }
        }
    }
    public void UpdateButtonBlockers(bool val)
    {

        for (int i = 0; i < buttonBlockers.Length; i++)
        {
            buttonBlockers[i].SetActive(val);
        }
    }
    public void ConfirmPnRSelection()
    {
        
        Time.timeScale = 1;
        _customPnRTriangle.objectA = _playerList[0];
        _customPnRTriangle.objectB = _playerList[1];
        _customPnRTriangle.objectC = _playerList[2];
        ResetPnRSelection();
    }

    public void ResetPnRSelection()
    {

        Time.timeScale = 1;
        _isSelecting = false;
        _playerList = new GameObject[3];
        _customPnRButtonText.text = "Custom PnR Targets";
        UpdateButtonBlockers(false);
    }

    public void StartPnRSelection()
    {
        if (_isSelecting) { ResetPnRSelection(); }
        Time.timeScale = 0;
        _isSelecting = true;
        _playerList = new GameObject[3];
        _customPnRButtonText.text = "Cancel PnR Select";
        UpdateButtonBlockers(true);
    }

}
