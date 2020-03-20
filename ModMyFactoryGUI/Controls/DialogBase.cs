//  Copyright (C) 2020 Mathis Rech
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.

using Avalonia.Controls;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using ModMyFactory.Win32;
using ModMyFactoryGUI.Helpers;
using System;

namespace ModMyFactoryGUI.Controls
{
    internal abstract class DialogBase : WindowBase
    {
        private static readonly IStyle _style =
            new StyleInclude(new Uri("avares://ModMyFactoryGUI"))
            {
                Source = new Uri("/Assets/Styles/Dialog.xaml", UriKind.Relative)
            };

        protected DialogBase()
        {
            ShowInTaskbar = false;
            CanResize = false;
            HasSystemDecorations = false;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            Styles.Add(_style);

            // Need to disable resize buttons manually on Windows since Avalonia doesn't.
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                var handle = PlatformImpl.Handle.Handle;
                var styles = User32.GetWindowStyles(handle);
                styles = styles.UnsetFlag(WindowStyles.MaximizeBox | WindowStyles.MinimizeBox);
                User32.SetWindowStyles(handle, styles);
            }
        }

        public void Close(DialogResult result)
            => Close((object)result);
    }
}
