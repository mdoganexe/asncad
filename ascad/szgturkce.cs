namespace ascad
{
    using DevExpress.XtraGrid.Localization;
    using System;

    public class szgturkce : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            switch (id)
            {
                case GridStringId.CustomizationCaption:
                    return "Gizli Kolonlar";

                case GridStringId.FilterPanelCustomizeButton:
                    return "Ayarla";

                case GridStringId.PopupFilterCustom:
                    return "Filtrelemeyi D\x00fczenle";

                case GridStringId.PopupFilterBlanks:
                    return "Boş Değerlileri G\x00f6ster";

                case GridStringId.PopupFilterNonBlanks:
                    return "Boş Olmayanları G\x00f6ster";

                case GridStringId.MenuFooterSum:
                    return "Bu S\x00fctundaki Toplamını G\x00f6ster";

                case GridStringId.MenuFooterMin:
                    return "Bu S\x00fctundaki En K\x00fc\x00e7\x00fck Veri";

                case GridStringId.MenuFooterMax:
                    return "Bu S\x00fctundaki En B\x00fcy\x00fck Veri";

                case GridStringId.MenuFooterCount:
                    return "Ka\x00e7 Adet S\x00fctun Var";

                case GridStringId.MenuFooterAverage:
                    return "Bu S\x00fctundaki Ortalamayı G\x00f6ster";

                case GridStringId.MenuFooterNone:
                    return "İşlemi Gizle";

                case GridStringId.MenuColumnSortAscending:
                    return "A'dan Z'ye sırala";

                case GridStringId.MenuColumnSortDescending:
                    return "Z'den A'ya sırala";

                case GridStringId.MenuColumnRemoveColumn:
                    return "Kolonu Gizle";

                case GridStringId.MenuColumnGroup:
                    return "Bu Kolona G\x00f6re Grupla";

                case GridStringId.MenuColumnUnGroup:
                    return "Gruplandırmadan \x00c7ıkart";

                case GridStringId.MenuColumnColumnCustomization:
                    return "Men\x00fcy\x00fc D\x00fczenle";

                case GridStringId.MenuColumnBestFit:
                    return "Kolonu Sığdır";

                case GridStringId.MenuColumnBestFitAllColumns:
                    return "T\x00fcm Kolonları Sığdır";

                case GridStringId.MenuColumnFilterModeDisplayText:
                    return "Buradan Arama Yapılıyr";

                case GridStringId.MenuGroupPanelFullExpand:
                    return "Gruplandırılmış \x00d6ğeleri Genişlet";

                case GridStringId.MenuGroupPanelFullCollapse:
                    return "Gruplandırılmış \x00d6ğeleri Daralt";

                case GridStringId.MenuGroupPanelClearGrouping:
                    return "Gruplandırmayı Temizle";

                case GridStringId.MenuGroupPanelShow:
                    return "Gruplama Panelini G\x00f6ster";

                case GridStringId.MenuGroupPanelHide:
                    return "Gruplama Panelini Gizle";

                case GridStringId.CardViewQuickCustomizationButton:
                    return "Button ya hacı";

                case GridStringId.GridGroupPanelText:
                    return "GRUPLANDIRMAK İ\x00c7İN S\x00dcR\x00dcKLEYİN";

                case GridStringId.MenuColumnClearSorting:
                    return "Sıralamayı Temizle";

                case GridStringId.MenuColumnFilterEditor:
                    return "Filtre Edit\x00f6r\x00fc";

                case GridStringId.MenuColumnAutoFilterRowHide:
                    return "\x00d6zel Arattırma Satırını Gizle";

                case GridStringId.MenuColumnAutoFilterRowShow:
                    return "\x00d6zel Arattırma Satırını G\x00f6ster";

                case GridStringId.MenuColumnFindFilterHide:
                    return "Genel Arattırma Gizle";

                case GridStringId.MenuColumnFindFilterShow:
                    return "Genel Arattırma G\x00f6ster";

                case GridStringId.FilterBuilderOkButton:
                    return "Kaydet ve \x00c7ık";

                case GridStringId.FilterBuilderCancelButton:
                    return "İptal";

                case GridStringId.FilterBuilderApplyButton:
                    return "Tamam";

                case GridStringId.FilterBuilderCaption:
                    return "Kapsamlı Arattırma";

                case GridStringId.CustomizationFormColumnHint:
                    return "D\x00fczenlenecek S\x00fctun Bulunamadı";

                case GridStringId.FindControlFindButton:
                    return "Arattır";

                case GridStringId.FindControlClearButton:
                    return "Temizle";

                case GridStringId.SearchLookUpAddNewButton:
                    return "Yeni Ekle";

                case GridStringId.MenuFooterAddSummaryItem:
                    return "Yeni Bir Veri Ekle";

                case GridStringId.MenuFooterClearSummaryItems:
                    return "T\x00fcm İşlemleri Gizle";
            }
            return base.GetLocalizedString(id);
        }

        public override string Language =>
            "TR";
    }
}

