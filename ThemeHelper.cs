﻿using FreneticUtilities.FreneticExtensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DenizenMetaWebsite
{
    /// <summary>Helper class that handles theme processing.</summary>
    public class ThemeHelper
    {
        public static void HandleTheme(HttpRequest request, ViewDataDictionary viewData)
        {
            if (!request.Cookies.TryGetValue("cookie_theme", out string optTheme) || optTheme == null || !Themes.TryGetValue(optTheme.ToLowerFast(), out ThemeHelper theme))
            {
                theme = Dark;
            }
            viewData["Bootstrap_URL"] = theme.BootstrapURL;
            viewData["Bootstrap_Footer"] = theme.BootstrapFooterText;
            viewData["Theme_Colors"] = theme.ColorCSS;
            viewData["Theme_Footer"] = theme.Footer;
        }

        public static Dictionary<string, ThemeHelper> Themes = new();

        public static ThemeHelper Dark;

        static ThemeHelper()
        {
            Dark = new ThemeHelper()
            {
                BootstrapURL = "/css/bootstrap_dark.min.css",
                BootstrapFooterText = new HtmlString("<a href=\"https://bootswatch.com/darkly/\">Darkly Bootstrap Theme</a>"),
                ColorCSS = "/css/theme/colors_dark.css",
                Footer = "Theme: Standard Dark, created by Alex 'mcmonkey' Goodwin"
            };
            Themes.Add("dark", Dark);
            ThemeHelper lightRef = new()
            {
                BootstrapURL = "/css/bootstrap_light.min.css",
                BootstrapFooterText = new HtmlString("<a href=\"https://bootswatch.com/litera/\">Lightera Bootstrap Theme</a>"),
                ColorCSS = "/css/theme/colors_light.css",
                Footer = "Theme: Quite Light, created by Alex 'mcmonkey' Goodwin"
            };
            Themes.Add("light", lightRef);
            ThemeHelper Darkbehr = Dark.MemberwiseClone() as ThemeHelper;
            Darkbehr.ColorCSS = "/css/theme/colors_darkbehr.css";
            Darkbehr.Footer = "Theme: Behrry Dark, created by Behr AKA Hydra";
            Themes.Add("darkbehr", Darkbehr);
            ThemeHelper acidic = Dark.MemberwiseClone() as ThemeHelper;
            acidic.ColorCSS = "/css/theme/colors_acidic.css";
            acidic.Footer = "Theme: Acidic (Dark), created by acikek";
            Themes.Add("acidic", acidic);
            ThemeHelper chrispy = Dark.MemberwiseClone() as ThemeHelper;
            chrispy.ColorCSS = "/css/theme/colors_chrispy.css";
            chrispy.Footer = "Theme: Chrispy Dark, created by Chris|LordNoob";
            Themes.Add("chrispy", chrispy);
            ThemeHelper breadcrumb = Dark.MemberwiseClone() as ThemeHelper;
            breadcrumb.ColorCSS = "/css/theme/colors_breadcrumb.css";
            breadcrumb.Footer = "Theme: Breadcrumb Dark, created by Breadcrumb";
            Themes.Add("breadcrumb", breadcrumb);
            ThemeHelper baguette = lightRef.MemberwiseClone() as ThemeHelper;
            baguette.ColorCSS = "/css/theme/colors_baguette.css";
            baguette.Footer = "Theme: Baguette, created by Apademide";
            Themes.Add("baguette", baguette);
            ThemeHelper analogous_orange = Dark.MemberwiseClone() as ThemeHelper;
            analogous_orange.ColorCSS = "/css/theme/colors_analogousorange.css";
            analogous_orange.Footer = "Theme: Analogous Orange, created by drjoenh";
            Themes.Add("analogous_orange", analogous_orange);
        }

        public string BootstrapURL;

        public HtmlString BootstrapFooterText;

        public string ColorCSS;

        public string Footer;
    }
}
