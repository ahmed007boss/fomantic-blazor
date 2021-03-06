﻿///-------------------------------------------------------------------------------------------------
// file:	Animators\FomanticComponentAnimator.cs
//
// summary:	Implements the fomantic component animator class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary> Extension class responsibe for animating a <see cref="IFomanticComponent"/> </summary>
    ///
    /// <typeparam name="TFomanticComponent">   Type of the fomantic component. </typeparam>
    ///-------------------------------------------------------------------------------------------------
    public class FomanticComponentAnimator<TFomanticComponent> : ElementReferenceFomanticAnimator, IFomanticExtension where TFomanticComponent : IFomanticComponentWithExtensions
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the component. </summary>
        ///
        /// <value> The component. </value>
        ///-------------------------------------------------------------------------------------------------

        public TFomanticComponent Parent { get; private set; }
        Action IFomanticExtension.ParentStateHasChanged { get; set; }
        IFomanticComponentWithExtensions IFomanticExtension.Parent { get => Parent; set => Parent = (TFomanticComponent)value; }

        List<ComponentFragment> IFomanticExtension.ComponentAdditionalFragments { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Create An instant of Animator. </summary>
        ///
        /// <param name="component">    Fomantic component to animate. </param>
        ///-------------------------------------------------------------------------------------------------

        public FomanticComponentAnimator(TFomanticComponent component) : base(component.JsRuntime, component.RootElement)
        {
            Parent = component;
        }

        /// <inheritdoc/>
        public async override Task Animate(int interval = 200, params Tuple<TransitionAnimation, int>[] animations)
        {
            await base.Animate(interval, animations);

            if (Parent is IVisibleFomanticComponent)
            {
                (Parent as IVisibleFomanticComponent).IsHidden = !(Parent as IVisibleFomanticComponent).IsHidden;
            }


        }
        /// <inheritdoc/>
        public async override Task Animate(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            await base.Animate(animation, duration, interval);

            if (Parent is IVisibleFomanticComponent)
            {
                (Parent as IVisibleFomanticComponent).IsHidden = !(Parent as IVisibleFomanticComponent).IsHidden;
            }


        }

        /// <inheritdoc/>
        public async override Task AnimatedHide(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            await base.AnimatedHide(animation, duration, interval);

            if (Parent is IVisibleFomanticComponent)
            {
                (Parent as IVisibleFomanticComponent).IsHidden = true;
            }


        }
        /// <inheritdoc/>
        public async override Task AnimatedShow(TransitionAnimation animation, int duration = 800, int interval = 200)
        {
            await base.AnimatedShow(animation, duration, interval);

            if (Parent is IVisibleFomanticComponent)
            {
                (Parent as IVisibleFomanticComponent).IsHidden = false;
            }


        }

        async ValueTask<bool> IFomanticExtension.OnComponentAfterEachRender()
        {
            return false;
        }

        async ValueTask<bool> IFomanticExtension.OnComponentAfterFirstRender()
        {
            return false;
        }

        async ValueTask IFomanticExtension.OnComponentInitialized()
        {

        }

        string[] IFomanticExtension.ProvideComponentCssClasses()
        {
            return Array.Empty<string>();
        }

        string IFomanticExtension.ProvideComponentCssClass()
        {
            return string.Empty;
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {

        }
    }

}

