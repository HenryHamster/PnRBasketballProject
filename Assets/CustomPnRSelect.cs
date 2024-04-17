using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomPnRSelect : MonoBehaviour
{
    [SerializeField] private bool _isSelecting;
    private GameObject[] _playerList=new GameObject[3];//stores clickColliders
    private int _cindex;
    [SerializeField] private LayerMask _collidingObjectsLayerMask;
    [SerializeField] private GenerateTriangle _customPnRTriangle;
    public GameObject[] buttonBlockers;
    public GameObject PnRGroundPrefab;
    [SerializeField] private TextMeshProUGUI _customPnRButtonText;
    [SerializeField] private TextMeshProUGUI _customPnRHelperText;
    private Button button;
    private string[] helperTextPrompts = { "Choose the screen player.", "Choose the defender.", "Choose the ballHandler. " };
    // Start is called before the first frame update
    // Update is called once per frame
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    void Update()
    {
        if (_isSelecting)
        {
            if (_playerList[2] != null) { _isSelecting = false; ConfirmPnRSelection(); return; }
            else
            {
                _customPnRHelperText.text = ((_playerList[0] == null) ? helperTextPrompts[0] : ((_playerList[1] == null) ? helperTextPrompts[1] : helperTextPrompts[2]));
                if (Input.GetMouseButton(0))Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction * 100, Color.red, 0.1f);
                
                if (Input.GetMouseButtonDown(0))
                {
                    bool didHit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit rh, 100, _collidingObjectsLayerMask);
                    //Update for Minimap
                    if (CameraToggle.inMinimap) { Physics.Raycast(new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.down), out rh, 100,_collidingObjectsLayerMask); }
                    //Debug.Log("Ray: " + Camera.main.ScreenPointToRay(Input.mousePosition).origin + " " + Camera.main.ScreenPointToRay(Input.mousePosition).direction);
                    Debug.Log("Did Raycast Hit: " + didHit + " Hit: " + rh.transform);
                    if (rh.transform == null) return;
                    Debug.Log("Hit click collider: " + rh.transform.transform.parent.name);
                    for (int i = 0; i < _cindex; i++) { if (_playerList[i] == rh.transform.gameObject) { return; } }
                    rh.transform.GetComponent<MeshRenderer>().material.color = Color.red; //Debug
                    _playerList[_cindex] = rh.transform.gameObject;
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
        _customPnRHelperText.gameObject.SetActive(val);
    }
    public void ConfirmPnRSelection()
    {

        if (_playerList[2] == null) { 
            ResetPnRSelection();
            Time.timeScale = 1;
            return; 
        }
        Time.timeScale = 1;
        GameObject pnr=Instantiate(PnRGroundPrefab, Vector3.zero, Quaternion.identity);
        GroundPnRDisplayHelper gpnr = pnr.GetComponent<GroundPnRDisplayHelper>();
        gpnr.startPlayer = _playerList[0].transform;
        gpnr.blockingPlayer = _playerList[1].transform;
        gpnr.helpingPlayer = _playerList[2].transform;
        //_customPnRTriangle.objectA[DataInterpreter.instance.usedDataIndex] = _playerList[0];
        //_customPnRTriangle.objectB[DataInterpreter.instance.usedDataIndex] = _playerList[1];
        //_customPnRTriangle.objectC[DataInterpreter.instance.usedDataIndex] = _playerList[2];
        ResetPnRSelection();
    }

    public void ResetPnRSelection()
    {

        Time.timeScale = 1;
        _isSelecting = false;
        _playerList = new GameObject[3];
        _customPnRButtonText.text = "Custom PnR Targets";

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(StartPnRSelection);
        UpdateButtonBlockers(false);
    }

    public void StartPnRSelection()
    {
        if (_isSelecting) { ResetPnRSelection(); }
        Time.timeScale = 0;
        _isSelecting = true;
        _playerList = new GameObject[3];
        _customPnRButtonText.text = "Cancel PnR Select";
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ResetPnRSelection);
        UpdateButtonBlockers(true);
    }

}
