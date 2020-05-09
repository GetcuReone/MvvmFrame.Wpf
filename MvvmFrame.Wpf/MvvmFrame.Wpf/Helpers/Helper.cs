﻿using System.Collections.Generic;

namespace GetcuReone.MvvmFrame.Wpf.Helpers
{
    internal static class Helper
    {
        internal static bool IsNullOrEmpty<TItem>(this ICollection<TItem> items)
        {
            return items == null || items.Count == 0;
        }
    }
}
