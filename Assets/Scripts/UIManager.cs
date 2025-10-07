// UIManager.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button scanButton;
    [SerializeField] private TMP_Text statusText;

    // We'll add a reference to the thing that does the work (API call)
    // For now, let's pretend it's this manager.
    // [SerializeField] private APICaller apiCaller;

    void Start()
    {
        // Add the listener here, in the manager.
        scanButton.onClick.AddListener(OnScanButtonPressed);
        // Start with the UI hidden
        HideAllUI();
    }

    private void OnScanButtonPressed()
    {
        statusText.text = "Memindai...";
        scanButton.interactable = false;

        // In a real scenario, you'd call a method on another script
        // to capture the screen or camera feed and send it to your API.
        // For example: apiCaller.PerformGenderPrediction();
        
        // Using the mock result from your original script
        Invoke("ShowMockResult", 2f);
    }

    public void ShowUIForFaceDetected()
    {
        statusText.gameObject.SetActive(true);
        statusText.text = "Wajah Terdeteksi! Silakan klik Scan.";
        
        scanButton.gameObject.SetActive(true);
        scanButton.interactable = true;
    }

    public void HideAllUI()
    {
        scanButton.gameObject.SetActive(false);
        statusText.gameObject.SetActive(false);
    }

    // This method would be called by your API handler once it gets a result.
    public void UpdateResultText(string result)
    {
        statusText.text = $"Hasil: {result}";
        scanButton.interactable = true; // Re-enable the button
    }
    
    // Example function from your original script
    private void ShowMockResult()
    {
        UpdateResultText("Male (Contoh)");
    }
}