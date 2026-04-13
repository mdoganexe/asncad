# Gereksinimler Dokümanı — AutoCAD Web UI Dönüşümü

## Giriş

Bu doküman, mevcut ASNCAD CAD uygulamasının (AscadCadApp.tsx) arayüzünü AutoCAD Web (web.autocad.com) tarzı profesyonel bir CAD arayüzüne dönüştürmek için gereken gereksinimleri tanımlar. Dönüşüm; ribbon-style toolbar, collapsible sol panel (Object Properties + Layer), profesyonel koyu tema, Model/Layout tabları, crosshair cursor, command line ve Quick Access Toolbar bileşenlerini kapsar. Tüm UI metinleri Türkçe olacaktır.

## Sözlük

- **ASNCAD**: Mevcut asansör CAD uygulaması (AscadCadApp.tsx, ~3600 satır, React + Canvas2D)
- **Ribbon_Toolbar**: AutoCAD Web tarzı üst araç çubuğu; sekmeli gruplar (Çizim, Düzenle, Açıklama vb.) içerir
- **Quick_Access_Toolbar**: Ribbon üzerinde yer alan küçük araç çubuğu (kaydet, geri al, yinele gibi sık kullanılan işlemler)
- **Sol_Panel**: Çizim alanının solunda yer alan, Object Properties ve Layer yönetimini barındıran daraltılabilir panel
- **Object_Properties_Paneli**: Seçili entity'nin özelliklerini (tip, katman, renk, koordinatlar) gösteren panel bölümü
- **Layer_Paneli**: Katman görünürlük, kilit ve renk yönetimi sağlayan panel bölümü
- **Status_Bar**: Uygulama penceresinin alt kısmında yer alan durum çubuğu (koordinatlar, snap/ortho/grid göstergeleri)
- **Command_Line**: Status Bar içinde yer alan, AutoCAD tarzı komut giriş alanı
- **Model_Layout_Tabları**: Status Bar'ın sol kısmında yer alan Model ve Layout sekmeleri
- **Crosshair_Cursor**: Çizim alanında tam genişlik/yükseklikte görünen artı imleci
- **Koyu_Tema**: AutoCAD Web referanslı koyu renk paleti (#1e1e2e arka plan, #2d2d3f panel, #0d0d1a canvas)
- **Drawing_Tab**: Mevcut çizim sekmeleri (Kuyu Kesiti, Boyuna Kesit, Makine Dairesi vb.)
- **Canvas_Alanı**: 2D çizim render alanı (Canvas2D)
- **Entity**: CAD çizim nesnesi (çizgi, dikdörtgen, daire, ölçü, metin vb.)

## Gereksinimler

### Gereksinim 1: Koyu Tema Sistemi

**Kullanıcı Hikayesi:** Bir CAD kullanıcısı olarak, AutoCAD Web tarzı profesyonel koyu tema istiyorum, böylece uzun süreli çalışmalarda göz yorgunluğu azalır ve profesyonel bir görünüm elde ederim.

#### Kabul Kriterleri

1. THE ASNCAD SHALL render the application background using the Koyu_Tema color palette with #1e1e2e as the primary background color
2. THE ASNCAD SHALL render the Ribbon_Toolbar area with #2d2d3f background color and #3d3d5c border color
3. THE ASNCAD SHALL render the Sol_Panel with #252536 background color and #3d3d5c border color
4. THE ASNCAD SHALL render the Canvas_Alanı with #0d0d1a background color for maximum contrast with drawing entities
5. THE ASNCAD SHALL render the Status_Bar with #1a1a2e background color and #3d3d5c top border color
6. THE ASNCAD SHALL use #e2e8f0 as the primary text color and #94a3b8 as the secondary text color across all UI components
7. THE ASNCAD SHALL use #00b4d8 as the accent color for active states, selected items, and interactive highlights

### Gereksinim 2: Ribbon-Style Toolbar

**Kullanıcı Hikayesi:** Bir CAD kullanıcısı olarak, AutoCAD Web tarzı sekmeli ribbon toolbar istiyorum, böylece çizim araçlarına organize gruplar halinde hızlıca erişebilirim.

#### Kabul Kriterleri

1. THE Ribbon_Toolbar SHALL display tab buttons for at least the following groups: "Çizim", "Düzenle", "Açıklama", "Görünüm"
2. WHEN a ribbon tab is clicked, THE Ribbon_Toolbar SHALL display the corresponding tool group panel below the tab bar
3. THE Ribbon_Toolbar "Çizim" group SHALL contain buttons for: Çizgi (line), Dikdörtgen (rect), Daire (circle), Ölçü (dimension), Metin (text)
4. THE Ribbon_Toolbar "Düzenle" group SHALL contain buttons for: Taşı (move), Kopyala (copy), Döndür (rotate), Ölçekle (scale), Aynala (mirror), Sil (delete)
5. THE Ribbon_Toolbar "Açıklama" group SHALL contain buttons for: Ölçü (dimension), Metin (text), Ölçü Düzenle (DD)
6. THE Ribbon_Toolbar "Görünüm" group SHALL contain buttons for: Tümünü Göster (zoom extents), Izgara (grid toggle), Snap (snap toggle), Ortho (ortho toggle)
7. WHEN a tool button in the Ribbon_Toolbar is active, THE Ribbon_Toolbar SHALL highlight the active button with the accent color (#00b4d8)
8. THE Ribbon_Toolbar SHALL display each tool button with an icon and a label text below the icon

### Gereksinim 3: Quick Access Toolbar

**Kullanıcı Hikayesi:** Bir CAD kullanıcısı olarak, en sık kullandığım işlemlere (kaydet, geri al, yinele) tek tıkla erişmek istiyorum, böylece iş akışım kesintiye uğramaz.

#### Kabul Kriterleri

1. THE Quick_Access_Toolbar SHALL be positioned above the Ribbon_Toolbar at the top-left corner of the application
2. THE Quick_Access_Toolbar SHALL contain buttons for: Yeni, Kaydet, Aç, Geri Al (undo), Yinele (redo)
3. THE Quick_Access_Toolbar SHALL contain export buttons for: DXF, SVG, JSON
4. WHEN the undo stack is empty, THE Quick_Access_Toolbar SHALL display the Geri Al button in a disabled visual state
5. WHEN the redo stack is empty, THE Quick_Access_Toolbar SHALL display the Yinele button in a disabled visual state
6. THE Quick_Access_Toolbar SHALL display the application title "ASNCAD" to the right of the action buttons

### Gereksinim 4: Sol Panel — Object Properties ve Layer Yönetimi

**Kullanıcı Hikayesi:** Bir CAD kullanıcısı olarak, seçili nesnenin özelliklerini ve katman yönetimini sol panelde görmek istiyorum, böylece çizim nesnelerini verimli şekilde yönetebilirim.

#### Kabul Kriterleri

1. THE Sol_Panel SHALL be positioned to the left of the Canvas_Alanı with a default width of 260 pixels
2. THE Sol_Panel SHALL contain two collapsible sections: Object_Properties_Paneli and Layer_Paneli
3. WHEN an Entity is selected on the Canvas_Alanı, THE Object_Properties_Paneli SHALL display the entity type, layer name, color, and coordinate values
4. WHEN no Entity is selected, THE Object_Properties_Paneli SHALL display the text "Nesne seçilmedi"
5. THE Layer_Paneli SHALL display all layers with their name, color indicator, visibility toggle icon, and lock toggle icon
6. WHEN a layer visibility toggle is clicked, THE Layer_Paneli SHALL toggle the visibility state of that layer
7. WHEN a layer lock toggle is clicked, THE Layer_Paneli SHALL toggle the lock state of that layer
8. THE Sol_Panel SHALL be collapsible via a toggle button, and WHEN collapsed, THE Sol_Panel SHALL reduce to a narrow strip showing only the toggle button
9. WHEN the Sol_Panel collapse toggle is clicked, THE Sol_Panel SHALL animate between collapsed and expanded states

### Gereksinim 5: Status Bar ve Model/Layout Tabları

**Kullanıcı Hikayesi:** Bir CAD kullanıcısı olarak, ekranın alt kısmında koordinat bilgisi, snap/ortho/grid durumu ve Model/Layout sekmelerini görmek istiyorum, böylece çizim durumumu sürekli takip edebilirim.

#### Kabul Kriterleri

1. THE Status_Bar SHALL be positioned at the bottom of the application window as a single horizontal bar
2. THE Status_Bar SHALL display Model_Layout_Tabları on the left side with at least "Model" and "Layout1" tabs
3. WHEN the "Model" tab is active, THE Status_Bar SHALL highlight the Model tab with the accent color
4. THE Status_Bar SHALL display the current mouse cursor X and Y world coordinates in monospace font
5. THE Status_Bar SHALL display toggle buttons for SNAP, GRID, and ORTHO with visual indication of their on/off state
6. WHEN a status toggle button (SNAP, GRID, ORTHO) is clicked, THE Status_Bar SHALL toggle the corresponding drawing aid state
7. THE Status_Bar SHALL display the active tool name and entity count on the right side
8. THE Status_Bar SHALL display quick info showing beyan yük (kg), kabin boyutları, and kuyu boyutları

### Gereksinim 6: Command Line

**Kullanıcı Hikayesi:** Bir CAD kullanıcısı olarak, AutoCAD tarzı komut satırı istiyorum, böylece klavye ile hızlıca komut girebilirim.

#### Kabul Kriterleri

1. THE Command_Line SHALL be positioned between the Canvas_Alanı and the Status_Bar as a resizable area
2. THE Command_Line SHALL contain a text input field with "Komut:" label prefix
3. WHEN a valid command is typed and Enter is pressed, THE Command_Line SHALL execute the corresponding action (param, kk, dd, save, konut, ofis, hastane, otel, ze, dall, export-json, load)
4. THE Command_Line SHALL display the input text in monospace font with the accent color (#00b4d8)
5. THE Command_Line SHALL display a placeholder text showing available commands

### Gereksinim 7: Crosshair Cursor

**Kullanıcı Hikayesi:** Bir CAD kullanıcısı olarak, çizim alanında tam ekran genişliğinde crosshair imleci görmek istiyorum, böylece çizim hizalamasını kolayca yapabilirim.

#### Kabul Kriterleri

1. WHILE the mouse cursor is over the Canvas_Alanı, THE ASNCAD SHALL render a full-width and full-height crosshair at the cursor position
2. THE ASNCAD SHALL render the Crosshair_Cursor lines with a thin line width (0.5px) and semi-transparent color (#ffffff33)
3. WHILE a drawing tool is active and the cursor is over the Canvas_Alanı, THE ASNCAD SHALL change the CSS cursor style to "none" to show only the rendered crosshair
4. WHILE the select tool is active, THE ASNCAD SHALL display the default crosshair CSS cursor alongside the rendered crosshair

### Gereksinim 8: Drawing Tab Sistemi

**Kullanıcı Hikayesi:** Bir CAD kullanıcısı olarak, mevcut 12 çizim sekmesini ribbon altında organize bir şekilde görmek istiyorum, böylece farklı çizim görünümleri arasında hızlıca geçiş yapabilirim.

#### Kabul Kriterleri

1. THE ASNCAD SHALL display Drawing_Tab buttons between the Ribbon_Toolbar and the Canvas_Alanı
2. THE ASNCAD SHALL display all 12 drawing tabs: Kuyu Kesiti, Boyuna Kesit, Makine Dairesi, Kabin Planı, TTK-AA, TTK-BB, Kapı Detayı, Askı Diyagramı, Tüm Proje, Hesap Raporu, Hesap Özeti, 3D Görünüm
3. WHEN a Drawing_Tab is clicked, THE ASNCAD SHALL switch the Canvas_Alanı to display the corresponding drawing view
4. THE ASNCAD SHALL highlight the active Drawing_Tab with a bottom border accent color and brighter text
5. WHEN the active Drawing_Tab is "3D Görünüm", THE ASNCAD SHALL render the Elevator3DViewer component instead of the Canvas_Alanı

### Gereksinim 9: Şablon Seçici

**Kullanıcı Hikayesi:** Bir CAD kullanıcısı olarak, hazır bina şablonlarına (Konut, Ofis, Hastane, Otel) ribbon toolbar üzerinden erişmek istiyorum, böylece hızlıca proje başlatabilirim.

#### Kabul Kriterleri

1. THE Ribbon_Toolbar SHALL include a "Şablonlar" dropdown or button group within the toolbar area
2. THE ASNCAD SHALL provide preset buttons for: Konut, Ofis, Hastane, Otel
3. WHEN a preset button is clicked, THE ASNCAD SHALL load the corresponding elevator parameter preset and regenerate all drawings
4. THE ASNCAD SHALL display the Parametreler (⚙) button in the Ribbon_Toolbar for opening the full parameter dialog

### Gereksinim 10: Responsive Layout ve Panel Yeniden Boyutlandırma

**Kullanıcı Hikayesi:** Bir CAD kullanıcısı olarak, panel boyutlarını ayarlayabilmek istiyorum, böylece çalışma alanımı ihtiyacıma göre düzenleyebilirim.

#### Kabul Kriterleri

1. THE ASNCAD SHALL use a flex-based layout where the Canvas_Alanı fills all remaining space after the Sol_Panel, Ribbon_Toolbar, Drawing_Tab bar, Command_Line, and Status_Bar are rendered
2. WHEN the Sol_Panel is collapsed, THE Canvas_Alanı SHALL expand to fill the freed horizontal space
3. THE ASNCAD SHALL maintain all existing functionality (drawing tools, snap, ortho, polar tracking, entity selection, dimension editing, context menu, keyboard shortcuts, undo/redo, export) after the UI transformation
4. THE ASNCAD SHALL preserve the single-file architecture within AscadCadApp.tsx
