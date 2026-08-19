using GeorgeWpfDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace _51.ListBoxPractice
{
    public class Sentence:ObservableObject
    {
		private string _content;

		public string Content
		{
			get { return _content; }
			set { _content = value; OnPropertyChanged(); }
		}

	}
}
