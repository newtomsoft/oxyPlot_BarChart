using System;
using System.Collections.Generic;

namespace WpfApplication.ViewModels
{
    public interface IColumnChartViewModel
    {
        IReadOnlyList<Tuple<string, int>> CountList { get; }
    }
}