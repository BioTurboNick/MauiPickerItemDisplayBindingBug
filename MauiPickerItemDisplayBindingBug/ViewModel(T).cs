﻿namespace MauiPickerItemDisplayBindingBug;

/// <summary>
/// Provides a base class for ViewModels that are mapped to an underlying Model,
/// allowing implicit conversion from ViewModel to Model.
/// </summary>
/// <typeparam name="T">The type of the underlying Model.</typeparam>
/// <remarks>
/// Creates a new ViewModel around a new Model or around an existing Model.
/// </remarks>
/// <param name="model">The Model to build the ViewModel around.</param>
public class ViewModel<T>(T model) : ViewModel where T : class?, new()
{
    /// <summary>
    /// Gets the model backing the ViewModel. Avoid directly using this.
    /// </summary>
    public T Model { get; } = model ?? new T();

    /// <summary>
    /// Provides the underlying Model for this ViewModel.
    /// </summary>
    /// <param name="viewModel">The ViewModel.</param>
    public static implicit operator T?(ViewModel<T> viewModel) => viewModel?.Model;

    /// <summary>
    /// Provides the underlying Model for this ViewModel.
    /// </summary>
    /// <param name="viewModel">The ViewModel.</param>
    /// <returns>The Model.</returns>
    public T? ToT(ViewModel<T> viewModel) => viewModel?.Model;
}
