﻿///-------------------------------------------------------------------------------------------------
// file:	FomanticBase\FomanticComponentWithContentBase.cs
//
// summary:	Implements the fomantic component with content base class
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base class for all Fomantic Component. </summary>
    public abstract class FomanticComponentWithContentBase : FomanticComponentBase

    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Content of the component.   </summary>
        ///
        /// <value> The child content. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public RenderFragment ChildContent { get; set; }
        // just an alias for ChildContent

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Content of the component.   </summary>
        ///
        /// <value> The content. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public RenderFragment Content { get { return ChildContent; } set { ChildContent = value; } }

    }
}
