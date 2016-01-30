using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;

namespace Sitecore.Foundation.Microsites
{
    public class Templates
    {
        public struct MicrositeRoot
        {
            public static ID ID = new ID("{5432A264-88F9-41F2-92FB-3A0C8327F8C4}");

            public struct Fields
            {
                public static readonly ID SiteParameters = new ID("{BC758BC7-CD11-460C-BE27-8C6A7C83A2B2}");
                public static readonly ID SiteHome = new ID("{4A8822CC-B418-4452-AB0F-8BB6DF2F2114}");
                public static readonly ID SiteLanguage = new ID("{F75DB2B4-910F-4343-8453-00ED982F6FB3}");
                public static readonly ID SiteDatabase = new ID("{0EEEA8A3-CDA3-4F2F-A0EB-79A84055066A}");
                public static readonly ID SiteHostName = new ID("{B8027200-AAB0-4876-B454-DBB85ADD9E3C}");
                public static readonly ID SiteDomain = new ID("{C08D7A31-15E0-4145-B66D-38AB3CB19A0B}");
                public static readonly ID SiteBackgroundColour = new ID("{3467F8A6-CC41-4AF4-8878-9A8922FF3995}");
                public static readonly ID SiteTextColour = new ID("{CD4E4AA4-DC24-41D4-9338-1955200347EA}");
            }
        }

        public struct MicrositeRootBranch
        {
            public static ID ID = new ID("{6208EF71-0793-49FD-AD51-BBFDA80FD814}");
        }
    }
}
