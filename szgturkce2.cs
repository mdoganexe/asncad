using DevExpress.XtraEditors.Controls;
using System;

namespace ascad
{
	public class szgturkce2 : Localizer
	{
		public override string Language
		{
			get
			{
				return "TR";
			}
		}

		public override string GetLocalizedString(StringId id)
		{
			string result;
			if (id <= 28)
			{
				if (id <= 4)
				{
					if (id == 3)
					{
						result = "İşaretli";
						return result;
					}
					if (id == 4)
					{
						result = "İşaretsiz";
						return result;
					}
				}
				else
				{
					if (id == 9)
					{
						result = "Tamam";
						return result;
					}
					if (id == 10)
					{
						result = "İptal";
						return result;
					}
					switch (id)
					{
					case 22:
						result = "Satır 0 ve 1";
						return result;
					case 23:
						result = "KES";
						return result;
					case 24:
						result = "KOPYALA";
						return result;
					case 25:
						result = "YAPIŞTIR";
						return result;
					case 26:
						result = "SİL";
						return result;
					case 27:
						result = "YÜKLE";
						return result;
					case 28:
						result = "KAYDET";
						return result;
					}
				}
			}
			else if (id <= 121)
			{
				switch (id)
				{
				case 72:
					result = "GERİ AL";
					return result;
				case 73:
					result = "KES";
					return result;
				case 74:
					result = "KOPYALA";
					return result;
				case 75:
					result = "YAPIŞTIR";
					return result;
				case 76:
					result = "SİL";
					return result;
				case 77:
					result = "HEPSİNİ SEÇ";
					return result;
				default:
					if (id == 121)
					{
						result = "İsmini Değiştirme";
						return result;
					}
					break;
				}
			}
			else
			{
				if (id == 133)
				{
					result = "=";
					return result;
				}
				if (id == 259)
				{
					result = "Starts with";
					return result;
				}
				if (id == 261)
				{
					result = "Contains";
					return result;
				}
			}
			string localizedString = base.GetLocalizedString(id);
			result = localizedString;
			return result;
		}
	}
}
