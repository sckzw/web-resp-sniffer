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
        //public int index;
        //public bool isCached;
        //public bool isSaved;
        //public bool isClosed;

        public ResponseData( string id, string url, string filePath )
        {
            Id = id;
            Url = url;
            ContentType = "";
            Tag = "";
            TempFile = new FileStream( filePath, FileMode.Create, FileAccess.ReadWrite );
            SaveFilePath = "";
        }

        public string UpdateTag( Regex regex )
        {
            Match match = regex.Match( Url );

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

        public int UpdatePosition( Regex regex )
        {
            Match match = regex.Match( Url );

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

        public string GetPositionText()
        {
            if ( Position < 0 )
            {
                return "";
            }
            else if ( Position < 1024 * 10 )
            {
                return Position.ToString() + " B";
            }
            else if ( Position < 1024 * 1024 * 10 )
            {
                return ( Position / 1024 ).ToString() + " KB";
            }
            else
            {
                return ( Position / 1024 / 1024 ).ToString() + " MB";
            }
        }
    }
}
