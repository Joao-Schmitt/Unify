using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unify.UI.Controls.Classes
{
    public static class RecursosSvg
    {
        public static string Lupa => @"
        <svg viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'>
            <path fill='#4A4A4A' d='M15.5 14h-.79l-.28-.27A6.471 6.471 0 0016 9.5 
                6.5 6.5 0 109.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 
                19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 
                11.99 14 9.5 14z'/>
        </svg>";

        public static string Calendario => @"
        <svg viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'>
          <path fill='#4A4A4A' d='M19 4h-1V2h-2v2H8V2H6v2H5c-1.11 0-1.99.9-1.99 2L3 
             20a2 2 0 002 2h14c1.1 0 2-.9 2-2V6c0-1.1-.9-2-2-2zm0 
             16H5V9h14v11z'/>
        </svg>";

        public static string Limpar => @"
        <svg viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'>
          <path fill='#4A4A4A' d='M19 6.41L17.59 5 12 10.59 6.41 5 5 
             6.41 10.59 12 5 17.59 6.41 19 12 13.41 17.59 19 19 
             17.59 13.41 12z'/>
        </svg>";

        public static string Pesquisa => @"
        <svg viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'>
          <path fill='#4A4A4A' d='M9 2a7 7 0 015.29 11.71l4 4-1.42 
             1.42-4-4A7 7 0 119 2m0 2a5 5 0 100 10A5 5 0 009 4z'/>
        </svg>";

        public static string Editar => @"
        <svg viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'>
          <path fill='#4A4A4A' d='M3 17.25V21h3.75L17.81 9.94l-3.75-3.75L3 
             17.25zM20.71 7.04a1.003 1.003 0 000-1.41l-2.34-2.34a1.003 1.003 
             0 00-1.41 0l-1.83 1.83 3.75 3.75 1.83-1.83z'/>
        </svg>";

        public static string Duplicar => @"
        <svg viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'>
          <path fill='#4A4A4A' d='M16 1H4c-1.1 0-2 .9-2 2v14h2V3h12V1zm3 
             4H8c-1.1 0-2 .9-2 2v14c0 1.1.9 2 2 2h11c1.1 0 2-.9 
             2-2V7c0-1.1-.9-2-2-2zm0 16H8V7h11v14z'/>
        </svg>";

        public static string Excluir => @"
        <svg viewBox='0 0 24 24' xmlns='http://www.w3.org/2000/svg'>
          <path fill='#4A4A4A' d='M6 19c0 1.1.9 2 2 2h8c1.1 0 2-.9 
             2-2V7H6v12zM19 4h-3.5l-1-1h-5l-1 1H5v2h14V4z'/>
        </svg>";


        public static Bitmap SvgToBitmap(SvgDocument svg, int width, int height)
        {
            if (svg == null)
                return new Bitmap(width, height);

            svg.Width = width;
            svg.Height = height;

            var bmp = new Bitmap(width, height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                svg.Draw(g);
            }

            return bmp;
        }

    }
}
