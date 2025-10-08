using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIController : MonoBehaviour
{
    [Header("UI References")]
    public RawImage rawImageResult;
    public TextMeshProUGUI textGender;
    public TextMeshProUGUI textConfidence;
    public TextMeshProUGUI textTotalDetected;
    public Button buttonInputPhoto; // Tambahkan referensi untuk tombol Input Photo
    public Button buttonTakePhoto;

    void Start()
    {
        // Set default text
        textGender.text = "Gender: -";
        textConfidence.text = "Confidence: -";
        textTotalDetected.text = "Total Detected: -";

        // Tambahkan listener untuk kedua tombol
        buttonInputPhoto.onClick.AddListener(OnInputPhotoClicked); // Listener baru
        buttonTakePhoto.onClick.AddListener(OnTakePhotoClicked);
    }

    void OnInputPhotoClicked()
    {
        Debug.Log("Input Photo clicked! (Membuka galeri/file explorer)");
        // TODO: Tambahkan kode untuk memilih foto dari galeri/file explorer di sini
    }

    void OnTakePhotoClicked()
    {
        Debug.Log("Take Photo clicked! (Membuka kamera)");
        // TODO: Tambahkan kode panggil kamera di sini
    }

    // Fungsi untuk update UI setelah klasifikasi
    public void UpdateResult(Texture2D photo, string gender, float confidence, int total)
    {
        rawImageResult.texture = photo;
        textGender.text = "Gender: " + gender;
        textConfidence.text = "Confidence: " + confidence.ToString("F2");
        textTotalDetected.text = "Total Detected: " + total;
    }
}