# Bomb Defusal AR–VR

![Unity](https://img.shields.io/badge/Unity-6.6-000000?logo=unity&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Android-3DDC84?logo=android&logoColor=white)
![AR](https://img.shields.io/badge/AR-AR%20Foundation-5C2D91)
![Pipeline](https://img.shields.io/badge/Render%20Pipeline-URP-0A84FF)
![Status](https://img.shields.io/badge/Status-Dalam%20Pengembangan-orange)

**Bomb Defusal AR–VR** adalah proyek Unity untuk Android yang menggabungkan deteksi marker AR dengan simulasi ruang virtual 3D. Pengguna memindai marker untuk menampilkan bom dan virtual button, lalu masuk ke simulasi penjinakan bom dengan navigasi, spatial audio, dan interaksi berbasis fisika.

> [!IMPORTANT]
> Istilah “VR” pada proyek ini mengacu pada simulasi ruang virtual 3D di perangkat Android, bukan aplikasi headset VR mandiri.

## Informasi Proyek

| Informasi | Nilai |
|---|---|
| 🎮 Nama proyek | **Bomb Defusal AR–VR / bombAR** |
| 🧰 Unity | **Unity 6.6 (6000.6.0f1)** |
| 📱 Target | **Android** |
| 🧩 Teknologi | **AR Foundation, URP, C#** |
| 🗺️ Lingkungan | **Bombsite B** |
| 🚧 Status | ![Development](https://img.shields.io/badge/Dalam%20Pengembangan-F59E0B?style=flat-square) |
| 📄 Storyboard | [STORYBOARD APLIKASI BOMB DEFUSAL AR–VR.pdf](./STORYBOARD%20APLIKASI%20BOMB%20DEFUSAL%20AR%E2%80%93VR.pdf) |

## Status Tahapan Storyboard

Keterangan status:

- ![Available](https://img.shields.io/badge/Tersedia-22C55E?style=flat-square) fitur sudah ada di proyek.
- ![Progress](https://img.shields.io/badge/Dalam%20Pengembangan-F59E0B?style=flat-square) struktur atau aset awal sudah tersedia, tetapi belum final.
- ![Planned](https://img.shields.io/badge/Direncanakan-64748B?style=flat-square) masuk roadmap dan belum diimplementasikan penuh.
- Fitur AR tetap perlu divalidasi melalui build pada perangkat Android.

| Tahap | Alur | Deskripsi | Status |
|:---:|---|---|:---:|
| 1 | Deteksi Marker Bom | Kamera mengenali dan melacak marker bom. | ![Available](https://img.shields.io/badge/Tersedia-22C55E?style=flat-square) |
| 2 | Bom dan Virtual Button Muncul | Model bom 3D dan virtual button tampil di atas marker. | ![Available](https://img.shields.io/badge/Tersedia-22C55E?style=flat-square) |
| 3 | Tekan Virtual Button Mulai | Virtual button menjalankan perpindahan dari AR ke ruang simulasi. | ![Available](https://img.shields.io/badge/Tersedia-22C55E?style=flat-square) |
| 4 | Masuk ke Ruang Virtual | Tampilan kamera AR diganti dengan lingkungan Bombsite B 3D. | ![Progress](https://img.shields.io/badge/Dalam%20Pengembangan-F59E0B?style=flat-square) |
| 5 | Bergerak Menggunakan Analog | Pemain menjelajahi ruang menggunakan analog virtual. | ![Planned](https://img.shields.io/badge/Direncanakan-64748B?style=flat-square) |
| 6 | Mencari Bom melalui Spatial Audio | Arah dan volume bunyi beep berubah berdasarkan posisi dan jarak. | ![Planned](https://img.shields.io/badge/Direncanakan-64748B?style=flat-square) |
| 7 | Mengambil Tang | Pemain mendekati tang dan menekan tombol **Ambil**. | ![Planned](https://img.shields.io/badge/Direncanakan-64748B?style=flat-square) |
| 8 | Memilih Kabel | Tang diarahkan ke kabel dan target mendapatkan highlight. | ![Planned](https://img.shields.io/badge/Direncanakan-64748B?style=flat-square) |
| 9 | Memotong Kabel | Tombol **Potong** memicu interaksi collider dan fisika kabel. | ![Planned](https://img.shields.io/badge/Direncanakan-64748B?style=flat-square) |
| 10 | Hasil Berhasil atau Gagal | Kabel benar menghentikan timer; kabel salah memicu efek ledakan. | ![Planned](https://img.shields.io/badge/Direncanakan-64748B?style=flat-square) |
| 11 | Ulangi atau Kembali ke AR | Pengguna mengulang simulasi atau kembali memindai marker. | ![Planned](https://img.shields.io/badge/Direncanakan-64748B?style=flat-square) |

## Alur Pengguna

```text
Buka aplikasi
    ↓
Arahkan kamera ke marker bom
    ↓
Bom 3D dan Virtual Button muncul
    ↓
Tekan tombol Mulai
    ↓
Masuk ke ruang virtual Bombsite B
    ↓
Jelajahi ruang → temukan bom → ambil tang → potong kabel
    ↓
Berhasil / gagal → ulangi atau kembali ke AR
```

## Struktur Utama Proyek

```text
Assets/
├── Ar/ReferenceImages/              # Reference Image Library AR
├── Art/
│   ├── Markers/                     # Gambar marker
│   ├── Models/Bomb/                 # Model bom
│   └── Models/Environment/          # Model Bombsite B
├── Prefabs/AR/                      # Prefab objek AR
├── Scenes/
│   ├── Scenes/SampleScene.unity     # Scene AR
│   └── Virtual/VirtualRoom.unity    # Scene ruang virtual
└── Scripts/Runtime/
    ├── AR/                           # Deteksi virtual button
    └── Transition/                   # Transisi AR ke ruang virtual
```

> [!NOTE]
> File `.meta` adalah bagian penting dari referensi aset Unity dan harus ikut disimpan di Git.

## Persiapan Proyek

1. Clone fork proyek ini.
2. Buka folder proyek melalui Unity Hub menggunakan **Unity 6.6 (6000.6.0f1)**.
3. Pastikan Android Build Support, Android SDK, NDK, dan OpenJDK terpasang.
4. Tunggu Unity selesai mengimpor paket dan aset.
5. Periksa Console dan selesaikan error kompilasi sebelum menjalankan scene.

## Konfigurasi Scene

Buka **File → Build Profiles → Scene List**, lalu pastikan urutannya:

| Build Index | Scene | Fungsi |
|:---:|---|---|
| `0` | `Assets/Scenes/Scenes/SampleScene.unity` | Kamera, marker, bom, dan virtual button AR |
| `1` | `Assets/Scenes/Virtual/VirtualRoom.unity` | Simulasi ruang virtual Bombsite B |

Kedua scene harus dicentang. Transisi tahap 3 membutuhkan `VirtualRoom` berada di Scene List.

## Menjalankan dan Build Android

1. Hubungkan perangkat Android dan aktifkan **USB debugging**.
2. Buka `SampleScene.unity`.
3. Pilih **File → Build Profiles → Android** dan pastikan profil Android aktif.
4. Gunakan **Build and Run** untuk memasang aplikasi langsung ke perangkat.
5. Izinkan akses kamera ketika aplikasi meminta permission.
6. Arahkan kamera ke marker yang tersimpan di `Assets/Art/Markers/Bomb.png`.

> [!WARNING]
> Kamera AR dan deteksi marker tidak dapat divalidasi sepenuhnya hanya melalui Game View di Editor. Pengujian akhir harus dilakukan pada perangkat Android yang mendukung AR.

## Checklist Pengujian

- [ ] Proyek terbuka tanpa error merah di Console.
- [ ] `SampleScene` dan `VirtualRoom` aktif di Scene List.
- [ ] Permission kamera muncul pada perangkat Android.
- [ ] Marker dapat dikenali dan dilacak.
- [ ] Bom serta virtual button tampil stabil di atas marker.
- [ ] Tombol Mulai membuka `VirtualRoom`.
- [ ] Bombsite B tampil dengan material dan tekstur yang benar.
- [ ] Tahap 5–11 diuji setelah masing-masing fitur selesai dibuat.

## Alur Git untuk Fork

```bash
git remote -v
git fetch upstream
git switch -c feature/nama-fitur
git add Assets Packages ProjectSettings README.md
git commit -m "feat: jelaskan perubahan"
git push -u origin feature/nama-fitur
```

- `origin`: fork milik pengembang.
- `upstream`: repositori sumber milik tim.
- Hindari memasukkan `Library`, `Temp`, hasil build, konfigurasi MCP, atau kredensial lokal.
- Tinjau `git status` sebelum commit agar hanya file proyek yang masuk.

## Dokumentasi

Storyboard lengkap dapat dibuka melalui [dokumen PDF proyek](./STORYBOARD%20APLIKASI%20BOMB%20DEFUSAL%20AR%E2%80%93VR.pdf). Dokumen PDF diperbolehkan masuk ke repositori sebagai dokumentasi proyek.

## Lisensi Aset dan Audio

Pastikan model, tekstur, marker, musik, dan efek suara mempunyai izin penggunaan yang jelas. Jangan menyertakan audio hasil ekstraksi dari game komersial; gunakan audio buatan sendiri atau aset berlisensi agar proyek aman dibagikan dan dipublikasikan.

