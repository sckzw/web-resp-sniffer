using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace WebRespSnifferApp
{
    public partial class MainForm: Form
    {
        private readonly List<ResponseData> responseDataList = [];
        private readonly Dictionary<string, ResponseData> responseDataIds = [];

        public class ExtMessage
        {
            [JsonPropertyName( "command" )]
            public string Command
            {
                get; set;
            }
            [JsonPropertyName( "id" )]
            public string Id
            {
                get; set;
            }
            [JsonPropertyName( "url" )]
            public string Url
            {
                get; set;
            }
            [JsonPropertyName( "type" )]
            public string Type
            {
                get; set;
            }
            [JsonPropertyName( "content_type" )]
            public string ContentType
            {
                get; set;
            }
            [JsonPropertyName( "content_length" )]
            public int ContentLength
            {
                get; set;
            }
            [JsonPropertyName( "data" )]
            public string Data
            {
                get; set;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            ResponseDataListView_Initialize();

            TextBoxFileNameFormat.Text = ResponseData.FileNameFormat;

            this.Load += ( s, e ) => Task.Run( () => InputExtMessage() );
        }

        private void ResponseDataListView_Initialize()
        {
            var property = typeof( Control ).GetProperty( "DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance );
            property?.SetValue( ResponseDataListView, true, null );

            this.ResponseDataListView.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler( ResponseDataListView_RetrieveVirtualItem );
        }

        private void ResponseDataListView_RetrieveVirtualItem( object? sender, RetrieveVirtualItemEventArgs e )
        {
            var responseData = responseDataList[e.ItemIndex];
            responseData.UpdateTag();
            responseData.UpdateIndex();
            responseData.UpdatePosition();

            var item = new ListViewItem( responseData.Url );
            item.SubItems.Add( responseData.ContentType );
            item.SubItems.Add( responseData.ContentLength.ToString() );
            item.SubItems.Add( responseData.GetSizeText() );
            item.SubItems.Add( responseData.Tag );
            item.SubItems.Add( Path.GetRelativePath( Directory.GetCurrentDirectory(), responseData.TempFile.Name ) );
            item.SubItems.Add( responseData.GetPositionText() );
            item.SubItems.Add( responseData.SaveFilePath );
            item.SubItems.Add( responseData.Type );
            item.SubItems.Add( responseData.GetIndexText() );

            e.Item = item;
        }

        private void InputExtMessage()
        {
            using Stream stdin = Console.OpenStandardInput();
            using BinaryReader stdinReader = new( stdin, Encoding.UTF8 );
            byte[] messageLengthBytes = new byte[4];
            int messageLength;

            try
            {
                while ( true )
                {
                    stdin.ReadExactly( messageLengthBytes, 0, 4 );
                    messageLength = BitConverter.ToInt32( messageLengthBytes, 0 );

                    if ( messageLength == 0 )
                    {
                        continue;
                    }

                    byte[] messageBytes = new byte[messageLength];
                    stdinReader.Read( messageBytes, 0, messageLength );

                    string messageString = Encoding.UTF8.GetString( messageBytes );
                    ExtMessage? extMessage = JsonSerializer.Deserialize<ExtMessage>( messageString );

                    if ( extMessage != null )
                    {
                        HandleExtMessage( extMessage );
                    }
                }
            }
            catch ( EndOfStreamException )
            {
            }
        }

        private void HandleExtMessage( ExtMessage extMessage )
        {
            ResponseData responseData;

            switch ( extMessage.Command )
            {
                case "onBeforeRequest":
                    if ( responseDataIds.ContainsKey( extMessage.Id ) )
                    {
                        break;
                    }

                    responseData = new ResponseData( extMessage.Id, extMessage.Url, Path.GetRandomFileName() );
                    responseData.Type = extMessage.Type;
                    responseDataIds.Add( responseData.Id, responseData );
                    responseDataList.Add( responseData );

                    BeginInvoke( new Action( () =>
                    {
                        ResponseDataListView.BeginUpdate();

                        if ( ResponseDataListView.TopItem != null )
                        {
                            ResponseDataListView.TopItem.Focused = true;
                        }

                        ResponseDataListView.VirtualListSize = responseDataList.Count;

                        ResponseDataListView.EndUpdate();
                    } ) );

                    break;
                case "onResponseStarted":
                    responseData = responseDataIds[extMessage.Id];
                    responseData.ContentType = extMessage.ContentType;
                    responseData.ContentLength = extMessage.ContentLength;

                    BeginInvoke( new Action( () =>
                    {
                        ResponseDataListView.Invalidate();
                    } ) );

                    break;
                case "onData":
                    byte[] data = Convert.FromBase64String( extMessage.Data );

                    responseData = responseDataIds[extMessage.Id];
                    responseData.Size += data.Length;
                    responseData.TempFile.Write( data, 0, data.Length );

                    BeginInvoke( new Action( () =>
                    {
                        ResponseDataListView.Invalidate();
                    } ) );

                    break;
                case "onCompleted":
                    // responseDataIds.Remove( nativeMsg.Id );
                    break;
                case "onDisconnect":
                    var message = new
                    {
                        command = "disconnect"
                    };
                    string messageJson = JsonSerializer.Serialize( message );
                    byte[] messageBytes = Encoding.UTF8.GetBytes( messageJson );
                    byte[] messageLength = BitConverter.GetBytes( messageBytes.Length );

                    using ( Stream stdout = Console.OpenStandardOutput() )
                    {
                        stdout.Write( messageLength, 0, 4 );
                        stdout.Write( messageBytes, 0, messageBytes.Length );
                        stdout.Flush();
                    }

                    Close();

                    break;
            }
        }

        private void TextBoxTagRegex_TextChanged( object sender, EventArgs e )
        {
            try
            {
                ResponseData.TagRegex = new( TextBoxTagRegex.Text, RegexOptions.Compiled );
                ResponseDataListView.Invalidate();
            }
            catch ( ArgumentException )
            {
            }
        }

        private void TextBoxIndexRegex_TextChanged( object sender, EventArgs e )
        {
            try
            {
                ResponseData.IndexRegex = new( TextBoxIndexRegex.Text, RegexOptions.Compiled );
                ResponseDataListView.Invalidate();
            }
            catch ( ArgumentException )
            {
            }
        }

        private void TextBoxPositionRegex_TextChanged( object sender, EventArgs e )
        {
            try
            {
                ResponseData.PositionRegex = new( TextBoxPositionRegex.Text, RegexOptions.Compiled );
                ResponseDataListView.Invalidate();
            }
            catch ( ArgumentException )
            {
            }
        }

        private void TextBoxFileNameFormat_TextChanged( object sender, EventArgs e )
        {
            ResponseData.FileNameFormat = TextBoxFileNameFormat.Text;
        }

        private void ToolStripMenuItemSelectAll_Click( object sender, EventArgs e )
        {
            ResponseDataListView.BeginUpdate();
            ResponseDataListView.SelectedIndices.Clear();
            for ( int i = 0; i < responseDataList.Count; i++ )
            {
                ResponseDataListView.SelectedIndices.Add( i );
            }
            ResponseDataListView.EndUpdate();
        }

        private void ToolStripMenuItemSelectTag_Click( object sender, EventArgs e )
        {
            if ( ResponseDataListView.SelectedIndices.Count == 0 )
            {
                return;
            }

            var responseData = responseDataList[ResponseDataListView.SelectedIndices[0]];
            var tag = responseData.UpdateTag();
            if ( tag == "" )
            {
                return;
            }

            ResponseDataListView.BeginUpdate();
            ResponseDataListView.SelectedIndices.Clear();
            for ( int i = 0; i < responseDataList.Count; i++ )
            {
                if ( responseDataList[i].UpdateTag() == tag )
                {
                    ResponseDataListView.SelectedIndices.Add( i );
                }
            }
            ResponseDataListView.EndUpdate();
        }

        private void ToolStripMenuItemDelete_Click( object sender, EventArgs e )
        {
            if ( ResponseDataListView.SelectedIndices.Count == 0 )
            {
                return;
            }

            int[] indices = new int[ResponseDataListView.SelectedIndices.Count];

            ResponseDataListView.SelectedIndices.CopyTo( indices, 0 );
            Array.Sort( indices );
            Array.Reverse( indices );

            for ( int i = 0; i < indices.Length; i++ )
            {
                ResponseData responseData = responseDataList[indices[i]];
                responseDataList.RemoveAt( indices[i] );
                responseDataIds.Remove( responseData.Id );
                responseData.TempFile.Close();
                File.Delete( responseData.TempFile.Name );
            }

            ResponseDataListView.VirtualListSize = responseDataList.Count;
            ResponseDataListView.SelectedIndices.Clear();
            ResponseDataListView.Invalidate();
        }

        private void ToolStripMenuItemCopy_Click( object sender, EventArgs e )
        {
            if ( ResponseDataListView.SelectedIndices.Count == 0 )
            {
                return;
            }

            string text = "";

            for ( int i = 0; i < ResponseDataListView.SelectedIndices.Count; i++ )
            {
                int index = ResponseDataListView.SelectedIndices[i];
                text += string.Join( "\t", ResponseDataListView.Items[index].SubItems.Cast<ListViewItem.ListViewSubItem>().Select( s => s.Text ) ) + "\n";
            }

            try
            {
                Clipboard.SetText( text );
            }
            catch ( ExternalException )
            {
                MessageBox.Show( "Failed to copy." );
            }
        }

        private void ToolStripMenuItemCopyUrl_Click( object sender, EventArgs e )
        {
            if ( ResponseDataListView.SelectedIndices.Count == 0 )
            {
                return;
            }

            string text = "";

            for ( int i = 0; i < ResponseDataListView.SelectedIndices.Count; i++ )
            {
                int index = ResponseDataListView.SelectedIndices[i];
                text += responseDataList[index].Url + "\n";
            }

            try
            {
                Clipboard.SetText( text );
            }
            catch ( ExternalException )
            {
                MessageBox.Show( "Failed to copy." );
            }
        }

        private void ToolStripMenuItemSave_Click( object sender, EventArgs e )
        {
            if ( ResponseDataListView.SelectedIndices.Count == 0 )
            {
                return;
            }
            else if ( ResponseDataListView.SelectedIndices.Count == 1 )
            {
                var responseData = responseDataList[ResponseDataListView.SelectedIndices[0]];

                using SaveFileDialog dialog = new();

                dialog.FileName = responseData.GetFileName();
                dialog.Filter = "すべてのファイル(*.*)|*.*";
                dialog.InitialDirectory = Directory.GetCurrentDirectory();

                if ( dialog.ShowDialog() == DialogResult.OK )
                {
                    responseData.SaveFilePath = dialog.FileName;
                    File.Copy( responseData.TempFile.Name, responseData.SaveFilePath, true );
                }
            }
            else
            {
                using FolderBrowserDialog dialog = new();

                dialog.InitialDirectory = Directory.GetCurrentDirectory();
                dialog.ShowNewFolderButton = true;

                if ( dialog.ShowDialog() == DialogResult.OK )
                {
                    var selectedPath = dialog.SelectedPath;

                    for ( int i = 0; i < ResponseDataListView.SelectedIndices.Count; i++ )
                    {
                        var responseData = responseDataList[ResponseDataListView.SelectedIndices[i]];
                        responseData.SaveFilePath = selectedPath + Path.DirectorySeparatorChar + responseData.GetFileName();
                        File.Copy( responseData.TempFile.Name, responseData.SaveFilePath, true );
                    }
                }
            }
        }

        private void ToolStripMenuItemConcat_Click( object sender, EventArgs e )
        {
            if ( ResponseDataListView.SelectedIndices.Count == 0 )
            {
                return;
            }

            var responseData = responseDataList[ResponseDataListView.SelectedIndices[0]];

            string saveFilePath;
            using ( SaveFileDialog dialog = new() )
            {
                dialog.FileName = Path.GetFileName( new Uri( responseData.Url ).LocalPath );
                dialog.Filter = "すべてのファイル(*.*)|*.*";
                dialog.InitialDirectory = Directory.GetCurrentDirectory();
                dialog.RestoreDirectory = true;

                if ( dialog.ShowDialog() != DialogResult.OK )
                {
                    return;
                }

                saveFilePath = dialog.FileName;
            }

            List<ResponseData> selectedResponseDataList = [];

            for ( int i = 0; i < ResponseDataListView.SelectedIndices.Count; i++ )
            {
                ResponseData selectedResponseData = responseDataList[ResponseDataListView.SelectedIndices[i]];
                selectedResponseDataList.Add( selectedResponseData );
            }

            // TODO: selectedResponseDataListをソート

            using ( FileStream saveFileStream = new( saveFilePath, FileMode.Create, FileAccess.Write ) )
            {
                for ( int i = 0; i < selectedResponseDataList.Count; i++ )
                {
                    ResponseData selectedResponseData = selectedResponseDataList[i];
                    selectedResponseData.SaveFilePath = saveFilePath;

                    selectedResponseData.UpdatePosition();
                    if ( selectedResponseData.Position >= 0 )
                    {
                        saveFileStream.Position = selectedResponseData.Position;
                    }

                    selectedResponseData.TempFile.Seek( 0, SeekOrigin.Begin );
                    selectedResponseData.TempFile.CopyTo( saveFileStream );
                    selectedResponseData.TempFile.Seek( 0, SeekOrigin.End );
                }
            }
        }

        private void ToolStripMenuItemExit_Click( object sender, EventArgs e )
        {
            Close();
        }

        private void MainForm_FormClosed( object sender, FormClosedEventArgs e )
        {
            for ( int i = 0; i < responseDataList.Count; i++ )
            {
                ResponseData responseData = responseDataList[i];
                responseData.TempFile.Close();
                File.Delete( responseData.TempFile.Name );
            }
        }

        private void ToolStripMenuItemOpenFolder_Click( object sender, EventArgs e )
        {
            if ( ResponseDataListView.SelectedIndices.Count == 0 )
            {
                return;
            }

            var responseData = responseDataList[ResponseDataListView.SelectedIndices[0]];
            string filePath = "";

            if ( File.Exists( responseData.SaveFilePath ) )
            {
                filePath = responseData.SaveFilePath;
            }
            else if ( File.Exists( responseData.TempFile.Name ) )
            {
                filePath = responseData.TempFile.Name;
            }

            if ( filePath == "" )
            {
                return;
            }

            ProcessStartInfo processStartInfo = new()
            {
                FileName = "explorer.exe",
                Arguments = $"/select,\"{filePath}\"",
                UseShellExecute = true
            };

            Process.Start( processStartInfo );
        }
    }
}
