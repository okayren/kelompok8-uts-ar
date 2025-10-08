// APIPredictor.cs
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Text;

// Kelas untuk struktur data JSON yang dikirim
[Serializable]
public class APIRequestData
{
    public string image_data;
}

// Kelas untuk struktur data JSON yang diterima
[Serializable]
public class APIResponseData
{
    public float confidence;
    public int faces_detected;
    public string prediksi;
}

public class APIPredictor : MonoBehaviour
{
    // Gunakan event agar APIPredictor tidak perlu tahu UIManager secara langsung (arsitektur yg baik)
    public static event Action<string> OnPredictionResult;

    private string apiUrl = "https://aninoore-kelompok8-uts-ar-backend.hf.space/api/predict";

    // Method publik ini akan dipanggil dari UIManager
    public void StartPrediction()
    {
        StartCoroutine(CaptureAndSendFrame());
    }

    private IEnumerator CaptureAndSendFrame()
    {
        // Tunggu hingga akhir frame agar semua rendering selesai
        yield return new WaitForEndOfFrame();

        // Ambil screenshot
        Texture2D screenTexture = ScreenCapture.CaptureScreenshotAsTexture();

        // Encode texture ke format JPG (lebih kecil dari PNG)
        byte[] imageBytes = screenTexture.EncodeToJPG(75); // Kualitas 75%
        
        // Hapus texture dari memori setelah tidak digunakan
        Destroy(screenTexture);

        // Konversi byte array ke string Base64
        string base64String = Convert.ToBase64String(imageBytes);

        // Buat objek request dan isi datanya
        APIRequestData requestData = new APIRequestData();
        requestData.image_data = base64String;

        // Konversi objek request menjadi string JSON
        string jsonRequestBody = JsonUtility.ToJson(requestData);

        // Kirim ke API
        StartCoroutine(PostRequest(jsonRequestBody));
    }

    private IEnumerator PostRequest(string json)
    {
        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            // Kirim request dan tunggu respons
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                // Jika berhasil, parse respons JSON
                string jsonResponse = request.downloadHandler.text;
                APIResponseData responseData = JsonUtility.FromJson<APIResponseData>(jsonResponse);
                
                // Kirim hasil prediksi melalui event
                OnPredictionResult?.Invoke(responseData.prediksi);
            }
            else
            {
                // Jika gagal, kirim pesan error
                Debug.LogError("API Error: " + request.error);
                OnPredictionResult?.Invoke("Error: Gagal terhubung ke server.");
            }
        }
    }
}