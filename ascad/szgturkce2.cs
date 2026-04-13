namespace ascad
{
    using DevExpress.XtraEditors.Controls;
    using System;

    public class szgturkce2 : Localizer
    {
        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
                case StringId.CheckChecked:
                    return "İşaretli";

                case StringId.CheckUnchecked:
                    return "İşaretsiz";

                case StringId.OK:
                    return "Tamam";

                case StringId.Cancel:
                    return "İptal";

                case StringId.NavigatorTextStringFormat:
                    return "Satır 0 ve 1";

                case StringId.PictureEditMenuCut:
                    return "KES";

                case StringId.PictureEditMenuCopy:
                    return "KOPYALA";

                case StringId.PictureEditMenuPaste:
                    return "YAPIŞTIR";

                case StringId.PictureEditMenuDelete:
                    return "SİL";

                case StringId.PictureEditMenuLoad:
                    return "Y\x00dcKLE";

                case StringId.PictureEditMenuSave:
                    return "KAYDET";

                case StringId.TextEditMenuUndo:
                    return "GERİ AL";

                case StringId.TextEditMenuCut:
                    return "KES";

                case StringId.TextEditMenuCopy:
                    return "KOPYALA";

                case StringId.TextEditMenuPaste:
                    return "YAPIŞTIR";

                case StringId.TextEditMenuDelete:
                    return "SİL";

                case StringId.TextEditMenuSelectAll:
                    return "HEPSİNİ SE\x00c7";

                case StringId.ContainerAccessibleEditName:
                    return "İsmini Değiştirme";

                case StringId.FilterCriteriaToStringBinaryOperatorEqual:
                    return "=";

                case StringId.FilterCriteriaToStringFunctionStartsWith:
                    return "Starts with";

                case StringId.FilterCriteriaToStringFunctionContains:
                    return "Contains";
            }
            return base.GetLocalizedString(id);
        }

        public override string Language =>
            "TR";
    }
}

