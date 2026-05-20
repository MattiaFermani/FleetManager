using System;
using System.Reflection;
using System.Text.RegularExpressions;

using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace FleetManager
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
        /// Restituisce la stringa ottimizzata nascondendo gli zeri non significativi alla fine.
        /// </summary>
        public static string GetDisplayString()
        {
            Version v = Get();

            // Caso 1: C'è un numero di Revision (es. 1.1.0.5 -> mostra tutto)
            if (v.Revision > 0)
            {
                return v.ToString(4); // Ritorna "Major.Minor.Build.Revision"
            }

            // Caso 2: Revision è 0, ma Patch (Build) è maggiore di 0 (es. 1.0.1.0 -> mostra 1.0.1)
            if (v.Build > 0)
            {
                return v.ToString(3); // Ritorna "Major.Minor.Build"
            }

            // Caso 3: Sia Revision che Patch sono 0 (es. 1.1.0.0 -> mostra 1.1)
            return v.ToString(2); // Ritorna "Major.Minor"
        }
    }
}