﻿namespace WPF
{
    public interface ISearchInputModel
    {
        SearchEngine Engine { get; set; }
        string? Keyword { get; set; }
        int? SearchLimit { get; set; }
    }
}