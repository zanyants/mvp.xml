using System.Xml.XPath;
using System.Xml;
using System.Collections.Generic;

namespace Mvp.Xml.Exslt
{
    /// <summary>
    /// Useful general-purpose extension methods related to the <c>Mvp.Xml.Exsl</c> namespace.
    /// </summary>
    public static class ExsltExtensionMethods
    {
        /// <summary>
        /// Evaluate an XPath expression on an <c>IXPathNavigable</c> instance, using the <c>ExsltContext</c> context.
        /// </summary>
        /// <param name="xpn">An <c>IXPathNavigable</c> instance.</param>
        /// <param name="xpath">The XPath epression to be evaluated.</param>
        /// <returns>The result of the evaluation.</returns>
        public static object ExsltEvaluate( this IXPathNavigable xpn, string xpath )
        {
            XPathNavigator nav = xpn.CreateNavigator();
            XPathExpression expr = nav.Compile( xpath );
            ExsltContext ctxt = new ExsltContext( nav.NameTable );
            expr.SetContext( ctxt );

            return nav.Evaluate( expr );
        }

        /// <summary>
        /// Evaluate an XPath expression on an <c>IXPathNavigable</c> instance, using the <c>ExsltContext</c> context.
        /// </summary>
        /// <param name="xpn">An <c>IXPathNavigable</c> instance.</param>
        /// <param name="xpath">The XPath epression to be evaluated.</param>
        /// <param name="namespaces">An array of prefix/URI pairs to be added as namespaces to the evaluation context.</param>
        /// <returns>The result of the evaluation.</returns>
        public static object ExsltEvaluate( this IXPathNavigable xpn, string xpath, KeyValuePair< string, string >[] namespaces )
        {
            XPathNavigator nav = xpn.CreateNavigator();
            XPathExpression expr = nav.Compile( xpath );
            ExsltContext ctxt = new ExsltContext( nav.NameTable );
            
            foreach ( var kvp in namespaces )
            {
                ctxt.AddNamespace( kvp.Key, kvp.Value );
            }

            expr.SetContext( ctxt );

            return nav.Evaluate( expr );
        }

    }
}
