using System;
using System.Collections.Generic;
using System.Text;

namespace LetMeKnow.Services
{
    public static class DomainToUniNameConverter {
        // For large scale, this should be parsed from somewhere else...
        // For example, here: https://foiwiki.com/foiwiki/index.php/List_of_.ac.uk_domain_names
        private static readonly IDictionary<string, string> uniDomainToName = new Dictionary<string, string>() {
            { "leeds", "University of Leeds" },
            { "unit.ox", "University of Oxford"},
            { "imperial", "Imperial College London" },
            { "student.manchester", "University of Manchester" },
            { "ncl", "Newcastle University" } // ...
        };

        public static string GetUniversity(string email) {
            string domainCut = email.Split('@')[1].Split('.')[0];
            // Loop through a domain list of universities. For now it will only be @leeds.ac.uk
            return uniDomainToName.ContainsKey(domainCut) ? uniDomainToName[domainCut] : domainCut;
        }
    }
}
