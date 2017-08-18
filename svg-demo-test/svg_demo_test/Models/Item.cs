namespace svg_demo_test.Models
{
	public class Item : BaseDataObject
	{
		string text = string.Empty;
		public string Text
		{
			get { return text; }
			set { SetProperty(ref text, value); }
		}

		string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}

		string iconPath = string.Empty;
		public string IconPath
		{
			get { return iconPath; }
			set { SetProperty(ref iconPath, value); }
		}


		private int _size = 30;
		public int Size
		{
			get { return _size; }
			set { SetProperty(ref _size, value); }
		}
	}
}
