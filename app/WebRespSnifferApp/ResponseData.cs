using System.Text.RegularExpressions;

namespace WebRespSnifferApp
{
    internal class ResponseData
    {
        public string Id;
        public string Url;
        public string Type;
        public string ContentType;
        public int ContentLength;
        public int Size;
        public string Tag;
        public int Position;
        public FileStream TempFile;
        public string SaveFilePath;
        public int Index;
        //public bool isCached;
        //public bool isSaved;
        //public bool isClosed;
        public static string FileNameFormat = "{FileName}_{Tag}_{Index}_{Position}{FileExtension}";
        public static Regex TagRegex = new( @"^$", RegexOptions.Compiled );
        public static Regex IndexRegex = new( @"^$", RegexOptions.Compiled );
        public static Regex PositionRegex = new( @"^$", RegexOptions.Compiled );

        public ResponseData( string id, string url, string filePath )
        {
            Id = id;
            Url = url;
            ContentType = "";
            Tag = "";
            TempFile = new FileStream( filePath, FileMode.Create, FileAccess.ReadWrite );
            SaveFilePath = "";
            Position = -1;
            Index = -1;
        }

        public string GetFileName()
        {
            string fileName = FileNameFormat;
            string filePath = new Uri( Url ).LocalPath;

            var args = new Dictionary<string, string>
            {
                { "{FileName}", Path.GetFileNameWithoutExtension( filePath ) },
                { "{FileExtension}", Path.GetExtension( filePath ) },
                { "{Tag}", Tag },
                { "{Index}", GetIndexText() },
                { "{Position}", GetPositionText() }
            };

            foreach ( var arg in args )
            {
                fileName = fileName.Replace( arg.Key, arg.Value );
            }

            return fileName;
        }

        public string UpdateTag()
        {
            Match match = TagRegex.Match( Url );

            if ( match.Success )
            {
                if ( match.Groups.Count > 1 && match.Groups[1].Success )
                {
                    Tag = match.Groups[1].Value;
                }
                else
                {
                    Tag = match.Value;
                }
            }
            else
            {
                Tag = "";
            }

            return Tag;
        }

        public int UpdateIndex()
        {
            Match match = IndexRegex.Match( Url );

            if ( match.Success )
            {
                if ( match.Groups.Count > 1 && match.Groups[1].Success )
                {
                    _ = int.TryParse( match.Groups[1].Value, out Index );
                }
                else
                {
                    _ = int.TryParse( match.Value, out Index );
                }
            }
            else
            {
                Index = -1;
            }

            return Index;
        }

        public int UpdatePosition()
        {
            Match match = PositionRegex.Match( Url );

            if ( match.Success )
            {
                if ( match.Groups.Count > 1 && match.Groups[1].Success )
                {
                    _ = int.TryParse( match.Groups[1].Value, out Position );
                }
                else
                {
                    _ = int.TryParse( match.Value, out Position );
                }
            }
            else
            {
                Position = -1;
            }

            return Position;
        }

        public string GetSizeText()
        {
            if ( Size < 1024 * 10 )
            {
                return Size.ToString() + " B";
            }
            else if ( Size < 1024 * 1024 * 10 )
            {
                return ( Size / 1024 ).ToString() + " KB";
            }
            else
            {
                return ( Size / 1024 / 1024 ).ToString() + " MB";
            }
        }

        public string GetIndexText()
        {
            if ( Index < 0 )
            {
                return "";
            }
            else
            {
                return Index.ToString();
            }
        }

        public string GetPositionText()
        {
            if ( Position < 0 )
            {
                return "";
            }
            {
                return Position.ToString();
            }
        }
    }
}
