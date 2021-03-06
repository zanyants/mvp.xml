#region using

using System;    
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;

using Mvp.Xml.Common.XPath;

#endregion

namespace Mvp.Xml.XPointer 
{        	
    /// <summary>
    /// xpath1() scheme based XPointer pointer part.
    /// </summary>
    internal class XPath1SchemaPointerPart : PointerPart 
    {       
        #region private members

        private string _xpath;        		
        
        #endregion

        #region public members

        public string XPath 
        {
            get { return _xpath; }
            set { _xpath = value; }
        }
		       
        #endregion
    
        #region PointerPart overrides

        /// <summary>
        /// Evaluates <see cref="XPointer"/> pointer part and returns pointed nodes.
        /// </summary>
        /// <param name="doc">Document to evaluate pointer part on</param>
        /// <param name="nm">Namespace manager</param>
        /// <returns>Pointed nodes</returns>		    
        public override XPathNodeIterator Evaluate(XPathNavigator doc, XmlNamespaceManager nm)
        {		    
            try 
            {
                return XPathCache.Select(_xpath, doc, nm);
            } 
            catch 
            {
                return null;
            }
        }		
		
        #endregion

        #region parser

        public static XPath1SchemaPointerPart ParseSchemaData(XPointerLexer lexer) 
        {                                    
            XPath1SchemaPointerPart part = new XPath1SchemaPointerPart();
            try 
            {
                part.XPath = lexer.ParseEscapedData();
            } 
            catch (Exception e) 
            {
                throw new XPointerSyntaxException(SR.GetString("SyntaxErrorInXPath1SchemeData", 
                    e.Message));                                   
            }                                   
            return part;
        }		

        #endregion
    }
}
