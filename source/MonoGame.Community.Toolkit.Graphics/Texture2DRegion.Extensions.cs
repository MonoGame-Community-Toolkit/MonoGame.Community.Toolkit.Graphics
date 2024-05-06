// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Community.Toolkit.Graphics;

/// <summary>
/// Defines extension methods for the <see cref="Texture2DRegion"/> class.
/// </summary>
public static class Texture2DRegionExtensions
{
    /// <summary>
    /// Draws a <see cref="Texture2DRegion"/> at the specified position.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    public static void Draw(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position) =>
        spriteBatch.Draw(region, position, Color.White);

    /// <summary>
    /// Draws a <see cref="Texture2DRegion"/> at the specified position with the specified color.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    /// <param name="color">The color tint to apply to the texture.</param>
    public static void Draw(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color) =>
        spriteBatch.Draw(region, position, color, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f);

    /// <summary>
    /// Draws a <see cref="Texture2DRegion"/> at the specified position with the specified parameters.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    /// <param name="color">The color tint to apply to the render.</param>
    /// <param name="rotation">The rotation angle, in radians, of the render.</param>
    /// <param name="origin">The origin of the region (relative to its dimensions).</param>
    /// <param name="scale">The scale factor to apply to the render.</param>
    /// <param name="effects">The sprite effects to apply to the render.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw at..</param>
    public static void Draw(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth) =>
        spriteBatch.Draw(region, position, color, rotation, origin, new Vector2(scale, scale), effects, layerDepth);

