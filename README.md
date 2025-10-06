# Unity AR Face Tracking and Gender Recognition

| Nama | NIM   |
| ---- | ----- |
| Karenina Nurmelita Malik   | 2210511089         |
|     |          |
|    |  |
|     |     |
|    |   |

## 📖 Deskripsi Proyek
Aplikasi ini mengimplementasikan Augmented Reality (AR) yang terintegrasi dengan Artificial Intelligence (AI) berbasis platform Unity dan Google ARCore. Aplikasi ini dikembangkan untuk melakukan identifikasi gender dengan mendeteksi wajah pengguna melalui kamera perangkat mobile menggunakan model TensorFlow Lite (.tflite) yang berjalan lokal pada perangkat. Informasi yang disajikan kepada pengguna meliputi:
* Citra wajah pengguna yang terdeteksi
* Label jenis kelamin berdasarkan hasil prediksi
* Skor confidence sebagai indikator prediksi
* Hitungan total individu yang sudah terdeteksi

Visualisasi menggunakan teknologi AR Face Tracking dengan prefab 3D muncul secara langsung pada wajah pengguna sesuai hasil deteksi.

## 🏗️ Arsitektur Sistem
Alur kerja sistem dapat diuraikan sebagai berikut:

* Input Citra (ARCore Face Tracking): Kamera perangkat mobile menangkap wajah pengguna secara langsung dengan memanfaatkan teknologi ARCore.
* Pemrosesan AI (TensorFlow Lite): Frame citra yang ditangkap diteruskan ke model `.tflite`untuk dilakukan klasifikasi jenis kelamin menjadi kategori pria atau wanita.
* Hasil Prediksi: Model memberikan output label gender dan nilai kepercayaan prediksi (contoh: "0.92").
*  Display UI: Informasi klasifikasi disajikan dalam format teks di layar, dilengkapi dengan informasi total wajah yang telah berhasil diidentifikasi.

💡 Mode AI yang digunakan: Model lokal (`.tflite`) memastikan aplikasi dapat beroperasi secara offline dan real-time tanpa memerlukan koneksi internet.

## 🧩 Fitur Utama
| Fitur                                 | Deskripsi                                                              |
| ------------------------------------- | ---------------------------------------------------------------------- |
| **Face Tracking (ARCore)**      | Melacak wajah pengguna secara real-time untuk posisi overlay.          |
|**Gender Classification (TFLite)** | Mengklasifikasikan gender dari input wajah menggunakan model AI lokal. |
|**UI Info & Confidence**           | Menampilkan hasil klasifikasi dan nilai confidence di layar.           |
|**Splash & Loading Screen**                  | Menampilkan logo saat aplikasi pertama kali dijalankan, dilanjutkan animasi loading sebelum kamera aktif.            |
|**Total Detection Counter**        | Menghitung jumlah orang yang sudah terdeteksi selama sesi berlangsung.             |

## 💻 Development Tools
* Unity 6000.2.2f1
* Google ARCore/AR Foundation
* TensorFlow Lite for Unity Plugin
* Android SDK 29
* C# Scripting

## 🔃 Prosedur Mengganti Model AI

## 📝 Alur Penggunaan Aplikasi

## Kesimpulan
