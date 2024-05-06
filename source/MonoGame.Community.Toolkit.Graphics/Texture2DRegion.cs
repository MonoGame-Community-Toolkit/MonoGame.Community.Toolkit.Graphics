// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Community.Toolkit.Graphics;

/// <summary>
/// Defines a class that represents a rectangular bound region within Texture2D
/// This class cannot be inherited.
/// </summary>
public sealed class Texture2DRegion : IDisposable
{
    /// <summary>
    /// Gets the source texture this region is for.
    /// </summary>
    public Texture2D Texture { get; }

    /// <summary>
    /// Gets the rectangular bounds of this region relative to the top-left of the source texture.
    /// </summary>
    public Rectangle SourceRectangle { get; }

    /// <summary>
    /// Gets the width of this region, in pixels.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Gets the height of this region, in pixels.
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Gets the center xy-coordinate location of this region.
    /// </summary>
    public Vector2 Center { get; }

    /// <summary>
    /// Gets the normalized y-coordinate of the top edge of this region relative to the bounds of the base texture.
    /// </summary>
    public float TopUV { get; }

    /// <summary>
    /// Gets the normalized y-coordinate of the bottom edge of this region relative to the bounds of the base texture.
    /// </summary>
    public float BottomUV { get; }

    /// <summary>
    /// Gets the normalized x-coordinate of the left edge of this region relative to the bounds of the base texture.
    /// </summary>
    public float LeftUV { get; }

    /// <summary>
    /// Gets the normalized x-coordinate of the right edge of this region relative to the bounds of the base texture.
    /// </summary>
    public float RightUV { get; }

    /// <summary>
    /// Gets a value indicating whether this region has been disposed
    /// </summary>
    public bool IsDisposed { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Texture2DRegion"/> class.
    /// </summary>
    /// <param name="texture">The base texture.</param>
    public Texture2DRegion(Texture2D texture)
    {
        Debug.Assert(texture is not null);
        Texture = texture;
        SourceRectangle = texture.Bounds;
        Width = SourceRectangle.Width;
        Height = SourceRectangle.Height;
        Center = SourceRectangle.Center.ToVector2();
        LeftUV = SourceRectangle.Left / (float)texture.Width;
        RightUV = SourceRectangle.Right / (float)texture.Width;
        TopUV = SourceRectangle.Top / (float)texture.Height;
        BottomUV = SourceRectangle.Bottom / (float)texture.Height;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Texture2DRegion"/> class using a parent region and specified
    /// dimensions.
    /// </summary>
    /// <param name="parent">The parent <see cref="Texture2DRegion"/>.</param>
    /// <param name="x">
    /// The x-coordinate of the top-left corner of the region relative to the bounds of the parent region.
    /// </param>
    /// <param name="y">
    /// The y-coordinate of the top-left corner of the region relative to the bounds of the parent region.
    /// </param>
    /// <param name="width">The width of the region, in pixels.</param>
    /// <param name="height">The height of the region, in pixels..</param>
    public Texture2DRegion(Texture2DRegion parent, int x, int y, int width, int height)
    {
        Debug.Assert(parent is not null);
        Debug.Assert(x >= 0);
        Debug.Assert(y >= 0);
        Debug.Assert(width > 0);
        Debug.Assert(height > 0);

        Texture = parent.Texture;
        SourceRectangle = GetRelativeRectangle(parent.SourceRectangle, x, y, width, height);

        Width = SourceRectangle.Width;
        Height = SourceRectangle.Height;
        Center = SourceRectangle.Center.ToVector2();
        LeftUV = SourceRectangle.Left / (float)parent.Width;
        RightUV = SourceRectangle.Right / (float)parent.Width;
        TopUV = SourceRectangle.Top / (float)parent.Height;
        BottomUV = SourceRectangle.Bottom / (float)parent.Height;
    }

    private static Rectangle GetRelativeRectangle(Rectangle source, int x, int y, int width, int height)
    {
        int absoluteX = source.X + x;
        int absoluteY = source.Y + y;

        Rectangle relative;
        relative.X = MathHelper.Clamp(absoluteX, source.Left, source.Right);
        relative.Y = MathHelper.Clamp(absoluteY, source.Top, source.Bottom);
        relative.Width = Math.Max(Math.Min(absoluteX + width, source.Right) - relative.X, 0);
        relative.Height = Math.Max(Math.Min(absoluteY + height, source.Bottom) - relative.Y, 0);

        return relative;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Texture2DRegion"/> class using a parent region and a relative
    /// bounding rectangle.
    /// </summary>
    /// <param name="parent">The parent <see cref="Texture2DRegion"/>/</param>
    /// <param name="relativeBounds">The bounds of this region relative to the bounds of the parent.</param>
    public Texture2DRegion(Texture2DRegion parent, Rectangle relativeBounds)
        : this(parent, relativeBounds.X, relativeBounds.Y, relativeBounds.Width, relativeBounds.Height) { }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool isDisposing)
    {
        if (IsDisposed) { return; }
        if (isDisposing)
        {
            Texture.Dispose();
        }
        IsDisposed = true;
    }
}