    /// <summary>
    /// Draws a <see cref="Texture2DRegion"/> at the specified position with the specified parameters.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    /// <param name="color">The color tint to apply to the render.</param>
    /// <param name="rotation">The rotation angle, in radians, of the render.</param>
    /// <param name="origin">The origin of the region (relative to its dimensions).</param>
    /// <param name="scale">The scale factor to apply to the render.</param>
    /// <param name="effects">The sprite effects to apply to the render.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw at..</param>
    public static void Draw(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        Debug.Assert(spriteBatch is not null);
        Debug.Assert(region is not null);
        Debug.Assert(!region.IsDisposed, "Texture region was disposed prior to drawing");
        spriteBatch.Draw(region.Texture, position, region.SourceRectangle, color, rotation, origin, scale, effects, layerDepth);
    }

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> centered at the specified position.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    public static void DrawCentered(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position) =>
        spriteBatch.DrawCentered(region, position, Color.White);

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> centered at the specified position with the specified color.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    /// <param name="color">The color tint to apply to the render.</param>
    public static void DrawCentered(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color) =>
        spriteBatch.DrawCentered(region, position, color, 0.0f, Vector2.One, SpriteEffects.None, 0.0f);

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> centered at the specified position with the specified parameters.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    /// <param name="color">The color tint to apply to the render.</param>
    /// <param name="rotation">The rotation angle, in radians, of the render.</param>
    /// <param name="scale">The uniform scale factor to apply to the render.</param>
    /// <param name="effects">The sprite effects to apply to the render.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw at.</param>
    public static void DrawCentered(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color, float rotation, float scale, SpriteEffects effects, float layerDepth) =>
        spriteBatch.DrawCentered(region, position, color, rotation, new Vector2(scale), effects, layerDepth);

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> centered at the specified position with the specified parameters.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    /// <param name="color">The color tint to apply to the render.</param>
    /// <param name="rotation">The rotation angle, in radians, of the render.</param>
    /// <param name="scale">The uniform scale factor to apply to the render.</param>
    /// <param name="effects">The sprite effects to apply to the render.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw at.</param>
    public static void DrawCentered(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color, float rotation, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        Debug.Assert(spriteBatch is not null);
        Debug.Assert(region is not null);
        Debug.Assert(!region.IsDisposed, "Texture region was disposed prior to drawing");
        spriteBatch.Draw(region.Texture, position, region.SourceRectangle, color, rotation, region.Center, scale, effects, layerDepth);
    }

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> with an outline effect at the specified position.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    public static void DrawOutlined(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position) =>
        spriteBatch.DrawOutlined(region, position, Color.White);

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> with an outline effect at the specified position with the specified color.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    /// <param name="color">The color tint to apply to the render and its outline.</param>
    public static void DrawOutlined(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color) =>
        spriteBatch.DrawOutlined(region, position, color, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f);

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> with an outline effect at the specified position with the specified parameters.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    /// <param name="color">The color tint to apply to the render and its outline.</param>
    /// <param name="rotation">The rotation angle, in radians, of the render.</param>
    /// <param name="origin">The origin of the region (relative to its dimensions).</param>
    /// <param name="scale">The scale factors to apply to the render.</param>
    /// <param name="effects">The sprite effects to apply to the render.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw at.</param>
    public static void DrawOutlined(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth) =>
        spriteBatch.DrawOutlined(region, position, color, rotation, origin, new Vector2(scale), effects, layerDepth);

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> with an outline effect at the specified position with the specified parameters.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    /// <param name="color">The color tint to apply to the render and its outline.</param>
    /// <param name="rotation">The rotation angle, in radians, of the render.</param>
    /// <param name="origin">The origin of the region (relative to its dimensions).</param>
    /// <param name="scale">The scale factors to apply to the render.</param>
    /// <param name="effects">The sprite effects to apply to the render.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw at.</param>
    public static void DrawOutlined(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
    {

        Debug.Assert(spriteBatch is not null);
        Debug.Assert(region is not null);
        Debug.Assert(!region.IsDisposed, "Texture region was disposed prior to drawing");

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) { continue; }
                Vector2 offset = new Vector2(x, y);
                spriteBatch.Draw(region.Texture, position + offset, region.SourceRectangle, color, rotation, origin, scale, effects, layerDepth);
            }
        }

        spriteBatch.Draw(region.Texture, position, region.SourceRectangle, color, rotation, origin, scale, effects, layerDepth);
    }

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> centered with an outline effect at the specified position.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    public static void DrawOutlinedCentered(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position) =>
        spriteBatch.DrawOutlinedCentered(region, position, Color.White);

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> centered with an outline effect at the specified position with the specified color.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    /// <param name="color">The color tint to apply to the render and its outline.</param>>
    public static void DrawOutlinedCentered(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color) =>
        spriteBatch.DrawOutlinedCentered(region, position, color, 0.0f, Vector2.One, SpriteEffects.None, 0.0f);

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> centered with an outline effect at the specified position with the specified parameters.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the region.</param>
    /// <param name="color">The color tint to apply to the render and its outline.</param>
    /// <param name="rotation">The rotation angle, in radians, of the render.</param>
    /// <param name="scale">The uniform scale factor to apply to the render.</param>
    /// <param name="effects">The sprite effects to apply to the render.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw ate.</param>
    public static void DrawOutlinedCentered(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color, float rotation, float scale, SpriteEffects effects, float layerDepth) =>
        spriteBatch.DrawOutlinedCentered(region, position, color, rotation, new Vector2(scale), effects, layerDepth);

    /// <summary>
    /// Draws the <see cref="Texture2DRegion"/> centered with an outline effect at the specified position with the specified parameters.
    /// </summary>
    /// <param name="spriteBatch">The <see cref="SpriteBatch"/> to use for drawing.</param>
    /// <param name="region">The <see cref="Texture2DRegion"/> to draw.</param>
    /// <param name="position">The position at which to draw the render.</param>
    /// <param name="color">The color tint to apply to the render and its outline.</param>
    /// <param name="rotation">The rotation angle, in radians, of the render.</param>
    /// <param name="scale">The scale factors to apply to the render.</param>
    /// <param name="effects">The sprite effects to apply to the render.</param>
    /// <param name="layerDepth">The depth of the layer in which to draw at.</param>
    public static void DrawOutlinedCentered(this SpriteBatch spriteBatch, Texture2DRegion region, Vector2 position, Color color, float rotation, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        Debug.Assert(spriteBatch is not null);
        Debug.Assert(region is not null);
        Debug.Assert(!region.IsDisposed, "Texture region was disposed prior to drawing");

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) { continue; }
                Vector2 offset = new Vector2(x, y);
                spriteBatch.Draw(region.Texture, position + offset, region.SourceRectangle, color, rotation, region.Center, scale, effects, layerDepth);
            }
        }

        spriteBatch.Draw(region.Texture, position, region.SourceRectangle, color, rotation, region.Center, scale, effects, layerDepth);
    }

}
