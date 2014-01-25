﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SafeLibraryHandle.cs" company="http://sqllocaldb.codeplex.com">
//   Martin Costello (c) 2012-2014
// </copyright>
// <license>
//   See license.txt in the project root for license information.
// </license>
// <summary>
//   NativeMethods.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Security;
using Microsoft.Win32.SafeHandles;

namespace System.Data.SqlLocalDb
{
    /// <summary>
    /// A class that represents a handle to a library.  This class cannot be inherited.
    /// </summary>
    [SecurityCritical]
    internal sealed class SafeLibraryHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        #region Constructor

        /// <summary>
        /// Prevents a default instance of the <see cref="SafeLibraryHandle"/> class from being created.
        /// </summary>
        private SafeLibraryHandle()
            : base(true)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the code required to free the handle.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the handle is released successfully;
        /// otherwise, in the event of a catastrophic failure,
        /// <see langword="false"/>. In this case, it generates a ReleaseHandleFailed
        /// Managed Debugging Assistant.
        /// </returns>
        [SecurityCritical]
        protected override bool ReleaseHandle()
        {
            return NativeMethods.FreeLibrary(this.handle);
        }

        #endregion
    }
}