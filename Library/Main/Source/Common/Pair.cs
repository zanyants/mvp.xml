using System;
using System.Runtime;

namespace Mvp.Xml.Common
{
    /// <summary>
    /// Provides a basic utility class that is used to store two related objects.
    /// </summary>
    [Serializable]
    public sealed class Pair
    {
        /// <summary>
        /// Gets or sets the first object of the object pair.
        /// </summary>
        public object First;
        
        /// <summary>
        /// Gets or sets the second object of the object pair.
        /// </summary>
        public object Second;

        /// <summary>
        /// Creates a new, uninitialized instance of the Pair class.
        /// </summary>
        [TargetedPatchingOptOut( "Performance critical to inline this type of method across NGen image boundaries" )]
        public Pair()
        {
            First = null;
            Second = null;
        }

        /// <summary>
        /// Initializes a new instance of the System.Web.UI.Pair class, using the specified object pair.
        /// </summary>
        /// <param name="x">An object.</param>
        /// <param name="y">An object.</param>
        [TargetedPatchingOptOut( "Performance critical to inline this type of method across NGen image boundaries" )]
        public Pair( object x, object y )
        {
            First = x;
            Second = y;
        }
    }
}
