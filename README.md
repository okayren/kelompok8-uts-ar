# Unity AR Face Tracking and Gender Recognition

| Nama | NIM   |
| ---- | ----- |
| Karenina Nurmelita Malik   | 2210511089 |
| Dwikhi Deandra Purnianto    | 2210511131 |
| Zah Rainy Raushana Kuwada   | 2210511163 |
| Auliana Maharani    | 2410511017 |

## 📖 Deskripsi Proyek
Aplikasi ini mengimplementasikan Augmented Reality (AR) yang terintegrasi dengan Artificial Intelligence (AI) berbasis platform Unity dan Google ARCore. Aplikasi ini dikembangkan untuk melakukan identifikasi gender dengan mendeteksi wajah pengguna melalui kamera perangkat mobile secara real-time menggunakan model AI yang di hosting dalam backend. Informasi yang disajikan kepada pengguna meliputi:
* Citra wajah pengguna yang terdeteksi
* Label jenis kelamin berdasarkan hasil prediksi

## 🏗️ Arsitektur Sistem
Alur kerja sistem dapat diuraikan sebagai berikut:

* Input Citra (ARCore Face Tracking): Kamera perangkat mobile menangkap wajah pengguna secara langsung dengan memanfaatkan teknologi ARCore.
* Pindai Wajah: Pengguna menekan button "Take Photo", kemudian aplikasi akan mengambil tangkapan layar (screenshot) dari tampilan saat itu.
* Proses di Backend: Citra tangkapan layar dikonversi menjadi format Base64 dan dikirim ke API backend. Selanjutnya, backend akan memproses gambar ini menggunakan model machine learning.
* Tampilan Hasil: Aplikasi menerima respons dari backend dan menampilkan hasil di layar yang mencakup:
  * Prediksi Gender ("Laki-laki" atau "Perempuan")

## 💻 Arsitektur dan Teknologi 
Proyek akan dibagi menjadi dua komponen utama yaitu:
* Front End (Unity)
  * Engine: Unity 6000.2.2f1
  * AR Framework: AR Foundation dengan ARCore (Android).
  * Bahasa: C#
  * Tugas: Menangani rendering AR, deteksi wajah, interaksi UI, dan komunikasi dengan API.
* Backend (API)
  * Framework: Python (Flask)
  * Hosting: Dihosting sebagai layanan web (Hugging Face Spaces)
  * Tugas: Menerima data gambar, melakukan prediksi, dan mengirimkan hasil dalam format JSON.
  
## 🧩 Fitur Utama
| Fitur                                 | Deskripsi                                                              |
| ------------------------------------- | ---------------------------------------------------------------------- |
| **Face Tracking**      | Melacak wajah pengguna secara real-time menggunakan AR Foundation.          |
|**Integrasi API** | Terhubung dengan backend Python untuk pemrosesan citra dan prediksi gender oleh model AI. |
|**UI Info & Confidence**           | Menampilkan hasil klasifikasi dan nilai confidence di layar.           |
|**Splash & Loading Screen**                  | Menampilkan splash screen saat aplikasi pertama kali dijalankan, dilanjutkan animasi loading sebelum kamera aktif.            |

## 🧑‍💻 Panduan Pengaturan dan Build
Berikut adalah langkah-langkah build proyek Unity dalam perangkat mobile yaitu:
### Prasyarat
* Unity Hub telah terinstal.
* Unity Editor 6000.2.2f1
* Package Unity:
  * AR Foundation
* Android SDK terkonfigurasi dalam Unity.

### Langkah-langkah Build
* Clone repository: download atau clone repositori proyek dalam komputer.
* Buka Proyek: Proyek kemudian dibuka melalui Unity Hub.
* Buka Build Settings: Masuk ke `File > Build Settings`
* Pilih Platform: Pilih `Android` dan klik `Switch Platform`
* Konfigurasi Player Settings:
  * Buka `Edit > Project Settings > Player`
  * Di bagian `Other Settings`, pastikan Graphics APIs menyertakan OpenGLES3.
  * Atur Minimum API Level (ubah ke API Level 29).
  * Pastikan Scripting Backend diatur ke IL2CPP dan Target Architectures memuat ARM64.
  * Hubungkan Perangkat: Sambungkan perangkat Android ke komputer dan pastikan USB Debugging telah aktif.
  * Build dan Jalankan: Kembali ke `Build Settings`, klik 'Build and Run`. Pilih lokasi untuk menyimpan file APK dan tunggu hingga proses selesai.

## Konfigurasi Lanjutan

### Mengganti Model (Endpoint API)
Model AI berada dalam sisi backend, untuk menggnati model hanya perlu mengubah URL ednpoint API yang dituju oleh aplikasi Unity.
* Buka Skrip: Membuka file skrip `APIPredictor.cs` di dalam Unity.
* Ubah URL: Cari baris kode dan ganti nilainya dengan URL endpoint API yang baru
  ```private string apiUrl = "https://your-name-backend-url.hf.space/api/predict";```
* Simpan Skrip: Simpan perubahan dalam skrip dan aplikasi akan mengirim permintaan ke backend baru.

## 📈 Pembagian Peran Fungsional

| Nama                      | Peran                                                                            |
| ------------------------- | -------------------------------------------------------------------------------- |
| Dwikhi Deandra Purnianto  | AI Developer & Tester (Integrasi Model TFLite)                                   |
| Karenina Nurmelita Malik  | AR Developer (ARCore Scene & Prefab) & Documentation Lead (README & Laporan PDF) |
| Zah Rainy Raushana Kuwada | AR Developer (ARCore Scene & Prefab) & Presenter (Presentasi)                    |
| Auliana Maharani          | UI Developer (Splash, Loading & Result Panel)                                    |
