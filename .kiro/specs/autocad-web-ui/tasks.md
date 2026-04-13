# Görevler — AutoCAD Web UI Dönüşümü

## Görev Listesi

- [x] 1. THEME sabitleri ve yeni tip tanımları ekle
  - [x] 1.1 THEME renk objesi ekle (bg, panelBg, ribbonBg, canvasBg, statusBg, border, text, textSecondary, accent vb.)
  - [x] 1.2 RibbonTabId, RibbonToolDef, RIBBON_GROUPS sabitlerini ekle
  - [x] 1.3 Yeni state değişkenlerini ekle (activeRibbonTab, leftPanelCollapsed, objPropsCollapsed, layerSectionCollapsed, modelLayoutTab)

- [x] 2. QuickAccessToolbar bileşenini oluştur
  - [x] 2.1 QuickAccessToolbar fonksiyon bileşenini dosya içinde tanımla (Yeni, Kaydet, Aç, Undo, Redo, DXF, SVG, JSON, "ASNCAD" başlık)
  - [x] 2.2 Undo/Redo butonlarını canUndo/canRedo state'ine göre devre dışı göster

- [x] 3. RibbonToolbar bileşenini oluştur
  - [x] 3.1 RibbonToolbar fonksiyon bileşenini dosya içinde tanımla (sekmeli: Çizim, Düzenle, Açıklama, Görünüm)
  - [x] 3.2 Her sekme için araç grubu panelini render et (ikon + etiket butonları)
  - [x] 3.3 Aktif aracı accent rengiyle vurgula
  - [x] 3.4 Sağ tarafa Şablonlar bölümü (Konut, Ofis, Hastane, Otel) ve Parametreler (⚙) butonu ekle

- [x] 4. DrawingTabBar bileşenini oluştur
  - [x] 4.1 12 çizim sekmesini yatay bar olarak render et
  - [x] 4.2 Aktif sekmeyi alt kenarlık accent rengiyle vurgula

- [x] 5. Sol Panel — ObjectPropertiesPanel bileşenini oluştur
  - [x] 5.1 ObjectPropertiesPanel bileşenini tanımla (seçili entity: tip, katman, renk, koordinatlar)
  - [x] 5.2 Entity seçili değilken "Nesne seçilmedi" mesajı göster
  - [x] 5.3 Sol paneli daraltılabilir (collapsible) yap — toggle butonu ile 260px ↔ 36px

- [x] 6. LayerPanel bileşenini güncelle
  - [x] 6.1 Mevcut LayerPanel'i THEME renklerine göre güncelle
  - [x] 6.2 Daraltılabilir bölüm başlığı ekle

- [x] 7. CommandLine bileşenini oluştur
  - [x] 7.1 Canvas ile StatusBar arasında komut giriş alanı oluştur
  - [x] 7.2 "Komut:" etiketi, monospace input, accent renk, placeholder metin

- [x] 8. StatusBar bileşenini oluştur
  - [x] 8.1 Model/Layout tabları (sol), koordinatlar (orta), SNAP/GRID/ORTHO toggle'ları, bilgi (sağ)
  - [x] 8.2 Toggle butonlarının on/off durumunu görsel olarak göster

- [x] 9. Ana layout'u yeniden yapılandır
  - [x] 9.1 Mevcut JSX layout'u yeni yapıya dönüştür (QAT → Ribbon → DrawingTabs → [SolPanel | Canvas] → CommandLine → StatusBar)
  - [x] 9.2 Tüm mevcut toolbar/status bar kodunu yeni bileşenlere taşı
  - [x] 9.3 Canvas alanının flex ile kalan alanı doldurmasını sağla

- [x] 10. Crosshair cursor güncellemesi
  - [x] 10.1 renderCrosshair fonksiyonunu güncelle (0.5px, #ffffff33)
  - [x] 10.2 Çizim aracı aktifken cursor:'none', select aracında cursor:'crosshair'

- [x] 11. Mevcut işlevsellik korunma testi
  - [x] 11.1 Tüm çizim araçlarının (line, rect, circle, dimension, text, move, copy, rotate, mirror) çalıştığını doğrula
  - [x] 11.2 Snap, ortho, polar tracking, undo/redo, export (DXF/SVG/JSON), save/load işlevlerinin çalıştığını doğrula
  - [x] 11.3 Klavye kısayollarının (L, R, C, D, T, M, Z, P, F3, F7, F8, Ctrl+Z/Y/S/O/A) çalıştığını doğrula

- [ ]* 12. Property-Based Tests
  - [ ]* 12.1 Ribbon sekme değiştirme property testi
  - [ ]* 12.2 Aktif araç vurgusu property testi
  - [ ]* 12.3 Entity özellik gösterimi property testi
  - [ ]* 12.4 Katman toggle işlemi property testi
  - [ ]* 12.5 Komut yürütme property testi
  - [ ]* 12.6 Crosshair render property testi
