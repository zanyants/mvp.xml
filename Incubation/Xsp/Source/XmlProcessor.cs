using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Mvp.Xml
{
	public abstract class XmlProcessor
	{
		public abstract XmlReader Process(XmlReader reader);
	}
}
