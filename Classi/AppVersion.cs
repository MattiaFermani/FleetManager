using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace FleetManager // Cambialo col namespace dei tuoi futuri progetti
{
    public static class AppVersion
    {
        /// <summary>
        /// Restituisce la versione formattata a 4 cifre: Major.Minor.Patch.Revision
        /// </summary>
        public static Version Get()
        {
            string minVerString = Assembly.GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion ?? "1.0.0.0";

            // Rimuove eventuali metadati extra generati da GitHub Actions (es. +build123)
            minVerString = minVerString.Split('+')[0];

            // Regex intelligente: cattura i 3 numeri standard e l'eventuale 4° numero (i commit dal tag)
            var match = Regex.Match(minVerString, @"^(\d+)\.(\d+)\.(\d+)(?:-.*\.(\d+))?");

            if (match.Success)
            {
                int major = int.Parse(match.Groups[1].Value);
                int minor = int.Parse(match.Groups[2].Value);
                int patch = int.Parse(match.Groups[3].Value);
                
                // Se c'è un quarto numero (es. il ".48" di alpha.0.48), lo usa come Revision. Altrimenti 0.
                int revision = match.Groups[4].Success ? int.Parse(match.Groups[4].Value) : 0;

                return new Version(major, minor, patch, revision);
            }

            // Fallback ultra-sicuro in caso di errori imprevisti
            return new Version(1, 0, 0, 0); 
        }

        /// <summary>
        /// Restituisce la stringa già pronta per la UI (es. "1.0.7.0")
        /// </summary>
        public static string GetDisplayString()
        {
            return Get().ToString(); 
        }
    }
}