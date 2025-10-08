// UIManager.cs (Dengan State Management)
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // 1. Definisikan state yang mungkin untuk UI kita
    private enum UIState
    {
        Hidden,
        FaceDetected,
        Scanning,
        ShowingResult
    }

    [SerializeField] private Button scanButton;
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private APIPredictor apiPredictor;

    // 2. Buat variabel untuk menyimpan state saat ini
    private UIState currentState;

    void OnEnable()
    {
        APIPredictor.OnPredictionResult += HandlePredictionResult;
    }

    void OnDisable()
    {
        APIPredictor.OnPredictionResult -= HandlePredictionResult;
    }

    void Start()
    {
        scanButton.onClick.AddListener(OnScanButtonPressed);
        HideAllUI();
    }

    private void OnScanButtonPressed()
    {
        // 3. Ubah state menjadi Scanning saat tombol ditekan
        currentState = UIState.Scanning; 
        statusText.text = "Memindai...";
        scanButton.interactable = false;
        apiPredictor.StartPrediction();
    }

    private void HandlePredictionResult(string result)
    {
        // 4. Ubah state menjadi ShowingResult saat hasil diterima
        currentState = UIState.ShowingResult; 
        string formattedResult = char.ToUpper(result[0]) + result.Substring(1);
        UpdateResultText(formattedResult);
    }
    
    public void ShowUIForFaceDetected()
    {
        // 5. INI BAGIAN PENTING:
        // Jangan lakukan apa pun jika UI sedang sibuk memindai atau menampilkan hasil.
        if (currentState == UIState.Scanning || currentState == UIState.ShowingResult)
        {
            return; // Abaikan panggilan ini
        }

        // Jika tidak sibuk, lanjutkan seperti biasa dan set state-nya
        currentState = UIState.FaceDetected;
        statusText.gameObject.SetActive(true);
        statusText.text = "Wajah Terdeteksi! Silakan klik Scan.";
        scanButton.gameObject.SetActive(true);
        scanButton.interactable = true;
    }

    public void HideAllUI()
    {
        // Set state menjadi Hidden saat UI disembunyikan
        currentState = UIState.Hidden;
        scanButton.gameObject.SetActive(false);
        statusText.gameObject.SetActive(false);
    }

    public void UpdateResultText(string result)
    {
        statusText.text = $"Hasil Prediksi: {result}";
        scanButton.interactable = true;
    }
}