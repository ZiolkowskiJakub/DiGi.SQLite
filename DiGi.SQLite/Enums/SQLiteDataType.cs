using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiGi.SQLite.Enums
{
    public enum SQLiteDataType
    {
        /// <summary>
        ///     A signed integer.
        /// </summary>
        [Description("Integer")] Integer,

        /// <summary>
        ///     A floating point value.
        /// </summary>
        [Description("Real")] Real,

        /// <summary>
        ///     A text string.
        /// </summary>
        [Description("Text")] Text,

        /// <summary>
        ///     A blob of data.
        /// </summary>
        [Description("Blob")] Blob,
    }
}
