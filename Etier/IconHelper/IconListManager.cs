namespace Etier.IconHelper
{
    using System;
    using System.Collections;
    using System.Windows.Forms;

    public class IconListManager
    {
        private Hashtable _extensionList;
        private IconReader.IconSize _iconSize;
        private ArrayList _imageLists;
        private bool ManageBothSizes;

        public IconListManager(ImageList imageList, IconReader.IconSize iconSize)
        {
            this._extensionList = new Hashtable();
            this._imageLists = new ArrayList();
            this.ManageBothSizes = false;
            this._imageLists.Add(imageList);
            this._iconSize = iconSize;
        }

        public IconListManager(ImageList smallImageList, ImageList largeImageList)
        {
            this._extensionList = new Hashtable();
            this._imageLists = new ArrayList();
            this.ManageBothSizes = false;
            this._imageLists.Add(smallImageList);
            this._imageLists.Add(largeImageList);
            this.ManageBothSizes = true;
        }

        private void AddExtension(string Extension, int ImageListPosition)
        {
            this._extensionList.Add(Extension, ImageListPosition);
        }

        public int AddFileIcon(string filePath)
        {
            char[] separator = new char[] { '.' };
            string[] strArray = filePath.Split(separator);
            string str = (string) strArray.GetValue(strArray.GetUpperBound(0));
            if (this._extensionList.ContainsKey(str.ToUpper()))
            {
                return (int) this._extensionList[str.ToUpper()];
            }
            int count = ((ImageList) this._imageLists[0]).Images.Count;
            if (this.ManageBothSizes)
            {
                ((ImageList) this._imageLists[0]).Images.Add(IconReader.GetFileIcon(filePath, IconReader.IconSize.Small, false));
                ((ImageList) this._imageLists[1]).Images.Add(IconReader.GetFileIcon(filePath, IconReader.IconSize.Large, false));
            }
            else
            {
                ((ImageList) this._imageLists[0]).Images.Add(IconReader.GetFileIcon(filePath, this._iconSize, false));
            }
            this.AddExtension(str.ToUpper(), count);
            return count;
        }

        public void ClearLists()
        {
            foreach (ImageList list in this._imageLists)
            {
                list.Images.Clear();
            }
            this._extensionList.Clear();
        }
    }
}

