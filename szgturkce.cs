using DevExpress.XtraGrid.Localization;
using System;

namespace ascad
{
	public class szgturkce : GridLocalizer
	{
		public override string Language
		{
			get
			{
				return "TR";
			}
		}

		public override string GetLocalizedString(GridStringId id)
		{
			string result;
			if (id <= 44)
			{
				switch (id)
				{
				case 2:
					result = "Gizli Kolonlar";
					return result;
				case 3:
				case 4:
				case 6:
					break;
				case 5:
					result = "Ayarla";
					return result;
				case 7:
					result = "Filtrelemeyi Düzenle";
					return result;
				case 8:
					result = "Boş Değerlileri Göster";
					return result;
				case 9:
					result = "Boş Olmayanları Göster";
					return result;
				default:
					switch (id)
					{
					case 22:
						result = "Bu Sütundaki Toplamını Göster";
						return result;
					case 23:
						result = "Bu Sütundaki En Küçük Veri";
						return result;
					case 24:
						result = "Bu Sütundaki En Büyük Veri";
						return result;
					case 25:
						result = "Kaç Adet Sütun Var";
						return result;
					case 26:
						result = "Bu Sütundaki Ortalamayı Göster";
						return result;
					case 27:
						result = "İşlemi Gizle";
						return result;
					case 33:
						result = "A'dan Z'ye sırala";
						return result;
					case 34:
						result = "Z'den A'ya sırala";
						return result;
					case 36:
						result = "Kolonu Gizle";
						return result;
					case 37:
						result = "Bu Kolona Göre Grupla";
						return result;
					case 38:
						result = "Gruplandırmadan Çıkart";
						return result;
					case 39:
						result = "Menüyü Düzenle";
						return result;
					case 41:
						result = "Kolonu Sığdır";
						return result;
					case 44:
						result = "Tüm Kolonları Sığdır";
						return result;
					}
					break;
				}
			}
			else
			{
				switch (id)
				{
				case 65:
					result = "Buradan Arama Yapılıyr";
					return result;
				case 66:
					result = "Gruplandırılmış Öğeleri Genişlet";
					return result;
				case 67:
					result = "Gruplandırılmış Öğeleri Daralt";
					return result;
				case 68:
					result = "Gruplandırmayı Temizle";
					return result;
				case 69:
					result = "Gruplama Panelini Göster";
					return result;
				case 70:
					result = "Gruplama Panelini Gizle";
					return result;
				case 71:
				case 72:
				case 73:
				case 74:
				case 75:
				case 76:
				case 77:
				case 79:
				case 80:
				case 81:
				case 83:
				case 84:
				case 85:
				case 86:
				case 87:
				case 89:
					break;
				case 78:
					result = "Button ya hacı";
					return result;
				case 82:
					result = "GRUPLANDIRMAK İÇİN SÜRÜKLEYİN";
					return result;
				case 88:
					result = "Sıralamayı Temizle";
					return result;
				case 90:
					result = "Filtre Editörü";
					return result;
				case 91:
					result = "Özel Arattırma Satırını Gizle";
					return result;
				case 92:
					result = "Özel Arattırma Satırını Göster";
					return result;
				case 93:
					result = "Genel Arattırma Gizle";
					return result;
				case 94:
					result = "Genel Arattırma Göster";
					return result;
				case 95:
					result = "Kaydet ve Çık";
					return result;
				case 96:
					result = "İptal";
					return result;
				case 97:
					result = "Tamam";
					return result;
				case 98:
					result = "Kapsamlı Arattırma";
					return result;
				case 99:
					result = "Düzenlenecek Sütun Bulunamadı";
					return result;
				default:
					switch (id)
					{
					case 172:
						result = "Arattır";
						return result;
					case 173:
						result = "Temizle";
						return result;
					case 175:
						result = "Yeni Ekle";
						return result;
					case 176:
						result = "Yeni Bir Veri Ekle";
						return result;
					case 177:
						result = "Tüm İşlemleri Gizle";
						return result;
					}
					break;
				}
			}
			string localizedString = base.GetLocalizedString(id);
			result = localizedString;
			return result;
		}
	}
}
